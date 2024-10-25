CREATE PROCEDURE ZVrnaEsitoConcessioneFindFind
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdRichiestaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, COD_STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, STATO_CONCESSIONE, ID_RICHIESTA, COR, DATA_ASSEGNAZIONE_COR, PUNTEGGIO FROM vRNA_ESITO_CONCESSIONE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdRichiestaequalthis VARCHAR(255)',@IdBandoequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdRichiestaequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, COD_STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, STATO_CONCESSIONE, ID_RICHIESTA, COR, DATA_ASSEGNAZIONE_COR, PUNTEGGIO
		FROM vRNA_ESITO_CONCESSIONE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis)
		

GO