CREATE PROCEDURE [dbo].[ZPrioritaSettorialiFindSelect]
(
	@IdPrioritaSettorialeequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PRIORITA_SETTORIALE, DESCRIZIONE FROM PRIORITA_SETTORIALI WHERE 1=1';
	IF (@IdPrioritaSettorialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)'; set @lensql=@lensql+len(@IdPrioritaSettorialeequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPrioritaSettorialeequalthis INT, @Descrizioneequalthis VARCHAR(1000)',@IdPrioritaSettorialeequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_PRIORITA_SETTORIALE, DESCRIZIONE
		FROM PRIORITA_SETTORIALI
		WHERE 
			((@IdPrioritaSettorialeequalthis IS NULL) OR ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'





CREATE PROCEDURE [dbo].[ZPrioritaSettorialiFindSelect]
(
	@IdPrioritaSettorialeequalthis INT, 
	@IdSettoreProduttivoequalthis INT, 
	@Descrizioneequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PRIORITA_SETTORIALE, ID_SETTORE_PRODUTTIVO, DESCRIZIONE, SETTORE_PRODUTTIVO, ID_BANDO FROM vPRIORITA_SETTORIALI WHERE 1=1'';
	IF (@IdPrioritaSettorialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis)''; set @lensql=@lensql+len(@IdPrioritaSettorialeequalthis);end;
	IF (@IdSettoreProduttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis)''; set @lensql=@lensql+len(@IdSettoreProduttivoequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DESCRIZIONE = @Descrizioneequalthis)''; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	--	@sql = @sql + '' order by ecc.ecc.''
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPrioritaSettorialeequalthis INT, @IdSettoreProduttivoequalthis INT, @Descrizioneequalthis VARCHAR(1000)'',@IdPrioritaSettorialeequalthis , @IdSettoreProduttivoequalthis , @Descrizioneequalthis ;
	else
		SELECT ID_PRIORITA_SETTORIALE, ID_SETTORE_PRODUTTIVO, DESCRIZIONE, SETTORE_PRODUTTIVO, ID_BANDO
		FROM vPRIORITA_SETTORIALI
		WHERE 
			((@IdPrioritaSettorialeequalthis IS NULL) OR ID_PRIORITA_SETTORIALE = @IdPrioritaSettorialeequalthis) AND 
			((@IdSettoreProduttivoequalthis IS NULL) OR ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivoequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis)
		-- order by ecc.ecc.

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaSettorialiFindSelect';

