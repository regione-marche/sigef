﻿CREATE PROCEDURE dbo.SpCruscottoGetVarianti
(
	@IdUtente INT
)
AS
	/*
	//PRECEDENTEMENTE ERA
	SELECT * 
	FROM VCRUSCOTTO_VARIANTI
	WHERE 1 = 1 
		AND ((FIRMA_PREDISPOSTA_RUP = 1 AND ID_UTENTE_RUP = @IdUtente) 
			OR ID_UTENTE_ISTRUTTORE = @IdUtente 
			OR ID_OPERATORE_FIRMA_COMITATO = @IdUtente);
	*/

	SELECT * 
	FROM VCRUSCOTTO_VARIANTI
	WHERE 1 = 1 
	AND (ID_UTENTE_RUP = @IdUtente 
		OR ID_UTENTE_ISTRUTTORE = @IdUtente 
		OR ID_OPERATORE_FIRMA_COMITATO = @IdUtente);