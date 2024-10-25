﻿CREATE VIEW VCRUSCOTTO_DOMANDE_BENEFICIARIO
AS 
	SELECT 
		BAN.ID_BANDO, 
		BAN.DESCRIZIONE AS DESCRIZIONE_BANDO, 
		BAN.DATA_SCADENZA AS DATA_SCADENZA_BANDO, 
		BAN.COD_ENTE AS COD_ENTE_BANDO,
		BAN.ID_PROGRAMMAZIONE AS ID_PROGRAMMAZIONE_BANDO,
		PROG.ID_PROGETTO, 
		PROG.COD_STATO AS COD_STATO_PROGETTO,
		PROG.STATO AS STATO_PROGETTO, 
		IMP.ID_IMPRESA,
		IMP.RAGIONE_SOCIALE AS RAGIONE_SOCIALE_IMPRESA,
		UT.ID_UTENTE, 
		UT.NOMINATIVO AS NOMINATIVO_UTENTE_IMPRESA, 
		UT.CF_UTENTE AS CF_UTENTE_IMPRESA, 
		UT.ATTIVO AS UTENTE_ATTIVO,
		PERS_X_IMP.COD_RUOLO AS COD_RUOLO_UTENTE_IMPRESA,
		PERS_X_IMP.RUOLO AS RUOLO_UTENTE_IMPRESA,
		PERS_X_IMP.DATA_INIZIO AS DATA_INIZIO_UTENTE_IMPRESA,
		PERS_X_IMP.DATA_FINE AS DATA_FINE_UTENTE_IMPRESA,
		PERS_X_IMP.POTERE_DI_FIRMA AS POTERE_DI_FIRMA_UTENTE_IMPRESA
	FROM vBANDO BAN
		JOIN vPROGETTO PROG ON PROG.ID_BANDO = BAN.ID_BANDO 
		JOIN vIMPRESA IMP ON IMP.ID_IMPRESA = PROG.ID_IMPRESA 
		JOIN vPERSONE_X_IMPRESE PERS_X_IMP ON PERS_X_IMP.ID_IMPRESA = IMP.ID_IMPRESA 
		JOIN vUTENTI UT ON UT.CF_UTENTE = PERS_X_IMP.CODICE_FISCALE
	WHERE 1 = 1
		AND PERS_X_IMP.ATTIVO = 1