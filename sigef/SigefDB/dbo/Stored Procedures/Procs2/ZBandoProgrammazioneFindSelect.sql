CREATE PROCEDURE [dbo].[ZBandoProgrammazioneFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@MisuraPrevalenteequalthis BIT, 
	@IdDisposizioniAttuativeequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, MISURA_PREVALENTE, ID_DISPOSIZIONI_ATTUATIVE, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO FROM vBANDO_PROGRAMMAZIONE WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)'; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	IF (@IdDisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuativeequalthis)'; set @lensql=@lensql+len(@IdDisposizioniAttuativeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @IdProgrammazioneequalthis INT, @MisuraPrevalenteequalthis BIT, @IdDisposizioniAttuativeequalthis INT',@Idequalthis , @IdBandoequalthis , @IdProgrammazioneequalthis , @MisuraPrevalenteequalthis , @IdDisposizioniAttuativeequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, MISURA_PREVALENTE, ID_DISPOSIZIONI_ATTUATIVE, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO
		FROM vBANDO_PROGRAMMAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@MisuraPrevalenteequalthis IS NULL) OR MISURA_PREVALENTE = @MisuraPrevalenteequalthis) AND 
			((@IdDisposizioniAttuativeequalthis IS NULL) OR ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuativeequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoProgrammazioneFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@MisuraPrevalenteequalthis BIT, 
	@IdDisposizioniAttuativeequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, MISURA_PREVALENTE, ID_DISPOSIZIONI_ATTUATIVE, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO FROM vBANDO_PROGRAMMAZIONE WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@MisuraPrevalenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (MISURA_PREVALENTE = @MisuraPrevalenteequalthis)''; set @lensql=@lensql+len(@MisuraPrevalenteequalthis);end;
	IF (@IdDisposizioniAttuativeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuativeequalthis)''; set @lensql=@lensql+len(@IdDisposizioniAttuativeequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdBandoequalthis INT, @IdProgrammazioneequalthis INT, @MisuraPrevalenteequalthis BIT, @IdDisposizioniAttuativeequalthis INT'',@Idequalthis , @IdBandoequalthis , @IdProgrammazioneequalthis , @MisuraPrevalenteequalthis , @IdDisposizioniAttuativeequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, MISURA_PREVALENTE, ID_DISPOSIZIONI_ATTUATIVE, COD_TIPO, CODICE, DESCRIZIONE, ID_PADRE, COD_PSR, TIPO, LIVELLO
		FROM vBANDO_PROGRAMMAZIONE
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@MisuraPrevalenteequalthis IS NULL) OR MISURA_PREVALENTE = @MisuraPrevalenteequalthis) AND 
			((@IdDisposizioniAttuativeequalthis IS NULL) OR ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuativeequalthis)
		


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoProgrammazioneFindSelect';

