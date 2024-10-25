﻿-- DROP VIEW VERRORE;
CREATE VIEW VERRORE
AS
	SELECT ER.*, 
		ASSE.ID AS ID_ASSE,
		BAN.ID_BANDO,
		BAN.DESCRIZIONE AS DESCRIZIONE_BANDO,
		BAN.DATA_SCADENZA AS DATA_SCADENZA_BANDO,
		PROG.COD_STATO AS COD_STATO_PROGETTO,
		PROG.STATO AS STATO_PROGETTO
		/*,IMP.CODICE_FISCALE AS CODICE_FISCALE_IMPRESA_BENEFICIARIO,
		IMP.CUAA AS CUAA_IMPRESA_BENEFICIARIO,
		IMP.RAGIONE_SOCIALE AS RAGIONE_SOCIALE_IMPRESA_BENEFICIARIO*/
	FROM ERRORE ER
		JOIN VPROGETTO PROG ON ER.ID_PROGETTO = PROG.ID_PROGETTO
		LEFT JOIN VDOMANDA_DI_PAGAMENTO DOM ON ER.ID_DOMANDA_PAGAMENTO = DOM.ID_DOMANDA_PAGAMENTO
		JOIN VBANDO BAN ON PROG.ID_BANDO = BAN.ID_BANDO
		JOIN vBANDO_PROGRAMMAZIONE BAN_P ON BAN.ID_BANDO = BAN_P.ID_BANDO
									AND BAN_P.ID_PROGRAMMAZIONE NOT IN (17, 18, 19)
		JOIN zPROGRAMMAZIONE TI ON BAN_P.ID_PROGRAMMAZIONE = TI.ID
		JOIN zPROGRAMMAZIONE AZIONE ON TI.ID_PADRE = AZIONE.ID
		JOIN zPROGRAMMAZIONE ASSE ON AZIONE.ID_PADRE = ASSE.ID
		--LEFT JOIN vIMPRESA IMP ON ER.ID_IMPRESA_BENEFICIARIO = IMP.ID_IMPRESA
;
GO