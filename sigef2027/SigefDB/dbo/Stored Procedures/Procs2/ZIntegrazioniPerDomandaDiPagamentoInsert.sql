CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @IntegrazioneCompleta = ISNULL(@IntegrazioneCompleta,((0)))
	INSERT INTO INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	(
		ID_DOMANDA_PAGAMENTO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		ISTANZA_DOMANDA_PAGAMENTO, 
		INTEGRAZIONE_COMPLETA, 
		NOTE_INTEGRAZIONE_DOMANDA, 
		CF_ISTRUTTORE, 
		DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, 
		SEGNATURA_ISTRUTTORE, 
		CF_BENFICIARIO, 
		SEGNATURA_BENEFICIARIO, 
		DATA_CONCLUSIONE_INTEGRAZIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@DataInserimento, 
		@DataModifica, 
		@IstanzaDomandaPagamento, 
		@IntegrazioneCompleta, 
		@NoteIntegrazioneDomanda, 
		@CfIstruttore, 
		@DataRichiestaIntegrazioneDomanda, 
		@SegnaturaIstruttore, 
		@CfBenficiario, 
		@SegnaturaBeneficiario, 
		@DataConclusioneIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @IntegrazioneCompleta AS INTEGRAZIONE_COMPLETA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioniPerDomandaDiPagamentoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @IntegrazioneCompleta = ISNULL(@IntegrazioneCompleta,((0)))
	INSERT INTO INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO
	(
		ID_DOMANDA_PAGAMENTO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		ISTANZA_DOMANDA_PAGAMENTO, 
		INTEGRAZIONE_COMPLETA, 
		NOTE_INTEGRAZIONE_DOMANDA, 
		CF_ISTRUTTORE, 
		DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, 
		SEGNATURA_ISTRUTTORE, 
		CF_BENFICIARIO, 
		SEGNATURA_BENEFICIARIO, 
		DATA_CONCLUSIONE_INTEGRAZIONE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@DataInserimento, 
		@DataModifica, 
		@IstanzaDomandaPagamento, 
		@IntegrazioneCompleta, 
		@NoteIntegrazioneDomanda, 
		@CfIstruttore, 
		@DataRichiestaIntegrazioneDomanda, 
		@SegnaturaIstruttore, 
		@CfBenficiario, 
		@SegnaturaBeneficiario, 
		@DataConclusioneIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_INTEGRAZIONE_DOMANDA_DI_PAGAMENTO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @IntegrazioneCompleta AS INTEGRAZIONE_COMPLETA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioniPerDomandaDiPagamentoInsert';

