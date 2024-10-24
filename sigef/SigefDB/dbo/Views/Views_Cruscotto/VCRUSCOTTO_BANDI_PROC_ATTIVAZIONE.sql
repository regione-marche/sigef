﻿CREATE VIEW VCRUSCOTTO_BANDI_PROC_ATTIVAZIONE
AS
SELECT DISTINCT 
	BAN.*,
	UT.ID_UTENTE AS ID_UTENTE_RUP,
	UT.CF_UTENTE AS CF_RUP,
	UT.NOMINATIVO AS RUP
	--COUNT(*) OVER (PARTITION BY BAN.ID_BANDO) AS CHECK_FESR
FROM VBANDO BAN
	JOIN BANDO_PROGRAMMAZIONE BND ON BAN.ID_BANDO = BND.ID_BANDO
	JOIN zPROGRAMMAZIONE PRG ON BND.ID_PROGRAMMAZIONE = PRG.ID
	JOIN zPSR_ALBERO ALB ON PRG.COD_TIPO = ALB.CODICE
	JOIN BANDO_RESPONSABILI RESP ON BAN.ID_BANDO = RESP.ID_BANDO
	JOIN vUTENTI UT ON RESP.ID_UTENTE = UT.ID_UTENTE
	LEFT JOIN  BANDO_CODICI_ATTIVAZIONE BCA ON BAN.ID_BANDO = BCA.ID_BANDO
WHERE 1 = 1
	-- TUTTI I BANDI PUBBLICATI
	AND BAN.COD_STATO != 'P'
	-- SOLO BANDI FESR
	AND ALB.COD_PSR = 'POR20142020'
	-- SOLO I RUP ATTIVI
	AND RESP.ATTIVO = 1
	AND RESP.PROVINCIA IS NULL
	-- SENZA COD_PROCEDURA_ATTIVAZIONE
	AND BCA.COD_PROCEDURA_ATTIVAZIONE IS NULL

GO