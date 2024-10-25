CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiUpdate]
(
	@IdDettaglioInvestimento INT, 
	@IdCodificaInvestimento INT, 
	@CodDettaglio VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Mobile BIT, 
	@QuotaSpeseGenerali DECIMAL(10,2), 
	@RichiediParticella BIT, 
	@IdUdm INT
)
AS
	UPDATE DETTAGLIO_INVESTIMENTI
	SET
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		COD_DETTAGLIO = @CodDettaglio, 
		DESCRIZIONE = @Descrizione, 
		MOBILE = @Mobile, 
		QUOTA_SPESE_GENERALI = @QuotaSpeseGenerali, 
		RICHIEDI_PARTICELLA = @RichiediParticella, 
		ID_UDM = @IdUdm
	WHERE 
		(ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiUpdate]
(
	@IdDettaglioInvestimento INT, 
	@IdCodificaInvestimento INT, 
	@CodDettaglio CHAR(2), 
	@Descrizione VARCHAR(255), 
	@Mobile BIT, 
	@QuotaSpeseGenerali DECIMAL(10,2), 
	@RichiediParticella BIT
)
AS
	UPDATE DETTAGLIO_INVESTIMENTI
	SET
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		COD_DETTAGLIO = @CodDettaglio, 
		DESCRIZIONE = @Descrizione, 
		MOBILE = @Mobile, 
		QUOTA_SPESE_GENERALI = @QuotaSpeseGenerali, 
		RICHIEDI_PARTICELLA = @RichiediParticella
	WHERE 
		(ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimento)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDettaglioInvestimentiUpdate';

