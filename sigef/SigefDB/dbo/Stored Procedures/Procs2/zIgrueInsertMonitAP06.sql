﻿CREATE PROCEDURE [dbo].[zIgrueInsertMonitAP06]
( 
 @DataDa DATETIME,
 @DataA DATETIME,
 @IdInvio INT,
 @rNumber INT
)
AS
BEGIN
INSERT INTO IGRUE_MONIT.dbo.IGRUE_AP06
(
COD_LOCALE_PROGETTO,
COD_REGIONE,
COD_PROVINCIA,
COD_COMUNE,
INDIRIZZO,
COD_CAP,
FLG_CANCELLAZIONE,
--OPERAZIONE,
ID_INVIO,
NR_RIGA_INVIO,
--NR_RIGA_CANCELLAZIONE
CODICE_FONDO
)

SELECT 
P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
REGIONI.CODICE AS COD_REGIONE, --TC16 (dovrebbe essere la codifica ISTAT)
PROVINCE.CODICE AS COD_PROVINCIA, --TC16 (dovrebbe essere la codifica ISTAT)
COMUNI.ISTAT AS COD_COMUNE, --TC16 (dovrebbe essere la codifica ISTAT)
CASE WHEN TIPO_DUG.DESCRIZIONE = 'Altro' THEN 
RTRIM(LP.VIA + ' ' + ISNULL(LP.NUM,''))
ELSE
RTRIM(TIPO_DUG.Descrizione + ' ' + LP.VIA + ' ' + ISNULL(LP.NUM,'')) END AS INDIRIZZO,
LP.CAP AS COD_CAP,
NULL AS FLG_CANCELLAZIONE,
@IdInvio AS ID_INVIO,
ISNULL(@rNumber,0) + ROW_NUMBER() OVER(ORDER BY P.ID_PROGETTO ASC) AS NR_RIGA_INVIO,
'FESR20142020' AS CODICE_FONDO 
FROM vPROGETTO P
INNER JOIN LOCALIZZAZIONE_PROGETTO LP ON
P.ID_PROGETTO = LP.ID_PROGETTO
AND 
P.ID_IMPRESA = LP.ID_IMPRESA
INNER JOIN COMUNI ON
LP.ID_COMUNE = COMUNI.ID_COMUNE
INNER JOIN PROVINCE ON
COMUNI.SIGLA = PROVINCE.SIGLA
INNER JOIN REGIONI ON 
PROVINCE.COD_REGIONE = REGIONI.CODICE
INNER JOIN TIPO_DUG ON
LP.DUG = TIPO_DUG.ID_DUG
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
--INNER JOIN PROGETTO_STORICO PS ON
--P.ID_PROGETTO = PS.ID_PROGETTO
INNER JOIN BANDO_PROGRAMMAZIONE BP ON
B.ID_BANDO = BP.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
BP.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
--INNER JOIN BANDO_RESPONSABILI BR ON
--B.ID_BANDO = BR.ID_BANDO
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
PSR.CODICE = 'POR20142020'
AND 
PRG.ID NOT IN (17,18,19)
AND 
BP.ID_PROGRAMMAZIONE NOT IN (17,18,19)
AND 
P.COD_AGEA IS NOT NULL
--26/01/2018
--CLAUSOLA TEMPORANEA PER ESCLUDERE PROGETTO STRUMENTI FINANZIARI ARTIGIANCASSA
AND P.ID_PROGETTO <> 13301
GROUP BY 
P.ID_PROGETTO,
REGIONI.CODICE,
PROVINCE.CODICE,
COMUNI.ISTAT,
TIPO_DUG.DESCRIZIONE,
LP.VIA,
LP.NUM,
LP.CAP
--AND
--BR.ATTIVO = 1 AND BR.PROVINCIA IS NULL
--AND
--B.DATA_SCADENZA BETWEEN @DataDa AND @DataA

SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo.IGRUE_AP06 WHERE ID_INVIO = @IdInvio

END