CREATE PROCEDURE [dbo].[ZGiustificativoXRegistroIrregolaritaFindFind]
(
	@IdGiustificativoXIrregolaritaequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@IdRegistroIrregolaritaequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_GIUSTIFICATIVO_X_IRREGOLARITA, ID_GIUSTIFICATIVO, ID_REGISTRO_IRREGOLARITA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM VGIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA WHERE 1=1';
	IF (@IdGiustificativoXIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO_X_IRREGOLARITA = @IdGiustificativoXIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdGiustificativoXIrregolaritaequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@IdRegistroIrregolaritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis)'; set @lensql=@lensql+len(@IdRegistroIrregolaritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdGiustificativoXIrregolaritaequalthis INT, @IdGiustificativoequalthis INT, @IdRegistroIrregolaritaequalthis INT, @IdProgettoequalthis INT',@IdGiustificativoXIrregolaritaequalthis , @IdGiustificativoequalthis , @IdRegistroIrregolaritaequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_GIUSTIFICATIVO_X_IRREGOLARITA, ID_GIUSTIFICATIVO, ID_REGISTRO_IRREGOLARITA, DATA_INSERIMENTO, CF_INSERIMENTO, DATA_MODIFICA, CF_MODIFICA, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM VGIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA
		WHERE 
			((@IdGiustificativoXIrregolaritaequalthis IS NULL) OR ID_GIUSTIFICATIVO_X_IRREGOLARITA = @IdGiustificativoXIrregolaritaequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@IdRegistroIrregolaritaequalthis IS NULL) OR ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolaritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativoXRegistroIrregolaritaFindFind';

