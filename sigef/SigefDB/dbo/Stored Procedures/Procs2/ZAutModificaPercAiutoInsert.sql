CREATE PROCEDURE [dbo].[ZAutModificaPercAiutoInsert]
(
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@IdInvestimento INT, 
	@CostoInvestimentoPrecedente DECIMAL(18,2), 
	@CostoInvestimentoAutorizzato DECIMAL(18,2), 
	@QuantitaPrecedente DECIMAL(10,2), 
	@QuantitaAutorizzata DECIMAL(10,2), 
	@PercPrecedente DECIMAL(15,12), 
	@PercAutorizzata DECIMAL(15,12)
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO AUT_MODIFICA_PERC_AIUTO
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		ID_INVESTIMENTO, 
		COSTO_INVESTIMENTO_PRECEDENTE, 
		COSTO_INVESTIMENTO_AUTORIZZATO, 
		QUANTITA_PRECEDENTE, 
		QUANTITA_AUTORIZZATA, 
		PERC_PRECEDENTE, 
		PERC_AUTORIZZATA
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@IdInvestimento, 
		@CostoInvestimentoPrecedente, 
		@CostoInvestimentoAutorizzato, 
		@QuantitaPrecedente, 
		@QuantitaAutorizzata, 
		@PercPrecedente, 
		@PercAutorizzata
	)
	SELECT SCOPE_IDENTITY() AS ID_AUTORIZZAZIONE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA

GO