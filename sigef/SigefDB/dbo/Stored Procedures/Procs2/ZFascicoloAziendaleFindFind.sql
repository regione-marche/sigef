CREATE PROCEDURE [dbo].[ZFascicoloAziendaleFindFind]
(
	@IdFascicoloequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE, STATO_TERRITORIO, STATO_VETERINARIA, STATO_FABBRICATI, STATO_MANODOPERA, STATO_MACCHINARI FROM FASCICOLO_AZIENDALE WHERE 1=1';
	IF (@IdFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO = @IdFascicoloequalthis)'; set @lensql=@lensql+len(@IdFascicoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_FASCICOLO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFascicoloequalthis INT, @IdImpresaequalthis INT',@IdFascicoloequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE, STATO_TERRITORIO, STATO_VETERINARIA, STATO_FABBRICATI, STATO_MANODOPERA, STATO_MACCHINARI
		FROM FASCICOLO_AZIENDALE
		WHERE 
			((@IdFascicoloequalthis IS NULL) OR ID_FASCICOLO = @IdFascicoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)
		ORDER BY ID_FASCICOLO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFascicoloAziendaleFindFind]
(
	@IdFascicoloequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE FROM FASCICOLO_AZIENDALE WHERE 1=1'';
	IF (@IdFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_FASCICOLO = @IdFascicoloequalthis)''; set @lensql=@lensql+len(@IdFascicoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @sql = @sql + ''ORDER BY ID_FASCICOLO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdFascicoloequalthis INT, @IdImpresaequalthis INT'',@IdFascicoloequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE
		FROM FASCICOLO_AZIENDALE
		WHERE 
			((@IdFascicoloequalthis IS NULL) OR ID_FASCICOLO = @IdFascicoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)
		ORDER BY ID_FASCICOLO DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloAziendaleFindFind';

