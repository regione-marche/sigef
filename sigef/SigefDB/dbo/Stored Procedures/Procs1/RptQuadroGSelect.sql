-- =============================================
-- Author:		Sardini Claudio
-- Create date: 20/03/2008
-- Description:	Report del quadro G
-- =============================================
CREATE PROCEDURE [dbo].[RptQuadroGSelect] 
	-- Add the parameters for the stored procedure here
	@ID_Domanda int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IDFascicolo int
	SET @IDFascicolo = (select isNull (ID_FASCICOLO,( SELECT    MAX(F.ID_FASCICOLO) AS Expr1  
								FROM  IMPRESA INNER JOIN PROGETTO ON IMPRESA.ID_IMPRESA = PROGETTO.ID_IMPRESA 
								INNER JOIN FASCICOLO_AZIENDALE AS F ON IMPRESA.ID_IMPRESA = F.ID_IMPRESA
								WHERE     (PROGETTO.ID_PROGETTO = @ID_Domanda) ) ) 
								FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda )

	DECLARE @Count int
	SET @Count = (SELECT COUNT(ID_FASCICOLO) FROM vMANODOPERA WHERE ID_FASCICOLO = @IDFascicolo)

	IF (@Count > 0)
		SELECT TIPO_LAVORO_PREVALENTE,
				TIPO_LAVORATORE,
				TIPO_COLLABORAZIONE,
				UNITA_MISURA,
				QUANTITA
		FROM	vMANODOPERA
		WHERE ID_FASCICOLO = @IDFascicolo
	ELSE SELECT NULL AS TIPO_LAVORO_PREVALENTE,
				NULL AS TIPO_LAVORATORE,
				NULL AS TIPO_COLLABORAZIONE,
				NULL AS UNITA_MISURA,
				NULL AS QUANTITA
END
