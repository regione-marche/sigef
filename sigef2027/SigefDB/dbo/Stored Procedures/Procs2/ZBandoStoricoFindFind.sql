CREATE PROCEDURE [dbo].[ZBandoStoricoFindFind]
(
	@IdBandoequalthis INT, 
	@CodStatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, STATO, ORDINE_STATO, PROFILO, NOMINATIVO, NUMERO_ATTO, DATA_ATTO FROM vBANDO_STORICO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @CodStatoequalthis VARCHAR(255)',@IdBandoequalthis , @CodStatoequalthis ;
	else
		SELECT ID, ID_BANDO, COD_STATO, DATA, OPERATORE, SEGNATURA, ID_ATTO, STATO, ORDINE_STATO, PROFILO, NOMINATIVO, NUMERO_ATTO, DATA_ATTO
		FROM vBANDO_STORICO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis)
		ORDER BY DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoStoricoFindFind';

