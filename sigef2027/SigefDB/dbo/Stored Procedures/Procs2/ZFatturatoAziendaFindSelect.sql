CREATE PROCEDURE [dbo].[ZFatturatoAziendaFindSelect]
(
	@IdFatturatoequalthis INT, 
	@IdImpresaequalthis INT, 
	@DataModificaequalthis DATETIME, 
	@Annoequalthis INT, 
	@Aliquotaequalthis DECIMAL(10,2), 
	@Importoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FATTURATO, ID_IMPRESA, DATA_MODIFICA, ANNO, ALIQUOTA, IMPORTO FROM FATTURATO_AZIENDA WHERE 1=1';
	IF (@IdFatturatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FATTURATO = @IdFatturatoequalthis)'; set @lensql=@lensql+len(@IdFatturatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@Aliquotaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ALIQUOTA = @Aliquotaequalthis)'; set @lensql=@lensql+len(@Aliquotaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFatturatoequalthis INT, @IdImpresaequalthis INT, @DataModificaequalthis DATETIME, @Annoequalthis INT, @Aliquotaequalthis DECIMAL(10,2), @Importoequalthis DECIMAL(18,2)',@IdFatturatoequalthis , @IdImpresaequalthis , @DataModificaequalthis , @Annoequalthis , @Aliquotaequalthis , @Importoequalthis ;
	else
		SELECT ID_FATTURATO, ID_IMPRESA, DATA_MODIFICA, ANNO, ALIQUOTA, IMPORTO
		FROM FATTURATO_AZIENDA
		WHERE 
			((@IdFatturatoequalthis IS NULL) OR ID_FATTURATO = @IdFatturatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@Aliquotaequalthis IS NULL) OR ALIQUOTA = @Aliquotaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFatturatoAziendaFindSelect]
(
	@IdFatturatoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdProdottoequalthis INT, 
	@IdUnitaMisuraequalthis INT, 
	@Annoequalthis INT, 
	@MetodoProduzioneequalthis VARCHAR(50), 
	@QuantitaVendutaequalthis DECIMAL(10,2), 
	@PrezzoUnitarioMedioequalthis DECIMAL(10,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_FATTURATO, ID_IMPRESA, ID_PRODOTTO, ID_UNITA_MISURA, ANNO, METODO_PRODUZIONE, QUANTITA_VENDUTA, PREZZO_UNITARIO_MEDIO FROM FATTURATO_AZIENDA WHERE 1=1'';
	IF (@IdFatturatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FATTURATO = @IdFatturatoequalthis)''; set @lensql=@lensql+len(@IdFatturatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdProdottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRODOTTO = @IdProdottoequalthis)''; set @lensql=@lensql+len(@IdProdottoequalthis);end;
	IF (@IdUnitaMisuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_UNITA_MISURA = @IdUnitaMisuraequalthis)''; set @lensql=@lensql+len(@IdUnitaMisuraequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO = @Annoequalthis)''; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@MetodoProduzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (METODO_PRODUZIONE = @MetodoProduzioneequalthis)''; set @lensql=@lensql+len(@MetodoProduzioneequalthis);end;
	IF (@QuantitaVendutaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUANTITA_VENDUTA = @QuantitaVendutaequalthis)''; set @lensql=@lensql+len(@QuantitaVendutaequalthis);end;
	IF (@PrezzoUnitarioMedioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PREZZO_UNITARIO_MEDIO = @PrezzoUnitarioMedioequalthis)''; set @lensql=@lensql+len(@PrezzoUnitarioMedioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFatturatoequalthis INT, @IdImpresaequalthis INT, @IdProdottoequalthis INT, @IdUnitaMisuraequalthis INT, @Annoequalthis INT, @MetodoProduzioneequalthis VARCHAR(50), @QuantitaVendutaequalthis DECIMAL(10,2), @PrezzoUnitarioMedioequalthis DECIMAL(10,2)'',@IdFatturatoequalthis , @IdImpresaequalthis , @IdProdottoequalthis , @IdUnitaMisuraequalthis , @Annoequalthis , @MetodoProduzioneequalthis , @QuantitaVendutaequalthis , @PrezzoUnitarioMedioequalthis ;
	else
		SELECT ID_FATTURATO, ID_IMPRESA, ID_PRODOTTO, ID_UNITA_MISURA, ANNO, METODO_PRODUZIONE, QUANTITA_VENDUTA, PREZZO_UNITARIO_MEDIO
		FROM FATTURATO_AZIENDA
		WHERE 
			((@IdFatturatoequalthis IS NULL) OR ID_FATTURATO = @IdFatturatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdProdottoequalthis IS NULL) OR ID_PRODOTTO = @IdProdottoequalthis) AND 
			((@IdUnitaMisuraequalthis IS NULL) OR ID_UNITA_MISURA = @IdUnitaMisuraequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@MetodoProduzioneequalthis IS NULL) OR METODO_PRODUZIONE = @MetodoProduzioneequalthis) AND 
			((@QuantitaVendutaequalthis IS NULL) OR QUANTITA_VENDUTA = @QuantitaVendutaequalthis) AND 
			((@PrezzoUnitarioMedioequalthis IS NULL) OR PREZZO_UNITARIO_MEDIO = @PrezzoUnitarioMedioequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFatturatoAziendaFindSelect';

