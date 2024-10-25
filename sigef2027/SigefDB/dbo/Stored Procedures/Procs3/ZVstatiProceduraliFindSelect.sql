CREATE PROCEDURE [dbo].[ZVstatiProceduraliFindSelect]
(
	@CodStatoequalthis CHAR(1), 
	@Statoequalthis VARCHAR(80), 
	@CodFaseequalthis CHAR(1), 
	@Faseequalthis VARCHAR(100), 
	@OrdineFaseequalthis INT, 
	@OrdineStatoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_STATO, STATO, COD_FASE, FASE, ORDINE_FASE, ORDINE_STATO FROM vSTATI_PROCEDURALI WHERE 1=1';
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@Faseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASE = @Faseequalthis)'; set @lensql=@lensql+len(@Faseequalthis);end;
	IF (@OrdineFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_FASE = @OrdineFaseequalthis)'; set @lensql=@lensql+len(@OrdineFaseequalthis);end;
	IF (@OrdineStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_STATO = @OrdineStatoequalthis)'; set @lensql=@lensql+len(@OrdineStatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodStatoequalthis CHAR(1), @Statoequalthis VARCHAR(80), @CodFaseequalthis CHAR(1), @Faseequalthis VARCHAR(100), @OrdineFaseequalthis INT, @OrdineStatoequalthis INT',@CodStatoequalthis , @Statoequalthis , @CodFaseequalthis , @Faseequalthis , @OrdineFaseequalthis , @OrdineStatoequalthis ;
	else
		SELECT COD_STATO, STATO, COD_FASE, FASE, ORDINE_FASE, ORDINE_STATO
		FROM vSTATI_PROCEDURALI
		WHERE 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@Statoequalthis IS NULL) OR STATO = @Statoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@Faseequalthis IS NULL) OR FASE = @Faseequalthis) AND 
			((@OrdineFaseequalthis IS NULL) OR ORDINE_FASE = @OrdineFaseequalthis) AND 
			((@OrdineStatoequalthis IS NULL) OR ORDINE_STATO = @OrdineStatoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVstatiProceduraliFindSelect';

