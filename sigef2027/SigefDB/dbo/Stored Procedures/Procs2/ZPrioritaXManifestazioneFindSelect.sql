create PROCEDURE [dbo].[ZPrioritaXManifestazioneFindSelect]
(
	@IdManifestazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@IdValoreequalthis INT, 
	@Valoreequalthis DECIMAL(18,2), 
	@DataValutazioneequalthis DATETIME, 
	@OperatoreValutazioneequalthis VARCHAR(16), 
	@ModificaManualeequalthis BIT, 
	@Punteggioequalthis DECIMAL(18,6)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, ID_PRIORITA, ID_VALORE, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PUNTEGGIO, VALORE_DESC, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vPRIORITA_X_MANIFESTAZIONE WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdValoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALORE = @IdValoreequalthis)'; set @lensql=@lensql+len(@IdValoreequalthis);end;
	IF (@Valoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (VALORE = @Valoreequalthis)'; set @lensql=@lensql+len(@Valoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@OperatoreValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis)'; set @lensql=@lensql+len(@OperatoreValutazioneequalthis);end;
	IF (@ModificaManualeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MODIFICA_MANUALE = @ModificaManualeequalthis)'; set @lensql=@lensql+len(@ModificaManualeequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @IdPrioritaequalthis INT, @IdValoreequalthis INT, @Valoreequalthis DECIMAL(18,2), @DataValutazioneequalthis DATETIME, @OperatoreValutazioneequalthis VARCHAR(16), @ModificaManualeequalthis BIT, @Punteggioequalthis DECIMAL(18,6)',@IdManifestazioneequalthis , @IdPrioritaequalthis , @IdValoreequalthis , @Valoreequalthis , @DataValutazioneequalthis , @OperatoreValutazioneequalthis , @ModificaManualeequalthis , @Punteggioequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_PRIORITA, ID_VALORE, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PUNTEGGIO, VALORE_DESC, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vPRIORITA_X_MANIFESTAZIONE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdValoreequalthis IS NULL) OR ID_VALORE = @IdValoreequalthis) AND 
			((@Valoreequalthis IS NULL) OR VALORE = @Valoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@OperatoreValutazioneequalthis IS NULL) OR OPERATORE_VALUTAZIONE = @OperatoreValutazioneequalthis) AND 
			((@ModificaManualeequalthis IS NULL) OR MODIFICA_MANUALE = @ModificaManualeequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis)
