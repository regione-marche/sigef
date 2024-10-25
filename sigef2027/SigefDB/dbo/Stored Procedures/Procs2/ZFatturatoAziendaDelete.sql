CREATE PROCEDURE [dbo].[ZFatturatoAziendaDelete]
(
	@IdFatturato INT
)
AS
	DELETE FATTURATO_AZIENDA
	WHERE 
		(ID_FATTURATO = @IdFatturato)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFatturatoAziendaDelete]
(
	@IdFatturato INT
)
AS
	DELETE FATTURATO_AZIENDA
	WHERE 
		(ID_FATTURATO = @IdFatturato)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFatturatoAziendaDelete';

