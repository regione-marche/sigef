﻿CREATE PROCEDURE [dbo].[SpGetPrioritaConAiutoAddizionale]
(
	@ID_PROGETTO INT=NULL
)
AS
SELECT     PRIORITA_X_PROGETTO.ID_PROGETTO, PRIORITA_X_PROGETTO.ID_PRIORITA, PRIORITA_X_PROGETTO.VALORE, PRIORITA_X_PROGETTO.DATA_VALUTAZIONE, 
                      PRIORITA_X_PROGETTO.OPERATORE_VALUTAZIONE, PRIORITA_X_PROGETTO.MODIFICA_MANUALE, PRIORITA.DESCRIZIONE AS PRIORITA, 
                      PRIORITA.COD_LIVELLO, PRIORITA.PLURI_VALORE, PRIORITA.EVAL, PRIORITA.FLAG_MANUALE, VALORI_PRIORITA.DESCRIZIONE AS VALORE_DESC, 
                      PRIORITA_X_PROGETTO.ID_VALORE, PRIORITA_X_PROGETTO.PUNTEGGIO, PRIORITA.INPUT_NUMERICO, PRIORITA.MISURA, PRIORITA.DATETIME, 
                      PRIORITA.TESTO_SEMPLICE, PRIORITA.TESTO_AREA, PRIORITA.PLURI_VALORE_SQL, PRIORITA.QUERY_PLURIVALORE, PRIORITA_X_PROGETTO.VAL_DATA, PRIORITA_X_PROGETTO.VAL_TESTO
FROM         PRIORITA_X_PROGETTO INNER JOIN
                      PRIORITA ON PRIORITA_X_PROGETTO.ID_PRIORITA = PRIORITA.ID_PRIORITA INNER JOIN
                      PROGETTO ON PRIORITA_X_PROGETTO.ID_PROGETTO = PROGETTO.ID_PROGETTO INNER JOIN
                      BANDO ON PROGETTO.ID_BANDO = BANDO.ID_BANDO INNER JOIN
                      SCHEDA_VALUTAZIONE ON BANDO.ID_SCHEDA_VALUTAZIONE = SCHEDA_VALUTAZIONE.ID_SCHEDA_VALUTAZIONE INNER JOIN
                      SCHEDA_X_PRIORITA ON PRIORITA.ID_PRIORITA = SCHEDA_X_PRIORITA.ID_PRIORITA AND 
                      SCHEDA_VALUTAZIONE.ID_SCHEDA_VALUTAZIONE = SCHEDA_X_PRIORITA.ID_SCHEDA_VALUTAZIONE LEFT OUTER JOIN
                      VALORI_PRIORITA ON PRIORITA_X_PROGETTO.ID_VALORE = VALORI_PRIORITA.ID_VALORE
where 
PRIORITA_X_PROGETTO.ID_PROGETTO = @ID_PROGETTO and SCHEDA_X_PRIORITA.AIUTO_ADDIZIONALE is not null and SCHEDA_X_PRIORITA.AIUTO_ADDIZIONALE <> 0