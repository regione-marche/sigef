CREATE PROCEDURE [dbo].[ZProgettoSegnatureFindSelect]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@RiapriDomandaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RIAPRI_DOMANDA, MOTIVAZIONE FROM vPROGETTO_SEGNATURE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@RiapriDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIAPRI_DOMANDA = @RiapriDomandaequalthis)'; set @lensql=@lensql+len(@RiapriDomandaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodTipoequalthis CHAR(3), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100), @RiapriDomandaequalthis BIT',@IdProgettoequalthis , @CodTipoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @RiapriDomandaequalthis ;
	else
		SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RIAPRI_DOMANDA, MOTIVAZIONE
		FROM vPROGETTO_SEGNATURE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@RiapriDomandaequalthis IS NULL) OR RIAPRI_DOMANDA = @RiapriDomandaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureFindSelect]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@RiapriDomandaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, DATA_FINE_VALIDITA, RIAPRI_DOMANDA, MOTIVAZIONE FROM vPROGETTO_SEGNATURE WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@RiapriDomandaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RIAPRI_DOMANDA = @RiapriDomandaequalthis)''; set @lensql=@lensql+len(@RiapriDomandaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @CodTipoequalthis CHAR(3), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100), @RiapriDomandaequalthis BIT'',@IdProgettoequalthis , @CodTipoequalthis , @Dataequalthis , @Operatoreequalthis , @Segnaturaequalthis , @RiapriDomandaequalthis ;
	else
		SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, DATA_FINE_VALIDITA, RIAPRI_DOMANDA, MOTIVAZIONE
		FROM vPROGETTO_SEGNATURE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@RiapriDomandaequalthis IS NULL) OR RIAPRI_DOMANDA = @RiapriDomandaequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureFindSelect';

