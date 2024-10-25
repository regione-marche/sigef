CREATE PROCEDURE [dbo].[ZCaaStoricoOperatoriFindSelect]
(
	@Idequalthis INT, 
	@IdOperatoreequalthis INT, 
	@MandatoPsrequalthis BIT, 
	@MandatoUmaequalthis BIT, 
	@Responsabileequalthis BIT, 
	@CodStatoequalthis VARCHAR(255), 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_OPERATORE, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE FROM CAA_STORICO_OPERATORI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE = @IdOperatoreequalthis)'; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@MandatoPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_PSR = @MandatoPsrequalthis)'; set @lensql=@lensql+len(@MandatoPsrequalthis);end;
	IF (@MandatoUmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MANDATO_UMA = @MandatoUmaequalthis)'; set @lensql=@lensql+len(@MandatoUmaequalthis);end;
	IF (@Responsabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RESPONSABILE = @Responsabileequalthis)'; set @lensql=@lensql+len(@Responsabileequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdOperatoreequalthis INT, @MandatoPsrequalthis BIT, @MandatoUmaequalthis BIT, @Responsabileequalthis BIT, @CodStatoequalthis VARCHAR(255), @Dataequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @IdOperatoreequalthis , @MandatoPsrequalthis , @MandatoUmaequalthis , @Responsabileequalthis , @CodStatoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_OPERATORE, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE
		FROM CAA_STORICO_OPERATORI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@MandatoPsrequalthis IS NULL) OR MANDATO_PSR = @MandatoPsrequalthis) AND 
			((@MandatoUmaequalthis IS NULL) OR MANDATO_UMA = @MandatoUmaequalthis) AND 
			((@Responsabileequalthis IS NULL) OR RESPONSABILE = @Responsabileequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoOperatoriFindSelect';

