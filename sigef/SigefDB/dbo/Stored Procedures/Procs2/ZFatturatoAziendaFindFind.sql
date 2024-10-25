CREATE PROCEDURE [dbo].[ZFatturatoAziendaFindFind]
(
	@IdFatturatoequalthis INT, 
	@IdImpresaequalthis INT, 
	@Annoequalthis INT, 
	@Aliquotaequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FATTURATO, ID_IMPRESA, DATA_MODIFICA, ANNO, ALIQUOTA, IMPORTO FROM FATTURATO_AZIENDA WHERE 1=1';
	IF (@IdFatturatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FATTURATO = @IdFatturatoequalthis)'; set @lensql=@lensql+len(@IdFatturatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@Aliquotaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ALIQUOTA = @Aliquotaequalthis)'; set @lensql=@lensql+len(@Aliquotaequalthis);end;
	set @sql = @sql + 'ORDER BY ANNO DESC , ALIQUOTA DESC ';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFatturatoequalthis INT, @IdImpresaequalthis INT, @Annoequalthis INT, @Aliquotaequalthis DECIMAL(10,2)',@IdFatturatoequalthis , @IdImpresaequalthis , @Annoequalthis , @Aliquotaequalthis ;
	else
		SELECT ID_FATTURATO, ID_IMPRESA, DATA_MODIFICA, ANNO, ALIQUOTA, IMPORTO
		FROM FATTURATO_AZIENDA
		WHERE 
			((@IdFatturatoequalthis IS NULL) OR ID_FATTURATO = @IdFatturatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@Aliquotaequalthis IS NULL) OR ALIQUOTA = @Aliquotaequalthis)
		ORDER BY ANNO DESC, ALIQUOTA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFatturatoAziendaFindFind]
(
	@IdFatturatoequalthis INT, 
	@IdImpresaequalthis INT, 
	@Annoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_FATTURATO, ID_IMPRESA, ID_PRODOTTO, ID_UNITA_MISURA, ANNO, METODO_PRODUZIONE, QUANTITA_VENDUTA, PREZZO_UNITARIO_MEDIO FROM FATTURATO_AZIENDA WHERE 1=1'';
	IF (@IdFatturatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FATTURATO = @IdFatturatoequalthis)''; set @lensql=@lensql+len(@IdFatturatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO = @Annoequalthis)''; set @lensql=@lensql+len(@Annoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFatturatoequalthis INT, @IdImpresaequalthis INT, @Annoequalthis INT'',@IdFatturatoequalthis , @IdImpresaequalthis , @Annoequalthis ;
	else
		SELECT ID_FATTURATO, ID_IMPRESA, ID_PRODOTTO, ID_UNITA_MISURA, ANNO, METODO_PRODUZIONE, QUANTITA_VENDUTA, PREZZO_UNITARIO_MEDIO
		FROM FATTURATO_AZIENDA
		WHERE 
			((@IdFatturatoequalthis IS NULL) OR ID_FATTURATO = @IdFatturatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFatturatoAziendaFindFind';

