CREATE PROCEDURE [dbo].[ZRataUpdate]
(
	@IdRata INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataRata DATETIME, 
	@DataScadenza DATETIME, 
	@DataPagamento DATETIME, 
	@ImportoRata DECIMAL(15,2), 
	@Pagata BIT, 
	@IdRegistroRecupero INT, 
	@IdTipoRata INT
)
AS
	SET @DataModifica=getdate()
	UPDATE RATA
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		DATA_RATA = @DataRata, 
		DATA_SCADENZA = @DataScadenza, 
		DATA_PAGAMENTO = @DataPagamento, 
		IMPORTO_RATA = @ImportoRata, 
		PAGATA = @Pagata, 
		ID_REGISTRO_RECUPERO = @IdRegistroRecupero, 
		ID_TIPO_RATA = @IdTipoRata
	WHERE 
		(ID_RATA = @IdRata)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRataUpdate';

