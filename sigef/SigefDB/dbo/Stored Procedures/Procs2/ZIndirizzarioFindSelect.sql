CREATE PROCEDURE [dbo].[ZIndirizzarioFindSelect]
(
	@IdIndirizzarioequalthis INT, 
	@IdIndirizzoequalthis INT, 
	@IdPersonaequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoSedeequalthis VARCHAR(255), 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@FlagAttivoequalthis BIT, 
	@Telefonoequalthis VARCHAR(255), 
	@Faxequalthis VARCHAR(255), 
	@Emailequalthis VARCHAR(255), 
	@Pecequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, TIPO_AREA, PEC FROM vINDIRIZZARIO WHERE 1=1';
	IF (@IdIndirizzarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INDIRIZZARIO = @IdIndirizzarioequalthis)'; set @lensql=@lensql+len(@IdIndirizzarioequalthis);end;
	IF (@IdIndirizzoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INDIRIZZO = @IdIndirizzoequalthis)'; set @lensql=@lensql+len(@IdIndirizzoequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoSedeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SEDE = @CodTipoSedeequalthis)'; set @lensql=@lensql+len(@CodTipoSedeequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@FlagAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FLAG_ATTIVO = @FlagAttivoequalthis)'; set @lensql=@lensql+len(@FlagAttivoequalthis);end;
	IF (@Telefonoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TELEFONO = @Telefonoequalthis)'; set @lensql=@lensql+len(@Telefonoequalthis);end;
	IF (@Faxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FAX = @Faxequalthis)'; set @lensql=@lensql+len(@Faxequalthis);end;
	IF (@Emailequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (EMAIL = @Emailequalthis)'; set @lensql=@lensql+len(@Emailequalthis);end;
	IF (@Pecequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PEC = @Pecequalthis)'; set @lensql=@lensql+len(@Pecequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdIndirizzarioequalthis INT, @IdIndirizzoequalthis INT, @IdPersonaequalthis INT, @IdImpresaequalthis INT, @CodTipoSedeequalthis VARCHAR(255), @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @FlagAttivoequalthis BIT, @Telefonoequalthis VARCHAR(255), @Faxequalthis VARCHAR(255), @Emailequalthis VARCHAR(255), @Pecequalthis VARCHAR(255)',@IdIndirizzarioequalthis , @IdIndirizzoequalthis , @IdPersonaequalthis , @IdImpresaequalthis , @CodTipoSedeequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @FlagAttivoequalthis , @Telefonoequalthis , @Faxequalthis , @Emailequalthis , @Pecequalthis ;
	else
		SELECT ID_INDIRIZZARIO, ID_INDIRIZZO, ID_PERSONA, ID_IMPRESA, COD_TIPO_SEDE, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, FLAG_ATTIVO, TIPO_SEDE, VIA, LOCALITA, ID_COMUNE, TELEFONO, FAX, EMAIL, DENOMINAZIONE, COMUNE, CAP, ISTAT, SIGLA, PROVINCIA, COD_REGIONE, REGIONE, TIPO_AREA, PEC
		FROM vINDIRIZZARIO
		WHERE 
			((@IdIndirizzarioequalthis IS NULL) OR ID_INDIRIZZARIO = @IdIndirizzarioequalthis) AND 
			((@IdIndirizzoequalthis IS NULL) OR ID_INDIRIZZO = @IdIndirizzoequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoSedeequalthis IS NULL) OR COD_TIPO_SEDE = @CodTipoSedeequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@FlagAttivoequalthis IS NULL) OR FLAG_ATTIVO = @FlagAttivoequalthis) AND 
			((@Telefonoequalthis IS NULL) OR TELEFONO = @Telefonoequalthis) AND 
			((@Faxequalthis IS NULL) OR FAX = @Faxequalthis) AND 
			((@Emailequalthis IS NULL) OR EMAIL = @Emailequalthis) AND 
			((@Pecequalthis IS NULL) OR PEC = @Pecequalthis)
