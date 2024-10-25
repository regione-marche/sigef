CREATE PROCEDURE [dbo].[ZRequisitiVarianteFindSelect]
(
	@IdRequisitoequalthis INT, 
	@Automaticoequalthis BIT, 
	@Descrizioneequalthis VARCHAR(500), 
	@QueryEvalequalthis VARCHAR(3000), 
	@QueryInsertequalthis VARCHAR(3000), 
	@ValMinimoequalthis DECIMAL(18,2), 
	@ValMassimoequalthis DECIMAL(18,2), 
	@Misuraequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REQUISITO, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA FROM REQUISITI_VARIANTE WHERE 1=1';
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Automaticoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AUTOMATICO = @Automaticoequalthis)'; set @lensql=@lensql+len(@Automaticoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@QueryEvalequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_EVAL = @QueryEvalequalthis)'; set @lensql=@lensql+len(@QueryEvalequalthis);end;
	IF (@QueryInsertequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_INSERT = @QueryInsertequalthis)'; set @lensql=@lensql+len(@QueryInsertequalthis);end;
	IF (@ValMinimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MINIMO = @ValMinimoequalthis)'; set @lensql=@lensql+len(@ValMinimoequalthis);end;
	IF (@ValMassimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_MASSIMO = @ValMassimoequalthis)'; set @lensql=@lensql+len(@ValMassimoequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRequisitoequalthis INT, @Automaticoequalthis BIT, @Descrizioneequalthis VARCHAR(500), @QueryEvalequalthis VARCHAR(3000), @QueryInsertequalthis VARCHAR(3000), @ValMinimoequalthis DECIMAL(18,2), @ValMassimoequalthis DECIMAL(18,2), @Misuraequalthis VARCHAR(10)',@IdRequisitoequalthis , @Automaticoequalthis , @Descrizioneequalthis , @QueryEvalequalthis , @QueryInsertequalthis , @ValMinimoequalthis , @ValMassimoequalthis , @Misuraequalthis ;
	else
		SELECT ID_REQUISITO, AUTOMATICO, DESCRIZIONE, QUERY_EVAL, QUERY_INSERT, VAL_MINIMO, VAL_MASSIMO, MISURA
		FROM REQUISITI_VARIANTE
		WHERE 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Automaticoequalthis IS NULL) OR AUTOMATICO = @Automaticoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@QueryEvalequalthis IS NULL) OR QUERY_EVAL = @QueryEvalequalthis) AND 
			((@QueryInsertequalthis IS NULL) OR QUERY_INSERT = @QueryInsertequalthis) AND 
			((@ValMinimoequalthis IS NULL) OR VAL_MINIMO = @ValMinimoequalthis) AND 
			((@ValMassimoequalthis IS NULL) OR VAL_MASSIMO = @ValMassimoequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiVarianteFindSelect';

