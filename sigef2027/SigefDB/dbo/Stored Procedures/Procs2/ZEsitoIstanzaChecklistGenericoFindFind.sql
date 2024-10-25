CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoFindFind]
(
	@IdIstanzaGenericaequalthis INT, 
	@IdVoceGenericaequalthis INT, 
	@CodEsitoequalthis VARCHAR(255), 
	@CodEsitoRevisoreequalthis VARCHAR(255), 
	@IdChecklistGenericaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA FROM VESITO_ISTANZA_CHECKLIST_GENERICO WHERE 1=1';
	IF (@IdIstanzaGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis)'; set @lensql=@lensql+len(@IdIstanzaGenericaequalthis);end;
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO = @CodEsitoequalthis)'; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)'; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIstanzaGenericaequalthis INT, @IdVoceGenericaequalthis INT, @CodEsitoequalthis VARCHAR(255), @CodEsitoRevisoreequalthis VARCHAR(255), @IdChecklistGenericaequalthis INT',@IdIstanzaGenericaequalthis , @IdVoceGenericaequalthis , @CodEsitoequalthis , @CodEsitoRevisoreequalthis , @IdChecklistGenericaequalthis ;
	else
		SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA
		FROM VESITO_ISTANZA_CHECKLIST_GENERICO
		WHERE 
			((@IdIstanzaGenericaequalthis IS NULL) OR ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis) AND 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@CodEsitoRevisoreequalthis IS NULL) OR COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis) AND 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoFindFind]
(
	@IdIstanzaGenericaequalthis INT, 
	@IdVoceGenericaequalthis INT, 
	@CodEsitoequalthis VARCHAR(255), 
	@CodEsitoRevisoreequalthis VARCHAR(255), 
	@IdChecklistGenericaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA FROM VESITO_ISTANZA_CHECKLIST_GENERICO WHERE 1=1'';
	IF (@IdIstanzaGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis)''; set @lensql=@lensql+len(@IdIstanzaGenericaequalthis);end;
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)''; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@CodEsitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO = @CodEsitoequalthis)''; set @lensql=@lensql+len(@CodEsitoequalthis);end;
	IF (@CodEsitoRevisoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis)''; set @lensql=@lensql+len(@CodEsitoRevisoreequalthis);end;
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)''; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdIstanzaGenericaequalthis INT, @IdVoceGenericaequalthis INT, @CodEsitoequalthis VARCHAR(255), @CodEsitoRevisoreequalthis VARCHAR(255), @IdChecklistGenericaequalthis INT'',@IdIstanzaGenericaequalthis , @IdVoceGenericaequalthis , @CodEsitoequalthis , @CodEsitoRevisoreequalthis , @IdChecklistGenericaequalthis ;
	else
		SELECT ID_ESITO_GENERICO, ID_VOCE_GENERICA, ID_ISTANZA_GENERICA, COD_ESITO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, NOTE, COD_ESITO_REVISORE, DATA_REVISORE, REVISORE, NOTE_REVISORE, ESCLUDI_DA_COMUNICAZIONE, DESCRIZIONE, ESITO_POSITIVO, DESCRIZIONE_ESITO_REVISORE, ESITO_POSITIVO_REVISORE, DESCRIZIONE_VOCE_GENERICA, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, ORDINE, OBBLIGATORIO, PESO, ID_CHECKLIST_GENERICA, DESCRIZIONE_CHECKLIST_GENERICA, VALORE, VAL_ESITO_NEGATIVO, MISURA, ID_VOCE_X_CHECKLIST_GENERICA
		FROM VESITO_ISTANZA_CHECKLIST_GENERICO
		WHERE 
			((@IdIstanzaGenericaequalthis IS NULL) OR ID_ISTANZA_GENERICA = @IdIstanzaGenericaequalthis) AND 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@CodEsitoequalthis IS NULL) OR COD_ESITO = @CodEsitoequalthis) AND 
			((@CodEsitoRevisoreequalthis IS NULL) OR COD_ESITO_REVISORE = @CodEsitoRevisoreequalthis) AND 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoFindFind';

