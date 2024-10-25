CREATE PROCEDURE [dbo].[ZGiustificativiFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Numeroequalthis VARCHAR(255), 
	@Dataeqlessthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO = @Numeroequalthis)'; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA <= @Dataeqlessthanthis)'; set @lensql=@lensql+len(@Dataeqlessthanthis);end;
	set @sql = @sql + 'ORDER BY DATA, NUMERO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Numeroequalthis VARCHAR(255), @Dataeqlessthanthis DATETIME',@IdProgettoequalthis , @CodTipoequalthis , @Numeroequalthis , @Dataeqlessthanthis ;
	else
		SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM GIUSTIFICATIVI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataeqlessthanthis IS NULL) OR DATA <= @Dataeqlessthanthis)
		ORDER BY DATA, NUMERO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZGiustificativiFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Numeroequalthis VARCHAR(255), 
	@Dataeqlessthanthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE FROM GIUSTIFICATIVI WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Numeroequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO = @Numeroequalthis)''; set @lensql=@lensql+len(@Numeroequalthis);end;
	IF (@Dataeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA <= @Dataeqlessthanthis)''; set @lensql=@lensql+len(@Dataeqlessthanthis);end;
	set @sql = @sql + ''ORDER BY DATA, NUMERO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Numeroequalthis VARCHAR(255), @Dataeqlessthanthis DATETIME'',@IdProgettoequalthis , @CodTipoequalthis , @Numeroequalthis , @Dataeqlessthanthis ;
	else
		SELECT ID_GIUSTIFICATIVO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, IVA_NON_RECUPERABILE, ID_FILE, IN_INTEGRAZIONE, ID_FILE_MODIFICATO_INTEGRAZIONE
		FROM GIUSTIFICATIVI
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Numeroequalthis IS NULL) OR NUMERO = @Numeroequalthis) AND 
			((@Dataeqlessthanthis IS NULL) OR DATA <= @Dataeqlessthanthis)
		ORDER BY DATA, NUMERO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativiFindFind';

