CREATE PROCEDURE [dbo].[ZVisiteAziendaliFindSelect]
(
	@IdVisitaequalthis INT, 
	@IdDomandaPagamentoequalthis INT, 
	@IdDomandaEroaequalthis INT, 
	@IdImpresaequalthis INT, 
	@CodTipoequalthis CHAR(3), 
	@DataAperturaequalthis DATETIME, 
	@OperatoreAperturaequalthis VARCHAR(16), 
	@ControlloConclusoequalthis BIT, 
	@DataChiusuraequalthis DATETIME, 
	@OperatoreChiusuraequalthis VARCHAR(16), 
	@SegnaturaVerbaleequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO, ID_DOMANDA_EROA FROM vVISITE_AZIENDALI WHERE 1=1';
	IF (@IdVisitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_VISITA = @IdVisitaequalthis)'; set @lensql=@lensql+len(@IdVisitaequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdDomandaEroaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_EROA = @IdDomandaEroaequalthis)'; set @lensql=@lensql+len(@IdDomandaEroaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@DataAperturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APERTURA = @DataAperturaequalthis)'; set @lensql=@lensql+len(@DataAperturaequalthis);end;
	IF (@OperatoreAperturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_APERTURA = @OperatoreAperturaequalthis)'; set @lensql=@lensql+len(@OperatoreAperturaequalthis);end;
	IF (@ControlloConclusoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTROLLO_CONCLUSO = @ControlloConclusoequalthis)'; set @lensql=@lensql+len(@ControlloConclusoequalthis);end;
	IF (@DataChiusuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CHIUSURA = @DataChiusuraequalthis)'; set @lensql=@lensql+len(@DataChiusuraequalthis);end;
	IF (@OperatoreChiusuraequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_CHIUSURA = @OperatoreChiusuraequalthis)'; set @lensql=@lensql+len(@OperatoreChiusuraequalthis);end;
	IF (@SegnaturaVerbaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_VERBALE = @SegnaturaVerbaleequalthis)'; set @lensql=@lensql+len(@SegnaturaVerbaleequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdVisitaequalthis INT, @IdDomandaPagamentoequalthis INT, @IdDomandaEroaequalthis INT, @IdImpresaequalthis INT, @CodTipoequalthis CHAR(3), @DataAperturaequalthis DATETIME, @OperatoreAperturaequalthis VARCHAR(16), @ControlloConclusoequalthis BIT, @DataChiusuraequalthis DATETIME, @OperatoreChiusuraequalthis VARCHAR(16), @SegnaturaVerbaleequalthis VARCHAR(100)',@IdVisitaequalthis , @IdDomandaPagamentoequalthis , @IdDomandaEroaequalthis , @IdImpresaequalthis , @CodTipoequalthis , @DataAperturaequalthis , @OperatoreAperturaequalthis , @ControlloConclusoequalthis , @DataChiusuraequalthis , @OperatoreChiusuraequalthis , @SegnaturaVerbaleequalthis ;
	else
		SELECT ID_VISITA, ID_DOMANDA_PAGAMENTO, ID_IMPRESA, COD_TIPO, DATA_APERTURA, OPERATORE_APERTURA, CONTROLLO_CONCLUSO, DATA_CHIUSURA, OPERATORE_CHIUSURA, SEGNATURA_VERBALE, TIPO_VISITA_AZIENDALE, NOMINATIVO_OPERATORE_APERTURA, NOMINATIVO_OPERATORE_CHIUSURA, ID_PROGETTO, TIPO_DOMANDA_PAGAMENTO, ID_DOMANDA_EROA
		FROM vVISITE_AZIENDALI
		WHERE 
			((@IdVisitaequalthis IS NULL) OR ID_VISITA = @IdVisitaequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdDomandaEroaequalthis IS NULL) OR ID_DOMANDA_EROA = @IdDomandaEroaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@DataAperturaequalthis IS NULL) OR DATA_APERTURA = @DataAperturaequalthis) AND 
			((@OperatoreAperturaequalthis IS NULL) OR OPERATORE_APERTURA = @OperatoreAperturaequalthis) AND 
			((@ControlloConclusoequalthis IS NULL) OR CONTROLLO_CONCLUSO = @ControlloConclusoequalthis) AND 
			((@DataChiusuraequalthis IS NULL) OR DATA_CHIUSURA = @DataChiusuraequalthis) AND 
			((@OperatoreChiusuraequalthis IS NULL) OR OPERATORE_CHIUSURA = @OperatoreChiusuraequalthis) AND 
			((@SegnaturaVerbaleequalthis IS NULL) OR SEGNATURA_VERBALE = @SegnaturaVerbaleequalthis)
