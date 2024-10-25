CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@IdImpresaBeneficiaria INT, 
	@IdDecreto INT, 
	@RichiestaMandatoImporto DECIMAL(18,2), 
	@RichiestaMandatoSegnatura VARCHAR(255), 
	@RichiestaMandatoData DATETIME, 
	@MandatoNumero VARCHAR(255), 
	@MandatoData DATETIME, 
	@MandatoImporto DECIMAL(18,2), 
	@MandatoIdFile INT, 
	@QuietanzaData DATETIME, 
	@QuietanzaImporto DECIMAL(18,2), 
	@Liquidato BIT
)
AS
	SET @Liquidato = ISNULL(@Liquidato,((0)))
	INSERT INTO DOMANDA_PAGAMENTO_LIQUIDAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		ID_IMPRESA_BENEFICIARIA, 
		ID_DECRETO, 
		RICHIESTA_MANDATO_IMPORTO, 
		RICHIESTA_MANDATO_SEGNATURA, 
		RICHIESTA_MANDATO_DATA, 
		MANDATO_NUMERO, 
		MANDATO_DATA, 
		MANDATO_IMPORTO, 
		MANDATO_ID_FILE, 
		QUIETANZA_DATA, 
		QUIETANZA_IMPORTO, 
		LIQUIDATO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@IdImpresaBeneficiaria, 
		@IdDecreto, 
		@RichiestaMandatoImporto, 
		@RichiestaMandatoSegnatura, 
		@RichiestaMandatoData, 
		@MandatoNumero, 
		@MandatoData, 
		@MandatoImporto, 
		@MandatoIdFile, 
		@QuietanzaData, 
		@QuietanzaImporto, 
		@Liquidato
	)
	SELECT SCOPE_IDENTITY() AS ID, @Liquidato AS LIQUIDATO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@IdImpresaBeneficiaria INT, 
	@IdDecreto INT, 
	@RichiestaMandatoImporto DECIMAL(18,2), 
	@RichiestaMandatoSegnatura VARCHAR(255), 
	@RichiestaMandatoData DATETIME, 
	@MandatoNumero VARCHAR(255), 
	@MandatoData DATETIME, 
	@MandatoImporto DECIMAL(18,2), 
	@MandatoIdFile INT, 
	@QuietanzaData DATETIME, 
	@QuietanzaImporto DECIMAL(18,2), 
	@Liquidato BIT
)
AS
	SET @Liquidato = ISNULL(@Liquidato,((0)))
	INSERT INTO DOMANDA_PAGAMENTO_LIQUIDAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		ID_IMPRESA_BENEFICIARIA, 
		ID_DECRETO, 
		RICHIESTA_MANDATO_IMPORTO, 
		RICHIESTA_MANDATO_SEGNATURA, 
		RICHIESTA_MANDATO_DATA, 
		MANDATO_NUMERO, 
		MANDATO_DATA, 
		MANDATO_IMPORTO, 
		MANDATO_ID_FILE, 
		QUIETANZA_DATA, 
		QUIETANZA_IMPORTO, 
		LIQUIDATO
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@IdImpresaBeneficiaria, 
		@IdDecreto, 
		@RichiestaMandatoImporto, 
		@RichiestaMandatoSegnatura, 
		@RichiestaMandatoData, 
		@MandatoNumero, 
		@MandatoData, 
		@MandatoImporto, 
		@MandatoIdFile, 
		@QuietanzaData, 
		@QuietanzaImporto, 
		@Liquidato
	)
	SELECT SCOPE_IDENTITY() AS ID, @Liquidato AS LIQUIDATO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoLiquidazioneInsert';

