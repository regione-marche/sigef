CREATE PROCEDURE [dbo].[ZTestataControlliLocoFindFind]
(
	@IdTestataequalthis INT, 
	@Idlocoequalthis INT, 
	@IdlocoDettaglioequalthis INT, 
	@IdIstanzaChecklistGenericaequalthis INT, 
	@IdChecklistGenericaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_TESTATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_SOPRALLUOGO, LUOGO_SOPRALLUOGO, ID_ISTANZA_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, IDLOCO_DETTAGLIO, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, ESITO_CONTROLLO, DATAESITO_CONTROLLO, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, ImportoContributoPubblico_Incrementale, SpesaAmmessa_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Azione, Intervento, ESITO_TESTATA, ID_FILE_VERBALE, ID_FILE_ATTESTAZIONE, TIPO_DOMANDA, SEGNATURA_TESTATA, DATA_VERBALE, DATA_ATTESTAZIONE, DATA_SEGNATURA, ID_UTENTE_COMPILATORE, ID_UTENTE_VALIDATORE, ID_PERSONA_FISICA_COMPILATORE, ID_STORICO_ULTIMO_COMPILATORE, CF_UTENTE_COMPILATORE, PROFILO_COMPILATORE, ENTE_COMPILATORE, NOMINATIVO_COMPILATORE, ID_PERSONA_FISICA_VALIDATORE, ID_STORICO_ULTIMO_VALIDATORE, CF_UTENTE_VALIDATORE, PROFILO_VALIDATORE, ENTE_VALIDATORE, NOMINATIVO_VALIDATORE FROM VTESTATA_CONTROLLI_LOCO WHERE 1=1';
	IF (@IdTestataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_TESTATA = @IdTestataequalthis)'; set @lensql=@lensql+len(@IdTestataequalthis);end;
	IF (@Idlocoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IdLoco = @Idlocoequalthis)'; set @lensql=@lensql+len(@Idlocoequalthis);end;
	IF (@IdlocoDettaglioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IDLOCO_DETTAGLIO = @IdlocoDettaglioequalthis)'; set @lensql=@lensql+len(@IdlocoDettaglioequalthis);end;
	IF (@IdIstanzaChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTANZA_CHECKLIST_GENERICA = @IdIstanzaChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdIstanzaChecklistGenericaequalthis);end;
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Progetto = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdTestataequalthis INT, @Idlocoequalthis INT, @IdlocoDettaglioequalthis INT, @IdIstanzaChecklistGenericaequalthis INT, @IdChecklistGenericaequalthis INT, @IdDomandaPagamentoequalthis INT, @IdProgettoequalthis INT',@IdTestataequalthis , @Idlocoequalthis , @IdlocoDettaglioequalthis , @IdIstanzaChecklistGenericaequalthis , @IdChecklistGenericaequalthis , @IdDomandaPagamentoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_TESTATA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, DATA_SOPRALLUOGO, LUOGO_SOPRALLUOGO, ID_ISTANZA_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, IDLOCO_DETTAGLIO, IdLoco, Id_Domanda_Pagamento, Id_Progetto, Asse, Selezionata, ESITO_CONTROLLO, DATAESITO_CONTROLLO, CostoTotale, ImportoAmmesso, ImportoConcesso, NrOperazioniB, Beneficiario, SpesaAmmessa, ImportoContributoPubblico, ImportoContributoPubblico_Incrementale, SpesaAmmessa_Incrementale, Esclusione, RischioIR, RischioCR, RischioComp, Azione, Intervento, ESITO_TESTATA, ID_FILE_VERBALE, ID_FILE_ATTESTAZIONE, TIPO_DOMANDA, SEGNATURA_TESTATA, DATA_VERBALE, DATA_ATTESTAZIONE, DATA_SEGNATURA, ID_UTENTE_COMPILATORE, ID_UTENTE_VALIDATORE, ID_PERSONA_FISICA_COMPILATORE, ID_STORICO_ULTIMO_COMPILATORE, CF_UTENTE_COMPILATORE, PROFILO_COMPILATORE, ENTE_COMPILATORE, NOMINATIVO_COMPILATORE, ID_PERSONA_FISICA_VALIDATORE, ID_STORICO_ULTIMO_VALIDATORE, CF_UTENTE_VALIDATORE, PROFILO_VALIDATORE, ENTE_VALIDATORE, NOMINATIVO_VALIDATORE
		FROM VTESTATA_CONTROLLI_LOCO
		WHERE 
			((@IdTestataequalthis IS NULL) OR ID_TESTATA = @IdTestataequalthis) AND 
			((@Idlocoequalthis IS NULL) OR IdLoco = @Idlocoequalthis) AND 
			((@IdlocoDettaglioequalthis IS NULL) OR IDLOCO_DETTAGLIO = @IdlocoDettaglioequalthis) AND 
			((@IdIstanzaChecklistGenericaequalthis IS NULL) OR ID_ISTANZA_CHECKLIST_GENERICA = @IdIstanzaChecklistGenericaequalthis) AND 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR Id_Progetto = @IdProgettoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoFindFind';

