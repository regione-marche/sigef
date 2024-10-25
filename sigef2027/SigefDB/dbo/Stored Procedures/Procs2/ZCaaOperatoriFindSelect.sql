CREATE PROCEDURE [dbo].[ZCaaOperatoriFindSelect]
(
	@Idequalthis INT, 
	@CodiceSportelloequalthis VARCHAR(255), 
	@IdUtenteequalthis INT, 
	@IdStoricoUltimoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CODICE_SPORTELLO, ID_UTENTE, ID_STORICO_ULTIMO, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE, ID_PERSONA_FISICA, CF_UTENTE, NOMINATIVO, STATO, COD_ENTE, COD_TIPO_ENTE FROM vCAA_OPERATORI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@CodiceSportelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SPORTELLO = @CodiceSportelloequalthis)'; set @lensql=@lensql+len(@CodiceSportelloequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @CodiceSportelloequalthis VARCHAR(255), @IdUtenteequalthis INT, @IdStoricoUltimoequalthis INT',@Idequalthis , @CodiceSportelloequalthis , @IdUtenteequalthis , @IdStoricoUltimoequalthis ;
	else
		SELECT ID, CODICE_SPORTELLO, ID_UTENTE, ID_STORICO_ULTIMO, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE, ID_PERSONA_FISICA, CF_UTENTE, NOMINATIVO, STATO, COD_ENTE, COD_TIPO_ENTE
		FROM vCAA_OPERATORI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@CodiceSportelloequalthis IS NULL) OR CODICE_SPORTELLO = @CodiceSportelloequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaOperatoriFindSelect';

