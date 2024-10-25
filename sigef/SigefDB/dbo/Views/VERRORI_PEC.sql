﻿CREATE VIEW [dbo].[VERRORI_PEC] 
AS
SELECT ER.*,
	PRS.ID_PROGETTO AS ID_PROGETTO_STORICO,
	PCE.ID_PROGETTO AS ID_PROGETTO_COMUNICAZIONE,
	PCI.ID_PROGETTO AS ID_PROGETTO_COMUNICAZIONI,
	PROGS.ID_PROGETTO AS ID_PROGETTO_SEGNATURE,
	INTE.ID_DOMANDA_PAGAMENTO AS ID_DOMANDA_INTEGRAZIONI,
	DOM.ID_PROGETTO AS ID_PROGETTO_DOMANDA,
	DOM.ID_DOMANDA_PAGAMENTO AS ID_DOMANDA_PAGAMENTO,
	DOMS.ID_DOMANDA_PAGAMENTO AS ID_DOMANDA_PAGAMENTO_SEGNATURE,
	VA.ID_VARIANTE AS ID_VARIANTE
FROM ERRORI_PEC ER
	LEFT JOIN PROGETTO_STORICO PRS 
		ON (ER.SEGNATURA = PRS.SEGNATURA 
			OR ER.SEGNATURA = PRS.SEGNATURA_RI)
	LEFT JOIN PROGETTO_COMUNICAZIONE PCE
		ON ER.SEGNATURA = PCE.SEGNATURA 
	LEFT JOIN PROGETTO_COMUNICAZIONI PCI
		ON (ER.SEGNATURA = PCI.SEGNATURA
			OR ER.SEGNATURA = PCI.SEGNATURA_ISTRUTTORIA)
	LEFT jOIN PROGETTO_SEGNATURE PROGS
		ON ER.SEGNATURA = PROGS.SEGNATURA
	LEFT JOIN INTEGRAZIONI_PER_DOMANDA_DI_PAGAMENTO INTE 
		ON (ER.SEGNATURA = INTE.SEGNATURA_ISTRUTTORE 
			OR ER.SEGNATURA = INTE.SEGNATURA_BENEFICIARIO)
	LEFT JOIN DOMANDA_DI_PAGAMENTO DOM 
		ON (ER.SEGNATURA = DOM.SEGNATURA 
			OR ER.SEGNATURA = DOM.SEGNATURA_ALLEGATI
			OR ER.SEGNATURA = DOM.SEGNATURA_ANNULLAMENTO 
			OR ER.SEGNATURA = DOM.SEGNATURA_APPROVAZIONE 
			OR ER.SEGNATURA = DOM.SEGNATURA_SECONDA_APPROVAZIONE)
	LEFT JOIN DOMANDA_DI_PAGAMENTO_SEGNATURE DOMS
		ON ER.SEGNATURA = DOMS.SEGNATURA
	LEFT JOIN VARIANTI_SEGNATURE VA
		ON ER.SEGNATURA = VA.SEGNATURA;