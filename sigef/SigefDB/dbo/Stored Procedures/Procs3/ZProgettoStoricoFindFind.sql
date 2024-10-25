CREATE PROCEDURE [dbo].[ZProgettoStoricoFindFind]
(
	@IdProgettoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@CodFaseequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE, ID_ATTO FROM vPROGETTO_STORICO WHERE 1=1';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_FASE = @CodFaseequalthis)'; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoequalthis INT, @CodStatoequalthis VARCHAR(255), @CodFaseequalthis VARCHAR(255)',@IdProgettoequalthis , @CodStatoequalthis , @CodFaseequalthis ;
	else
		SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE, ID_ATTO
		FROM vPROGETTO_STORICO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		ORDER BY DATA DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoStoricoFindFind]
(
	@IdProgettoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@CodFaseequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE FROM vPROGETTO_STORICO WHERE 1=1'';
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_STATO = @CodStatoequalthis)''; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@CodFaseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_FASE = @CodFaseequalthis)''; set @lensql=@lensql+len(@CodFaseequalthis);end;
	set @sql = @sql + ''ORDER BY DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoequalthis INT, @CodStatoequalthis VARCHAR(255), @CodFaseequalthis VARCHAR(255)'',@IdProgettoequalthis , @CodStatoequalthis , @CodFaseequalthis ;
	else
		SELECT ID, ID_PROGETTO, COD_STATO, DATA, OPERATORE, SEGNATURA, REVISIONE, RIESAME, RICORSO, RIAPERTURA_PROVINCIALE, DATA_RI, OPERATORE_RI, SEGNATURA_RI, STATO, COD_FASE, ORDINE_STATO, FASE, ORDINE_FASE, NOMINATIVO, COD_ENTE, PROVINCIA, ID_PROFILO, PROFILO, ENTE, COD_TIPO_ENTE
		FROM vPROGETTO_STORICO
		WHERE 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@CodFaseequalthis IS NULL) OR COD_FASE = @CodFaseequalthis)
		ORDER BY DATA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoStoricoFindFind';

