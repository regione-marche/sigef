CREATE PROCEDURE [dbo].[ZRequisitiPagamentoFindSelect]
(
	@IdRequisitoequalthis INT, 
	@Descrizioneequalthis VARCHAR(500), 
	@Plurivaloreequalthis BIT, 
	@Numericoequalthis BIT, 
	@Datetimeequalthis BIT, 
	@TestoSempliceequalthis BIT, 
	@TestoAreaequalthis BIT, 
	@Urlequalthis VARCHAR(100), 
	@QueryEvalequalthis VARCHAR(3000), 
	@QueryInsertequalthis VARCHAR(3000), 
	@Misuraequalthis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REQUISITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA FROM REQUISITI_PAGAMENTO WHERE 1=1';
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@Plurivaloreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PLURIVALORE = @Plurivaloreequalthis)'; set @lensql=@lensql+len(@Plurivaloreequalthis);end;
	IF (@Numericoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERICO = @Numericoequalthis)'; set @lensql=@lensql+len(@Numericoequalthis);end;
	IF (@Datetimeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATETIME = @Datetimeequalthis)'; set @lensql=@lensql+len(@Datetimeequalthis);end;
	IF (@TestoSempliceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_SEMPLICE = @TestoSempliceequalthis)'; set @lensql=@lensql+len(@TestoSempliceequalthis);end;
	IF (@TestoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO_AREA = @TestoAreaequalthis)'; set @lensql=@lensql+len(@TestoAreaequalthis);end;
	IF (@Urlequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (URL = @Urlequalthis)'; set @lensql=@lensql+len(@Urlequalthis);end;
	IF (@QueryEvalequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_EVAL = @QueryEvalequalthis)'; set @lensql=@lensql+len(@QueryEvalequalthis);end;
	IF (@QueryInsertequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUERY_INSERT = @QueryInsertequalthis)'; set @lensql=@lensql+len(@QueryInsertequalthis);end;
	IF (@Misuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA = @Misuraequalthis)'; set @lensql=@lensql+len(@Misuraequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRequisitoequalthis INT, @Descrizioneequalthis VARCHAR(500), @Plurivaloreequalthis BIT, @Numericoequalthis BIT, @Datetimeequalthis BIT, @TestoSempliceequalthis BIT, @TestoAreaequalthis BIT, @Urlequalthis VARCHAR(100), @QueryEvalequalthis VARCHAR(3000), @QueryInsertequalthis VARCHAR(3000), @Misuraequalthis VARCHAR(10)',@IdRequisitoequalthis , @Descrizioneequalthis , @Plurivaloreequalthis , @Numericoequalthis , @Datetimeequalthis , @TestoSempliceequalthis , @TestoAreaequalthis , @Urlequalthis , @QueryEvalequalthis , @QueryInsertequalthis , @Misuraequalthis ;
	else
		SELECT ID_REQUISITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA
		FROM REQUISITI_PAGAMENTO
		WHERE 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@Plurivaloreequalthis IS NULL) OR PLURIVALORE = @Plurivaloreequalthis) AND 
			((@Numericoequalthis IS NULL) OR NUMERICO = @Numericoequalthis) AND 
			((@Datetimeequalthis IS NULL) OR DATETIME = @Datetimeequalthis) AND 
			((@TestoSempliceequalthis IS NULL) OR TESTO_SEMPLICE = @TestoSempliceequalthis) AND 
			((@TestoAreaequalthis IS NULL) OR TESTO_AREA = @TestoAreaequalthis) AND 
			((@Urlequalthis IS NULL) OR URL = @Urlequalthis) AND 
			((@QueryEvalequalthis IS NULL) OR QUERY_EVAL = @QueryEvalequalthis) AND 
			((@QueryInsertequalthis IS NULL) OR QUERY_INSERT = @QueryInsertequalthis) AND 
			((@Misuraequalthis IS NULL) OR MISURA = @Misuraequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoFindSelect';

