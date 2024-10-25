CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaFindSelect]
(
	@IdVoceXChecklistGenericaequalthis INT, 
	@IdChecklistGenericaequalthis INT, 
	@IdVoceGenericaequalthis INT, 
	@Ordineequalthis INT, 
	@Obbligatorioequalthis BIT, 
	@Pesoequalthis DECIMAL(10,2), 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@Misuraequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO FROM VVOCE_X_CHECKLIST_GENERICA WHERE 1=1';
	IF (@IdVoceXChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_X_CHECKLIST_GENERICA = @IdVoceXChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceXChecklistGenericaequalthis);end;
	IF (@IdChecklistGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis)'; set @lensql=@lensql+len(@IdChecklistGenericaequalthis);end;
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	IF (@Obbligatorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OBBLIGATORIO = @Obbligatorioequalthis)'; set @lensql=@lensql+len(@Obbligatorioequalthis);end;
	IF (@Pesoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PESO = @Pesoequalthis)'; set @lensql=@lensql+len(@Pesoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVoceXChecklistGenericaequalthis INT, @IdChecklistGenericaequalthis INT, @IdVoceGenericaequalthis INT, @Ordineequalthis INT, @Obbligatorioequalthis BIT, @Pesoequalthis DECIMAL(10,2), @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @Misuraequalthis VARCHAR(255)',@IdVoceXChecklistGenericaequalthis , @IdChecklistGenericaequalthis , @IdVoceGenericaequalthis , @Ordineequalthis , @Obbligatorioequalthis , @Pesoequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @Misuraequalthis ;
	else
		SELECT ID_VOCE_X_CHECKLIST_GENERICA, ID_CHECKLIST_GENERICA, ID_VOCE_GENERICA, ORDINE, OBBLIGATORIO, PESO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, MISURA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DESCRIZIONE_CHECKLIST_GENERICA, FLAG_TEMPLATE, VAL_ESITO_NEGATIVO
		FROM VVOCE_X_CHECKLIST_GENERICA
		WHERE 
			((@IdVoceXChecklistGenericaequalthis IS NULL) OR ID_VOCE_X_CHECKLIST_GENERICA = @IdVoceXChecklistGenericaequalthis) AND 
			((@IdChecklistGenericaequalthis IS NULL) OR ID_CHECKLIST_GENERICA = @IdChecklistGenericaequalthis) AND 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis) AND 
			((@Obbligatorioequalthis IS NULL) OR OBBLIGATORIO = @Obbligatorioequalthis) AND 
			((@Pesoequalthis IS NULL) OR PESO = @Pesoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaFindSelect';

