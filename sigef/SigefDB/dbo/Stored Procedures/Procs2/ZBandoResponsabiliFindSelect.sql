CREATE PROCEDURE [dbo].[ZBandoResponsabiliFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdUtenteequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@Dataequalthis DATETIME, 
	@Operatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_UTENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, DENOMINAZIONE_PROVINCIA, NOMINATIVO, COD_ENTE, ENTE, PROFILO FROM vBANDO_RESPONSABILI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Operatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE = @Operatoreequalthis)'; set @lensql=@lensql+len(@Operatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @IdUtenteequalthis INT, @Provinciaequalthis VARCHAR(255), @Attivoequalthis BIT, @Dataequalthis DATETIME, @Operatoreequalthis INT',@Idequalthis , @IdBandoequalthis , @IdUtenteequalthis , @Provinciaequalthis , @Attivoequalthis , @Dataequalthis , @Operatoreequalthis ;
	else
		SELECT ID, ID_BANDO, ID_UTENTE, PROVINCIA, ATTIVO, DATA, OPERATORE, DENOMINAZIONE_PROVINCIA, NOMINATIVO, COD_ENTE, ENTE, PROFILO
		FROM vBANDO_RESPONSABILI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Operatoreequalthis IS NULL) OR OPERATORE = @Operatoreequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoResponsabiliFindSelect';

