﻿CREATE PROCEDURE [dbo].[zCUPGetDescrizioneConcessioneIncentiviUnitaProduttive]
(
	@IdProgetto INT 
)
AS
BEGIN

SELECT 
P.ID_PROGETTO AS id_progetto,
--LEFT(IPS.RAGIONE_SOCIALE,100) AS denominazione_impresa_stabilimento,
LEFT(REPLACE(IPS.RAGIONE_SOCIALE,'*',' '),100) AS denominazione_impresa_stabilimento,
I.CUAA AS partita_iva,
--CASE WHEN BRT.TESTO IS NULL  
--THEN LEFT(IPS.RAGIONE_SOCIALE,100) 
--ELSE LEFT(CAST(BRT.TESTO AS VARCHAR(MAX)),100) END AS descrizione_intervento,
LEFT('PROGETTO ID SIGEF ' + CONVERT(VARCHAR(10),P.ID_PROGETTO) + ' POR MARCHE FESR 2014-2020 - Azione ' + ZP.CODICE + ' ' + ZP.DESCRIZIONE, 255) AS descrizione_intervento,
CASE WHEN TIPO_DUG.Descrizione = 'Altro' THEN
LEFT(LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) ELSE
LEFT(TIPO_DUG.Descrizione + ' ' + LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) END AS ind_area_rif,
LP.CAP AS cap_area_rif,
LP.NUM AS numero_area_rif
FROM 
vPROGETTO P
INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
P.ID_PROGETTO = LP.ID_PROGETTO
AND
P.ID_IMPRESA = LP.ID_IMPRESA
INNER JOIN TIPO_DUG ON
LP.DUG = TIPO_DUG.ID_DUG
INNER JOIN COMUNI ON
LP.ID_COMUNE = COMUNI.ID_COMUNE
INNER JOIN IMPRESA I ON
P.ID_IMPRESA = I.ID_IMPRESA
INNER JOIN IMPRESA_STORICO IPS ON
I.ID_STORICO_ULTIMO = IPS.ID_STORICO_IMPRESA
INNER JOIN vBANDO B ON 
P.ID_BANDO = B.ID_BANDO
INNER JOIN zPROGRAMMAZIONE ZP ON
B.ID_PROGRAMMAZIONE = ZP.ID
LEFT OUTER JOIN
(
	SELECT   
	PROGETTO.ID_PROGETTO, 
	PROGETTO.ID_BANDO, 
	dbo.BANDO_RELAZIONE_TECNICA.ORDINE, 
	dbo.PROGETTO_RELAZIONE_TECNICA.TESTO
	FROM         
	dbo.BANDO_RELAZIONE_TECNICA 
	INNER JOIN
	dbo.PROGETTO_RELAZIONE_TECNICA ON 
	dbo.BANDO_RELAZIONE_TECNICA.ID_PARAGRAFO = dbo.PROGETTO_RELAZIONE_TECNICA.ID_PARAGRAFO 
	INNER JOIN
	dbo.vPROGETTO PROGETTO ON 
	dbo.PROGETTO_RELAZIONE_TECNICA.ID_PROGETTO = PROGETTO.ID_PROGETTO
	WHERE 
	dbo.BANDO_RELAZIONE_TECNICA.ORDINE = 1 
	AND 
	PROGETTO.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
) BRT ON
P.ID_PROGETTO = BRT.ID_PROGETTO
WHERE 
P.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
AND
P.ID_PROGETTO = @IdProgetto

--SELECT 
--P.ID_PROGETTO AS id_progetto,
--LEFT(IPS.RAGIONE_SOCIALE,100) AS denominazione_impresa_stabilimento,
--I.CUAA AS partita_iva,
--CASE WHEN BRT.TESTO IS NULL  
--THEN LEFT(IPS.RAGIONE_SOCIALE,100) 
--ELSE LEFT(CAST(BRT.TESTO AS VARCHAR(MAX)),100) END AS descrizione_intervento,
--CASE WHEN TIPO_DUG.Descrizione = 'Altro' THEN
--LEFT(LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) ELSE
--LEFT(TIPO_DUG.Descrizione + ' ' + LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) END AS ind_area_rif,
--LP.CAP AS cap_area_rif,
--LP.NUM AS numero_area_rif
--FROM 
--vPROGETTO P
--INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
--P.ID_PROGETTO = LP.ID_PROGETTO
--AND
--P.ID_IMPRESA = LP.ID_IMPRESA
--INNER JOIN TIPO_DUG ON
--LP.DUG = TIPO_DUG.ID_DUG
--INNER JOIN COMUNI ON
--LP.ID_COMUNE = COMUNI.ID_COMUNE
--INNER JOIN IMPRESA I ON
--P.ID_IMPRESA = I.ID_IMPRESA
--INNER JOIN IMPRESA_STORICO IPS ON
--I.ID_STORICO_ULTIMO = IPS.ID_STORICO_IMPRESA
--LEFT OUTER JOIN
--(
--	SELECT   
--	PROGETTO.ID_PROGETTO, 
--	PROGETTO.ID_BANDO, 
--	dbo.BANDO_RELAZIONE_TECNICA.ORDINE, 
--	dbo.PROGETTO_RELAZIONE_TECNICA.TESTO
--	FROM         
--	dbo.BANDO_RELAZIONE_TECNICA 
--	INNER JOIN
--	dbo.PROGETTO_RELAZIONE_TECNICA ON 
--	dbo.BANDO_RELAZIONE_TECNICA.ID_PARAGRAFO = dbo.PROGETTO_RELAZIONE_TECNICA.ID_PARAGRAFO 
--	INNER JOIN
--	dbo.vPROGETTO PROGETTO ON 
--	dbo.PROGETTO_RELAZIONE_TECNICA.ID_PROGETTO = PROGETTO.ID_PROGETTO
--	WHERE 
--	dbo.BANDO_RELAZIONE_TECNICA.ORDINE = 1 
--	AND 
--	PROGETTO.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
--) BRT ON
--P.ID_PROGETTO = BRT.ID_PROGETTO
--WHERE 
--P.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
--AND
--P.ID_PROGETTO = @IdProgetto

