CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioFindSelect]
(
	@IdPrioritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Punteggioequalthis DECIMAL(10,6), 
	@DataValutazioneequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(255), 
	@ModificaManualeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vGRADUATORIA_PROGETTI_DETTAGLIO WHERE 1=1';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@ModificaManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MODIFICA_MANUALE = @ModificaManualeequalthis)'; set @lensql=@lensql+len(@ModificaManualeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @IdProgettoequalthis INT, @Punteggioequalthis DECIMAL(10,6), @DataValutazioneequalthis DATETIME, @Operatoreequalthis VARCHAR(255), @ModificaManualeequalthis BIT',@IdPrioritaequalthis , @IdProgettoequalthis , @Punteggioequalthis , @DataValutazioneequalthis , @Operatoreequalthis , @ModificaManualeequalthis ;
	else
		SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vGRADUATORIA_PROGETTI_DETTAGLIO
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@ModificaManualeequalthis IS NULL) OR MODIFICA_MANUALE = @ModificaManualeequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioFindSelect]
(
	@IdPrioritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@Punteggioequalthis DECIMAL(10,6), 
	@DataValutazioneequalthis DATETIME, 
	@Operatoreequalthis VARCHAR(16), 
	@ModificaManualeequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vGRADUATORIA_PROGETTI_DETTAGLIO WHERE 1=1'';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PUNTEGGIO = @Punteggioequalthis)''; set @lensql=@lensql+len(@Punteggioequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)''; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (OPERATORE = @Operatoreequalthis)''; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@ModificaManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MODIFICA_MANUALE = @ModificaManualeequalthis)''; set @lensql=@lensql+len(@ModificaManualeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @IdProgettoequalthis INT, @Punteggioequalthis DECIMAL(10,6), @DataValutazioneequalthis DATETIME, @Operatoreequalthis VARCHAR(16), @ModificaManualeequalthis BIT'',@IdPrioritaequalthis , @IdProgettoequalthis , @Punteggioequalthis , @DataValutazioneequalthis , @Operatoreequalthis , @ModificaManualeequalthis ;
	else
		SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vGRADUATORIA_PROGETTI_DETTAGLIO
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@ModificaManualeequalthis IS NULL) OR MODIFICA_MANUALE = @ModificaManualeequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiDettaglioFindSelect';

