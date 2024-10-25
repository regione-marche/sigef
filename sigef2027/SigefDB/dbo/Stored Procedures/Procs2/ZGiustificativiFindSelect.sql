CREATE PROCEDURE [dbo].[ZGiustificativiFindSelect]
(
	@IdGiustificativoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@NumeroDoctrasportoequalthis VARCHAR(255), 
	@DataDoctrasportoequalthis DATETIME, 
	@Imponibileequalthis DECIMAL(18,2), 
	@Ivaequalthis DECIMAL(18,2), 
	@AltriOneriequalthis DECIMAL(18,2), 
	@Descrizioneequalthis VARCHAR(255), 
	@CfFornitoreequalthis VARCHAR(255), 
	@DescrizioneFornitoreequalthis VARCHAR(255), 
	@IvaNonRecuperabileequalthis BIT, 
	@IdFileequalthis INT, 
	@InIntegrazioneequalthis BIT, 
	@IdFileModificatoIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1';
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@NumeroDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_DOCTRASPORTO = @NumeroDoctrasportoequalthis)'; set @lensql=@lensql+len(@NumeroDoctrasportoequalthis);end;
	IF (@DataDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DOCTRASPORTO = @DataDoctrasportoequalthis)'; set @lensql=@lensql+len(@DataDoctrasportoequalthis);end;
	IF (@Imponibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPONIBILE = @Imponibileequalthis)'; set @lensql=@lensql+len(@Imponibileequalthis);end;
	IF (@Ivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA = @Ivaequalthis)'; set @lensql=@lensql+len(@Ivaequalthis);end;
	IF (@AltriOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ALTRI_ONERI = @AltriOneriequalthis)'; set @lensql=@lensql+len(@AltriOneriequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CfFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_FORNITORE = @CfFornitoreequalthis)'; set @lensql=@lensql+len(@CfFornitoreequalthis);end;
	IF (@DescrizioneFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_FORNITORE = @DescrizioneFornitoreequalthis)'; set @lensql=@lensql+len(@DescrizioneFornitoreequalthis);end;
	IF (@IvaNonRecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IVA_NON_RECUPERABILE = @IvaNonRecuperabileequalthis)'; set @lensql=@lensql+len(@IvaNonRecuperabileequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE = @IdFileequalthis)'; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@IdFileModificatoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)'; set @lensql=@lensql+len(@IdFileModificatoIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdGiustificativoequalthis INT, @IdProgettoequalthis INT, @Numeroequalthis VARCHAR(255), @CodTipoequalthis VARCHAR(255), @Dataequalthis DATETIME, @NumeroDoctrasportoequalthis VARCHAR(255), @DataDoctrasportoequalthis DATETIME, @Imponibileequalthis DECIMAL(18,2), @Ivaequalthis DECIMAL(18,2), @AltriOneriequalthis DECIMAL(18,2), @Descrizioneequalthis VARCHAR(255), @CfFornitoreequalthis VARCHAR(255), @DescrizioneFornitoreequalthis VARCHAR(255), @IvaNonRecuperabileequalthis BIT, @IdFileequalthis INT, @InIntegrazioneequalthis BIT, @IdFileModificatoIntegrazioneequalthis BIT',@IdGiustificativoequalthis , @IdProgettoequalthis , @Numeroequalthis , @CodTipoequalthis , @Dataequalthis , @NumeroDoctrasportoequalthis , @DataDoctrasportoequalthis , @Imponibileequalthis , @Ivaequalthis , @AltriOneriequalthis , @Descrizioneequalthis , @CfFornitoreequalthis , @DescrizioneFornitoreequalthis , @IvaNonRecuperabileequalthis , @IdFileequalthis , @InIntegrazioneequalthis , @IdFileModificatoIntegrazioneequalthis ;
	else
		SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM GIUSTIFICATIVI
		WHERE 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@NumeroDoctrasportoequalthis IS NULL) OR NUMERO_DOCTRASPORTO = @NumeroDoctrasportoequalthis) AND 
			((@DataDoctrasportoequalthis IS NULL) OR DATA_DOCTRASPORTO = @DataDoctrasportoequalthis) AND 
			((@Imponibileequalthis IS NULL) OR IMPONIBILE = @Imponibileequalthis) AND 
			((@Ivaequalthis IS NULL) OR IVA = @Ivaequalthis) AND 
			((@AltriOneriequalthis IS NULL) OR ALTRI_ONERI = @AltriOneriequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@CfFornitoreequalthis IS NULL) OR CF_FORNITORE = @CfFornitoreequalthis) AND 
			((@DescrizioneFornitoreequalthis IS NULL) OR DESCRIZIONE_FORNITORE = @DescrizioneFornitoreequalthis) AND 
			((@IvaNonRecuperabileequalthis IS NULL) OR IVA_NON_RECUPERABILE = @IvaNonRecuperabileequalthis) AND 
			((@IdFileequalthis IS NULL) OR ID_FILE = @IdFileequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@IdFileModificatoIntegrazioneequalthis IS NULL) OR ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZGiustificativiFindSelect]
(
	@IdGiustificativoequalthis INT, 
	@IdProgettoequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@CodTipoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@NumeroDoctrasportoequalthis VARCHAR(255), 
	@DataDoctrasportoequalthis DATETIME, 
	@Imponibileequalthis DECIMAL(18,2), 
	@Ivaequalthis DECIMAL(18,2), 
	@AltriOneriequalthis DECIMAL(18,2), 
	@Descrizioneequalthis VARCHAR(255), 
	@CfFornitoreequalthis VARCHAR(255), 
	@DescrizioneFornitoreequalthis VARCHAR(255), 
	@IvaNonRecuperabileequalthis BIT, 
	@IdFileequalthis INT, 
	@InIntegrazioneequalthis BIT, 
	@IdFileModificatoIntegrazioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1'';
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)''; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO = @Numeroequalthis)''; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@NumeroDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_DOCTRASPORTO = @NumeroDoctrasportoequalthis)''; set @lensql=@lensql+len(@NumeroDoctrasportoequalthis);end;
	IF (@DataDoctrasportoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_DOCTRASPORTO = @DataDoctrasportoequalthis)''; set @lensql=@lensql+len(@DataDoctrasportoequalthis);end;
	IF (@Imponibileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPONIBILE = @Imponibileequalthis)''; set @lensql=@lensql+len(@Imponibileequalthis);end;
	IF (@Ivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IVA = @Ivaequalthis)''; set @lensql=@lensql+len(@Ivaequalthis);end;
	IF (@AltriOneriequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ALTRI_ONERI = @AltriOneriequalthis)''; set @lensql=@lensql+len(@AltriOneriequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@CfFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_FORNITORE = @CfFornitoreequalthis)''; set @lensql=@lensql+len(@CfFornitoreequalthis);end;
	IF (@DescrizioneFornitoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE_FORNITORE = @DescrizioneFornitoreequalthis)''; set @lensql=@lensql+len(@DescrizioneFornitoreequalthis);end;
	IF (@IvaNonRecuperabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IVA_NON_RECUPERABILE = @IvaNonRecuperabileequalthis)''; set @lensql=@lensql+len(@IvaNonRecuperabileequalthis);end;
	IF (@IdFileequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE = @IdFileequalthis)''; set @lensql=@lensql+len(@IdFileequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)''; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@IdFileModificatoIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazioneequalthis)''; set @lensql=@lensql+len(@IdFileModificatoIntegrazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_exe', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativiFindSelect';