--VERSIONE TEMPORANEA PER ACQUISIZIONE CUP PROGETTO 10458,10075,10107 (Sostituzione descrizione in inglese con id progetto e azione)
--WITH TMP AS 
--(
--SELECT 
--P.ID_PROGETTO,
--P.ID_BANDO,
--B.ID_PROGRAMMAZIONE,
--ZP.CODICE,
--ZP.DESCRIZIONE 
--FROM VPROGETTO P
--INNER JOIN VBANDO B ON 
--P.ID_BANDO = B.ID_BANDO
--INNER JOIN ZPROGRAMMAZIONE ZP ON 
--B.ID_PROGRAMMAZIONE = ZP.ID
--WHERE ID_PROGETTO IN (10458,10075,10107)
--)

--SELECT 
--P.ID_PROGETTO AS id_progetto,
--LEFT(IPS.RAGIONE_SOCIALE,100) AS denominazione_impresa_stabilimento,
--I.CUAA AS partita_iva,
--CASE WHEN BRT.TESTO IS NULL  
--THEN LEFT(IPS.RAGIONE_SOCIALE,100) 
--ELSE 
--CASE WHEN P.ID_PROGETTO IN (10458,10075,10107) THEN 'ID SIGEF: ' + CONVERT(VARCHAR(20),P.ID_PROGETTO) + ' - ' + TMP.CODICE + ': ' + TMP.DESCRIZIONE ELSE  
--LEFT(CAST(BRT.TESTO AS VARCHAR(MAX)),100) 
--END
--END AS descrizione_intervento,
--CASE WHEN TIPO_DUG.Descrizione = 'Altro' THEN
--LEFT(LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) ELSE
--LEFT(TIPO_DUG.Descrizione + ' ' + LP.VIA + ' ' + LP.NUM + ' ' + LP.CAP + ' ' + COMUNI.DENOMINAZIONE,100) END AS ind_area_rif,
--LP.CAP AS cap_area_rif,
--LP.NUM AS numero_area_rif
--FROM 
--vPROGETTO P
--INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
--P.ID_PROGETTO = LP.ID_PROGETTO
--AND
--P.ID_IMPRESA = LP.ID_IMPRESA
--INNER JOIN TIPO_DUG ON
--LP.DUG = TIPO_DUG.ID_DUG
--INNER JOIN COMUNI ON
--LP.ID_COMUNE = COMUNI.ID_COMUNE
--INNER JOIN IMPRESA I ON
--P.ID_IMPRESA = I.ID_IMPRESA
--INNER JOIN IMPRESA_STORICO IPS ON
--I.ID_STORICO_ULTIMO = IPS.ID_STORICO_IMPRESA
--LEFT OUTER JOIN
--(
--	SELECT   
--	PROGETTO.ID_PROGETTO, 
--	PROGETTO.ID_BANDO, 
--	dbo.BANDO_RELAZIONE_TECNICA.ORDINE, 
--	dbo.PROGETTO_RELAZIONE_TECNICA.TESTO
--	FROM         
--	dbo.BANDO_RELAZIONE_TECNICA 
--	INNER JOIN
--	dbo.PROGETTO_RELAZIONE_TECNICA ON 
--	dbo.BANDO_RELAZIONE_TECNICA.ID_PARAGRAFO = dbo.PROGETTO_RELAZIONE_TECNICA.ID_PARAGRAFO 
--	INNER JOIN
--	dbo.vPROGETTO PROGETTO ON 
--	dbo.PROGETTO_RELAZIONE_TECNICA.ID_PROGETTO = PROGETTO.ID_PROGETTO
--	WHERE 
--	dbo.BANDO_RELAZIONE_TECNICA.ORDINE = 1 
--	AND 
--	PROGETTO.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
--) BRT ON
--P.ID_PROGETTO = BRT.ID_PROGETTO
--LEFT OUTER JOIN TMP ON 
--P.ID_PROGETTO = TMP.ID_PROGETTO
--WHERE 
--P.COD_STATO NOT IN ('P','L','A','Q','B','N','I')
--AND
--P.ID_PROGETTO = @IdProgetto



END
