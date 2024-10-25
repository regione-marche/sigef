CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneSpostamentiFindSelect]
(
	@Idequalthis INT, 
	@IdCorrettivaequalthis INT, 
	@IdInvestimentoDaequalthis INT, 
	@IdInvestimentoAequalthis INT, 
	@ImportoSpostatoequalthis DECIMAL(18,2), 
	@Conclusoequalthis BIT, 
	@Annullatoequalthis BIT, 
	@IdUtenteequalthis INT, 
	@Dataequalthis DATETIME, 
	@Descrizioneequalthis VARCHAR(255), 
	@IdJsonLogequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_CORRETTIVA, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSO, ANNULLATO, ID_UTENTE, DATA, DESCRIZIONE, ID_JSON_LOG FROM CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdCorrettivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CORRETTIVA = @IdCorrettivaequalthis)'; set @lensql=@lensql+len(@IdCorrettivaequalthis);end;
	IF (@IdInvestimentoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis)'; set @lensql=@lensql+len(@IdInvestimentoDaequalthis);end;
	IF (@IdInvestimentoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_A = @IdInvestimentoAequalthis)'; set @lensql=@lensql+len(@IdInvestimentoAequalthis);end;
	IF (@ImportoSpostatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_SPOSTATO = @ImportoSpostatoequalthis)'; set @lensql=@lensql+len(@ImportoSpostatoequalthis);end;
	IF (@Conclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONCLUSO = @Conclusoequalthis)'; set @lensql=@lensql+len(@Conclusoequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATO = @Annullatoequalthis)'; set @lensql=@lensql+len(@Annullatoequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@Dataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA = @Dataequalthis)'; set @lensql=@lensql+len(@Dataequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@IdJsonLogequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_JSON_LOG = @IdJsonLogequalthis)'; set @lensql=@lensql+len(@IdJsonLogequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdCorrettivaequalthis INT, @IdInvestimentoDaequalthis INT, @IdInvestimentoAequalthis INT, @ImportoSpostatoequalthis DECIMAL(18,2), @Conclusoequalthis BIT, @Annullatoequalthis BIT, @IdUtenteequalthis INT, @Dataequalthis DATETIME, @Descrizioneequalthis VARCHAR(255), @IdJsonLogequalthis INT',@Idequalthis , @IdCorrettivaequalthis , @IdInvestimentoDaequalthis , @IdInvestimentoAequalthis , @ImportoSpostatoequalthis , @Conclusoequalthis , @Annullatoequalthis , @IdUtenteequalthis , @Dataequalthis , @Descrizioneequalthis , @IdJsonLogequalthis ;
	else
		SELECT ID, ID_CORRETTIVA, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSO, ANNULLATO, ID_UTENTE, DATA, DESCRIZIONE, ID_JSON_LOG
		FROM CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdCorrettivaequalthis IS NULL) OR ID_CORRETTIVA = @IdCorrettivaequalthis) AND 
			((@IdInvestimentoDaequalthis IS NULL) OR ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis) AND 
			((@IdInvestimentoAequalthis IS NULL) OR ID_INVESTIMENTO_A = @IdInvestimentoAequalthis) AND 
			((@ImportoSpostatoequalthis IS NULL) OR IMPORTO_SPOSTATO = @ImportoSpostatoequalthis) AND 
			((@Conclusoequalthis IS NULL) OR CONCLUSO = @Conclusoequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@Dataequalthis IS NULL) OR DATA = @Dataequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@IdJsonLogequalthis IS NULL) OR ID_JSON_LOG = @IdJsonLogequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneSpostamentiFindSelect';

