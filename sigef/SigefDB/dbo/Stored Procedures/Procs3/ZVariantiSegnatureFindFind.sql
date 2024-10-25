CREATE PROCEDURE [dbo].[ZVariantiSegnatureFindFind]
(
	@IdVarianteequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@RiapriVarianteequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE, RIAPRI_VARIANTE FROM VARIANTI_SEGNATURE WHERE 1=1';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VARIANTE = @IdVarianteequalthis)'; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@RiapriVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RIAPRI_VARIANTE = @RiapriVarianteequalthis)'; set @lensql=@lensql+len(@RiapriVarianteequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVarianteequalthis INT, @CodTipoequalthis CHAR(3), @RiapriVarianteequalthis BIT',@IdVarianteequalthis , @CodTipoequalthis , @RiapriVarianteequalthis ;
	else
		SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE, RIAPRI_VARIANTE
		FROM VARIANTI_SEGNATURE
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@RiapriVarianteequalthis IS NULL) OR RIAPRI_VARIANTE = @RiapriVarianteequalthis)
		ORDER BY DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiSegnatureFindFind]
(
	@IdVarianteequalthis INT, 
	@CodTipoequalthis CHAR(3)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE FROM VARIANTI_SEGNATURE WHERE 1=1'';
	IF (@IdVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VARIANTE = @IdVarianteequalthis)''; set @lensql=@lensql+len(@IdVarianteequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdVarianteequalthis INT, @CodTipoequalthis CHAR(3)'',@IdVarianteequalthis , @CodTipoequalthis ;
	else
		SELECT ID_VARIANTE, COD_TIPO, SEGNATURA, DATA, OPERATORE, MOTIVAZIONE
		FROM VARIANTI_SEGNATURE
		WHERE 
			((@IdVarianteequalthis IS NULL) OR ID_VARIANTE = @IdVarianteequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiSegnatureFindFind';

