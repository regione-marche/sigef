CREATE PROCEDURE [dbo].[ZPrioritaXProgettoFindFind]
(
	@IdProgettoequalthis INT, 
	@IdPrioritaequalthis INT, 
	@CodLivelloequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO FROM vPRIORITA_X_PROGETTO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @IdPrioritaequalthis INT, @CodLivelloequalthis VARCHAR(255)',@IdProgettoequalthis , @IdPrioritaequalthis , @CodLivelloequalthis ;
	else
		SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPrioritaXProgettoFindFind]
(
	@IdProgettoequalthis INT, 
	@IdPrioritaequalthis INT, 
	@CodLivelloequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO FROM vPRIORITA_X_PROGETTO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_LIVELLO = @CodLivelloequalthis)''; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @IdPrioritaequalthis INT, @CodLivelloequalthis VARCHAR(255)'',@IdProgettoequalthis , @IdPrioritaequalthis , @CodLivelloequalthis ;
	else
		SELECT ID_PROGETTO, ID_PRIORITA, VALORE, DATA_VALUTAZIONE, OPERATORE_VALUTAZIONE, MODIFICA_MANUALE, PRIORITA, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, VALORE_DESC, ID_VALORE, PUNTEGGIO, INPUT_NUMERICO, MISURA, DATETIME, TESTO_SEMPLICE, TESTO_AREA, PLURI_VALORE_SQL, QUERY_PLURIVALORE, VAL_DATA, VAL_TESTO
		FROM vPRIORITA_X_PROGETTO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXProgettoFindFind';

