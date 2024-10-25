CREATE PROCEDURE [dbo].[ZIndirizzarioFindFind]
(
	@IdIndirizzoequalthis INT, 
	@IdPersonaequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoSedeequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Siglaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, TIPO_AREA, PEC FROM vINDIRIZZARIO WHERE 1=1';
	IF (@IdIndirizzoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INDIRIZZO = @IdIndirizzoequalthis)'; set @lensql=@lensql+len(@IdIndirizzoequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoSedeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SEDE = @CodTipoSedeequalthis)'; set @lensql=@lensql+len(@CodTipoSedeequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Siglaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIGLA = @Siglaequalthis)'; set @lensql=@lensql+len(@Siglaequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_INIZIO_VALIDITA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIndirizzoequalthis INT, @IdPersonaequalthis INT, @IdImpresaequalthis INT, @CodTipoSedeequalthis VARCHAR(255), @IdComuneequalthis INT, @Siglaequalthis VARCHAR(255)',@IdIndirizzoequalthis , @IdPersonaequalthis , @IdImpresaequalthis , @CodTipoSedeequalthis , @IdComuneequalthis , @Siglaequalthis ;
	else
		SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, TIPO_AREA, PEC
		FROM vINDIRIZZARIO
		WHERE 
			((@IdIndirizzoequalthis IS NULL) OR ID_INDIRIZZO = @IdIndirizzoequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoSedeequalthis IS NULL) OR COD_TIPO_SEDE = @CodTipoSedeequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Siglaequalthis IS NULL) OR SIGLA = @Siglaequalthis)
		ORDER BY DATA_INIZIO_VALIDITA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIndirizzarioFindFind]
(
	@IdIndirizzarioequalthis INT, 
	@IdIndirizzoequalthis INT, 
	@IdPersonaequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoSedeequalthis CHAR(1), 
	@IdComuneequalthis INT, 
	@Siglaequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ID_PROVINCIA, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, ISTAT_PROV, TIPO_AREA, PEC FROM vINDIRIZZARIO WHERE 1=1'';
	IF (@IdIndirizzarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INDIRIZZARIO = @IdIndirizzarioequalthis)''; set @lensql=@lensql+len(@IdIndirizzarioequalthis);end;
	IF (@IdIndirizzoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INDIRIZZO = @IdIndirizzoequalthis)''; set @lensql=@lensql+len(@IdIndirizzoequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA = @IdPersonaequalthis)''; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoSedeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO_SEDE = @CodTipoSedeequalthis)''; set @lensql=@lensql+len(@CodTipoSedeequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_COMUNE = @IdComuneequalthis)''; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Siglaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SIGLA = @Siglaequalthis)''; set @lensql=@lensql+len(@Siglaequalthis);end;
	set @sql = @sql + ''ORDER BY DATA_INIZIO_VALIDITA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdIndirizzarioequalthis INT, @IdIndirizzoequalthis INT, @IdPersonaequalthis INT, @IdImpresaequalthis INT, @CodTipoSedeequalthis CHAR(1), @IdComuneequalthis INT, @Siglaequalthis CHAR(2)'',@IdIndirizzarioequalthis , @IdIndirizzoequalthis , @IdPersonaequalthis , @IdImpresaequalthis , @CodTipoSedeequalthis , @IdComuneequalthis , @Siglaequalthis ;
	else
		SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ID_PROVINCIA, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, ISTAT_PROV, TIPO_AREA, PEC
		FROM vINDIRIZZARIO
		WHERE 
			((@IdIndirizzarioequalthis IS NULL) OR ID_INDIRIZZARIO = @IdIndirizzarioequalthis) AND 
			((@IdIndirizzoequalthis IS NULL) OR ID_INDIRIZZO = @IdIndirizzoequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoSedeequalthis IS NULL) OR COD_TIPO_SEDE = @CodTipoSedeequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Siglaequalthis IS NULL) OR SIGLA = @Siglaequalthis)
		ORDER BY DATA_INIZIO_VALIDITA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIndirizzarioFindFind';

