CREATE PROCEDURE [dbo].[ZAutModificaPercAiutoUpdate]
(
	@IdAutorizzazione INT, 
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
	SET @DataModifica=getdate()
	UPDATE AUT_MODIFICA_PERC_AIUTO
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		ID_INVESTIMENTO = @IdInvestimento, 
		COSTO_INVESTIMENTO_PRECEDENTE = @CostoInvestimentoPrecedente, 
		COSTO_INVESTIMENTO_AUTORIZZATO = @CostoInvestimentoAutorizzato, 
		QUANTITA_PRECEDENTE = @QuantitaPrecedente, 
		QUANTITA_AUTORIZZATA = @QuantitaAutorizzata, 
		PERC_PRECEDENTE = @PercPrecedente, 
		PERC_AUTORIZZATA = @PercAutorizzata
	WHERE 
		(ID_AUTORIZZAZIONE = @IdAutorizzazione)
	SELECT @DataModifica;

GO