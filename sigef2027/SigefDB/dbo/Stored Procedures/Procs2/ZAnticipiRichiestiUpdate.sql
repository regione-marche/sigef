CREATE PROCEDURE [dbo].[ZAnticipiRichiestiUpdate]
(
	@IdAnticipo INT, 
	@IdDomandaPagamento INT, 
	@IdBando INT, 
	@DataRichiesta DATETIME, 
	@ContributoRichiesto DECIMAL(18,2), 
	@ContributoAmmesso DECIMAL(18,2), 
	@Ammesso BIT, 
	@Istruttore VARCHAR(255), 
	@DataValutazione DATETIME
)
AS
	UPDATE ANTICIPI_RICHIESTI
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_BANDO = @IdBando, 
		DATA_RICHIESTA = @DataRichiesta, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		CONTRIBUTO_AMMESSO = @ContributoAmmesso, 
		AMMESSO = @Ammesso, 
		ISTRUTTORE = @Istruttore, 
		DATA_VALUTAZIONE = @DataValutazione
	WHERE 
		(ID_ANTICIPO = @IdAnticipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAnticipiRichiestiUpdate]
(
	@IdAnticipo INT, 
	@IdDomandaPagamento INT, 
	@IdBando INT, 
	@DataRichiesta DATETIME, 
	@ContributoRichiesto DECIMAL(18,2), 
	@ContributoAmmesso DECIMAL(18,2), 
	@Ammesso BIT, 
	@Istruttore VARCHAR(16), 
	@DataValutazione DATETIME
)
AS
	UPDATE ANTICIPI_RICHIESTI
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_BANDO = @IdBando, 
		DATA_RICHIESTA = @DataRichiesta, 
		CONTRIBUTO_RICHIESTO = @ContributoRichiesto, 
		CONTRIBUTO_AMMESSO = @ContributoAmmesso, 
		AMMESSO = @Ammesso, 
		ISTRUTTORE = @Istruttore, 
		DATA_VALUTAZIONE = @DataValutazione
	WHERE 
		(ID_ANTICIPO = @IdAnticipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAnticipiRichiestiUpdate';

