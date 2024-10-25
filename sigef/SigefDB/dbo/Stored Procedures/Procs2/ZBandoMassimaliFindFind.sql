CREATE PROCEDURE [dbo].[ZBandoMassimaliFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE FROM vBANDO_MASSIMALI WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	set @sql = @sql + 'ORDER BY CODICE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgrammazioneequalthis INT',@IdBandoequalthis , @IdProgrammazioneequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE
		FROM vBANDO_MASSIMALI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)
		ORDER BY CODICE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoMassimaliFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgrammazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE FROM vBANDO_MASSIMALI WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	set @sql = @sql + ''ORDER BY CODICE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @IdProgrammazioneequalthis INT'',@IdBandoequalthis , @IdProgrammazioneequalthis ;
	else
		SELECT ID, ID_BANDO, ID_PROGRAMMAZIONE, QUOTA, IMPORTO, CODICE, DESCRIZIONE
		FROM vBANDO_MASSIMALI
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)
		ORDER BY CODICE


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoMassimaliFindFind';

