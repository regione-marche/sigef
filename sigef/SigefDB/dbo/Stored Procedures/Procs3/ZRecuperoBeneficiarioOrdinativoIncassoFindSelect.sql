CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioOrdinativoIncassoFindSelect]
(
	@IdOrdinativoIncassoequalthis INT, 
	@IdRecuperoBeneficiarioequalthis INT, 
	@IdFileMandatoequalthis INT, 
	@Numeroequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Importoequalthis DECIMAL(15,2), 
	@Quietanzaequalthis DECIMAL(15,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ORDINATIVO_INCASSO, ID_RECUPERO_BENEFICIARIO, ID_FILE_MANDATO, NUMERO, DATA, IMPORTO, QUIETANZA FROM RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO WHERE 1=1';
	IF (@IdOrdinativoIncassoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ORDINATIVO_INCASSO = @IdOrdinativoIncassoequalthis)'; set @lensql=@lensql+len(@IdOrdinativoIncassoequalthis);end;
	IF (@IdRecuperoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis)'; set @lensql=@lensql+len(@IdRecuperoBeneficiarioequalthis);end;
	IF (@IdFileMandatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FILE_MANDATO = @IdFileMandatoequalthis)'; set @lensql=@lensql+len(@IdFileMandatoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	IF (@Quietanzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUIETANZA = @Quietanzaequalthis)'; set @lensql=@lensql+len(@Quietanzaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdOrdinativoIncassoequalthis INT, @IdRecuperoBeneficiarioequalthis INT, @IdFileMandatoequalthis INT, @Numeroequalthis VARCHAR(255), @Dataequalthis DATETIME, @Importoequalthis DECIMAL(15,2), @Quietanzaequalthis DECIMAL(15,2)',@IdOrdinativoIncassoequalthis , @IdRecuperoBeneficiarioequalthis , @IdFileMandatoequalthis , @Numeroequalthis , @Dataequalthis , @Importoequalthis , @Quietanzaequalthis ;
	else
		SELECT ID_ORDINATIVO_INCASSO, ID_RECUPERO_BENEFICIARIO, ID_FILE_MANDATO, NUMERO, DATA, IMPORTO, QUIETANZA
		FROM RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO
		WHERE 
			((@IdOrdinativoIncassoequalthis IS NULL) OR ID_ORDINATIVO_INCASSO = @IdOrdinativoIncassoequalthis) AND 
			((@IdRecuperoBeneficiarioequalthis IS NULL) OR ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis) AND 
			((@IdFileMandatoequalthis IS NULL) OR ID_FILE_MANDATO = @IdFileMandatoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis) AND 
			((@Quietanzaequalthis IS NULL) OR QUIETANZA = @Quietanzaequalthis)