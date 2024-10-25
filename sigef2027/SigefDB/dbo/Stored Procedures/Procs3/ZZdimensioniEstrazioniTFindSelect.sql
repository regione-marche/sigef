CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniTFindSelect]
(
	@IdEstrazioneequalthis INT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@CodPsrequalthis VARCHAR(255), 
	@Bloccatoequalthis BIT, 
	@TipoIndicatoriequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ESTRAZIONE, DATA_INIZIO, DATA_FINE, COD_PSR, BLOCCATO, TIPO_INDICATORI, ANNO FROM vzDIMENSIONI_ESTRAZIONI_T WHERE 1=1';
	IF (@IdEstrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ESTRAZIONE = @IdEstrazioneequalthis)'; set @lensql=@lensql+len(@IdEstrazioneequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PSR = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@Bloccatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BLOCCATO = @Bloccatoequalthis)'; set @lensql=@lensql+len(@Bloccatoequalthis);end;
	IF (@TipoIndicatoriequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_INDICATORI = @TipoIndicatoriequalthis)'; set @lensql=@lensql+len(@TipoIndicatoriequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdEstrazioneequalthis INT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @CodPsrequalthis VARCHAR(255), @Bloccatoequalthis BIT, @TipoIndicatoriequalthis VARCHAR(255)',@IdEstrazioneequalthis , @DataInizioequalthis , @DataFineequalthis , @CodPsrequalthis , @Bloccatoequalthis , @TipoIndicatoriequalthis ;
	else
		SELECT ID_ESTRAZIONE, DATA_INIZIO, DATA_FINE, COD_PSR, BLOCCATO, TIPO_INDICATORI, ANNO
		FROM vzDIMENSIONI_ESTRAZIONI_T
		WHERE 
			((@IdEstrazioneequalthis IS NULL) OR ID_ESTRAZIONE = @IdEstrazioneequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@CodPsrequalthis IS NULL) OR COD_PSR = @CodPsrequalthis) AND 
			((@Bloccatoequalthis IS NULL) OR BLOCCATO = @Bloccatoequalthis) AND 
			((@TipoIndicatoriequalthis IS NULL) OR TIPO_INDICATORI = @TipoIndicatoriequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniTFindSelect';

