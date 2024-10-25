CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoFindFind]
(
	@IdBandoequalthis INT, 
	@IdSettoreProduttivoequalthis INT, 
	@IdPrioritaSettorialeequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO_X_SETTORE_PRODUTTIVO, ID_BANDO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE FROM vBANDO_X_SETTORE_PRODUTTIVO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)'; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@IdPrioritaSettorialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)'; set @lensql=@lensql+len(@IdPrioritaSettorialeequalthis);end;
	set @sql = @sql + 'ORDER BY SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdSettoreProduttivoequalthis INT, @IdPrioritaSettorialeequalthis INT',@IdBandoequalthis , @IdSettoreProduttivoequalthis , @IdPrioritaSettorialeequalthis ;
	else
		SELECT ID_BANDO_X_SETTORE_PRODUTTIVO, ID_BANDO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE
		FROM vBANDO_X_SETTORE_PRODUTTIVO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@IdPrioritaSettorialeequalthis IS NULL) OR ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)
		ORDER BY SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoFindFind]
(
	@IdBandoXSettoreProduttivoequalthis INT, 
	@IdBandoequalthis INT, 
	@IdSettoreProduttivoequalthis INT, 
	@IdPrioritaSettorialeequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_BANDO_X_SETTORE_PRODUTTIVO, ID_BANDO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE FROM vBANDO_X_SETTORE_PRODUTTIVO WHERE 1=1'';
	IF (@IdBandoXSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivoequalthis)''; set @lensql=@lensql+len(@IdBandoXSettoreProduttivoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)''; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@IdPrioritaSettorialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)''; set @lensql=@lensql+len(@IdPrioritaSettorialeequalthis);end;
set @sql = @sql + '' AND ID_PRIORITA_SETTORIALE IS NOT NULL  ORDER BY SETTORE_PRODUTTIVO,PRIORITA_SETTORIALE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoXSettoreProduttivoequalthis INT, @IdBandoequalthis INT, @IdSettoreProduttivoequalthis INT, @IdPrioritaSettorialeequalthis INT'',@IdBandoXSettoreProduttivoequalthis , @IdBandoequalthis , @IdSettoreProduttivoequalthis , @IdPrioritaSettorialeequalthis ;
	else
		SELECT ID_BANDO_X_SETTORE_PRODUTTIVO, ID_BANDO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, SETTORE_PRODUTTIVO, PRIORITA_SETTORIALE
		FROM vBANDO_X_SETTORE_PRODUTTIVO
		WHERE 
			((@IdBandoXSettoreProduttivoequalthis IS NULL) OR ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@IdPrioritaSettorialeequalthis IS NULL) OR ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis) AND 
			ID_PRIORITA_SETTORIALE IS NOT NULL
		ORDER BY SETTORE_PRODUTTIVO,PRIORITA_SETTORIALE



', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoXSettoreProduttivoFindFind';

