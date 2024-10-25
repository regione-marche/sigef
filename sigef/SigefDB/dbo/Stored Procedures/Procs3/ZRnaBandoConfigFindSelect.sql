CREATE PROCEDURE ZRnaBandoConfigFindSelect
(
	@IdRnaBandoConfigequalthis INT, 
	@IdBandoequalthis INT, 
	@CodBandoRnaequalthis INT, 
	@DataPrevistaConcessioneequalthis DATETIME, 
	@Cumulabilitaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_BANDO_CONFIG, ID_BANDO, COD_BANDO_RNA, DATA_PREVISTA_CONCESSIONE, CUMULABILITA FROM RNA_BANDO_CONFIG WHERE 1=1';
	IF (@IdRnaBandoConfigequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_BANDO_CONFIG = @IdRnaBandoConfigequalthis)'; set @lensql=@lensql+len(@IdRnaBandoConfigequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodBandoRnaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_BANDO_RNA = @CodBandoRnaequalthis)'; set @lensql=@lensql+len(@CodBandoRnaequalthis);end;
	IF (@DataPrevistaConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_PREVISTA_CONCESSIONE = @DataPrevistaConcessioneequalthis)'; set @lensql=@lensql+len(@DataPrevistaConcessioneequalthis);end;
	IF (@Cumulabilitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUMULABILITA = @Cumulabilitaequalthis)'; set @lensql=@lensql+len(@Cumulabilitaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaBandoConfigequalthis INT, @IdBandoequalthis INT, @CodBandoRnaequalthis INT, @DataPrevistaConcessioneequalthis DATETIME, @Cumulabilitaequalthis VARCHAR(255)',@IdRnaBandoConfigequalthis , @IdBandoequalthis , @CodBandoRnaequalthis , @DataPrevistaConcessioneequalthis , @Cumulabilitaequalthis ;
	else
		SELECT ID_RNA_BANDO_CONFIG, ID_BANDO, COD_BANDO_RNA, DATA_PREVISTA_CONCESSIONE, CUMULABILITA
		FROM RNA_BANDO_CONFIG
		WHERE 
			((@IdRnaBandoConfigequalthis IS NULL) OR ID_RNA_BANDO_CONFIG = @IdRnaBandoConfigequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodBandoRnaequalthis IS NULL) OR COD_BANDO_RNA = @CodBandoRnaequalthis) AND 
			((@DataPrevistaConcessioneequalthis IS NULL) OR DATA_PREVISTA_CONCESSIONE = @DataPrevistaConcessioneequalthis) AND 
			((@Cumulabilitaequalthis IS NULL) OR CUMULABILITA = @Cumulabilitaequalthis)
		

GO