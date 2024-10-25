CREATE PROCEDURE [dbo].[ZCaaStoricoOperatoriFindFind]
(
	@IdOperatoreequalthis INT, 
	@Responsabileequalthis BIT, 
	@CodStatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_OPERATORE, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE FROM CAA_STORICO_OPERATORI WHERE 1=1';
	IF (@IdOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE = @IdOperatoreequalthis)'; set @lensql=@lensql+len(@IdOperatoreequalthis);end;
	IF (@Responsabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RESPONSABILE = @Responsabileequalthis)'; set @lensql=@lensql+len(@Responsabileequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdOperatoreequalthis INT, @Responsabileequalthis BIT, @CodStatoequalthis VARCHAR(255)',@IdOperatoreequalthis , @Responsabileequalthis , @CodStatoequalthis ;
	else
		SELECT ID, ID_OPERATORE, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE
		FROM CAA_STORICO_OPERATORI
		WHERE 
			((@IdOperatoreequalthis IS NULL) OR ID_OPERATORE = @IdOperatoreequalthis) AND 
			((@Responsabileequalthis IS NULL) OR RESPONSABILE = @Responsabileequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis)
		ORDER BY DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoOperatoriFindFind';

