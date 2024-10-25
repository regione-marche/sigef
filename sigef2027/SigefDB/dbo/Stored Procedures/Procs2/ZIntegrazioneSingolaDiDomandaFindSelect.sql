CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaFindSelect]
(
	@IdSingolaIntegrazioneequalthis INT, 
	@IdIntegrazioneDomandaequalthis INT, 
	@CodTipoIntegrazioneequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@CfIstruttoreSingolaIntegrazioneequalthis VARCHAR(255), 
	@NoteIntegrazioneIstruttoreequalthis VARCHAR(max), 
	@DataRichiestaIntegrazioneIstruttoreequalthis DATETIME, 
	@DataConclusioneIstruttoreequalthis DATETIME, 
	@SingolaIntegrazioneCompletataIstruttoreequalthis BIT, 
	@CfBeneficiarioSingolaIntegrazioneequalthis VARCHAR(255), 
	@NoteIntegrazioneBeneficiarioequalthis VARCHAR(max), 
	@DataRilascioIntegrazioneBeneficiarioequalthis DATETIME, 
	@DataConclusioneBeneficiarioequalthis DATETIME, 
	@SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, 
	@IdSpesaequalthis INT, 
	@IdGiustificativoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA WHERE 1=1';
	IF (@IdSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdSingolaIntegrazioneequalthis);end;
	IF (@IdIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomandaequalthis)'; set @lensql=@lensql+len(@IdIntegrazioneDomandaequalthis);end;
	IF (@CodTipoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazioneequalthis)'; set @lensql=@lensql+len(@CodTipoIntegrazioneequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfIstruttoreSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE = @CfIstruttoreSingolaIntegrazioneequalthis)'; set @lensql=@lensql+len(@CfIstruttoreSingolaIntegrazioneequalthis);end;
	IF (@NoteIntegrazioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_INTEGRAZIONE_ISTRUTTORE = @NoteIntegrazioneIstruttoreequalthis)'; set @lensql=@lensql+len(@NoteIntegrazioneIstruttoreequalthis);end;
	IF (@DataRichiestaIntegrazioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE = @DataRichiestaIntegrazioneIstruttoreequalthis)'; set @lensql=@lensql+len(@DataRichiestaIntegrazioneIstruttoreequalthis);end;
	IF (@DataConclusioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONCLUSIONE_ISTRUTTORE = @DataConclusioneIstruttoreequalthis)'; set @lensql=@lensql+len(@DataConclusioneIstruttoreequalthis);end;
	IF (@SingolaIntegrazioneCompletataIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataIstruttoreequalthis);end;
	IF (@CfBeneficiarioSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE = @CfBeneficiarioSingolaIntegrazioneequalthis)'; set @lensql=@lensql+len(@CfBeneficiarioSingolaIntegrazioneequalthis);end;
	IF (@NoteIntegrazioneBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_INTEGRAZIONE_BENEFICIARIO = @NoteIntegrazioneBeneficiarioequalthis)'; set @lensql=@lensql+len(@NoteIntegrazioneBeneficiarioequalthis);end;
	IF (@DataRilascioIntegrazioneBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO = @DataRilascioIntegrazioneBeneficiarioequalthis)'; set @lensql=@lensql+len(@DataRilascioIntegrazioneBeneficiarioequalthis);end;
	IF (@DataConclusioneBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONCLUSIONE_BENEFICIARIO = @DataConclusioneBeneficiarioequalthis)'; set @lensql=@lensql+len(@DataConclusioneBeneficiarioequalthis);end;
	IF (@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis)'; set @lensql=@lensql+len(@SingolaIntegrazioneCompletataBeneficiarioequalthis);end;
	IF (@IdSpesaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPESA = @IdSpesaequalthis)'; set @lensql=@lensql+len(@IdSpesaequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSingolaIntegrazioneequalthis INT, @IdIntegrazioneDomandaequalthis INT, @CodTipoIntegrazioneequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME, @CfIstruttoreSingolaIntegrazioneequalthis VARCHAR(255), @NoteIntegrazioneIstruttoreequalthis VARCHAR(max), @DataRichiestaIntegrazioneIstruttoreequalthis DATETIME, @DataConclusioneIstruttoreequalthis DATETIME, @SingolaIntegrazioneCompletataIstruttoreequalthis BIT, @CfBeneficiarioSingolaIntegrazioneequalthis VARCHAR(255), @NoteIntegrazioneBeneficiarioequalthis VARCHAR(max), @DataRilascioIntegrazioneBeneficiarioequalthis DATETIME, @DataConclusioneBeneficiarioequalthis DATETIME, @SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, @IdSpesaequalthis INT, @IdGiustificativoequalthis INT',@IdSingolaIntegrazioneequalthis , @IdIntegrazioneDomandaequalthis , @CodTipoIntegrazioneequalthis , @DataInserimentoequalthis , @DataModificaequalthis , @CfIstruttoreSingolaIntegrazioneequalthis , @NoteIntegrazioneIstruttoreequalthis , @DataRichiestaIntegrazioneIstruttoreequalthis , @DataConclusioneIstruttoreequalthis , @SingolaIntegrazioneCompletataIstruttoreequalthis , @CfBeneficiarioSingolaIntegrazioneequalthis , @NoteIntegrazioneBeneficiarioequalthis , @DataRilascioIntegrazioneBeneficiarioequalthis , @DataConclusioneBeneficiarioequalthis , @SingolaIntegrazioneCompletataBeneficiarioequalthis , @IdSpesaequalthis , @IdGiustificativoequalthis ;
	else
		SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO
		FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA
		WHERE 
			((@IdSingolaIntegrazioneequalthis IS NULL) OR ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazioneequalthis) AND 
			((@IdIntegrazioneDomandaequalthis IS NULL) OR ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomandaequalthis) AND 
			((@CodTipoIntegrazioneequalthis IS NULL) OR COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazioneequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfIstruttoreSingolaIntegrazioneequalthis IS NULL) OR CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE = @CfIstruttoreSingolaIntegrazioneequalthis) AND 
			((@NoteIntegrazioneIstruttoreequalthis IS NULL) OR NOTE_INTEGRAZIONE_ISTRUTTORE = @NoteIntegrazioneIstruttoreequalthis) AND 
			((@DataRichiestaIntegrazioneIstruttoreequalthis IS NULL) OR DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE = @DataRichiestaIntegrazioneIstruttoreequalthis) AND 
			((@DataConclusioneIstruttoreequalthis IS NULL) OR DATA_CONCLUSIONE_ISTRUTTORE = @DataConclusioneIstruttoreequalthis) AND 
			((@SingolaIntegrazioneCompletataIstruttoreequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis) AND 
			((@CfBeneficiarioSingolaIntegrazioneequalthis IS NULL) OR CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE = @CfBeneficiarioSingolaIntegrazioneequalthis) AND 
			((@NoteIntegrazioneBeneficiarioequalthis IS NULL) OR NOTE_INTEGRAZIONE_BENEFICIARIO = @NoteIntegrazioneBeneficiarioequalthis) AND 
			((@DataRilascioIntegrazioneBeneficiarioequalthis IS NULL) OR DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO = @DataRilascioIntegrazioneBeneficiarioequalthis) AND 
			((@DataConclusioneBeneficiarioequalthis IS NULL) OR DATA_CONCLUSIONE_BENEFICIARIO = @DataConclusioneBeneficiarioequalthis) AND 
			((@SingolaIntegrazioneCompletataBeneficiarioequalthis IS NULL) OR SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO = @SingolaIntegrazioneCompletataBeneficiarioequalthis) AND 
			((@IdSpesaequalthis IS NULL) OR ID_SPESA = @IdSpesaequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaFindSelect]
(
	@IdSingolaIntegrazioneequalthis INT, 
	@IdIntegrazioneDomandaequalthis INT, 
	@CodTipoIntegrazioneequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@CfIstruttoreSingolaIntegrazioneequalthis VARCHAR(255), 
	@NoteIntegrazioneIstruttoreequalthis VARCHAR(255), 
	@DataRichiestaIntegrazioneIstruttoreequalthis DATETIME, 
	@DataConclusioneIstruttoreequalthis DATETIME, 
	@SingolaIntegrazioneCompletataIstruttoreequalthis BIT, 
	@CfBeneficiarioSingolaIntegrazioneequalthis VARCHAR(255), 
	@NoteIntegrazioneBeneficiarioequalthis VARCHAR(255), 
	@DataRilascioIntegrazioneBeneficiarioequalthis DATETIME, 
	@DataConclusioneBeneficiarioequalthis DATETIME, 
	@SingolaIntegrazioneCompletataBeneficiarioequalthis BIT, 
	@IdSpesaequalthis INT, 
	@IdGiustificativoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_SINGOLA_INTEGRAZIONE, ID_INTEGRAZIONE_DOMANDA, COD_TIPO_INTEGRAZIONE, DATA_INSERIMENTO, DATA_MODIFICA, CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE, DATA_CONCLUSIONE_ISTRUTTORE, SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE, CF_BENEFICIARIO_SINGOLA_INTEGRAZIONE, NOTE_INTEGRAZIONE_BENEFICIARIO, DATA_RILASCIO_INTEGRAZIONE_BENEFICIARIO, DATA_CONCLUSIONE_BENEFICIARIO, SINGOLA_INTEGRAZIONE_COMPLETATA_BENEFICIARIO, ID_DOMANDA_PAGAMENTO, DATA_INSERIMENTO_INTEGRAZIONE, DATA_MODIFICA_INTEGRAZIONE, ISTANZA_DOMANDA_PAGAMENTO, INTEGRAZIONE_COMPLETA, NOTE_INTEGRAZIONE_DOMANDA, CF_ISTRUTTORE, DATA_RICHIESTA_INTEGRAZIONE_DOMANDA, SEGNATURA_ISTRUTTORE, CF_BENFICIARIO, SEGNATURA_BENEFICIARIO, DATA_CONCLUSIONE_INTEGRAZIONE, DESCRIZIONE_TIPO_INTEGRAZIONE, ID_SPESA, ID_GIUSTIFICATIVO FROM VINTEGRAZIONE_SINGOLA_DI_DOMANDA WHERE 1=1'';
	IF (@IdSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazioneequalthis)''; set @lensql=@lensql+len(@IdSingolaIntegrazioneequalthis);end;
	IF (@IdIntegrazioneDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INTEGRAZIONE_DOMANDA = @IdIntegrazioneDomandaequalthis)''; set @lensql=@lensql+len(@IdIntegrazioneDomandaequalthis);end;
	IF (@CodTipoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_INTEGRAZIONE = @CodTipoIntegrazioneequalthis)''; set @lensql=@lensql+len(@CodTipoIntegrazioneequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfIstruttoreSingolaIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_ISTRUTTORE_SINGOLA_INTEGRAZIONE = @CfIstruttoreSingolaIntegrazioneequalthis)''; set @lensql=@lensql+len(@CfIstruttoreSingolaIntegrazioneequalthis);end;
	IF (@NoteIntegrazioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NOTE_INTEGRAZIONE_ISTRUTTORE = @NoteIntegrazioneIstruttoreequalthis)''; set @lensql=@lensql+len(@NoteIntegrazioneIstruttoreequalthis);end;
	IF (@DataRichiestaIntegrazioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_RICHIESTA_INTEGRAZIONE_ISTRUTTORE = @DataRichiestaIntegrazioneIstruttoreequalthis)''; set @lensql=@lensql+len(@DataRichiestaIntegrazioneIstruttoreequalthis);end;
	IF (@DataConclusioneIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_CONCLUSIONE_ISTRUTTORE = @DataConclusioneIstruttoreequalthis)''; set @lensql=@lensql+len(@DataConclusioneIstruttoreequalthis);end;
	IF (@SingolaIntegrazioneCompletataIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SINGOLA_INTEGRAZIONE_COMPLETATA_ISTRUTTORE = @SingolaIntegrazioneCompletataIstruttoreequalthis)''; set @lensql=@', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioneSingolaDiDomandaFindSelect';

