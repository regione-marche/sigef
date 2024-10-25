CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@Annullataequalthis BIT, 
	@Conclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_DOMANDA_PAGAMENTO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, NOTE, NOMINATIVO, COD_ENTE FROM vCORRETTIVA_RENDICONTAZIONE WHERE 1=1';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATA = @Annullataequalthis)'; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@Conclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONCLUSA = @Conclusaequalthis)'; set @lensql=@lensql+len(@Conclusaequalthis);end;
	set @sql = @sql + 'ORDER BY ID';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdDomandaPagamentoequalthis INT, @Annullataequalthis BIT, @Conclusaequalthis BIT',@IdDomandaPagamentoequalthis , @Annullataequalthis , @Conclusaequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, NOTE, NOMINATIVO, COD_ENTE
		FROM vCORRETTIVA_RENDICONTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@Conclusaequalthis IS NULL) OR CONCLUSA = @Conclusaequalthis)
		ORDER BY ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneFindFind]
(
	@IdDomandaPagamentoequalthis INT, 
	@IdInvestimentoDaequalthis INT, 
	@IdInvestimentoAequalthis INT, 
	@Annullataequalthis BIT, 
	@Conclusaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_DOMANDA_PAGAMENTO, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, ID_JSON_LOG, CF_UTENTE, NOMINATIVO, PROVINCIA, ENTE, PROFILO, COD_ENTE, NOTE FROM vCORRETTIVA_RENDICONTAZIONE WHERE 1=1'';
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdInvestimentoDaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis)''; set @lensql=@lensql+len(@IdInvestimentoDaequalthis);end;
	IF (@IdInvestimentoAequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO_A = @IdInvestimentoAequalthis)''; set @lensql=@lensql+len(@IdInvestimentoAequalthis);end;
	IF (@Annullataequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNULLATA = @Annullataequalthis)''; set @lensql=@lensql+len(@Annullataequalthis);end;
	IF (@Conclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CONCLUSA = @Conclusaequalthis)''; set @lensql=@lensql+len(@Conclusaequalthis);end;
	set @sql = @sql + ''ORDER BY DATA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdDomandaPagamentoequalthis INT, @IdInvestimentoDaequalthis INT, @IdInvestimentoAequalthis INT, @Annullataequalthis BIT, @Conclusaequalthis BIT'',@IdDomandaPagamentoequalthis , @IdInvestimentoDaequalthis , @IdInvestimentoAequalthis , @Annullataequalthis , @Conclusaequalthis ;
	else
		SELECT ID, ID_DOMANDA_PAGAMENTO, ID_INVESTIMENTO_DA, ID_INVESTIMENTO_A, IMPORTO_SPOSTATO, CONCLUSA, ANNULLATA, ID_UTENTE, DATA, ID_NOTE, ID_JSON_LOG, CF_UTENTE, NOMINATIVO, PROVINCIA, ENTE, PROFILO, COD_ENTE, NOTE
		FROM vCORRETTIVA_RENDICONTAZIONE
		WHERE 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdInvestimentoDaequalthis IS NULL) OR ID_INVESTIMENTO_DA = @IdInvestimentoDaequalthis) AND 
			((@IdInvestimentoAequalthis IS NULL) OR ID_INVESTIMENTO_A = @IdInvestimentoAequalthis) AND 
			((@Annullataequalthis IS NULL) OR ANNULLATA = @Annullataequalthis) AND 
			((@Conclusaequalthis IS NULL) OR CONCLUSA = @Conclusaequalthis)
		ORDER BY DATA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneFindFind';

