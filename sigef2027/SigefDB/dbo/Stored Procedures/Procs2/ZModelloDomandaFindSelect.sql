create PROCEDURE [dbo].[ZModelloDomandaFindSelect]
(
	@IdDomandaequalthis INT, 
	@IdBandoequalthis INT, 
	@Definitivoequalthis BIT, 
	@Operatoreequalthis VARCHAR(16), 
	@Denominazioneequalthis VARCHAR(50), 
	@Descrizioneequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_DOMANDA, ID_BANDO, DEFINITIVO, OPERATORE, DENOMINAZIONE, DESCRIZIONE FROM MODELLO_DOMANDA WHERE 1=1';
	IF (@IdDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA = @IdDomandaequalthis)'; set @lensql=@lensql+len(@IdDomandaequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Definitivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DEFINITIVO = @Definitivoequalthis)'; set @lensql=@lensql+len(@Definitivoequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaequalthis INT, @IdBandoequalthis INT, @Definitivoequalthis BIT, @Operatoreequalthis VARCHAR(16), @Denominazioneequalthis VARCHAR(50), @Descrizioneequalthis VARCHAR(1000)',@IdDomandaequalthis , @IdBandoequalthis , @Definitivoequalthis , @Operatoreequalthis , @Denominazioneequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_DOMANDA, ID_BANDO, DEFINITIVO, OPERATORE, DENOMINAZIONE, DESCRIZIONE
		FROM MODELLO_DOMANDA
		WHERE 
			((@IdDomandaequalthis IS NULL) OR ID_DOMANDA = @IdDomandaequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Definitivoequalthis IS NULL) OR DEFINITIVO = @Definitivoequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		-- order by ecc.ecc.
