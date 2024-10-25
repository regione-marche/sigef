CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoFindSelect]
(
	@IdEsitoGenericoequalthis INT, 
	@IdVoceGenericaequalthis INT, 
	@IdIstanzaGenericaequalthis INT, 
	@CodEsitoequalthis VARCHAR(255), 
	@Valoreequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@CodEsitoRevisoreequalthis VARCHAR(255), 
	@DataRevisoreequalthis DATETIME, 
	@Revisoreequalthis VARCHAR(255), 
	@EscludiDaComunicazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA FROM VESITO_ISTANZA_CHECKLIST_GENERICO WHERE 1=1';
	IF (@IdEsitoGenericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ESITO_GENERICO = @IdEsitoGenericoequalthis)'; set @lensql=@lensql+len(@IdEsitoGenericoequalthis);end;
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@IdIstanzaGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis)'; set @lensql=@lensql+len(@IdIstanzaGenericaequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)'; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@DataRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_REVISORE = @DataRevisoreequalthis)'; set @lensql=@lensql+len(@DataRevisoreequalthis);end;
	IF (@Revisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISORE = @Revisoreequalthis)'; set @lensql=@lensql+len(@Revisoreequalthis);end;
	IF (@EscludiDaComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)'; set @lensql=@lensql+len(@EscludiDaComunicazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdEsitoGenericoequalthis INT, @IdVoceGenericaequalthis INT, @IdIstanzaGenericaequalthis INT, @CodEsitoequalthis VARCHAR(255), @Valoreequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @CodEsitoRevisoreequalthis VARCHAR(255), @DataRevisoreequalthis DATETIME, @Revisoreequalthis VARCHAR(255), @EscludiDaComunicazioneequalthis BIT',@IdEsitoGenericoequalthis , @IdVoceGenericaequalthis , @IdIstanzaGenericaequalthis , @CodEsitoequalthis , @Valoreequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @CodEsitoRevisoreequalthis , @DataRevisoreequalthis , @Revisoreequalthis , @EscludiDaComunicazioneequalthis ;
	else
		SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA
		FROM VESITO_ISTANZA_CHECKLIST_GENERICO
		WHERE 
			((@IdEsitoGenericoequalthis IS NULL) OR ID_ESITO_GENERICO = @IdEsitoGenericoequalthis) AND 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@IdIstanzaGenericaequalthis IS NULL) OR ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@CodEsitoRevisoreequalthis IS NULL) OR COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis) AND 
			((@DataRevisoreequalthis IS NULL) OR DATA_REVISORE = @DataRevisoreequalthis) AND 
			((@Revisoreequalthis IS NULL) OR REVISORE = @Revisoreequalthis) AND 
			((@EscludiDaComunicazioneequalthis IS NULL) OR ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoFindSelect]
(
	@IdEsitoGenericoequalthis INT, 
	@IdVoceGenericaequalthis INT, 
	@IdIstanzaGenericaequalthis INT, 
	@CodEsitoequalthis VARCHAR(255), 
	@Valoreequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@CodEsitoRevisoreequalthis VARCHAR(255), 
	@DataRevisoreequalthis DATETIME, 
	@Revisoreequalthis VARCHAR(255), 
	@EscludiDaComunicazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA FROM VESITO_ISTANZA_CHECKLIST_GENERICO WHERE 1=1'';
	IF (@IdEsitoGenericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ESITO_GENERICO = @IdEsitoGenericoequalthis)''; set @lensql=@lensql+len(@IdEsitoGenericoequalthis);end;
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)''; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@IdIstanzaGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis)''; set @lensql=@lensql+len(@IdIstanzaGenericaequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO = @CodEsitoequalthis)''; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE = @Valoreequalthis)''; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)''; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_INSERIMENTO = @CfInserimentoequalthis)''; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_MODIFICA = @DataModificaequalthis)''; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_MODIFICA = @CfModificaequalthis)''; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)''; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@DataRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_REVISORE = @DataRevisoreequalthis)''; set @lensql=@lensql+len(@DataRevisoreequalthis);end;
	IF (@Revisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REVISORE = @Revisoreequalthis)''; set @lensql=@lensql+len(@Revisoreequalthis);end;
	IF (@EscludiDaComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazioneequalthis)''; set @lensql=@lensql+len(@EscludiDaComunicazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdEsitoGenericoequalthis INT, @IdVoceGenericaequalthis INT, @IdIstanzaGenericaequalthis INT, @CodEsitoequalthis VARCHAR(255), @Valoreequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @CodEsitoRevisoreequalthis VARCHAR(255), @DataRevisoreequalthis DATETIME, @Revisoreequalthis VARCHAR(255), @EscludiDaComu', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoFindSelect';

