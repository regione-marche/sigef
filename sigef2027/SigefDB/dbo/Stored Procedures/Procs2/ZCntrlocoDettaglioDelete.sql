CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioDelete]
(
	@IdlocoDettaglio INT
)
AS
	DELETE CntrLoco_Dettaglio
	WHERE 
		(IdLoco_Dettaglio = @IdlocoDettaglio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCntrlocoDettaglioDelete]
(
	@IdlocoDettaglio INT
)
AS
	DELETE CntrLoco_Dettaglio
	WHERE 
		(IdLoco_Dettaglio = @IdlocoDettaglio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCntrlocoDettaglioDelete';

