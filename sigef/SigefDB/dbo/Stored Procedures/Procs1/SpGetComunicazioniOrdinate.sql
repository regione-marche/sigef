-- =============================================
-- Author:		<>
-- Create date: <11/05/>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SpGetComunicazioniOrdinate]
(
	@ID_PROGETTO INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH ComunicazioniFiglio(ID_COMUNICAZIONE, ID_PROGETTO, ID_COMUNICAZIONE_REF, OGGETTO, TESTO, COD_TIPO, DATA_INSERIMENTO, DATA_MODIFICA, OPERATORE, 
	SEGNATURA, SEGNATURA_ESTERNA, IN_ENTRATA, ID_NOTE, [Level], orderField) 
	AS 
	(
		(
			-- Start CTE off by selecting the home location of the user
			SELECT p1.ID_COMUNICAZIONE, p1.ID_PROGETTO, p1.ID_COMUNICAZIONE_REF, p1.OGGETTO, p1.TESTO, p1.COD_TIPO, p1.DATA_INSERIMENTO, p1.DATA_MODIFICA, p1.OPERATORE
			, p1.SEGNATURA, p1.SEGNATURA_ESTERNA, p1.IN_ENTRATA, p1.ID_NOTE, 0 as [Level],
					cast( str( p1.ID_COMUNICAZIONE ) as varchar(max) ) as orderField
			FROM   PROGETTO_COMUNICAZIONE p1
			WHERE  p1.ID_COMUNICAZIONE_REF is null
		)
		UNION ALL 
		-- Recursively add locations that are children ...
		SELECT p2.ID_COMUNICAZIONE, p2.ID_PROGETTO, p2.ID_COMUNICAZIONE_REF, p2.OGGETTO, p2.TESTO, p2.COD_TIPO, p2.DATA_INSERIMENTO, p2.DATA_MODIFICA, p2.OPERATORE, 
				p2.SEGNATURA, p2.SEGNATURA_ESTERNA, p2.IN_ENTRATA, p2.ID_NOTE, [Level] + 1, tmp.orderField + '-' + str(tmp.ID_COMUNICAZIONE) as orderField
		FROM   ComunicazioniFiglio tmp
				INNER JOIN PROGETTO_COMUNICAZIONE p2
					ON  p2.ID_COMUNICAZIONE_REF = tmp.ID_COMUNICAZIONE
	)
	SELECT f.ID_COMUNICAZIONE, f.ID_PROGETTO, f.ID_COMUNICAZIONE_REF, f.OGGETTO, f.TESTO, f.COD_TIPO, t.DESCRIZIONE, f.DATA_INSERIMENTO, f.DATA_MODIFICA, f.OPERATORE, 
	f.SEGNATURA, f.SEGNATURA_ESTERNA, f.IN_ENTRATA, f.ID_NOTE, n.TESTO AS TESTO_NOTE
	from ComunicazioniFiglio f
	INNER JOIN dbo.TIPO_COMUNICAZIONE t ON f.COD_TIPO = t.COD_TIPO 
	LEFT OUTER JOIN	dbo.NOTE n ON f.ID_NOTE = n.ID
	where f.ID_PROGETTO = @ID_PROGETTO
	order by orderField, f.DATA_MODIFICA
END
