CREATE PROCEDURE [dbo].[ZErroreAllegatiFindSelect]
(
	@IdErroreAllegatiequalthis INT, 
	@IdErroreequalthis INT, 
	@Protocollatoequalthis BIT, 
	@SegnaturaAllegatoequalthis VARCHAR(255), 
	@IdAllegatoequalthis INT, 
	@CfInserimentoequalthis VARCHAR(255), 
	@DataInserimentoequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ERRORE_ALLEGATI, ID_ERRORE, PROTOCOLLATO, SEGNATURA_ALLEGATO, ID_ALLEGATO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, TIPO_FILE, NOME_FILE, NOME_COMPLETO_FILE, CONTENUTO_FILE, DIMENSIONE_FILE, HASH_CODE_FILE FROM VERRORE_ALLEGATI WHERE 1=1';
	IF (@IdErroreAllegatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE_ALLEGATI = @IdErroreAllegatiequalthis)'; set @lensql=@lensql+len(@IdErroreAllegatiequalthis);end;
	IF (@IdErroreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ERRORE = @IdErroreequalthis)'; set @lensql=@lensql+len(@IdErroreequalthis);end;
	IF (@Protocollatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROTOCOLLATO = @Protocollatoequalthis)'; set @lensql=@lensql+len(@Protocollatoequalthis);end;
	IF (@SegnaturaAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_ALLEGATO = @SegnaturaAllegatoequalthis)'; set @lensql=@lensql+len(@SegnaturaAllegatoequalthis);end;
	IF (@IdAllegatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ALLEGATO = @IdAllegatoequalthis)'; set @lensql=@lensql+len(@IdAllegatoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdErroreAllegatiequalthis INT, @IdErroreequalthis INT, @Protocollatoequalthis BIT, @SegnaturaAllegatoequalthis VARCHAR(255), @IdAllegatoequalthis INT, @CfInserimentoequalthis VARCHAR(255), @DataInserimentoequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @DataModificaequalthis DATETIME',@IdErroreAllegatiequalthis , @IdErroreequalthis , @Protocollatoequalthis , @SegnaturaAllegatoequalthis , @IdAllegatoequalthis , @CfInserimentoequalthis , @DataInserimentoequalthis , @CfModificaequalthis , @DataModificaequalthis ;
	else
		SELECT ID_ERRORE_ALLEGATI, ID_ERRORE, PROTOCOLLATO, SEGNATURA_ALLEGATO, ID_ALLEGATO, CF_INSERIMENTO, DATA_INSERIMENTO, CF_MODIFICA, DATA_MODIFICA, TIPO_FILE, NOME_FILE, NOME_COMPLETO_FILE, CONTENUTO_FILE, DIMENSIONE_FILE, HASH_CODE_FILE
		FROM VERRORE_ALLEGATI
		WHERE 
			((@IdErroreAllegatiequalthis IS NULL) OR ID_ERRORE_ALLEGATI = @IdErroreAllegatiequalthis) AND 
			((@IdErroreequalthis IS NULL) OR ID_ERRORE = @IdErroreequalthis) AND 
			((@Protocollatoequalthis IS NULL) OR PROTOCOLLATO = @Protocollatoequalthis) AND 
			((@SegnaturaAllegatoequalthis IS NULL) OR SEGNATURA_ALLEGATO = @SegnaturaAllegatoequalthis) AND 
			((@IdAllegatoequalthis IS NULL) OR ID_ALLEGATO = @IdAllegatoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis)
		

GO