﻿CREATE PROCEDURE SpGetUltimaTestataValidazioneDomandeRup
(
	@ID_UTENTE INT,
	@ID_BANDO INT = NULL,
	@ID_PROGETTO INT = NULL,
	@ID_DOMANDA_PAGAMENTO INT = NULL
)
AS
	DECLARE @CF_VALIDATORE VARCHAR(16)

	SELECT @CF_VALIDATORE = CF_UTENTE 
	FROM vUTENTI 
	WHERE ID_UTENTE = @ID_UTENTE
	
	SELECT R.ID_TESTATA,
		--R.ID_ISTANZA_CHECKLIST_GENERICA,
		R.ID_DOMANDA_PAGAMENTO,
		R.TIPO_DOMANDA_PAGAMENTO,
		R.COD_FASE,
		R.DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO,
		R.DOMANDA_APPROVATA,
		R.SEGNATURA_APPROVAZIONE_DOMANDA,
		R.ID_PROGETTO,
		R.ID_LOTTO,
		R.CF_INSERIMENTO,
		R.DATA_INSERIMENTO,
		R.CF_MODIFICA,
		R.DATA_MODIFICA,
		R.CF_VALIDATORE,
		R.NOMINATIVO_VALIDATORE,
		R.SELEZIONATA_X_REVISIONE,
		R.APPROVATA,
		R.NUMERO_ESTRAZIONE,
		R.ORDINE,
		R.SEGNATURA_REVISIONE,
		R.SEGNATURA_SECONDA_REVISIONE,
		R.DATA_VALIDAZIONE,
		R.AUTOVALUTAZIONE,
		R.COD_TIPO,
		R.DATA_APPROVAZIONE,
		R.ID_BANDO,
		R.PROVINCIA_DI_PRESENTAZIONE,

		B.DESCRIZIONE 
	FROM (SELECT *, 
			ROW_NUMBER() OVER(PARTITION BY ID_DOMANDA_PAGAMENTO ORDER BY DATA_INSERIMENTO DESC) AS RN
			FROM VTESTATA_VALIDAZIONE) R
		JOIN BANDO B ON B.ID_BANDO = R.ID_BANDO
	WHERE 1 = 1
		AND R.RN = 1
		AND ((@ID_BANDO IS NULL 
				AND R.ID_BANDO IN (SELECT DISTINCT ID_BANDO 
									FROM BANDO_RESPONSABILI 
									WHERE ID_UTENTE = @ID_UTENTE 
									AND ATTIVO = 1)) 
			OR R.ID_BANDO = @ID_BANDO) 
		AND (@ID_PROGETTO IS NULL OR R.ID_PROGETTO = @ID_PROGETTO) 
		AND (@ID_DOMANDA_PAGAMENTO IS NULL OR R.ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO) 
		AND ID_LOTTO IS NOT NULL

	UNION

	SELECT R.ID_TESTATA,
		--R.ID_ISTANZA_CHECKLIST_GENERICA,
		R.ID_DOMANDA_PAGAMENTO,
		R.TIPO_DOMANDA_PAGAMENTO,
		R.COD_FASE,
		R.DATA_PRESENTAZIONE_DOMANDA_PAGAMENTO,
		R.DOMANDA_APPROVATA,
		R.SEGNATURA_APPROVAZIONE_DOMANDA,
		R.ID_PROGETTO,
		R.ID_LOTTO,
		R.CF_INSERIMENTO,
		R.DATA_INSERIMENTO,
		R.CF_MODIFICA,
		R.DATA_MODIFICA,
		R.CF_VALIDATORE,
		R.NOMINATIVO_VALIDATORE,
		R.SELEZIONATA_X_REVISIONE,
		R.APPROVATA,
		R.NUMERO_ESTRAZIONE,
		R.ORDINE,
		R.SEGNATURA_REVISIONE,
		R.SEGNATURA_SECONDA_REVISIONE,
		R.DATA_VALIDAZIONE,
		R.AUTOVALUTAZIONE,
		R.COD_TIPO,
		R.DATA_APPROVAZIONE,
		R.ID_BANDO,
		R.PROVINCIA_DI_PRESENTAZIONE,

		B.DESCRIZIONE 
	FROM (SELECT *, 
			ROW_NUMBER() OVER(PARTITION BY ID_DOMANDA_PAGAMENTO ORDER BY DATA_INSERIMENTO DESC) AS RN
			FROM VTESTATA_VALIDAZIONE) R
		JOIN BANDO B ON B.ID_BANDO = R.ID_BANDO
	WHERE 1 = 1
		AND R.RN = 1
		AND (@ID_BANDO IS NULL OR R.ID_BANDO = @ID_BANDO) 
		AND (@ID_PROGETTO IS NULL OR R.ID_PROGETTO = @ID_PROGETTO) 
		AND (@ID_DOMANDA_PAGAMENTO IS NULL OR R.ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO)
		AND ID_LOTTO IS NOT NULL 
		AND CF_VALIDATORE = @CF_VALIDATORE
GO