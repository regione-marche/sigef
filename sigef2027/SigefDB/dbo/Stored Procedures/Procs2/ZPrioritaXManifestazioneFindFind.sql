create PROCEDURE [dbo].[ZPrioritaXManifestazioneFindFind]
(
	@IdManifestazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@CodLivelloequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_MANIFESTAZIONE, ID_PRIORITA, ID_VALORE, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PUNTEGGIO, VALORE_DESC, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vPRIORITA_X_MANIFESTAZIONE WHERE 1=1';
	IF (@IdManifestazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_MANIFESTAZIONE = @IdManifestazioneequalthis)'; set @lensql=@lensql+len(@IdManifestazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdManifestazioneequalthis INT, @IdPrioritaequalthis INT, @CodLivelloequalthis CHAR(1)',@IdManifestazioneequalthis , @IdPrioritaequalthis , @CodLivelloequalthis ;
	else
		SELECT ID_MANIFESTAZIONE, ID_PRIORITA, ID_VALORE, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PUNTEGGIO, VALORE_DESC, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vPRIORITA_X_MANIFESTAZIONE
		WHERE 
			((@IdManifestazioneequalthis IS NULL) OR ID_MANIFESTAZIONE = @IdManifestazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis)
