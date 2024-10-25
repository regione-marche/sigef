CREATE PROCEDURE [dbo].[ZRequisitiPagamentoPlurivaloreFindSelect]
(
	@IdValoreequalthis INT, 
	@IdRequisitoequalthis INT, 
	@Codiceequalthis VARCHAR(10), 
	@Descrizioneequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VALORE, ID_REQUISITO, CODICE, DESCRIZIONE FROM REQUISITI_PAGAMENTO_PLURIVALORE WHERE 1=1';
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdValoreequalthis INT, @IdRequisitoequalthis INT, @Codiceequalthis VARCHAR(10), @Descrizioneequalthis VARCHAR(500)',@IdValoreequalthis , @IdRequisitoequalthis , @Codiceequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_VALORE, ID_REQUISITO, CODICE, DESCRIZIONE
		FROM REQUISITI_PAGAMENTO_PLURIVALORE
		WHERE 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoPlurivaloreFindSelect';

