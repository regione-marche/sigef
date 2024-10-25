CREATE PROCEDURE [dbo].[ZProgettoSegnatureFindFind]
(
	@IdProgettoequalthis INT, 
	@Operatoreequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@CodTipolikethis CHAR(3)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RIAPRI_DOMANDA, MOTIVAZIONE FROM vPROGETTO_SEGNATURE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@CodTipolikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO LIKE @CodTipolikethis)'; set @lensql=@lensql+len(@CodTipolikethis);end;
	set @sql = @sql + 'ORDER BY ID_PROGETTO, DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @Operatoreequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100), @CodTipolikethis CHAR(3)',@IdProgettoequalthis , @Operatoreequalthis , @Segnaturaequalthis , @CodTipolikethis ;
	else
		SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, RIAPRI_DOMANDA, MOTIVAZIONE
		FROM vPROGETTO_SEGNATURE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@CodTipolikethis IS NULL) OR COD_TIPO LIKE @CodTipolikethis)
		ORDER BY ID_PROGETTO, DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureFindFind]
(
	@IdProgettoequalthis INT, 
	@Operatoreequalthis VARCHAR(16), 
	@Segnaturaequalthis VARCHAR(100), 
	@CodTipolikethis CHAR(3)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, DATA_FINE_VALIDITA, RIAPRI_DOMANDA, MOTIVAZIONE FROM vPROGETTO_SEGNATURE WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@CodTipolikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO LIKE @CodTipolikethis)''; set @lensql=@lensql+len(@CodTipolikethis);end;
	set @sql = @sql + ''ORDER BY ID_PROGETTO,DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @Operatoreequalthis VARCHAR(16), @Segnaturaequalthis VARCHAR(100), @CodTipolikethis CHAR(3)'',@IdProgettoequalthis , @Operatoreequalthis , @Segnaturaequalthis , @CodTipolikethis ;
	else
		SELECT ID_PROGETTO, COD_TIPO, DATA, OPERATORE, SEGNATURA, TIPO_SEGNATURA, PROFILO, ENTE, ID_PROFILO, NOMINATIVO, COD_ENTE, PROVINCIA, DATA_FINE_VALIDITA, RIAPRI_DOMANDA, MOTIVAZIONE
		FROM vPROGETTO_SEGNATURE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@CodTipolikethis IS NULL) OR COD_TIPO LIKE @CodTipolikethis)
		ORDER BY ID_PROGETTO,DATA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureFindFind';

