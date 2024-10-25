CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleGetById]
(
	@IdModifica INT
)
AS
	SELECT *
	FROM VMODIFICA_DATI_GENERALE
	WHERE 
		(ID_MODIFICA = @IdModifica)

GO