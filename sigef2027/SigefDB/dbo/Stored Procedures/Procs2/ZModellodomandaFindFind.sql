CREATE PROCEDURE [dbo].[ZModellodomandaFindFind]
(
	@IdDomandaequalthis INT, 
	@IdBandoequalthis INT, 
	@Definitivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA, ID_BANDO, DEFINITIVO, OPERATORE, DENOMINAZIONE, DESCRIZIONE FROM MODELLO_DOMANDA WHERE 1=1';
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DEFINITIVO = @Definitivoequalthis)'; set @lensql=@lensql+len(@Definitivoequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaequalthis INT, @IdBandoequalthis INT, @Definitivoequalthis BIT',@IdDomandaequalthis , @IdBandoequalthis , @Definitivoequalthis ;
	else
		SELECT ID_DOMANDA, ID_BANDO, DEFINITIVO, OPERATORE, DENOMINAZIONE, DESCRIZIONE
		FROM MODELLO_DOMANDA
		WHERE 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Definitivoequalthis IS NULL) OR DEFINITIVO = @Definitivoequalthis)
		-- order by ecc.ecc.
