CREATE PROCEDURE [dbo].[ZVisiteAziendaliFindFind]
(
	@IdVisitaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@IdProgettoequalthis INT, 
	@IdDomandaEroaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO, ID_DOMANDA_EROA FROM vVISITE_AZIENDALI WHERE 1=1';
	IF (@IdVisitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VISITA = @IdVisitaequalthis)'; set @lensql=@lensql+len(@IdVisitaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdDomandaEroaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_EROA = @IdDomandaEroaequalthis)'; set @lensql=@lensql+len(@IdDomandaEroaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_VISITA DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVisitaequalthis INT, @IdDomandaPagamentoequalthis INT, @IdImpresaequalthis INT, @CodTipoequalthis CHAR(3), @IdProgettoequalthis INT, @IdDomandaEroaequalthis INT',@IdVisitaequalthis , @IdDomandaPagamentoequalthis , @IdImpresaequalthis , @CodTipoequalthis , @IdProgettoequalthis , @IdDomandaEroaequalthis ;
	else
		SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO, ID_DOMANDA_EROA
		FROM vVISITE_AZIENDALI
		WHERE 
			((@IdVisitaequalthis IS NULL) OR ID_VISITA = @IdVisitaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdDomandaEroaequalthis IS NULL) OR ID_DOMANDA_EROA = @IdDomandaEroaequalthis)
		ORDER BY ID_VISITA DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVisiteAziendaliFindFind]
(
	@IdVisitaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@IdProgettoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO FROM vVISITE_AZIENDALI WHERE 1=1'';
	IF (@IdVisitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_VISITA = @IdVisitaequalthis)''; set @lensql=@lensql+len(@IdVisitaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)''; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_TIPO = @CodTipoequalthis)''; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	set @sql = @sql + ''ORDER BY ID_VISITA DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdVisitaequalthis INT, @IdDomandaPagamentoequalthis INT, @IdImpresaequalthis INT, @CodTipoequalthis CHAR(3), @IdProgettoequalthis INT'',@IdVisitaequalthis , @IdDomandaPagamentoequalthis , @IdImpresaequalthis , @CodTipoequalthis , @IdProgettoequalthis ;
	else
		SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO
		FROM vVISITE_AZIENDALI
		WHERE 
			((@IdVisitaequalthis IS NULL) OR ID_VISITA = @IdVisitaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis)
		ORDER BY ID_VISITA DESC

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVisiteAziendaliFindFind';

