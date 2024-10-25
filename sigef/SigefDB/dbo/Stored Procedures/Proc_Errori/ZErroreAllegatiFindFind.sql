CREATE PROCEDURE [dbo].[ZErroreAllegatiFindFind]
(
	@IdErroreAllegatiequalthis INT, 
	@IdErroreequalthis INT, 
	@Protocollatoequalthis BIT, 
	@IdAllegatoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ERRORE_ALLEGATI, ID_ERRORE, PROTOCOLLATO, SEGNATURA_ALLEGATO, ID_ALLEGATO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, TIPO_FILE, NOME_FILE, NOME_COMPLETO_FILE, CONTENUTO_FILE, DIMENSIONE_FILE, HASH_CODE_FILE FROM VERRORE_ALLEGATI WHERE 1=1';
	IF (@IdErroreAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE_ALLEGATI = @IdErroreAllegatiequalthis)'; set @lensql=@lensql+len(@IdErroreAllegatiequalthis);end;
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLATO = @Protocollatoequalthis)'; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdErroreAllegatiequalthis INT, @IdErroreequalthis INT, @Protocollatoequalthis BIT, @IdAllegatoequalthis INT',@IdErroreAllegatiequalthis , @IdErroreequalthis , @Protocollatoequalthis , @IdAllegatoequalthis ;
	else
		SELECT ID_ERRORE_ALLEGATI, ID_ERRORE, PROTOCOLLATO, SEGNATURA_ALLEGATO, ID_ALLEGATO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, TIPO_FILE, NOME_FILE, NOME_COMPLETO_FILE, CONTENUTO_FILE, DIMENSIONE_FILE, HASH_CODE_FILE
		FROM VERRORE_ALLEGATI
		WHERE 
			((@IdErroreAllegatiequalthis IS NULL) OR ID_ERRORE_ALLEGATI = @IdErroreAllegatiequalthis) AND 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis)
		

GO