-- DROP VIEW VREGISTRO_CONTROLLI;
CREATE VIEW VREGISTRO_CONTROLLI
AS
-- Controllo I livello in loco
SELECT 
	LO.Asse,
	LO.Azione,
	LO.Intervento,
	LO.IdLoco AS Id_Lotto,
	LO.Id_Progetto,
	LO.Beneficiario,
	'Controllo I livello in loco' AS Tipo_controllo,
	LO.ENTE_VALIDATORE AS Soggetto_rilevazione,
	LO.NOMINATIVO_VALIDATORE AS Controllore,
	LO.DATA_SEGNATURA AS Data,
	LO.SEGNATURA_TESTATA AS Segnatura,
	CASE 
		WHEN LO.ESITO_TESTATA IS NOT NULL AND LO.ESITO_TESTATA = 1 THEN 'Positivo'
		ELSE 'Negativo'
	END AS Esito,
	LO.Id_Domanda_Pagamento,
	DOM.FASE AS Stato,
	LO.SpesaAmmessa AS Spesa_ammessa,
	LO.ImportoAmmesso AS Contributo_rendicontato,
	SUM(ISNULL(RE.CONTRIBUTO_PUBBLICO_ERRORE, RE.Importo_da_Recuperare_totale)) AS Contributo_irregolare
FROM VTESTATA_CONTROLLI_LOCO LO
	JOIN vDOMANDA_DI_PAGAMENTO DOM ON LO.Id_Domanda_Pagamento = DOM.ID_DOMANDA_PAGAMENTO
	JOIN PROGETTO PROG ON PROG.ID_PROGETTO = DOM.ID_PROGETTO
	JOIN vBando_Programmazione bprm ON PROG.Id_Bando = bprm.Id_Bando AND bprm.Id_Programmazione NOT IN (17, 18, 19) AND bprm.COD_PSR = 'POR20142020'
	LEFT JOIN CertSp_Dettaglio DET ON DET.Id_Domanda_Pagamento = LO.Id_Domanda_Pagamento
	LEFT JOIN CertSp_Dettaglio_Recuperi RE ON RE.IdCertSp_Dettaglio = DET.IdCertSp_Dettaglio
WHERE 1 = 1
	AND LO.SEGNATURA_TESTATA IS NOT NULL
	AND DOM.SEGNATURA_ANNULLAMENTO IS NULL
GROUP BY 
	LO.Id_Domanda_Pagamento,
	LO.Id_Progetto,
	LO.IdLoco,
	LO.Intervento,
	LO.Azione,
	LO.Asse,
	LO.Beneficiario,
	LO.ENTE_VALIDATORE,
	LO.NOMINATIVO_VALIDATORE,
	LO.DATA_SEGNATURA,
	LO.SEGNATURA_TESTATA,
	DOM.FASE,
	LO.SpesaAmmessa,
	LO.ImportoAmmesso,
	LO.ESITO_TESTATA

UNION

-- Controllo I livello documentale
SELECT 
	asse.Codice AS Asse,
	azione.CODICE AS Azione,
	ti.CODICE AS Intervento,
	RDP.ID_LOTTO AS Id_Lotto,
	DOM.ID_PROGETTO AS Id_Progetto,
	IMP.RAGIONE_SOCIALE AS Beneficiario,
	'Controllo I livello documentale' AS Tipo_Controllo,
	UT.ENTE AS Soggetto_rilevazione,
	UT.NOMINATIVO AS Controllore,
	RDP.DATA_VALIDAZIONE AS Data,
	RDP.SEGNATURA_REVISIONE AS Segnatura,
	CASE 
		WHEN RDP.APPROVATA IS NOT NULL AND RDP.APPROVATA = 1 THEN 'Positivo'
		ELSE 'Negativo'
	END AS Esito,
	RDP.ID_DOMANDA_PAGAMENTO AS Id_Domanda_Pagamento,
	DOM.FASE AS Stato,
	SUM(P.IMPORTO_AMMESSO) AS Spesa_ammessa,
	ESP.IMPORTO_AMMESSO AS Contributo_rendicontato,
	SUM(ISNULL(RE.CONTRIBUTO_PUBBLICO_ERRORE, RE.Importo_da_Recuperare_totale)) AS Contributo_irregolare
FROM CTE_TESTATA_VALIDAZIONE RDP --REVISIONE_DOMANDA_PAGAMENTO RDP
	JOIN VDOMANDA_DI_PAGAMENTO DOM ON DOM.ID_DOMANDA_PAGAMENTO = RDP.ID_DOMANDA_PAGAMENTO
	LEFT JOIN PAGAMENTI_RICHIESTI P ON DOM.ID_DOMANDA_PAGAMENTO = P.ID_DOMANDA_PAGAMENTO
	JOIN vDOMANDA_DI_PAGAMENTO_ESPORTAZIONE ESP ON ESP.ID_DOMANDA_PAGAMENTO = DOM.ID_DOMANDA_PAGAMENTO
	JOIN vUTENTI UT ON RDP.CF_VALIDATORE = UT.CF_UTENTE
	JOIN PROGETTO PROG ON PROG.ID_PROGETTO = DOM.ID_PROGETTO
	JOIN vIMPRESA IMP ON PROG.ID_IMPRESA = IMP.ID_IMPRESA
	JOIN vBando_Programmazione bprm ON PROG.Id_Bando = bprm.Id_Bando AND bprm.Id_Programmazione NOT IN (17, 18, 19) AND bprm.COD_PSR = 'POR20142020'
    JOIN zProgrammazione ti ON bprm.Id_Programmazione = ti.id
    JOIN zProgrammazione azione ON ti.Id_Padre = azione.Id
    JOIN zProgrammazione asse ON azione.Id_Padre = asse.Id
	LEFT JOIN CertSp_Dettaglio DET ON DET.Id_Domanda_Pagamento = RDP.ID_DOMANDA_PAGAMENTO
	LEFT JOIN CertSp_Dettaglio_Recuperi RE ON RE.IdCertSp_Dettaglio = DET.IdCertSp_Dettaglio
WHERE 1 = 1
	AND RDP.SEGNATURA_REVISIONE IS NOT NULL
	AND DOM.SEGNATURA_ANNULLAMENTO IS NULL
GROUP BY 
	RDP.ID_DOMANDA_PAGAMENTO, 
	DOM.ID_PROGETTO, 
	IMP.RAGIONE_SOCIALE,
	RDP.ID_LOTTO, 
	ti.CODICE, 
	azione.CODICE, 
	asse.Codice,
	RDP.DATA_VALIDAZIONE,
	RDP.SEGNATURA_REVISIONE,
	UT.ENTE,
	UT.NOMINATIVO,
	RDP.APPROVATA,
	DOM.FASE,
	ESP.IMPORTO_AMMESSO
GO