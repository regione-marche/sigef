CREATE PROCEDURE [dbo].[ZLottoDiRevisioneFindFind]
(
	@IdLottoequalthis INT, 
	@IdBandoequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@NumeroEstrazioniequalthis INT, 
	@RevisioneConclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE FROM vLOTTO_DI_REVISIONE WHERE 1=1';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_LOTTO = @IdLottoequalthis)'; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@NumeroEstrazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis)'; set @lensql=@lensql+len(@NumeroEstrazioniequalthis);end;
	IF (@RevisioneConclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)'; set @lensql=@lensql+len(@RevisioneConclusaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_LOTTO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdLottoequalthis INT, @IdBandoequalthis INT, @Provinciaequalthis VARCHAR(255), @NumeroEstrazioniequalthis INT, @RevisioneConclusaequalthis BIT',@IdLottoequalthis , @IdBandoequalthis , @Provinciaequalthis , @NumeroEstrazioniequalthis , @RevisioneConclusaequalthis ;
	else
		SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE
		FROM vLOTTO_DI_REVISIONE
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@NumeroEstrazioniequalthis IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis) AND 
			((@RevisioneConclusaequalthis IS NULL) OR REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)
		ORDER BY ID_LOTTO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZLottoDiRevisioneFindFind]
(
	@IdLottoequalthis INT, 
	@IdBandoequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@NumeroEstrazioniequalthis INT, 
	@RevisioneConclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE FROM vLOTTO_DI_REVISIONE WHERE 1=1'';
	IF (@IdLottoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_LOTTO = @IdLottoequalthis)''; set @lensql=@lensql+len(@IdLottoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA = @Provinciaequalthis)''; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@NumeroEstrazioniequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis)''; set @lensql=@lensql+len(@NumeroEstrazioniequalthis);end;
	IF (@RevisioneConclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)''; set @lensql=@lensql+len(@RevisioneConclusaequalthis);end;
	set @sql = @sql + ''ORDER BY DATA_CREAZIONE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdLottoequalthis INT, @IdBandoequalthis INT, @Provinciaequalthis CHAR(2), @NumeroEstrazioniequalthis INT, @RevisioneConclusaequalthis BIT'',@IdLottoequalthis , @IdBandoequalthis , @Provinciaequalthis , @NumeroEstrazioniequalthis , @RevisioneConclusaequalthis ;
	else
		SELECT ID_LOTTO, ID_BANDO, PROVINCIA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, NUMERO_ESTRAZIONI, REVISIONE_CONCLUSA, NUMERO_DOMANDE_ASSEGNATE, NUMERO_DOMANDE_ESTRATTE, OPERATORE
		FROM vLOTTO_DI_REVISIONE
		WHERE 
			((@IdLottoequalthis IS NULL) OR ID_LOTTO = @IdLottoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@NumeroEstrazioniequalthis IS NULL) OR NUMERO_ESTRAZIONI = @NumeroEstrazioniequalthis) AND 
			((@RevisioneConclusaequalthis IS NULL) OR REVISIONE_CONCLUSA = @RevisioneConclusaequalthis)
		ORDER BY DATA_CREAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZLottoDiRevisioneFindFind';

