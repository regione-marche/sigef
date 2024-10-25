CREATE PROCEDURE [dbo].[ZProgettoComunicazioneFindSelect]
(
	@IdComunicazioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdComunicazioneRefequalthis INT, 
	@Oggettoequalthis VARCHAR(255), 
	@Testoequalthis VARCHAR(max), 
	@CodTipoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaEsternaequalthis BIT, 
	@InEntrataequalthis BIT, 
	@IdNoteequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMUNICAZIONE, ID_PROGETTO, ID_COMUNICAZIONE_REF, OGGETTO, TESTO, COD_TIPO, DESCRIZIONE, DATA_INSERIMENTO, DATA_MODIFICA, OPERATORE, SEGNATURA, SEGNATURA_ESTERNA, IN_ENTRATA, ID_NOTE, TESTO_NOTE FROM vPROGETTO_COMUNICAZIONE WHERE 1=1';
	IF (@IdComunicazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE = @IdComunicazioneequalthis)'; set @lensql=@lensql+len(@IdComunicazioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdComunicazioneRefequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNICAZIONE_REF = @IdComunicazioneRefequalthis)'; set @lensql=@lensql+len(@IdComunicazioneRefequalthis);end;
	IF (@Oggettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OGGETTO = @Oggettoequalthis)'; set @lensql=@lensql+len(@Oggettoequalthis);end;
	IF (@Testoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TESTO = @Testoequalthis)'; set @lensql=@lensql+len(@Testoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaEsternaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ESTERNA = @SegnaturaEsternaequalthis)'; set @lensql=@lensql+len(@SegnaturaEsternaequalthis);end;
	IF (@InEntrataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_ENTRATA = @InEntrataequalthis)'; set @lensql=@lensql+len(@InEntrataequalthis);end;
	IF (@IdNoteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_NOTE = @IdNoteequalthis)'; set @lensql=@lensql+len(@IdNoteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComunicazioneequalthis INT, @IdProgettoequalthis INT, @IdComunicazioneRefequalthis INT, @Oggettoequalthis VARCHAR(255), @Testoequalthis VARCHAR(max), @CodTipoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @DataModificaequalthis DATETIME, @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @SegnaturaEsternaequalthis BIT, @InEntrataequalthis BIT, @IdNoteequalthis INT',@IdComunicazioneequalthis , @IdProgettoequalthis , @IdComunicazioneRefequalthis , @Oggettoequalthis , @Testoequalthis , @CodTipoequalthis , @DataInserimentoequalthis , @DataModificaequalthis , @Operatoreequalthis , @Segnaturaequalthis , @SegnaturaEsternaequalthis , @InEntrataequalthis , @IdNoteequalthis ;
	else
		SELECT ID_COMUNICAZIONE, ID_PROGETTO, ID_COMUNICAZIONE_REF, OGGETTO, TESTO, COD_TIPO, DESCRIZIONE, DATA_INSERIMENTO, DATA_MODIFICA, OPERATORE, SEGNATURA, SEGNATURA_ESTERNA, IN_ENTRATA, ID_NOTE, TESTO_NOTE
		FROM vPROGETTO_COMUNICAZIONE
		WHERE 
			((@IdComunicazioneequalthis IS NULL) OR ID_COMUNICAZIONE = @IdComunicazioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdComunicazioneRefequalthis IS NULL) OR ID_COMUNICAZIONE_REF = @IdComunicazioneRefequalthis) AND 
			((@Oggettoequalthis IS NULL) OR OGGETTO = @Oggettoequalthis) AND 
			((@Testoequalthis IS NULL) OR TESTO = @Testoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaEsternaequalthis IS NULL) OR SEGNATURA_ESTERNA = @SegnaturaEsternaequalthis) AND 
			((@InEntrataequalthis IS NULL) OR IN_ENTRATA = @InEntrataequalthis) AND 
			((@IdNoteequalthis IS NULL) OR ID_NOTE = @IdNoteequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneFindSelect';

