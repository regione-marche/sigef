CREATE PROCEDURE [dbo].[ZVoceGenericaFindFind]
(
	@IdVoceGenericaequalthis INT, 
	@Automaticoequalthis BIT, 
	@CodFaseequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT DESCRIZIONE_FASE, ORDINE, ID_VOCE_GENERICA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, VAL_ESITO_NEGATIVO FROM VVOCE_GENERICA WHERE 1=1';
	IF (@IdVoceGenericaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VOCE_GENERICA = @IdVoceGenericaequalthis)'; set @lensql=@lensql+len(@IdVoceGenericaequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVoceGenericaequalthis INT, @Automaticoequalthis BIT, @CodFaseequalthis VARCHAR(255)',@IdVoceGenericaequalthis , @Automaticoequalthis , @CodFaseequalthis ;
	else
		SELECT DESCRIZIONE_FASE, ORDINE, ID_VOCE_GENERICA, COD_FASE, DESCRIZIONE, AUTOMATICO, QUERY_SQL, QUERY_SQL_POST, CODE_METHOD, URL, VAL_MINIMO, VAL_MASSIMO, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, VAL_ESITO_NEGATIVO
		FROM VVOCE_GENERICA
		WHERE 
			((@IdVoceGenericaequalthis IS NULL) OR ID_VOCE_GENERICA = @IdVoceGenericaequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceGenericaFindFind';

