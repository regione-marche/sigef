CREATE PROCEDURE [dbo].[ZVoceGenericaFindSelect]
(
	@IdVoceGenericaequalthis INT, 
	@CodFaseequalthis VARCHAR(255), 
	@Descrizioneequalthis VARCHAR(8000), 
	@Automaticoequalthis BIT, 
	@QuerySqlequalthis VARCHAR(8000), 
	@QuerySqlPostequalthis VARCHAR(300), 
	@CodeMethodequalthis VARCHAR(255), 
	@Urlequalthis VARCHAR(255), 
	@ValMinimoequalthis VARCHAR(255), 
	@ValMassimoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@ValEsitoNegativoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT DESCRIZIONE_FASE, ORDINE, ID_VOCE_GENERICA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, VAL_ESITO_NEGATIVO FROM VVOCE_GENERICA WHERE 1=1';
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@QuerySqlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL = @QuerySqlequalthis)'; set @lensql=@lensql+len(@QuerySqlequalthis);end;
	IF (@QuerySqlPostequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_SQL_POST = @QuerySqlPostequalthis)'; set @lensql=@lensql+len(@QuerySqlPostequalthis);end;
	IF (@CodeMethodequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODE_METHOD = @CodeMethodequalthis)'; set @lensql=@lensql+len(@CodeMethodequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL = @Urlequalthis)'; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@ValMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MINIMO = @ValMinimoequalthis)'; set @lensql=@lensql+len(@ValMinimoequalthis);end;
	IF (@ValMassimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MASSIMO = @ValMassimoequalthis)'; set @lensql=@lensql+len(@ValMassimoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@ValEsitoNegativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_ESITO_NEGATIVO = @ValEsitoNegativoequalthis)'; set @lensql=@lensql+len(@ValEsitoNegativoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVoceGenericaequalthis INT, @CodFaseequalthis VARCHAR(255), @Descrizioneequalthis VARCHAR(8000), @Automaticoequalthis BIT, @QuerySqlequalthis VARCHAR(8000), @QuerySqlPostequalthis VARCHAR(300), @CodeMethodequalthis VARCHAR(255), @Urlequalthis VARCHAR(255), @ValMinimoequalthis VARCHAR(255), @ValMassimoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @ValEsitoNegativoequalthis BIT',@IdVoceGenericaequalthis , @CodFaseequalthis , @Descrizioneequalthis , @Automaticoequalthis , @QuerySqlequalthis , @QuerySqlPostequalthis , @CodeMethodequalthis , @Urlequalthis , @ValMinimoequalthis , @ValMassimoequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @DataModificaequalthis , @CfModificaequalthis , @ValEsitoNegativoequalthis ;
	else
		SELECT DESCRIZIONE_FASE, ORDINE, ID_VOCE_GENERICA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, VAL_ESITO_NEGATIVO
		FROM VVOCE_GENERICA
		WHERE 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@QuerySqlequalthis IS NULL) OR QUERY_SQL = @QuerySqlequalthis) AND 
			((@QuerySqlPostequalthis IS NULL) OR QUERY_SQL_POST = @QuerySqlPostequalthis) AND 
			((@CodeMethodequalthis IS NULL) OR CODE_METHOD = @CodeMethodequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@ValMinimoequalthis IS NULL) OR VAL_MINIMO = @ValMinimoequalthis) AND 
			((@ValMassimoequalthis IS NULL) OR VAL_MASSIMO = @ValMassimoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@ValEsitoNegativoequalthis IS NULL) OR VAL_ESITO_NEGATIVO = @ValEsitoNegativoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceGenericaFindSelect';

