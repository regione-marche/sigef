CREATE PROCEDURE [dbo].[ZRequisitiPagamentoFindFind]
(
	@IdRequisitoequalthis INT, 
	@Misuralikethis VARCHAR(10)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REQUISITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA FROM REQUISITI_PAGAMENTO WHERE 1=1';
	IF (@IdRequisitoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REQUISITO = @IdRequisitoequalthis)'; set @lensql=@lensql+len(@IdRequisitoequalthis);end;
	IF (@Misuralikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA LIKE @Misuralikethis)'; set @lensql=@lensql+len(@Misuralikethis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRequisitoequalthis INT, @Misuralikethis VARCHAR(10)',@IdRequisitoequalthis , @Misuralikethis ;
	else
		SELECT ID_REQUISITO, DESCRIZIONE, PLURIVALORE, NUMERICO, DATETIME, TESTO_SEMPLICE, TESTO_AREA, URL, QUERY_EVAL, QUERY_INSERT, MISURA
		FROM REQUISITI_PAGAMENTO
		WHERE 
			((@IdRequisitoequalthis IS NULL) OR ID_REQUISITO = @IdRequisitoequalthis) AND 
			((@Misuralikethis IS NULL) OR MISURA LIKE @Misuralikethis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRequisitiPagamentoFindFind';

