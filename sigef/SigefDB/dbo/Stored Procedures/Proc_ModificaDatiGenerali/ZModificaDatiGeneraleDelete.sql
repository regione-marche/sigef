CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleDelete]
(
	@IdModifica INT
)
AS
	DELETE MODIFICA_DATI_GENERALE
	WHERE 
		(ID_MODIFICA = @IdModifica)

GO