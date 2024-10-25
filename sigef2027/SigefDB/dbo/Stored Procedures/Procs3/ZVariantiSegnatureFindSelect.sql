CREATE PROCEDURE [dbo].[ZVariantiSegnatureFindSelect]
(
	@IdVarianteequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Segnaturaequalthis VARCHAR(100), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@RiapriVarianteequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE, RIAPRI_VARIANTE FROM VARIANTI_SEGNATURE WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@RiapriVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIAPRI_VARIANTE = @RiapriVarianteequalthis)'; set @lensql=@lensql+len(@RiapriVarianteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @CodTipoequalthis CHAR(3), @Segnaturaequalthis VARCHAR(100), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @RiapriVarianteequalthis BIT',@IdVarianteequalthis , @CodTipoequalthis , @Segnaturaequalthis , @Dataequalthis , @Operatoreequalthis , @RiapriVarianteequalthis ;
	else
		SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE, RIAPRI_VARIANTE
		FROM VARIANTI_SEGNATURE
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@RiapriVarianteequalthis IS NULL) OR RIAPRI_VARIANTE = @RiapriVarianteequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiSegnatureFindSelect]
(
	@IdVarianteequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@Segnaturaequalthis VARCHAR(100), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE FROM VARIANTI_SEGNATURE WHERE 1=1'';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SEGNATURA = @Segnaturaequalthis)''; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA = @Dataequalthis)''; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdVarianteequalthis INT, @CodTipoequalthis CHAR(3), @Segnaturaequalthis VARCHAR(100), @Dataequalthis DATETIME, @Operatoreequalthis VARCHAR(16)'',@IdVarianteequalthis , @CodTipoequalthis , @Segnaturaequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE
		FROM VARIANTI_SEGNATURE
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiSegnatureFindSelect';

