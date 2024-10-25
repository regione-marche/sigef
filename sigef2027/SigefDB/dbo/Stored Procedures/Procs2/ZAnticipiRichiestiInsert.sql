CREATE PROCEDURE [dbo].[ZAnticipiRichiestiInsert]
(
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
	INSERT INTO ANTICIPI_RICHIESTI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_BANDO, 
		DATA_RICHIESTA, 
		CONTRIBUTO_RICHIESTO, 
		CONTRIBUTO_AMMESSO, 
		AMMESSO, 
		ISTRUTTORE, 
		DATA_VALUTAZIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdBando, 
		@DataRichiesta, 
		@ContributoRichiesto, 
		@ContributoAmmesso, 
		@Ammesso, 
		@Istruttore, 
		@DataValutazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ANTICIPO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAnticipiRichiestiInsert]
(
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
	INSERT INTO ANTICIPI_RICHIESTI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_BANDO, 
		DATA_RICHIESTA, 
		CONTRIBUTO_RICHIESTO, 
		CONTRIBUTO_AMMESSO, 
		AMMESSO, 
		ISTRUTTORE, 
		DATA_VALUTAZIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdBando, 
		@DataRichiesta, 
		@ContributoRichiesto, 
		@ContributoAmmesso, 
		@Ammesso, 
		@Istruttore, 
		@DataValutazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ANTICIPO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAnticipiRichiestiInsert';

