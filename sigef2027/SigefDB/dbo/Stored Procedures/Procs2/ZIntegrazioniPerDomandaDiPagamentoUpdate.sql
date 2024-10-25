CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoUpdate]
(
	@IdIntegrazioneDomandaDiPagamento INT, 
	@IdDomandaPagamento INT, 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@IstanzaDomandaPagamento XML, 
	@IntegrazioneCompleta BIT, 
	@NoteIntegrazioneDomanda VARCHAR(max), 
	@CfIstruttore VARCHAR(255), 
	@DataRichiestaIntegrazioneDomanda DATETIME, 
	@SegnaturaIstruttore VARCHAR(255), 
	@CfBenficiario VARCHAR(255), 
	@SegnaturaBeneficiario VARCHAR(255), 
	@DataConclusioneIntegrazione DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		ISTANZA_DOMANDA_PAGAMENTO = @IstanzaDomandaPagamento, 
		INTEGRAZIONE_COMPLETA = @IntegrazioneCompleta, 
		NOTE_INTEGRAZIONE_DOMANDA = @NoteIntegrazioneDomanda, 
		CF_ISTRUTTORE = @CfIstruttore, 
		DATA_RICHIESTA_INTEGRAZIONE_DOMANDA = @DataRichiestaIntegrazioneDomanda, 
		SEGNATURA_ISTRUTTORE = @SegnaturaIstruttore, 
		CF_BENFICIARIO = @CfBenficiario, 
		SEGNATURA_BENEFICIARIO = @SegnaturaBeneficiario, 
		DATA_CONCLUSIONE_INTEGRAZIONE = @DataConclusioneIntegrazione
	WHERE 
		(ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamento)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoUpdate]
(
	@IdIntegrazioneDomandaDiPagamento INT, 
	@IdDomandaPagamento INT, 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@IstanzaDomandaPagamento XML, 
	@IntegrazioneCompleta BIT, 
	@NoteIntegrazioneDomanda VARCHAR(255), 
	@CfIstruttore VARCHAR(255), 
	@DataRichiestaIntegrazioneDomanda DATETIME, 
	@SegnaturaIstruttore VARCHAR(255), 
	@CfBenficiario VARCHAR(255), 
	@SegnaturaBeneficiario VARCHAR(255), 
	@DataConclusioneIntegrazione DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		ISTANZA_DOMANDA_PAGAMENTO = @IstanzaDomandaPagamento, 
		INTEGRAZIONE_COMPLETA = @IntegrazioneCompleta, 
		NOTE_INTEGRAZIONE_DOMANDA = @NoteIntegrazioneDomanda, 
		CF_ISTRUTTORE = @CfIstruttore, 
		DATA_RICHIESTA_INTEGRAZIONE_DOMANDA = @DataRichiestaIntegrazioneDomanda, 
		SEGNATURA_ISTRUTTORE = @SegnaturaIstruttore, 
		CF_BENFICIARIO = @CfBenficiario, 
		SEGNATURA_BENEFICIARIO = @SegnaturaBeneficiario, 
		DATA_CONCLUSIONE_INTEGRAZIONE = @DataConclusioneIntegrazione
	WHERE 
		(ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO = @IdIntegrazioneDomandaDiPagamento)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioniPerDomandaDiPagamentoUpdate';

