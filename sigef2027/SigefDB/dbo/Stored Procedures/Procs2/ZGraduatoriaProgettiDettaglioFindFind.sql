CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioFindFind]
(
	@IdPrioritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodLivelloequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vGRADUATORIA_PROGETTI_DETTAGLIO WHERE 1=1';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_LIVELLO = @CodLivelloequalthis)'; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaequalthis INT, @IdProgettoequalthis INT, @CodLivelloequalthis VARCHAR(255)',@IdPrioritaequalthis , @IdProgettoequalthis , @CodLivelloequalthis ;
	else
		SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vGRADUATORIA_PROGETTI_DETTAGLIO
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiDettaglioFindFind]
(
	@IdPrioritaequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodLivelloequalthis CHAR(1)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA FROM vGRADUATORIA_PROGETTI_DETTAGLIO WHERE 1=1'';
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA = @IdPrioritaequalthis)''; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodLivelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_LIVELLO = @CodLivelloequalthis)''; set @lensql=@lensql+len(@CodLivelloequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaequalthis INT, @IdProgettoequalthis INT, @CodLivelloequalthis CHAR(1)'',@IdPrioritaequalthis , @IdProgettoequalthis , @CodLivelloequalthis ;
	else
		SELECT ID_PRIORITA, ID_PROGETTO, PUNTEGGIO, DATA_VALUTAZIONE, OPERATORE, MODIFICA_MANUALE, DESCRIZIONE, COD_LIVELLO, PLURI_VALORE, EVAL, FLAG_MANUALE, INPUT_NUMERICO, MISURA
		FROM vGRADUATORIA_PROGETTI_DETTAGLIO
		WHERE 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodLivelloequalthis IS NULL) OR COD_LIVELLO = @CodLivelloequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiDettaglioFindFind';

