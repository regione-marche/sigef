﻿CREATE PROCEDURE dbo.SpCruscottoGetDomandeBeneficiario
(
	@IdUtente INT
)
AS
	SELECT * 
	FROM VCRUSCOTTO_DOMANDE_BENEFICIARIO
	WHERE 1 = 1 
		AND ((@IdUtente IS NULL) OR (@IdUtente = ID_UTENTE))
	ORDER BY 
		DATA_SCADENZA_BANDO ASC,
		ID_BANDO ASC,
		ID_PROGETTO ASC,
		ID_UTENTE ASC;