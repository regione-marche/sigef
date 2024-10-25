CREATE PROCEDURE [dbo].[ZTestataControlliLocoFindSelect]
(
	@IdTestataequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataSopralluogoequalthis DATETIME, 
	@LuogoSopralluogoequalthis VARCHAR(3000), 
	@IdIstanzaChecklistGenericaequalthis INT, 
	@IdlocoDettaglioequalthis INT, 
	@EsitoTestataequalthis BIT, 
	@IdFileVerbaleequalthis INT, 
	@DataVerbaleequalthis DATETIME, 
	@IdFileAttestazioneequalthis INT, 
	@DataAttestazioneequalthis DATETIME, 
	@SegnaturaTestataequalthis VARCHAR(1000), 
	@DataSegnaturaequalthis DATETIME, 
	@IdUtenteCompilatoreequalthis INT, 
	@IdUtenteValidatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TESTATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_SOPRALLUOGO, LUOGO_SOPRALLUOGO, ID_ISTANZA_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, IDLOCO_DETTAGLIO, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, ESITO_CONTROLLO, DATAESITO_CONTROLLO, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, ImportoContributoPubblico_Incrementale, SpesaAmmessa_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Azione, Intervento, ESITO_TESTATA, ID_FILE_VERBALE, ID_FILE_ATTESTAZIONE, TIPO_DOMANDA, SEGNATURA_TESTATA, DATA_VERBALE, DATA_ATTESTAZIONE, DATA_SEGNATURA, ID_UTENTE_COMPILATORE, ID_UTENTE_VALIDATORE, ID_PERSONA_FISICA_COMPILATORE, ID_STORICO_ULTIMO_COMPILATORE, CF_UTENTE_COMPILATORE, PROFILO_COMPILATORE, ENTE_COMPILATORE, NOMINATIVO_COMPILATORE, ID_PERSONA_FISICA_VALIDATORE, ID_STORICO_ULTIMO_VALIDATORE, CF_UTENTE_VALIDATORE, PROFILO_VALIDATORE, ENTE_VALIDATORE, NOMINATIVO_VALIDATORE FROM VTESTATA_CONTROLLI_LOCO WHERE 1=1';
	IF (@IdTestataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TESTATA = @IdTestataequalthis)'; set @lensql=@lensql+len(@IdTestataequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataSopralluogoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SOPRALLUOGO = @DataSopralluogoequalthis)'; set @lensql=@lensql+len(@DataSopralluogoequalthis);end;
	IF (@LuogoSopralluogoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (LUOGO_SOPRALLUOGO = @LuogoSopralluogoequalthis)'; set @lensql=@lensql+len(@LuogoSopralluogoequalthis);end;
	IF (@IdIstanzaChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTANZA_CHECKLIST_GENERICA = @IdIstanzaChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdIstanzaChecklistGenericaequalthis);end;
	IF (@IdlocoDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IDLOCO_DETTAGLIO = @IdlocoDettaglioequalthis)'; set @lensql=@lensql+len(@IdlocoDettaglioequalthis);end;
	IF (@EsitoTestataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO_TESTATA = @EsitoTestataequalthis)'; set @lensql=@lensql+len(@EsitoTestataequalthis);end;
	IF (@IdFileVerbaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_VERBALE = @IdFileVerbaleequalthis)'; set @lensql=@lensql+len(@IdFileVerbaleequalthis);end;
	IF (@DataVerbaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VERBALE = @DataVerbaleequalthis)'; set @lensql=@lensql+len(@DataVerbaleequalthis);end;
	IF (@IdFileAttestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_ATTESTAZIONE = @IdFileAttestazioneequalthis)'; set @lensql=@lensql+len(@IdFileAttestazioneequalthis);end;
	IF (@DataAttestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ATTESTAZIONE = @DataAttestazioneequalthis)'; set @lensql=@lensql+len(@DataAttestazioneequalthis);end;
	IF (@SegnaturaTestataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_TESTATA = @SegnaturaTestataequalthis)'; set @lensql=@lensql+len(@SegnaturaTestataequalthis);end;
	IF (@DataSegnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SEGNATURA = @DataSegnaturaequalthis)'; set @lensql=@lensql+len(@DataSegnaturaequalthis);end;
	IF (@IdUtenteCompilatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_COMPILATORE = @IdUtenteCompilatoreequalthis)'; set @lensql=@lensql+len(@IdUtenteCompilatoreequalthis);end;
	IF (@IdUtenteValidatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_VALIDATORE = @IdUtenteValidatoreequalthis)'; set @lensql=@lensql+len(@IdUtenteValidatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTestataequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataSopralluogoequalthis DATETIME, @LuogoSopralluogoequalthis VARCHAR(3000), @IdIstanzaChecklistGenericaequalthis INT, @IdlocoDettaglioequalthis INT, @EsitoTestataequalthis BIT, @IdFileVerbaleequalthis INT, @DataVerbaleequalthis DATETIME, @IdFileAttestazioneequalthis INT, @DataAttestazioneequalthis DATETIME, @SegnaturaTestataequalthis VARCHAR(1000), @DataSegnaturaequalthis DATETIME, @IdUtenteCompilatoreequalthis INT, @IdUtenteValidatoreequalthis INT',@IdTestataequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @DataSopralluogoequalthis , @LuogoSopralluogoequalthis , @IdIstanzaChecklistGenericaequalthis , @IdlocoDettaglioequalthis , @EsitoTestataequalthis , @IdFileVerbaleequalthis , @DataVerbaleequalthis , @IdFileAttestazioneequalthis , @DataAttestazioneequalthis , @SegnaturaTestataequalthis , @DataSegnaturaequalthis , @IdUtenteCompilatoreequalthis , @IdUtenteValidatoreequalthis ;
	else
		SELECT ID_TESTATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_SOPRALLUOGO, LUOGO_SOPRALLUOGO, ID_ISTANZA_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, IDLOCO_DETTAGLIO, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, ESITO_CONTROLLO, DATAESITO_CONTROLLO, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, ImportoContributoPubblico_Incrementale, SpesaAmmessa_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Azione, Intervento, ESITO_TESTATA, ID_FILE_VERBALE, ID_FILE_ATTESTAZIONE, TIPO_DOMANDA, SEGNATURA_TESTATA, DATA_VERBALE, DATA_ATTESTAZIONE, DATA_SEGNATURA, ID_UTENTE_COMPILATORE, ID_UTENTE_VALIDATORE, ID_PERSONA_FISICA_COMPILATORE, ID_STORICO_ULTIMO_COMPILATORE, CF_UTENTE_COMPILATORE, PROFILO_COMPILATORE, ENTE_COMPILATORE, NOMINATIVO_COMPILATORE, ID_PERSONA_FISICA_VALIDATORE, ID_STORICO_ULTIMO_VALIDATORE, CF_UTENTE_VALIDATORE, PROFILO_VALIDATORE, ENTE_VALIDATORE, NOMINATIVO_VALIDATORE
		FROM VTESTATA_CONTROLLI_LOCO
		WHERE 
			((@IdTestataequalthis IS NULL) OR ID_TESTATA = @IdTestataequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataSopralluogoequalthis IS NULL) OR DATA_SOPRALLUOGO = @DataSopralluogoequalthis) AND 
			((@LuogoSopralluogoequalthis IS NULL) OR LUOGO_SOPRALLUOGO = @LuogoSopralluogoequalthis) AND 
			((@IdIstanzaChecklistGenericaequalthis IS NULL) OR ID_ISTANZA_CHECKLIST_GENERICA = @IdIstanzaChecklistGenericaequalthis) AND 
			((@IdlocoDettaglioequalthis IS NULL) OR IDLOCO_DETTAGLIO = @IdlocoDettaglioequalthis) AND 
			((@EsitoTestataequalthis IS NULL) OR ESITO_TESTATA = @EsitoTestataequalthis) AND 
			((@IdFileVerbaleequalthis IS NULL) OR ID_FILE_VERBALE = @IdFileVerbaleequalthis) AND 
			((@DataVerbaleequalthis IS NULL) OR DATA_VERBALE = @DataVerbaleequalthis) AND 
			((@IdFileAttestazioneequalthis IS NULL) OR ID_FILE_ATTESTAZIONE = @IdFileAttestazioneequalthis) AND 
			((@DataAttestazioneequalthis IS NULL) OR DATA_ATTESTAZIONE = @DataAttestazioneequalthis) AND 
			((@SegnaturaTestataequalthis IS NULL) OR SEGNATURA_TESTATA = @SegnaturaTestataequalthis) AND 
			((@DataSegnaturaequalthis IS NULL) OR DATA_SEGNATURA = @DataSegnaturaequalthis) AND 
			((@IdUtenteCompilatoreequalthis IS NULL) OR ID_UTENTE_COMPILATORE = @IdUtenteCompilatoreequalthis) AND 
			((@IdUtenteValidatoreequalthis IS NULL) OR ID_UTENTE_VALIDATORE = @IdUtenteValidatoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoFindSelect';

