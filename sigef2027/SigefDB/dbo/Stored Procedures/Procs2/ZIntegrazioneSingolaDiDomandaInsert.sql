CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @SingolaIntegrazioneCompletataIstruttore = ISNULL(@SingolaIntegrazioneCompletataIstruttore,((0)))
	INSERT INTO INTEGRAZIONE_SINGOLA_DI_DOMANDA
	(
		ID_INTEGRAZIONE_DOMANDA, 
		COD_TIPO_INTEGRAZIONE, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, 
		NOTE_INTEGRAZIONE_ISTRUTTORE, 
		DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, 
		DATA_CONCLUSIONE_ISTRUTTORE, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, 
		CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, 
		NOTE_INTEGRAZIONE_BENEFICIARIO, 
		DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, 
		DATA_CONCLUSIONE_BENEFICIARIO, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, 
		ID_SPESA, 
		ID_GIUSTIFICATIVO
	)
	VALUES
	(
		@IdIntegrazioneDomanda, 
		@CodTipoIntegrazione, 
		@DataInserimento, 
		@DataModifica, 
		@CfIstruttoreSingolaIntegrazione, 
		@NoteIntegrazioneIstruttore, 
		@DataRichiestaIntegrazioneIstruttore, 
		@DataConclusioneIstruttore, 
		@SingolaIntegrazioneCompletataIstruttore, 
		@CfBeneficiarioSingolaIntegrazione, 
		@NoteIntegrazioneBeneficiario, 
		@DataRilascioIntegrazioneBeneficiario, 
		@DataConclusioneBeneficiario, 
		@SingolaIntegrazioneCompletataBeneficiario, 
		@IdSpesa, 
		@IdGiustificativo
	)
	SELECT SCOPE_IDENTITY() AS ID_SINGOLA_INTEGRAZIONE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @SingolaIntegrazioneCompletataIstruttore AS SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @SingolaIntegrazioneCompletataIstruttore = ISNULL(@SingolaIntegrazioneCompletataIstruttore,((0)))
	INSERT INTO INTEGRAZIONE_SINGOLA_DI_DOMANDA
	(
		ID_INTEGRAZIONE_DOMANDA, 
		COD_TIPO_INTEGRAZIONE, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, 
		NOTE_INTEGRAZIONE_ISTRUTTORE, 
		DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, 
		DATA_CONCLUSIONE_ISTRUTTORE, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, 
		CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, 
		NOTE_INTEGRAZIONE_BENEFICIARIO, 
		DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, 
		DATA_CONCLUSIONE_BENEFICIARIO, 
		SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, 
		ID_SPESA, 
		ID_GIUSTIFICATIVO
	)
	VALUES
	(
		@IdIntegrazioneDomanda, 
		@CodTipoIntegrazione, 
		@DataInserimento, 
		@DataModifica, 
		@CfIstruttoreSingolaIntegrazione, 
		@NoteIntegrazioneIstruttore, 
		@DataRichiestaIntegrazioneIstruttore, 
		@DataConclusioneIstruttore, 
		@SingolaIntegrazioneCompletataIstruttore, 
		@CfBeneficiarioSingolaIntegrazione, 
		@NoteIntegrazioneBeneficiario, 
		@DataRilascioIntegrazioneBeneficiario, 
		@DataConclusioneBeneficiario, 
		@SingolaIntegrazioneCompletataBeneficiario, 
		@IdSpesa, 
		@IdGiustificativo
	)
	SELECT SCOPE_IDENTITY() AS ID_SINGOLA_INTEGRAZIONE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @SingolaIntegrazioneCompletataIstruttore AS SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioneSingolaDiDomandaInsert';

