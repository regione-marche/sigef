CREATE PROCEDURE [dbo].[ZQuadriXDomandaFindSelect]
(
	@IdQuadroequalthis INT, 
	@IdDomandaequalthis INT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_QUADRO, ID_DOMANDA, ORDINE, DENOMINAZIONE, DESCRIZIONE, METODO_REPORT FROM vQUADRIDOMANDA WHERE 1=1';
	IF (@IdQuadroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_QUADRO = @IdQuadroequalthis)'; set @lensql=@lensql+len(@IdQuadroequalthis);end;
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdQuadroequalthis INT, @IdDomandaequalthis INT, @Ordineequalthis INT',@IdQuadroequalthis , @IdDomandaequalthis , @Ordineequalthis ;
	else
		SELECT ID_QUADRO, ID_DOMANDA, ORDINE, DENOMINAZIONE, DESCRIZIONE, METODO_REPORT
		FROM vQUADRIDOMANDA
		WHERE 
			((@IdQuadroequalthis IS NULL) OR ID_QUADRO = @IdQuadroequalthis) AND 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZQuadriXDomandaFindSelect';

