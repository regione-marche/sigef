﻿CREATE PROCEDURE [dbo].[zCUPGetDescrizioneRealizzAcquistoNoFormazioneRicerca]
(
	@IdProgetto INT 
)
AS
BEGIN


SELECT
P.ID_PROGETTO AS id_progetto,
--LEFT(IPS.RAGIONE_SOCIALE,100) AS nome_stru_infrastr,
LEFT(REPLACE(IPS.RAGIONE_SOCIALE,'*',' '),100) AS nome_stru_infrastr,
I.CUAA AS partita_iva,
--CASE WHEN BRT.TESTO IS NULL  
--THEN LEFT(IPS.RAGIONE_SOCIALE,256) 
--ELSE LEFT(CAST(BRT.TESTO AS VARCHAR(MAX)),256) END AS servizio,
LEFT('PROGETTO ID SIGEF ' + CONVERT(VARCHAR(10),P.ID_PROGETTO) + ' POR MARCHE FESR 2014-2020 - Azione ' + ZP.CODICE + ' ' + ZP.DESCRIZIONE, 256) AS servizio,
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

END

--SELECT 
--P.ID_PROGETTO as id_progetto,
--IPS.RAGIONE_SOCIALE as nome_stru_infrastr,
--I.CODICE_FISCALE as partita_iva,
--IPS.RAGIONE_SOCIALE as servizio,
----LP.DUG AS tipo_indirizzo,
--LP.VIA as ind_area_rif,
--LP.CAP AS cap_area_rif,
--LP.NUM as numero_area_rif,
--ISNULL(IP.NR_IMPRESE, 1) AS nr_imprese,
--CASE WHEN ISNULL(IP.NR_IMPRESE, 1) = 1 THEN 'S' ELSE 'N' END AS str_infrastr_unica
--FROM 
--PROGETTO P
--INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
--P.ID_PROGETTO = DMF.ID_PROGETTO
--INNER JOIN TIPO_CUP_CATEGORIE TCC ON
--DMF.CUP_CATEGORIA = TCC.COD_CUP_CATEGORIE
--INNER JOIN PROGETTO_STORICO PS ON
--P.ID_PROGETTO = PS.ID_PROGETTO
--INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
--P.ID_PROGETTO = LP.ID_PROGETTO
--INNER JOIN IMPRESA I ON
--P.ID_IMPRESA = I.ID_IMPRESA
--LEFT OUTER JOIN
--(
--SELECT 
--P.ID_PROGETTO,
--COUNT (IMS.ID_SOCIO) AS NR_IMPRESE--,
----P.ID_IMPRESA,
----SP.DATA,
----SP.COD_STATO,
----IMS.ID_SOCIO,
----IMS.COD_TIPO_SOCIO,
----IMS.DATA_INIZIO_VALIDITA,
----ISNULL(IMS.DATA_FINE_VALIDITA,'22000101') AS DATA_FINE_VALIDITA
--FROM
--PROGETTO P
--INNER JOIN 
--IMPRESA_SOCI IMS ON
--P.ID_IMPRESA = IMS.ID_IMPRESA
--INNER JOIN PROGETTO_STORICO SP ON
--P.ID_PROGETTO = SP.ID_PROGETTO
----AND SP.COD_STATO = 'L'
--WHERE 
--IMS.COD_TIPO_SOCIO = 'I'
--AND 
--SP.COD_STATO = 'L'
--AND 
--SP.DATA BETWEEN IMS.DATA_INIZIO_VALIDITA AND ISNULL(IMS.DATA_FINE_VALIDITA,GETDATE())
--GROUP BY 
--P.ID_PROGETTO
--) AS IP ON
--P.ID_PROGETTO = IP.ID_PROGETTO
--INNER JOIN IMPRESA_STORICO IPS ON
--I.ID_STORICO_ULTIMO = IPS.ID_STORICO_IMPRESA
----INNER JOIN INDIRIZZARIO IND ON
----I.ID_IMPRESA = IND.ID_IMPRESA 
----AND IND.COD_TIPO_SEDE = 'S'
----AND IND.DATA_FINE_VALIDITA IS NULL 
----AND FLAG_ATTIVO = 1
----INNER JOIN INDIRIZZO ON
----IND.ID_INDIRIZZO = INDIRIZZO.ID_INDIRIZZO
----INNER JOIN COMUNI C ON
----LP.ID_COMUNE = C.ID_COMUNE
--WHERE 
----PS.COD_STATO = 'I' --DA CAMBIARE IN 'F' non appena ci sono domande finanziabili
----AND
--P.ID_PROGETTO = @IdProgetto 
--END