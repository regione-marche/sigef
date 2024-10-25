CREATE PROCEDURE [dbo].[ZPrioritaXProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdPrioritaequalthis INT, 
	@IdValoreequalthis INT, 
	@Valoreequalthis DECIMAL(18,2), 
	@DataValutazioneequalthis DATETIME, 
	@OperatoreValutazioneequalthis VARCHAR(255), 
	@ModificaManualeequalthis BIT, 
	@Punteggioequalthis DECIMAL(18,6), 
	@ValDataequalthis DATETIME, 
	@ValTestoequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO FROM vPRIORITA_X_PROGETTO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@OperatoreValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis)'; set @lensql=@lensql+len(@OperatoreValutazioneequalthis);end;
	IF (@ModificaManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MODIFICA_MANUALE = @ModificaManualeequalthis)'; set @lensql=@lensql+len(@ModificaManualeequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@ValDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_DATA = @ValDataequalthis)'; set @lensql=@lensql+len(@ValDataequalthis);end;
	IF (@ValTestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VAL_TESTO = @ValTestoequalthis)'; set @lensql=@lensql+len(@ValTestoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdPrioritaequalthis INT, @IdValoreequalthis INT, @Valoreequalthis DECIMAL(18,2), @DataValutazioneequalthis DATETIME, @OperatoreValutazioneequalthis VARCHAR(255), @ModificaManualeequalthis BIT, @Punteggioequalthis DECIMAL(18,6), @ValDataequalthis DATETIME, @ValTestoequalthis VARCHAR(500)',@IdProgettoequalthis , @IdPrioritaequalthis , @IdValoreequalthis , @Valoreequalthis , @DataValutazioneequalthis , @OperatoreValutazioneequalthis , @ModificaManualeequalthis , @Punteggioequalthis , @ValDataequalthis , @ValTestoequalthis ;
	else
		SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@OperatoreValutazioneequalthis IS NULL) OR OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis) AND 
			((@ModificaManualeequalthis IS NULL) OR MODIFICA_MANUALE = @ModificaManualeequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis) AND 
			((@ValDataequalthis IS NULL) OR VAL_DATA = @ValDataequalthis) AND 
			((@ValTestoequalthis IS NULL) OR VAL_TESTO = @ValTestoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaXProgettoFindSelect]
(
	@IdProgettoequalthis INT, 
	@IdPrioritaequalthis INT, 
	@IdValoreequalthis INT, 
	@Valoreequalthis DECIMAL(18,2), 
	@DataValutazioneequalthis DATETIME, 
	@OperatoreValutazioneequalthis VARCHAR(255), 
	@ModificaManualeequalthis BIT, 
	@Punteggioequalthis DECIMAL(18,6), 
	@ValDataequalthis DATETIME, 
	@ValTestoequalthis VARCHAR(500)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO FROM vPRIORITA_X_PROGETTO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALORE = @IdValoreequalthis)''; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VALORE = @Valoreequalthis)''; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)''; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@OperatoreValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis)''; set @lensql=@lensql+len(@OperatoreValutazioneequalthis);end;
	IF (@ModificaManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MODIFICA_MANUALE = @ModificaManualeequalthis)''; set @lensql=@lensql+len(@ModificaManualeequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PUNTEGGIO = @Punteggioequalthis)''; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@ValDataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VAL_DATA = @ValDataequalthis)''; set @lensql=@lensql+len(@ValDataequalthis);end;
	IF (@ValTestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (VAL_TESTO = @ValTestoequalthis)''; set @lensql=@lensql+len(@ValTestoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdPrioritaequalthis INT, @IdValoreequalthis INT, @Valoreequalthis DECIMAL(18,2), @DataValutazioneequalthis DATETIME, @OperatoreValutazioneequalthis VARCHAR(255), @ModificaManualeequalthis BIT, @Punteggioequalthis DECIMAL(18,6), @ValDataequalthis DATETIME, @ValTestoequalthis VARCHAR(500)'',@IdProgettoequalthis , @IdPrioritaequalthis , @IdValoreequalthis , @Valoreequalthis , @DataValutazioneequalthis , @OperatoreValutazioneequalthis , @ModificaManualeequalthis , @Punteggioequalthis , @ValDataequalthis , @ValTestoequalthis ;
	else
		SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@OperatoreValutazioneequalthis IS NULL) OR OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis) AND 
			((@ModificaManualeequal', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXProgettoFindSelect';

