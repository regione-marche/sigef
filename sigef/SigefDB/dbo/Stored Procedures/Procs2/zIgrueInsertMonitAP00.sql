﻿CREATE PROCEDURE [dbo].[zIgrueInsertMonitAP00]
( 
 @DataDa DATETIME,
 @DataA DATETIME,
 @IdInvio INT,
 @rNumber INT
)
AS
BEGIN

WITH BRT AS 
(
	SELECT   
	dbo.PROGETTO.ID_PROGETTO, 
	dbo.PROGETTO.ID_BANDO, 
	dbo.BANDO_RELAZIONE_TECNICA.ORDINE, 
	ROW_NUMBER() OVER(PARTITION BY PROGETTO.ID_PROGETTO, dbo.BANDO_RELAZIONE_TECNICA.ORDINE ORDER BY PROGETTO.ID_PROGETTO, dbo.BANDO_RELAZIONE_TECNICA.ORDINE ASC) AS ORDER_ROW,
	dbo.PROGETTO_RELAZIONE_TECNICA.TESTO
	FROM         
	dbo.BANDO_RELAZIONE_TECNICA 
	INNER JOIN
	dbo.PROGETTO_RELAZIONE_TECNICA ON 
	dbo.BANDO_RELAZIONE_TECNICA.ID_PARAGRAFO = dbo.PROGETTO_RELAZIONE_TECNICA.ID_PARAGRAFO 
	INNER JOIN
	dbo.PROGETTO ON 
	dbo.PROGETTO_RELAZIONE_TECNICA.ID_PROGETTO = dbo.PROGETTO.ID_PROGETTO
	WHERE
	dbo.BANDO_RELAZIONE_TECNICA.ORDINE IN (1,2) 
)
,
PSIC AS (
	SELECT 
	MIN(PS1.DATA) AS DATA, 
	PS1.ID_PROGETTO,
	PS1.COD_STATO 
	FROM PROGETTO_STORICO PS1
	GROUP BY 
	PS1.ID_PROGETTO,
	PS1.COD_STATO
)

INSERT INTO IGRUE_MONIT.dbo.IGRUE_AP00
(
	COD_LOCALE_PROGETTO,
	TITOLO_PROGETTO,
	SINTESI_PRG,
	TIPO_OPERAZIONE,
	CUP,
	TIPO_AIUTO,
	DATA_INIZIO,
	DATA_FINE_PREVISTA,
	DATA_FINE_EFFETTIVA,
	TIP_PROC_ATT_ORIG,
	CODICE_PROC_ATT_ORIG,
	FLG_CANCELLAZIONE,
	--OPERAZIONE,
	ID_INVIO,
	NR_RIGA_INVIO,
	--NR_RIGA_CANCELLAZIONE
	CODICE_FONDO
) 

SELECT 
P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
--REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT1.TESTO,1,500),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' ') AS TITOLO_PROGETTO,
--REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT2.TESTO,1,1300),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' ') AS SINTESI_PRG,
ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT1.TESTO,1,500),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' '), I.RAGIONE_SOCIALE) AS TITOLO_PROGETTO,
ISNULL(REPLACE(REPLACE(REPLACE(REPLACE(SUBSTRING(BRT2.TESTO,1,1300),CHAR(10),' '),CHAR(13),' '),'#',' '),'|',' '),I.RAGIONE_SOCIALE) AS SINTESI_PRG,
CUP_TO.Natura + '.' + CUP_TO.Tipologia AS TIPO_OPERAZIONE, -- TC5 
P.COD_AGEA AS CUP, 
'A' AS TIPO_AIUTO, -- TC6 (16/11/2016: impostato valore fisso A in quanto regime di aiuto associato al Programma)
dbo.DateToString_Igrue(PSI.DATA_INIZIO) AS DATA_INIZIO, --VERIFICARE STATO
--NULL AS DATA_FINE_PREVISTA, --RIVEDERE
dbo.DateToString_Igrue(DATEADD(MONTH,12,PSP.DATA_FINANZIABILITA)) AS DATA_FINE_PREVISTA,
CASE 
WHEN PSC.DATA_FINE_EFFETTIVA IS NOT NULL 
THEN dbo.DateToString_Igrue(PSC.DATA_FINE_EFFETTIVA) 
END AS DATA_FINE_EFFETTIVA, --RIVEDERE
'5' AS TIP_PROC_ATT_ORIG,  --COLLEGARE TC48
NULL AS CODICE_PROC_ATT_ORIG, --COLLEGARE TC48
NULL AS FLG_CANCELLAZIONE,
@IdInvio AS ID_INVIO,
ISNULL(@rNumber, 0) + ROW_NUMBER() OVER(ORDER BY P.ID_PROGETTO ASC) AS NR_RIGA_INVIO,
'FESR20142020' AS CODICE_FONDO
FROM vPROGETTO P
INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
P.ID_PROGETTO = DMF.ID_PROGETTO
INNER JOIN TIPO_CUP_CATEGORIE_TIPIOPERAZIONI CUP_TO ON
DMF.CUP_CATEGORIA_TIPOOPER = CUP_TO.COD_CUP_CATEGORIE_TIPIOPERAZIONI
--INNER JOIN TIPO_QSN_TIPO_OPERAZIONE QSN_TO ON
--CUP_TO.IdTipoOperazioneQsn = QSN_TO.COD_TIPO_QSN_OPERAZIONE
--INNER JOIN PROGETTO_STORICO PS ON
--P.ID_PROGETTO = PS.ID_PROGETTO
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
B.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
--INNER JOIN BANDO_RESPONSABILI BR ON
--B.ID_BANDO = BR.ID_BANDO
LEFT OUTER JOIN 
(
SELECT BRT.ID_PROGETTO, BRT.TESTO FROM BRT
WHERE ORDINE = 2 AND ORDER_ROW = 1) AS BRT2
ON
P.ID_PROGETTO = BRT2.ID_PROGETTO
LEFT OUTER JOIN 
(
SELECT BRT.ID_PROGETTO, BRT.TESTO FROM BRT
WHERE ORDINE = 1 AND ORDER_ROW = 1) AS BRT1
ON
P.ID_PROGETTO = BRT1.ID_PROGETTO
INNER JOIN 
(SELECT PSIC.DATA DATA_INIZIO, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'F') PSI ON
P.ID_PROGETTO = PSI.ID_PROGETTO
LEFT OUTER JOIN 
(SELECT PSIC.DATA DATA_FINE_EFFETTIVA, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'C') PSC ON
P.ID_PROGETTO = PSC.ID_PROGETTO
LEFT OUTER JOIN 
(SELECT PSIC.DATA DATA_FINANZIABILITA, PSIC.ID_PROGETTO FROM PSIC WHERE PSIC.COD_STATO = 'F') PSP ON
P.ID_PROGETTO = PSP.ID_PROGETTO
INNER JOIN vIMPRESA I ON
P.ID_IMPRESA = I.ID_IMPRESA
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R')  --INSERIRE STATI VALIDI
AND 
PSR.CODICE = 'POR20142020'
AND
P.COD_AGEA IS NOT NULL
--26/01/2018
--CLAUSOLA TEMPORANEA PER ESCLUDERE PROGETTO STRUMENTI FINANZIARI ARTIGIANCASSA
AND P.ID_PROGETTO <> 13301

