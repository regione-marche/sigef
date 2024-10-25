CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneUpdate]
(
	@Id INT, 
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
	UPDATE DOMANDA_PAGAMENTO_LIQUIDAZIONE
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_PROGETTO = @IdProgetto, 
		ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiaria, 
		ID_DECRETO = @IdDecreto, 
		RICHIESTA_MANDATO_IMPORTO = @RichiestaMandatoImporto, 
		RICHIESTA_MANDATO_SEGNATURA = @RichiestaMandatoSegnatura, 
		RICHIESTA_MANDATO_DATA = @RichiestaMandatoData, 
		MANDATO_NUMERO = @MandatoNumero, 
		MANDATO_DATA = @MandatoData, 
		MANDATO_IMPORTO = @MandatoImporto, 
		MANDATO_ID_FILE = @MandatoIdFile, 
		QUIETANZA_DATA = @QuietanzaData, 
		QUIETANZA_IMPORTO = @QuietanzaImporto, 
		LIQUIDATO = @Liquidato
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDomandaPagamentoLiquidazioneUpdate]
(
	@Id INT, 
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
	UPDATE DOMANDA_PAGAMENTO_LIQUIDAZIONE
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_PROGETTO = @IdProgetto, 
		ID_IMPRESA_BENEFICIARIA = @IdImpresaBeneficiaria, 
		ID_DECRETO = @IdDecreto, 
		RICHIESTA_MANDATO_IMPORTO = @RichiestaMandatoImporto, 
		RICHIESTA_MANDATO_SEGNATURA = @RichiestaMandatoSegnatura, 
		RICHIESTA_MANDATO_DATA = @RichiestaMandatoData, 
		MANDATO_NUMERO = @MandatoNumero, 
		MANDATO_DATA = @MandatoData, 
		MANDATO_IMPORTO = @MandatoImporto, 
		MANDATO_ID_FILE = @MandatoIdFile, 
		QUIETANZA_DATA = @QuietanzaData, 
		QUIETANZA_IMPORTO = @QuietanzaImporto, 
		LIQUIDATO = @Liquidato
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaPagamentoLiquidazioneUpdate';

