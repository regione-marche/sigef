CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioFindFind]
(
	@IdRecuperoBeneficiarioequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdIrregolaritaequalthis INT, 
	@IdRevocaequalthis INT, 
	@IdErroreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RECUPERO_BENEFICIARIO, ID_PROGETTO, ID_IMPRESA, ORIGINE, ID_IRREGOLARITA, ID_REVOCA, ID_ERRORE, DECRETO_RECUPERO_NUMERO, DECRETO_RECUPERO_DATA, DATA_AVVIO_RECUPERO, SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO, CONTRIBUTO, INTERESSI, SPESE, SANZIONI, TOTALE_DA_RECUPERARE, NOTE, DEFINITIVO, IMPORTO_RECUPERATO, IMPORTO_IRRECUPERABILE FROM RECUPERO_BENEFICIARIO WHERE 1=1';
	IF (@IdRecuperoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis)'; set @lensql=@lensql+len(@IdRecuperoBeneficiarioequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IRREGOLARITA = @IdIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdIrregolaritaequalthis);end;
	IF (@IdRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REVOCA = @IdRevocaequalthis)'; set @lensql=@lensql+len(@IdRevocaequalthis);end;
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRecuperoBeneficiarioequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT, @IdIrregolaritaequalthis INT, @IdRevocaequalthis INT, @IdErroreequalthis INT',@IdRecuperoBeneficiarioequalthis , @IdProgettoequalthis , @IdImpresaequalthis , @IdIrregolaritaequalthis , @IdRevocaequalthis , @IdErroreequalthis ;
	else
		SELECT ID_RECUPERO_BENEFICIARIO, ID_PROGETTO, ID_IMPRESA, ORIGINE, ID_IRREGOLARITA, ID_REVOCA, ID_ERRORE, DECRETO_RECUPERO_NUMERO, DECRETO_RECUPERO_DATA, DATA_AVVIO_RECUPERO, SEGNATURA_PALEO_COMUNICAZIONE_BENEFICIARIO, CONTRIBUTO, INTERESSI, SPESE, SANZIONI, TOTALE_DA_RECUPERARE, NOTE, DEFINITIVO, IMPORTO_RECUPERATO, IMPORTO_IRRECUPERABILE
		FROM RECUPERO_BENEFICIARIO
		WHERE 
			((@IdRecuperoBeneficiarioequalthis IS NULL) OR ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiarioequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdIrregolaritaequalthis IS NULL) OR ID_IRREGOLARITA = @IdIrregolaritaequalthis) AND 
			((@IdRevocaequalthis IS NULL) OR ID_REVOCA = @IdRevocaequalthis) AND 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis)