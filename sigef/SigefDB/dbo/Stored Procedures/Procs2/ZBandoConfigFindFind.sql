CREATE PROCEDURE [dbo].[ZBandoConfigFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@CodMacrotipolikethis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@TipoAttivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE, VALORE_DESCRIZIONE FROM vBANDO_CONFIG WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodMacrotipolikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_MACROTIPO LIKE @CodMacrotipolikethis)'; set @lensql=@lensql+len(@CodMacrotipolikethis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@TipoAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_ATTIVO = @TipoAttivoequalthis)'; set @lensql=@lensql+len(@TipoAttivoequalthis);end;
	set @sql = @sql + 'ORDER BY ORDINE, DATA_INIZIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodTipoequalthis VARCHAR(255), @CodMacrotipolikethis VARCHAR(255), @Attivoequalthis BIT, @TipoAttivoequalthis BIT',@IdBandoequalthis , @CodTipoequalthis , @CodMacrotipolikethis , @Attivoequalthis , @TipoAttivoequalthis ;
	else
		SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE, VALORE_DESCRIZIONE
		FROM vBANDO_CONFIG
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodMacrotipolikethis IS NULL) OR COD_MACROTIPO LIKE @CodMacrotipolikethis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@TipoAttivoequalthis IS NULL) OR TIPO_ATTIVO = @TipoAttivoequalthis)
		ORDER BY ORDINE, DATA_INIZIO DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigFindFind]
(
	@IdBandoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@CodMacrotipolikethis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@TipoAttivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE FROM vBANDO_CONFIG WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@CodMacrotipolikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_MACROTIPO LIKE @CodMacrotipolikethis)''; set @lensql=@lensql+len(@CodMacrotipolikethis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@TipoAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (TIPO_ATTIVO = @TipoAttivoequalthis)''; set @lensql=@lensql+len(@TipoAttivoequalthis);end;
	set @sql = @sql + ''ORDER BY ORDINE, DATA_INIZIO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @CodTipoequalthis VARCHAR(255), @CodMacrotipolikethis VARCHAR(255), @Attivoequalthis BIT, @TipoAttivoequalthis BIT'',@IdBandoequalthis , @CodTipoequalthis , @CodMacrotipolikethis , @Attivoequalthis , @TipoAttivoequalthis ;
	else
		SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE
		FROM vBANDO_CONFIG
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@CodMacrotipolikethis IS NULL) OR COD_MACROTIPO LIKE @CodMacrotipolikethis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@TipoAttivoequalthis IS NULL) OR TIPO_ATTIVO = @TipoAttivoequalthis)
		ORDER BY ORDINE, DATA_INIZIO DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigFindFind';

