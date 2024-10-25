CREATE PROCEDURE [dbo].[ZVstatiProceduraliFindFind]
(
	@CodStatoequalthis CHAR(1), 
	@CodFaseequalthis CHAR(1), 
	@OrdineFasegreaterthanthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT COD_STATO, STATO, COD_FASE, FASE, ORDINE_FASE, ORDINE_STATO FROM vSTATI_PROCEDURALI WHERE 1=1';
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	IF (@OrdineFasegreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE_FASE > @OrdineFasegreaterthanthis)'; set @lensql=@lensql+len(@OrdineFasegreaterthanthis);end;
	set @sql = @sql + 'ORDER BY ORDINE_FASE, ORDINE_STATO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodStatoequalthis CHAR(1), @CodFaseequalthis CHAR(1), @OrdineFasegreaterthanthis INT',@CodStatoequalthis , @CodFaseequalthis , @OrdineFasegreaterthanthis ;
	else
		SELECT COD_STATO, STATO, COD_FASE, FASE, ORDINE_FASE, ORDINE_STATO
		FROM vSTATI_PROCEDURALI
		WHERE 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis) AND 
			((@OrdineFasegreaterthanthis IS NULL) OR ORDINE_FASE > @OrdineFasegreaterthanthis)
		ORDER BY ORDINE_FASE, ORDINE_STATO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVstatiProceduraliFindFind';

