CREATE PROCEDURE [dbo].[ZBancheFilialiFindSelect]
(
	@Idequalthis INT, 
	@Abiequalthis VARCHAR(255), 
	@Cabequalthis VARCHAR(255), 
	@Noteequalthis VARCHAR(255), 
	@Indirizzoequalthis VARCHAR(255), 
	@IdComuneequalthis INT, 
	@Comuneequalthis VARCHAR(255), 
	@Provinciaequalthis VARCHAR(255), 
	@Capequalthis VARCHAR(255), 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ABI, CAB, NOTE, INDIRIZZO, ID_COMUNE, COMUNE, PROVINCIA, CAP, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO FROM BANCHE_FILIALI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Abiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ABI = @Abiequalthis)'; set @lensql=@lensql+len(@Abiequalthis);end;
	IF (@Cabequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAB = @Cabequalthis)'; set @lensql=@lensql+len(@Cabequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	IF (@Indirizzoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (INDIRIZZO = @Indirizzoequalthis)'; set @lensql=@lensql+len(@Indirizzoequalthis);end;
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@Comuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COMUNE = @Comuneequalthis)'; set @lensql=@lensql+len(@Comuneequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Capequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAP = @Capequalthis)'; set @lensql=@lensql+len(@Capequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Abiequalthis VARCHAR(255), @Cabequalthis VARCHAR(255), @Noteequalthis VARCHAR(255), @Indirizzoequalthis VARCHAR(255), @IdComuneequalthis INT, @Comuneequalthis VARCHAR(255), @Provinciaequalthis VARCHAR(255), @Capequalthis VARCHAR(255), @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @Attivoequalthis BIT',@Idequalthis , @Abiequalthis , @Cabequalthis , @Noteequalthis , @Indirizzoequalthis , @IdComuneequalthis , @Comuneequalthis , @Provinciaequalthis , @Capequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @Attivoequalthis ;
	else
		SELECT ID, ABI, CAB, NOTE, INDIRIZZO, ID_COMUNE, COMUNE, PROVINCIA, CAP, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ATTIVO
		FROM BANCHE_FILIALI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Abiequalthis IS NULL) OR ABI = @Abiequalthis) AND 
			((@Cabequalthis IS NULL) OR CAB = @Cabequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis) AND 
			((@Indirizzoequalthis IS NULL) OR INDIRIZZO = @Indirizzoequalthis) AND 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@Comuneequalthis IS NULL) OR COMUNE = @Comuneequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Capequalthis IS NULL) OR CAP = @Capequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheFilialiFindSelect';

