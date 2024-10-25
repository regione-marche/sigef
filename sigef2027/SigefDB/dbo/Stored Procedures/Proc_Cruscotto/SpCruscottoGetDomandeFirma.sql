CREATE PROCEDURE dbo.SpCruscottoGetDomandeFirma
(
	@IdUtente INT,
	@CodStatoProgetto varchar = null,
    @CodIdDomandaPagamento int = null,
    @CodIdProgetto int = null


)
AS
	SELECT * 
	FROM VCRUSCOTTO_DOMANDE
	WHERE 1 = 1 
	AND ((FIRMA_PREDISPOSTA_RUP = 1 
			AND ID_UTENTE_RUP = @IdUtente) 
		OR ID_UTENTE_ISTRUTTORE = @IdUtente)
	AND ((@CodStatoProgetto IS NULL) OR (COD_STATO_PROGETTO = @CodStatoProgetto))
	AND ((@CodIdDomandaPagamento IS NULL ) OR ( ID_DOMANDA_PAGAMENTO = @CodIdDomandaPagamento))
	AND ((@CodIdProgetto IS NULL ) OR (ID_PROGETTO = @CodIdProgetto));
  