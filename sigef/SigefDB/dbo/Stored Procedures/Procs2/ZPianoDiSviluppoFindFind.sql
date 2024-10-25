CREATE PROCEDURE [dbo].[ZPianoDiSviluppoFindFind]
(
	@IdPianoequalthis INT, 
	@Annoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PIANO, ANNO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE FROM PIANO_DI_SVILUPPO WHERE 1=1';
	IF (@IdPianoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PIANO = @IdPianoequalthis)'; set @lensql=@lensql+len(@IdPianoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPianoequalthis INT, @Annoequalthis INT, @IdProgettoequalthis INT, @IdImpresaequalthis INT',@IdPianoequalthis , @Annoequalthis , @IdProgettoequalthis , @IdImpresaequalthis ;
	else
		SELECT ID_PIANO, ANNO, ID_IMPRESA, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE
		FROM PIANO_DI_SVILUPPO
		WHERE 
			((@IdPianoequalthis IS NULL) OR ID_PIANO = @IdPianoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPianoDiSviluppoFindFind]
(
	@IdPianoequalthis INT, 
	@Annoequalthis INT, 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PIANO, ANNO, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE FROM PIANO_DI_SVILUPPO WHERE 1=1'';
	IF (@IdPianoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PIANO = @IdPianoequalthis)''; set @lensql=@lensql+len(@IdPianoequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO = @Annoequalthis)''; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPianoequalthis INT, @Annoequalthis INT, @IdProgettoequalthis INT'',@IdPianoequalthis , @Annoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_PIANO, ANNO, ID_PROGETTO, COSTO_INVESTIMENTO, MEZZI_PROPRI, RISORSE_TERZI, CONTRIBUTI_PUBBLICI, SPESE_GESTIONE, RIMBORSO_DEBITO, ENTRATA_GESTIONE, ALTRE_COPERTURE
		FROM PIANO_DI_SVILUPPO
		WHERE 
			((@IdPianoequalthis IS NULL) OR ID_PIANO = @IdPianoequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoFindFind';