--AND
--BR.ATTIVO = 1 AND BR.PROVINCIA IS NULL
--AND
--B.DATA_SCADENZA BETWEEN @DataDa AND @DataA


--SELECT 
--P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
--P.ID_PROGETTO AS TITOLO_PROGETTO,
--P.ID_PROGETTO AS SINTESI_PRG,
--QSN_TO.COD_TIPO_QSN_OPERAZIONE AS TIPO_OPERAZIONE, --COLLEGARE TC5 
--P.COD_AGEA AS CUP, -- RIVEDERE
--'TIPO_AIUTO' AS TIPO_AIUTO, -- COLLEGARE TC6
--PS.DATA AS DATA_INIZIO, --VERIFICARE STATO
--NULL AS DATA_FINE_PREVISTA, --RIVEDERE
--NULL AS DATA_FINE_EFFETTIVA, --RIVEDERE
--NULL AS TIP_PROC_ATT_ORIG,  --COLLEGARE TC48
--NULL AS CODICE_PROC_ATT_ORIG, --COLLEGARE TC48
--NULL AS FLG_CANCELLAZIONE,
--@IdInvio AS ID_INVIO,
--ROW_NUMBER() OVER(ORDER BY P.ID_PROGETTO ASC) AS NR_RIGA_INVIO
--FROM vPROGETTO P
--INNER JOIN DATI_MONITORAGGIO_FESR DMF ON
--P.ID_PROGETTO = DMF.ID_PROGETTO
--INNER JOIN TIPO_CUP_CATEGORIE_TIPIOPERAZIONI CUP_TO ON
--DMF.CUP_CATEGORIA_TIPOOPER = CUP_TO.COD_CUP_CATEGORIE_TIPIOPERAZIONI
--INNER JOIN TIPO_QSN_TIPO_OPERAZIONE QSN_TO ON
--CUP_TO.IdTipoOperazioneQsn = QSN_TO.COD_TIPO_QSN_OPERAZIONE
--INNER JOIN PROGETTO_STORICO PS ON
--P.ID_PROGETTO = PS.ID_PROGETTO
--INNER JOIN vBANDO B ON
--P.ID_BANDO = B.ID_BANDO
--INNER JOIN zPROGRAMMAZIONE PRG ON
--B.ID_PROGRAMMAZIONE = PRG.ID
--INNER JOIN zPSR_ALBERO PA ON
--PRG.COD_TIPO = PA.CODICE
--INNER JOIN zPSR PSR ON
--PA.COD_PSR = PSR.CODICE
--INNER JOIN BANDO_RESPONSABILI BR ON
--B.ID_BANDO = BR.ID_BANDO
--WHERE 
--PS.COD_STATO = 'V'
--AND 
--PSR.CODICE = 'POR20142020'
--AND
--BR.ATTIVO = 1 AND BR.PROVINCIA IS NULL
--AND
--B.DATA_SCADENZA BETWEEN @DataDa AND @DataA


SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo.IGRUE_AP00 WHERE ID_INVIO = @IdInvio

END
