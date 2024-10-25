CREATE PROCEDURE [dbo].[ZBandoMassimaliFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Quotaequalthis DECIMAL(10,2), 
	@Importoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE FROM vBANDO_MASSIMALI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Quotaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA = @Quotaequalthis)'; set @lensql=@lensql+len(@Quotaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO = @Importoequalthis)'; set @lensql=@lensql+len(@Importoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdBandoequalthis INT, @IdProgrammazioneequalthis INT, @Quotaequalthis DECIMAL(10,2), @Importoequalthis DECIMAL(18,2)',@Idequalthis , @IdBandoequalthis , @IdProgrammazioneequalthis , @Quotaequalthis , @Importoequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE
		FROM vBANDO_MASSIMALI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Quotaequalthis IS NULL) OR QUOTA = @Quotaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoMassimaliFindSelect]
(
	@Idequalthis INT, 
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@Quotaequalthis DECIMAL(10,2), 
	@Importoequalthis DECIMAL(18,2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE FROM vBANDO_MASSIMALI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@Quotaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (QUOTA = @Quotaequalthis)''; set @lensql=@lensql+len(@Quotaequalthis);end;
	IF (@Importoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO = @Importoequalthis)''; set @lensql=@lensql+len(@Importoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdBandoequalthis INT, @IdProgrammazioneequalthis INT, @Quotaequalthis DECIMAL(10,2), @Importoequalthis DECIMAL(18,2)'',@Idequalthis , @IdBandoequalthis , @IdProgrammazioneequalthis , @Quotaequalthis , @Importoequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE
		FROM vBANDO_MASSIMALI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@Quotaequalthis IS NULL) OR QUOTA = @Quotaequalthis) AND 
			((@Importoequalthis IS NULL) OR IMPORTO = @Importoequalthis)
		


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoMassimaliFindSelect';

