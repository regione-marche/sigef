CREATE PROCEDURE [dbo].[ZProgettoComunicazioneFindFind]
(
	@IdProgettoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Operatoreequalthis INT, 
	@Segnaturaequalthis VARCHAR(255), 
	@SegnaturaEsternaequalthis BIT, 
	@InEntrataequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMUNICAZIONE, ID_PROGETTO, ID_COMUNICAZIONE_REF, OGGETTO, TESTO, COD_TIPO, DESCRIZIONE, DATA_INSERIMENTO, DATA_MODIFICA, OPERATORE, SEGNATURA, SEGNATURA_ESTERNA, IN_ENTRATA, ID_NOTE, TESTO_NOTE FROM vPROGETTO_COMUNICAZIONE WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@SegnaturaEsternaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ESTERNA = @SegnaturaEsternaequalthis)'; set @lensql=@lensql+len(@SegnaturaEsternaequalthis);end;
	IF (@InEntrataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_ENTRATA = @InEntrataequalthis)'; set @lensql=@lensql+len(@InEntrataequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodTipoequalthis VARCHAR(255), @Operatoreequalthis INT, @Segnaturaequalthis VARCHAR(255), @SegnaturaEsternaequalthis BIT, @InEntrataequalthis BIT',@IdProgettoequalthis , @CodTipoequalthis , @Operatoreequalthis , @Segnaturaequalthis , @SegnaturaEsternaequalthis , @InEntrataequalthis ;
	else
		SELECT ID_COMUNICAZIONE, ID_PROGETTO, ID_COMUNICAZIONE_REF, OGGETTO, TESTO, COD_TIPO, DESCRIZIONE, DATA_INSERIMENTO, DATA_MODIFICA, OPERATORE, SEGNATURA, SEGNATURA_ESTERNA, IN_ENTRATA, ID_NOTE, TESTO_NOTE
		FROM vPROGETTO_COMUNICAZIONE
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@SegnaturaEsternaequalthis IS NULL) OR SEGNATURA_ESTERNA = @SegnaturaEsternaequalthis) AND 
			((@InEntrataequalthis IS NULL) OR IN_ENTRATA = @InEntrataequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioneFindFind';

