CREATE PROCEDURE [dbo].[ZPrioritaSpecialeFindSelect]
(
	@IdSchedaValutazioneequalthis INT, 
	@IdPrioritaequalthis INT, 
	@IdPrioritaSelezionataequalthis INT, 
	@IsMaxequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_SCHEDA_VALUTAZIONE, ID_PRIORITA, ID_PRIORITA_SELEZIONATA, IS_MAX FROM PRIORITA_SPECIALE WHERE 1=1';
	IF (@IdSchedaValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis)'; set @lensql=@lensql+len(@IdSchedaValutazioneequalthis);end;
	IF (@IdPrioritaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA = @IdPrioritaequalthis)'; set @lensql=@lensql+len(@IdPrioritaequalthis);end;
	IF (@IdPrioritaSelezionataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PRIORITA_SELEZIONATA = @IdPrioritaSelezionataequalthis)'; set @lensql=@lensql+len(@IdPrioritaSelezionataequalthis);end;
	IF (@IsMaxequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IS_MAX = @IsMaxequalthis)'; set @lensql=@lensql+len(@IsMaxequalthis);end;
	--	@sql = @sql + ' order by ecc.ecc.'
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdSchedaValutazioneequalthis INT, @IdPrioritaequalthis INT, @IdPrioritaSelezionataequalthis INT, @IsMaxequalthis BIT',@IdSchedaValutazioneequalthis , @IdPrioritaequalthis , @IdPrioritaSelezionataequalthis , @IsMaxequalthis ;
	else
		SELECT ID_SCHEDA_VALUTAZIONE, ID_PRIORITA, ID_PRIORITA_SELEZIONATA, IS_MAX
		FROM PRIORITA_SPECIALE
		WHERE 
			((@IdSchedaValutazioneequalthis IS NULL) OR ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazioneequalthis) AND 
			((@IdPrioritaequalthis IS NULL) OR ID_PRIORITA = @IdPrioritaequalthis) AND 
			((@IdPrioritaSelezionataequalthis IS NULL) OR ID_PRIORITA_SELEZIONATA = @IdPrioritaSelezionataequalthis) AND 
			((@IsMaxequalthis IS NULL) OR IS_MAX = @IsMaxequalthis)
		-- order by ecc.ecc.
