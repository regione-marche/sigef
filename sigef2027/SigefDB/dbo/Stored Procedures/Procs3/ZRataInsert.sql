CREATE PROCEDURE [dbo].[ZRataInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @Pagata = ISNULL(@Pagata,((0)))
	INSERT INTO RATA
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		DATA_RATA, 
		DATA_SCADENZA, 
		DATA_PAGAMENTO, 
		IMPORTO_RATA, 
		PAGATA, 
		ID_REGISTRO_RECUPERO, 
		ID_TIPO_RATA
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@DataRata, 
		@DataScadenza, 
		@DataPagamento, 
		@ImportoRata, 
		@Pagata, 
		@IdRegistroRecupero, 
		@IdTipoRata
	)
	SELECT SCOPE_IDENTITY() AS ID_RATA, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @Pagata AS PAGATA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRataInsert';

