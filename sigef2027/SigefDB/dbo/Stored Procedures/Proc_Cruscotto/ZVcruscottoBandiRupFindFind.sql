﻿CREATE PROCEDURE [dbo].[ZVcruscottoBandiRupFindFind]
(
	@IdRupequalthis INT, 
	@IdIstruttoreProgettoequalthis INT, 
	@IdIstruttoreDomandaPagamentoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO, COD_FASE_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, ID_ISTRUTTORE_DOMANDA_PAGAMENTO, ISTRUTTORE_DOMANDA_PAGAMENTO, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP FROM VCRUSCOTTO_BANDI_RUP WHERE 1=1';
	IF (@IdRupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RUP = @IdRupequalthis)'; set @lensql=@lensql+len(@IdRupequalthis);end;
	IF (@IdIstruttoreProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis)'; set @lensql=@lensql+len(@IdIstruttoreProgettoequalthis);end;
	IF (@IdIstruttoreDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE_DOMANDA_PAGAMENTO = @IdIstruttoreDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdIstruttoreDomandaPagamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRupequalthis INT, @IdIstruttoreProgettoequalthis INT, @IdIstruttoreDomandaPagamentoequalthis INT',@IdRupequalthis , @IdIstruttoreProgettoequalthis , @IdIstruttoreDomandaPagamentoequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, COD_ENTE_BANDO, ENTE_BANDO, ID_RUP, RUP, CF_RUP, DATA_APERTURA_BANDO, DATA_SCADENZA_BANDO, COD_STATO_BANDO, STATO_BANDO, SEGNATURA_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, SEGNATURA_PROGETTO, ID_IMPRESA, IMPRESA, CF_IMPRESA, CUAA_IMPRESA, ID_ISTRUTTORE_PROGETTO, ISTRUTTORE_PROGETTO, ID_DOMANDA_PAGAMENTO, SEGNATURA_DOMANDA_PAGAMENTO, SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO, COD_FASE_DOMANDA_PAGAMENTO, FASE_DOMANDA_PAGAMENTO, ANNULLATA, APPROVATA, ID_ISTRUTTORE_DOMANDA_PAGAMENTO, ISTRUTTORE_DOMANDA_PAGAMENTO, IMPORTO_RICHIESTO, CONTRIBUTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, IN_INTEGRAZIONE, FIRMA_PREDISPOSTA_RUP
		FROM VCRUSCOTTO_BANDI_RUP
		WHERE 
			((@IdRupequalthis IS NULL) OR ID_RUP = @IdRupequalthis) AND 
			((@IdIstruttoreProgettoequalthis IS NULL) OR ID_ISTRUTTORE_PROGETTO = @IdIstruttoreProgettoequalthis) AND 
			((@IdIstruttoreDomandaPagamentoequalthis IS NULL) OR ID_ISTRUTTORE_DOMANDA_PAGAMENTO = @IdIstruttoreDomandaPagamentoequalthis)
		

GO