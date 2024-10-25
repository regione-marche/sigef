CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneSpostamentiFindFind]
(
	@IdCorrettivaequalthis INT, 
	@IdInvestimentoDaequalthis INT, 
	@IdInvestimentoAequalthis INT, 
	@Conclusoequalthis BIT, 
	@Annullatoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_CORRETTIVA, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSO, ANNULLATO, ID_UTENTE, DATA, DESCRIZIONE, ID_JSON_LOG FROM CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI WHERE 1=1';
	IF (@IdCorrettivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CORRETTIVA = @IdCorrettivaequalthis)'; set @lensql=@lensql+len(@IdCorrettivaequalthis);end;
	IF (@IdInvestimentoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis)'; set @lensql=@lensql+len(@IdInvestimentoDaequalthis);end;
	IF (@IdInvestimentoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_A = @IdInvestimentoAequalthis)'; set @lensql=@lensql+len(@IdInvestimentoAequalthis);end;
	IF (@Conclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONCLUSO = @Conclusoequalthis)'; set @lensql=@lensql+len(@Conclusoequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATO = @Annullatoequalthis)'; set @lensql=@lensql+len(@Annullatoequalthis);end;
	set @sql = @sql + 'ORDER BY ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdCorrettivaequalthis INT, @IdInvestimentoDaequalthis INT, @IdInvestimentoAequalthis INT, @Conclusoequalthis BIT, @Annullatoequalthis BIT',@IdCorrettivaequalthis , @IdInvestimentoDaequalthis , @IdInvestimentoAequalthis , @Conclusoequalthis , @Annullatoequalthis ;
	else
		SELECT ID, ID_CORRETTIVA, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSO, ANNULLATO, ID_UTENTE, DATA, DESCRIZIONE, ID_JSON_LOG
		FROM CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI
		WHERE 
			((@IdCorrettivaequalthis IS NULL) OR ID_CORRETTIVA = @IdCorrettivaequalthis) AND 
			((@IdInvestimentoDaequalthis IS NULL) OR ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis) AND 
			((@IdInvestimentoAequalthis IS NULL) OR ID_INVESTIMENTO_A = @IdInvestimentoAequalthis) AND 
			((@Conclusoequalthis IS NULL) OR CONCLUSO = @Conclusoequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis)
		ORDER BY ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneSpostamentiFindFind';

