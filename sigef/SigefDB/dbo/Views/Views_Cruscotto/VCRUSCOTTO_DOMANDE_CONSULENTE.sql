﻿CREATE VIEW [dbo].[VCRUSCOTTO_DOMANDE_CONSULENTE]
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
		MAN.ID_IMPRESA,
		MAN.RAGIONE_SOCIALE AS RAGIONE_SOCIALE_IMPRESA,
		UT.ID_UTENTE, 
		UT.NOMINATIVO AS NOMINATIVO_UTENTE_IMPRESA, 
		UT.CF_UTENTE AS CF_UTENTE_IMPRESA, 
		UT.ATTIVO AS UTENTE_ATTIVO
	FROM vBANDO AS BAN
		JOIN vPROGETTO AS PROG ON PROG.ID_BANDO = BAN.ID_BANDO 
		JOIN vMANDATI_IMPRESA AS MAN ON PROG.ID_IMPRESA = MAN.ID_IMPRESA
		JOIN vUTENTI AS UT ON MAN.ID_UTENTE_ABILITATO = UT.ID_UTENTE
	WHERE 1 = 1
		AND MAN.ATTIVO = 1
		AND GETDATE() BETWEEN MAN.DATA_INIZIO_VALIDITA AND MAN.DATA_FINE_VALIDITA;