CREATE PROCEDURE [dbo].[ZProgettoValutatoriFindFind]
(
	@IdProgettoValutazioneequalthis INT, 
	@IdValutatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE FROM PROGETTO_VALUTATORI WHERE 1=1';
	IF (@IdProgettoValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis)'; set @lensql=@lensql+len(@IdProgettoValutazioneequalthis);end;
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VALUTATORE = @IdValutatoreequalthis)'; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdProgettoValutazioneequalthis INT, @IdValutatoreequalthis INT',@IdProgettoValutazioneequalthis , @IdValutatoreequalthis ;
	else
		SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE
		FROM PROGETTO_VALUTATORI
		WHERE 
			((@IdProgettoValutazioneequalthis IS NULL) OR ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis) AND 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoValutatoriFindFind]
(
	@IdProgettoValutazioneequalthis INT, 
	@IdValutatoreequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE FROM PROGETTO_VALUTATORI WHERE 1=1'';
	IF (@IdProgettoValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis)''; set @lensql=@lensql+len(@IdProgettoValutazioneequalthis);end;
	IF (@IdValutatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VALUTATORE = @IdValutatoreequalthis)''; set @lensql=@lensql+len(@IdValutatoreequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdProgettoValutazioneequalthis INT, @IdValutatoreequalthis INT'',@IdProgettoValutazioneequalthis , @IdValutatoreequalthis ;
	else
		SELECT ID, ID_PROGETTO_VALUTAZIONE, ID_VALUTATORE, PRESENTE, ORDINE
		FROM PROGETTO_VALUTATORI
		WHERE 
			((@IdProgettoValutazioneequalthis IS NULL) OR ID_PROGETTO_VALUTAZIONE = @IdProgettoValutazioneequalthis) AND 
			((@IdValutatoreequalthis IS NULL) OR ID_VALUTATORE = @IdValutatoreequalthis)
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoValutatoriFindFind';

