CREATE PROCEDURE [dbo].[ZCaaOperatoriFindFind]
(
	@CodiceSportelloequalthis VARCHAR(255), 
	@IdUtenteequalthis INT, 
	@CfUtenteequalthis VARCHAR(255), 
	@Responsabileequalthis BIT, 
	@CodStatoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, CODICE_SPORTELLO, ID_UTENTE, ID_STORICO_ULTIMO, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE, ID_PERSONA_FISICA, CF_UTENTE, NOMINATIVO, STATO, COD_ENTE, COD_TIPO_ENTE FROM vCAA_OPERATORI WHERE 1=1';
	IF (@CodiceSportelloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SPORTELLO = @CodiceSportelloequalthis)'; set @lensql=@lensql+len(@CodiceSportelloequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@CfUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_UTENTE = @CfUtenteequalthis)'; set @lensql=@lensql+len(@CfUtenteequalthis);end;
	IF (@Responsabileequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RESPONSABILE = @Responsabileequalthis)'; set @lensql=@lensql+len(@Responsabileequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	set @sql = @sql + 'ORDER BY DATA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodiceSportelloequalthis VARCHAR(255), @IdUtenteequalthis INT, @CfUtenteequalthis VARCHAR(255), @Responsabileequalthis BIT, @CodStatoequalthis VARCHAR(255)',@CodiceSportelloequalthis , @IdUtenteequalthis , @CfUtenteequalthis , @Responsabileequalthis , @CodStatoequalthis ;
	else
		SELECT ID, CODICE_SPORTELLO, ID_UTENTE, ID_STORICO_ULTIMO, MANDATO_PSR, MANDATO_UMA, RESPONSABILE, COD_STATO, DATA, OPERATORE, ID_PERSONA_FISICA, CF_UTENTE, NOMINATIVO, STATO, COD_ENTE, COD_TIPO_ENTE
		FROM vCAA_OPERATORI
		WHERE 
			((@CodiceSportelloequalthis IS NULL) OR CODICE_SPORTELLO = @CodiceSportelloequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@CfUtenteequalthis IS NULL) OR CF_UTENTE = @CfUtenteequalthis) AND 
			((@Responsabileequalthis IS NULL) OR RESPONSABILE = @Responsabileequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis)
		ORDER BY DATA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaOperatoriFindFind';

