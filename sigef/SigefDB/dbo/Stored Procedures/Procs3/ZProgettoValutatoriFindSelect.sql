CREATE PROCEDURE [dbo].[ZProgettoValutatoriFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoValutazioneequalthis INT, 
	@IdValutatoreequalthis INT, 
	@Presenteequalthis BIT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE FROM PROGETTO_VALUTATORI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis)'; set @lensql=@lensql+len(@IdProgettoValutazioneequalthis);end;
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALUTATORE = @IdValutatoreequalthis)'; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	IF (@Presenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PRESENTE = @Presenteequalthis)'; set @lensql=@lensql+len(@Presenteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORDINE = @Ordineequalthis)'; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdProgettoValutazioneequalthis INT, @IdValutatoreequalthis INT, @Presenteequalthis BIT, @Ordineequalthis INT',@Idequalthis , @IdProgettoValutazioneequalthis , @IdValutatoreequalthis , @Presenteequalthis , @Ordineequalthis ;
	else
		SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE
		FROM PROGETTO_VALUTATORI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoValutazioneequalthis IS NULL) OR ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis) AND 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@Presenteequalthis IS NULL) OR PRESENTE = @Presenteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutatoriFindSelect]
(
	@Idequalthis INT, 
	@IdProgettoValutazioneequalthis INT, 
	@IdValutatoreequalthis INT, 
	@Presenteequalthis BIT, 
	@Ordineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE FROM PROGETTO_VALUTATORI WHERE 1=1'';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID = @Idequalthis)''; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdProgettoValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis)''; set @lensql=@lensql+len(@IdProgettoValutazioneequalthis);end;
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALUTATORE = @IdValutatoreequalthis)''; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	IF (@Presenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PRESENTE = @Presenteequalthis)''; set @lensql=@lensql+len(@Presenteequalthis);end;
	IF (@Ordineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ORDINE = @Ordineequalthis)''; set @lensql=@lensql+len(@Ordineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@Idequalthis INT, @IdProgettoValutazioneequalthis INT, @IdValutatoreequalthis INT, @Presenteequalthis BIT, @Ordineequalthis INT'',@Idequalthis , @IdProgettoValutazioneequalthis , @IdValutatoreequalthis , @Presenteequalthis , @Ordineequalthis ;
	else
		SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE
		FROM PROGETTO_VALUTATORI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdProgettoValutazioneequalthis IS NULL) OR ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis) AND 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis) AND 
			((@Presenteequalthis IS NULL) OR PRESENTE = @Presenteequalthis) AND 
			((@Ordineequalthis IS NULL) OR ORDINE = @Ordineequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutatoriFindSelect';

