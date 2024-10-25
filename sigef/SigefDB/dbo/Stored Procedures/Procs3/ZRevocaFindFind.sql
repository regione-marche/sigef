CREATE PROCEDURE [dbo].[ZRevocaFindFind]
(
	@IdRevocaequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_REVOCA, ID_PROGETTO, ID_IMPRESA, ORIGINE, NOTE, IMPORTO_REVOCA, NUMERO_ATTO, DATA_ATTO, RECUPERO_BENEFICIARIO, REVOCA_CONTRIBUTO, IMPORTO_DA_RECUPERARE, INTERESSI_LEGALI, SPESE_NOTIFICA, SANZIONI, TOTALE, IMPORTO_RECUPERATO, IRRECUPERABILE, DATA_IRRECUPERABILE, IMPORTO_IRRECUPERABILE, DATA_MODIFICA, RECUPERATO, STABILITA FROM REVOCA WHERE 1=1';
	IF (@IdRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REVOCA = @IdRevocaequalthis)'; set @lensql=@lensql+len(@IdRevocaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRevocaequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT',@IdRevocaequalthis , @IdProgettoequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_REVOCA, ID_PROGETTO, ID_IMPRESA, ORIGINE, NOTE, IMPORTO_REVOCA, NUMERO_ATTO, DATA_ATTO, RECUPERO_BENEFICIARIO, REVOCA_CONTRIBUTO, IMPORTO_DA_RECUPERARE, INTERESSI_LEGALI, SPESE_NOTIFICA, SANZIONI, TOTALE, IMPORTO_RECUPERATO, IRRECUPERABILE, DATA_IRRECUPERABILE, IMPORTO_IRRECUPERABILE, DATA_MODIFICA, RECUPERATO, STABILITA
		FROM REVOCA
		WHERE 
			((@IdRevocaequalthis IS NULL) OR ID_REVOCA = @IdRevocaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)