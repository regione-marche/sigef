CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaUpdate]
(
	@IdSingolaIntegrazione INT, 
	@IdIntegrazioneDomanda INT, 
	@CodTipoIntegrazione VARCHAR(255), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@CfIstruttoreSingolaIntegrazione VARCHAR(255), 
	@NoteIntegrazioneIstruttore VARCHAR(max), 
	@DataRichiestaIntegrazioneIstruttore DATETIME, 
	@DataConclusioneIstruttore DATETIME, 
	@SingolaIntegrazioneCompletataIstruttore BIT, 
	@CfBeneficiarioSingolaIntegrazione VARCHAR(255), 
	@NoteIntegrazioneBeneficiario VARCHAR(max), 
	@DataRilascioIntegrazioneBeneficiario DATETIME, 
	@DataConclusioneBeneficiario DATETIME, 
	@SingolaIntegrazioneCompletataBeneficiario BIT, 
	@IdSpesa INT, 
	@IdGiustificativo INT
)
AS
	SET @DataModifica=getdate()
	UPDATE INTEGRAZIONE_SINGOLA_DI_DOMANDA
	SET
		ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomanda, 
		COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazione, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE = @CfIstruttoreSingolaIntegrazione, 
		NOTE_INTEGRAZIONE_ISTRUTTORE = @NoteIntegrazioneIstruttore, 
		DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE = @DataRichiestaIntegrazioneIstruttore, 
		DATA_CONCLUSIONE_ISTRUTTORE = @DataConclusioneIstruttore, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttore, 
		CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE = @CfBeneficiarioSingolaIntegrazione, 
		NOTE_INTEGRAZIONE_BENEFICIARIO = @NoteIntegrazioneBeneficiario, 
		DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO = @DataRilascioIntegrazioneBeneficiario, 
		DATA_CONCLUSIONE_BENEFICIARIO = @DataConclusioneBeneficiario, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiario, 
		ID_SPESA = @IdSpesa, 
		ID_GIUSTIFICATIVO = @IdGiustificativo
	WHERE 
		(ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazione)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaUpdate]
(
	@IdSingolaIntegrazione INT, 
	@IdIntegrazioneDomanda INT, 
	@CodTipoIntegrazione VARCHAR(255), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME, 
	@CfIstruttoreSingolaIntegrazione VARCHAR(255), 
	@NoteIntegrazioneIstruttore VARCHAR(255), 
	@DataRichiestaIntegrazioneIstruttore DATETIME, 
	@DataConclusioneIstruttore DATETIME, 
	@SingolaIntegrazioneCompletataIstruttore BIT, 
	@CfBeneficiarioSingolaIntegrazione VARCHAR(255), 
	@NoteIntegrazioneBeneficiario VARCHAR(255), 
	@DataRilascioIntegrazioneBeneficiario DATETIME, 
	@DataConclusioneBeneficiario DATETIME, 
	@SingolaIntegrazioneCompletataBeneficiario BIT, 
	@IdSpesa INT, 
	@IdGiustificativo INT
)
AS
	SET @DataModifica=getdate()
	UPDATE INTEGRAZIONE_SINGOLA_DI_DOMANDA
	SET
		ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomanda, 
		COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazione, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE = @CfIstruttoreSingolaIntegrazione, 
		NOTE_INTEGRAZIONE_ISTRUTTORE = @NoteIntegrazioneIstruttore, 
		DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE = @DataRichiestaIntegrazioneIstruttore, 
		DATA_CONCLUSIONE_ISTRUTTORE = @DataConclusioneIstruttore, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttore, 
		CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE = @CfBeneficiarioSingolaIntegrazione, 
		NOTE_INTEGRAZIONE_BENEFICIARIO = @NoteIntegrazioneBeneficiario, 
		DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO = @DataRilascioIntegrazioneBeneficiario, 
		DATA_CONCLUSIONE_BENEFICIARIO = @DataConclusioneBeneficiario, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiario, 
		ID_SPESA = @IdSpesa, 
		ID_GIUSTIFICATIVO = @IdGiustificativo
	WHERE 
		(ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazione)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioneSingolaDiDomandaUpdate';

