CREATE PROCEDURE [dbo].[ZImpresaAggregazioneFindSelect]
(
	@Idequalthis INT, 
	@IdAggregazioneequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Percentualeequalthis DECIMAL(10,4), 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@Attivoequalthis BIT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE, COD_ATECO2007 FROM vIMPRESA_AGGREGAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_AGGREGAZIONE = @IdAggregazioneequalthis)'; set @lensql=@lensql+len(@IdAggregazioneequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO = @CodRuoloequalthis)'; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Percentualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PERCENTUALE = @Percentualeequalthis)'; set @lensql=@lensql+len(@Percentualeequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)'; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_FINE = @OperatoreFineequalthis)'; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdAggregazioneequalthis INT, @CodRuoloequalthis VARCHAR(255), @IdImpresaequalthis INT, @Percentualeequalthis DECIMAL(10,4), @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @Attivoequalthis BIT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT',@Idequalthis , @IdAggregazioneequalthis , @CodRuoloequalthis , @IdImpresaequalthis , @Percentualeequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @Attivoequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE, COD_ATECO2007
		FROM vIMPRESA_AGGREGAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdAggregazioneequalthis IS NULL) OR ID_AGGREGAZIONE = @IdAggregazioneequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Percentualeequalthis IS NULL) OR PERCENTUALE = @Percentualeequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaAggregazioneFindSelect]
(
	@Idequalthis INT, 
	@IdAggregazioneequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Percentualeequalthis DECIMAL(10,4), 
	@DataInizioequalthis DATETIME, 
	@OperatoreInizioequalthis INT, 
	@Attivoequalthis BIT, 
	@DataFineequalthis DATETIME, 
	@OperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE FROM vIMPRESA_AGGREGAZIONE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_AGGREGAZIONE = @IdAggregazioneequalthis)''; set @lensql=@lensql+len(@IdAggregazioneequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO = @CodRuoloequalthis)''; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Percentualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PERCENTUALE = @Percentualeequalthis)''; set @lensql=@lensql+len(@Percentualeequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@OperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_INIZIO = @OperatoreInizioequalthis)''; set @lensql=@lensql+len(@OperatoreInizioequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@OperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_FINE = @OperatoreFineequalthis)''; set @lensql=@lensql+len(@OperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdAggregazioneequalthis INT, @CodRuoloequalthis VARCHAR(255), @IdImpresaequalthis INT, @Percentualeequalthis DECIMAL(10,4), @DataInizioequalthis DATETIME, @OperatoreInizioequalthis INT, @Attivoequalthis BIT, @DataFineequalthis DATETIME, @OperatoreFineequalthis INT'',@Idequalthis , @IdAggregazioneequalthis , @CodRuoloequalthis , @IdImpresaequalthis , @Percentualeequalthis , @DataInizioequalthis , @OperatoreInizioequalthis , @Attivoequalthis , @DataFineequalthis , @OperatoreFineequalthis ;
	else
		SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE
		FROM vIMPRESA_AGGREGAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdAggregazioneequalthis IS NULL) OR ID_AGGREGAZIONE = @IdAggregazioneequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Percentualeequalthis IS NULL) OR PERCENTUALE = @Percentualeequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@OperatoreInizioequalthis IS NULL) OR OPERATORE_INIZIO = @OperatoreInizioequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@OperatoreFineequalthis IS NULL) OR OPERATORE_FINE = @OperatoreFineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaAggregazioneFindSelect';

