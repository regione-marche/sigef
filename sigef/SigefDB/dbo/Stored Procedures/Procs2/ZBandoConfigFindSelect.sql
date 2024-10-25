CREATE PROCEDURE [dbo].[ZBandoConfigFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Valoreequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE, VALORE_DESCRIZIONE FROM vBANDO_CONFIG WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @CodTipoequalthis VARCHAR(255), @Valoreequalthis VARCHAR(255), @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT',@Idequalthis , @IdBandoequalthis , @CodTipoequalthis , @Valoreequalthis , @Attivoequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE, VALORE_DESCRIZIONE
		FROM vBANDO_CONFIG
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Valoreequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE FROM vBANDO_CONFIG WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE = @Valoreequalthis)''; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)''; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_FINE = @OperatoreFineequalthis)''; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdBandoequalthis INT, @CodTipoequalthis VARCHAR(255), @Valoreequalthis VARCHAR(255), @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT'',@Idequalthis , @IdBandoequalthis , @CodTipoequalthis , @Valoreequalthis , @Attivoequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, ID_BANDO, COD_TIPO, VALORE, ATTIVO, DATA_INIZIO, OPERATORE_INIZIO, DATA_FINE, OPERATORE_FINE, COD_MACROTIPO, FORMATO, DESCRIZIONE, TIPO_ATTIVO, ORDINE
		FROM vBANDO_CONFIG
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigFindSelect';

