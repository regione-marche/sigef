﻿CREATE PROCEDURE [dbo].[zIgrueInsertMonitIN01]
( 
 @DataDa DATETIME,
 @DataA DATETIME,
 @IdInvio INT,
 @rNumber INT
)
AS
BEGIN


--WITH IOT AS (
--SELECT 
--P.ID_PROGETTO,
--ZP.ID ID_PROGRAMMAZIONE,
--NULL AS VALORE_PROGRAMMATO,
--NULL AS VALORE_REALIZZATO,
--CASE ZD.COD_DIM 
--WHEN 'IOC' THEN 'COM'
--WHEN 'IOS' THEN 'DPR'
--END AS TIPO_INDICATORE_DI_OUTPUT,
--CASE ZD.CODICE
--WHEN 'CO01' THEN '101'
--WHEN 'CO02' THEN '102'
--WHEN 'CO03' THEN '103'
--WHEN 'CO05' THEN '105'
--WHEN 'CO06' THEN '106'
--WHEN 'CO08' THEN '108'
--WHEN 'CO24' THEN '124'
--WHEN 'CO26' THEN '126'
--WHEN 'CO27' THEN '127'
--WHEN 'CO29' THEN '129'
--WHEN 'CO30' THEN '130'
--WHEN 'CO34' THEN '134'
--WHEN '798' THEN '798'
--ELSE ZD.CODICE + '2014IT16RFOP013'
--END AS COD_INDICATORE,
--NULL AS DATA_REG
--FROM vPROGETTO P 
--INNER JOIN vBANDO B ON
--P.ID_BANDO = B.ID_BANDO
--INNER JOIN BANDO_PROGRAMMAZIONE BP ON
--B.ID_BANDO = BP.ID_BANDO
--INNER JOIN zPROGRAMMAZIONE ZP ON
--BP.ID_PROGRAMMAZIONE = ZP.ID
--INNER JOIN zPSR_ALBERO PA ON
--ZP.COD_TIPO = PA.CODICE
--INNER JOIN zPSR PSR ON
--PA.COD_PSR = PSR.CODICE
--INNER JOIN zDIMENSIONI_X_PROGRAMMAZIONE ZDP ON 
--ZP.ID = ZDP.ID_PROGRAMMAZIONE
--INNER JOIN zDIMENSIONI ZD ON 
--ZDP.ID_DIMENSIONE = ZD.ID
--AND 
--ZD.COD_DIM IN ('IOC','IOS')
--WHERE 
--P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
--AND 
--PSR.CODICE = 'POR20142020'
--AND ZP.ID NOT IN (17,18,19)
--AND
--P.COD_AGEA IS NOT NULL
--AND P.ID_PROGETTO NOT IN
--(
--SELECT A.ID_PROGETTO FROM 
--(
--SELECT 
--	VI.ID_PROGETTO,
--	VI.ID_PROGRAMMAZIONE,
--	COALESCE(VI.VALORE_PROGRAMMATO_AMMESSO, VI.VALORE_PROGRAMMATO_RICHIESTO) AS VALORE_PROGRAMMATO,
--	COALESCE(VI.VALORE_REALIZZATO_AMMESSO, VI.VALORE_REALIZZATO_RICHIESTO) AS VALORE_REALIZZATO, 
--	--VI.Dim_Codice,
--	CASE 
--	WHEN LEFT(VI.Dim_Codice,2) = 'CO' THEN 'COM'
--	ELSE 'DPR'
--	END AS TIPO_INDICATORE_DI_OUTPUT,
--	CASE VI.Dim_Codice	
--	WHEN 'CO01' THEN '101'
--	WHEN 'CO02' THEN '102'
--	WHEN 'CO03' THEN '103'
--	WHEN 'CO05' THEN '105'
--	WHEN 'CO06' THEN '106'
--	WHEN 'CO08' THEN '108'
--	WHEN 'CO24' THEN '124'
--	WHEN 'CO26' THEN '126'
--	WHEN 'CO27' THEN '127'
--	WHEN 'CO29' THEN '129'
--	WHEN 'CO30' THEN '130'
--	WHEN 'CO34' THEN '134'
--	WHEN '798' THEN '798'
--	ELSE VI.Dim_Codice + '2014IT16RFOP013' END AS COD_INDICATORE,
--	--MAX(VI.DATA_REGISTRAZIONE) AS DATA_REG 
--	VMAX.DATA_REG
--	FROM 
--	(
--		SELECT 
--		ID_PROGETTO,
--		MAX(DATA_REGISTRAZIONE) AS DATA_REG
--		FROM 
--		vPROGETTO_INDICATORI
--		GROUP BY 
--		ID_PROGETTO
--	) AS VMAX
--	INNER JOIN 
--	vPROGETTO_INDICATORI VI ON 
--	VI.ID_PROGETTO = VMAX.ID_PROGETTO
--	AND
--	VI.DATA_REGISTRAZIONE = VMAX.DATA_REG) AS A
--)	
	
--UNION 

--SELECT 
--VI.ID_PROGETTO,
--VI.ID_PROGRAMMAZIONE,
--COALESCE(VI.VALORE_PROGRAMMATO_AMMESSO, VI.VALORE_PROGRAMMATO_RICHIESTO) AS VALORE_PROGRAMMATO,
--COALESCE(VI.VALORE_REALIZZATO_AMMESSO, VI.VALORE_REALIZZATO_RICHIESTO) AS VALORE_REALIZZATO, 
--CASE 
--WHEN LEFT(VI.Dim_Codice,2) = 'CO' THEN 'COM'
--ELSE 'DPR'
--END AS TIPO_INDICATORE_DI_OUTPUT,
--CASE VI.Dim_Codice	
--WHEN 'CO01' THEN '101'
--WHEN 'CO02' THEN '102'
--WHEN 'CO03' THEN '103'
--WHEN 'CO05' THEN '105'
--WHEN 'CO06' THEN '106'
--WHEN 'CO08' THEN '108'
--WHEN 'CO24' THEN '124'
--WHEN 'CO26' THEN '126'
--WHEN 'CO27' THEN '127'
--WHEN 'CO29' THEN '129'
--WHEN 'CO30' THEN '130'
--WHEN 'CO34' THEN '134'
--WHEN '798' THEN '798'
--ELSE VI.Dim_Codice + '2014IT16RFOP013' END AS COD_INDICATORE,
----MAX(VI.DATA_REGISTRAZIONE) AS DATA_REG 
--VMAX.DATA_REG
--FROM 
--(
--	SELECT 
--	ID_PROGETTO,
--	MAX(DATA_REGISTRAZIONE) AS DATA_REG
--	FROM 
--	vPROGETTO_INDICATORI
--	GROUP BY 
--	ID_PROGETTO
--) AS VMAX
--INNER JOIN 
--vPROGETTO_INDICATORI VI ON 
--VI.ID_PROGETTO = VMAX.ID_PROGETTO
--AND
--VI.DATA_REGISTRAZIONE = VMAX.DATA_REG
--INNER JOIN vPROGETTO P ON 
--VI.ID_PROGETTO = P.ID_PROGETTO
--WHERE 
--P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
--AND 
--P.COD_AGEA IS NOT NULL
--)

WITH CODIND AS
(
SELECT
ZD.ID,
ZD.COD_DIM,
CASE ZD.COD_DIM 
WHEN 'IOC' THEN 'COM'
WHEN 'IOS' THEN 'DPR'
END AS TIPO_INDICATORE_DI_OUTPUT,
CASE ZD.CODICE
WHEN 'CO01' THEN '101'
WHEN 'CO02' THEN '102'
WHEN 'CO03' THEN '103'
WHEN 'CO05' THEN '105'
WHEN 'CO06' THEN '106'
WHEN 'CO08' THEN '108'
WHEN 'CO24' THEN '124'
WHEN 'CO26' THEN '126'
WHEN 'CO27' THEN '127'
WHEN 'CO29' THEN '129'
WHEN 'CO30' THEN '130'
WHEN 'CO34' THEN '134'
WHEN '798' THEN '798'
WHEN '796' THEN '796'
WHEN '304' THEN '304'
ELSE ZD.CODICE + '2014IT16RFOP013'
END AS COD_INDICATORE
FROM zDIMENSIONI ZD
)

,IOT AS (
SELECT 
P.ID_PROGETTO,
ZP.ID ID_PROGRAMMAZIONE,
NULL AS VALORE_PROGRAMMATO,
NULL AS VALORE_REALIZZATO,
ZD.TIPO_INDICATORE_DI_OUTPUT,
ZD.COD_INDICATORE,
NULL AS DATA_REG
FROM vPROGETTO P 
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN BANDO_PROGRAMMAZIONE BP ON
B.ID_BANDO = BP.ID_BANDO
INNER JOIN zPROGRAMMAZIONE ZP ON
BP.ID_PROGRAMMAZIONE = ZP.ID
INNER JOIN zPSR_ALBERO PA ON
ZP.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
INNER JOIN zDIMENSIONI_X_PROGRAMMAZIONE ZDP ON 
ZP.ID = ZDP.ID_PROGRAMMAZIONE
--INNER JOIN zDIMENSIONI ZD ON 
--ZDP.ID_DIMENSIONE = ZD.ID
--AND 
--ZD.COD_DIM IN ('IOC','IOS')
INNER JOIN CODIND ZD ON
ZDP.ID_DIMENSIONE = ZD.ID
AND 
ZD.COD_DIM IN ('IOC','IOS')
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
PSR.CODICE = 'POR20142020'
AND ZP.ID NOT IN (17,18,19)
AND
P.COD_AGEA IS NOT NULL
--AND P.ID_PROGETTO NOT IN
AND NOT EXISTS
(
	SELECT A.ID_PROGETTO, A.COD_INDICATORE FROM 
	(
		SELECT 
		VI.ID_PROGETTO,
		VI.ID_PROGRAMMAZIONE,
		COALESCE(VI.VALORE_PROGRAMMATO_AMMESSO, VI.VALORE_PROGRAMMATO_RICHIESTO) AS VALORE_PROGRAMMATO,
		COALESCE(VI.VALORE_REALIZZATO_AMMESSO, VI.VALORE_REALIZZATO_RICHIESTO) AS VALORE_REALIZZATO, 
		--VI.Dim_Codice,
		CASE 
		--WHEN LEFT(VI.Dim_Codice,2) = 'CO' THEN 'COM'
		WHEN ((LEFT(VI.Dim_Codice,2) = 'CO') OR (VI.Dim_Codice = '798')) THEN 'COM'
		ELSE 'DPR'
		END AS TIPO_INDICATORE_DI_OUTPUT,
		CASE VI.Dim_Codice	
		WHEN 'CO01' THEN '101'
		WHEN 'CO02' THEN '102'
		WHEN 'CO03' THEN '103'
		WHEN 'CO05' THEN '105'
		WHEN 'CO06' THEN '106'
		WHEN 'CO08' THEN '108'
		WHEN 'CO24' THEN '124'
		WHEN 'CO26' THEN '126'
		WHEN 'CO27' THEN '127'
		WHEN 'CO29' THEN '129'
		WHEN 'CO30' THEN '130'
		WHEN 'CO34' THEN '134'
		WHEN '798' THEN '798'
		WHEN '796' THEN '796'
		WHEN '304' THEN '304'
		ELSE VI.Dim_Codice + '2014IT16RFOP013' END AS COD_INDICATORE,
		--MAX(VI.DATA_REGISTRAZIONE) AS DATA_REG 
		VMAX.DATA_REG
		FROM 
		(
			SELECT 
			ID_PROGETTO,
			MAX(DATA_REGISTRAZIONE) AS DATA_REG
			FROM 
			vPROGETTO_INDICATORI
			GROUP BY 
			ID_PROGETTO
		) AS VMAX
		INNER JOIN 
		vPROGETTO_INDICATORI VI ON 
		VI.ID_PROGETTO = VMAX.ID_PROGETTO
		AND
		VI.DATA_REGISTRAZIONE = VMAX.DATA_REG) AS A
		WHERE 
		A.ID_PROGETTO = P.ID_PROGETTO
		AND
		A.COD_INDICATORE = ZD.COD_INDICATORE
)	
	
UNION 

SELECT 
VI.ID_PROGETTO,
VI.ID_PROGRAMMAZIONE,
COALESCE(VI.VALORE_PROGRAMMATO_AMMESSO, VI.VALORE_PROGRAMMATO_RICHIESTO) AS VALORE_PROGRAMMATO,
COALESCE(VI.VALORE_REALIZZATO_AMMESSO, VI.VALORE_REALIZZATO_RICHIESTO) AS VALORE_REALIZZATO, 
CASE 
--WHEN LEFT(VI.Dim_Codice,2) = 'CO' THEN 'COM'
WHEN ((LEFT(VI.Dim_Codice,2) = 'CO') OR (VI.Dim_Codice = '798')) THEN 'COM'
ELSE 'DPR'
END AS TIPO_INDICATORE_DI_OUTPUT,
CASE VI.Dim_Codice	
WHEN 'CO01' THEN '101'
WHEN 'CO02' THEN '102'
WHEN 'CO03' THEN '103'
WHEN 'CO05' THEN '105'
WHEN 'CO06' THEN '106'
WHEN 'CO08' THEN '108'
WHEN 'CO24' THEN '124'
WHEN 'CO26' THEN '126'
WHEN 'CO27' THEN '127'
WHEN 'CO29' THEN '129'
WHEN 'CO30' THEN '130'
WHEN 'CO34' THEN '134'
WHEN '798' THEN '798'
WHEN '796' THEN '796'
WHEN '304' THEN '304'
ELSE VI.Dim_Codice + '2014IT16RFOP013' END AS COD_INDICATORE,
--MAX(VI.DATA_REGISTRAZIONE) AS DATA_REG 
VMAX.DATA_REG
FROM 
(
	SELECT 
	ID_PROGETTO,
	MAX(DATA_REGISTRAZIONE) AS DATA_REG
	FROM 
	vPROGETTO_INDICATORI
	GROUP BY 
	ID_PROGETTO
) AS VMAX
INNER JOIN 
vPROGETTO_INDICATORI VI ON 
VI.ID_PROGETTO = VMAX.ID_PROGETTO
AND
VI.DATA_REGISTRAZIONE = VMAX.DATA_REG
INNER JOIN vPROGETTO P ON 
VI.ID_PROGETTO = P.ID_PROGETTO
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
P.COD_AGEA IS NOT NULL
)

INSERT INTO IGRUE_MONIT.dbo.IGRUE_IN01
(
COD_LOCALE_PROGETTO,
TIPO_INDICATORE_DI_OUTPUT,
COD_INDICATORE,
VAL_PROGRAMMATO,
VALORE_REALIZZATO,
FLG_CANCELLAZIONE,
--OPERAZIONE,
ID_INVIO,
NR_RIGA_INVIO,
--NR_RIGA_CANCELLAZIONE
CODICE_FONDO
)


SELECT
P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
--'DPR' AS TIPO_INDICATORE_DI_OUTPUT,
T.TIPO_INDICATORE_DI_OUTPUT,
T.COD_INDICATORE,
--ISNULL(T.VALORE_PROGRAMMATO,1) AS VALORE_PROGRAMMATO,
CASE WHEN T.VALORE_PROGRAMMATO = 0 THEN 1 ELSE 
ISNULL(T.VALORE_PROGRAMMATO,1) END AS VALORE_PROGRAMMATO,
T.VALORE_REALIZZATO,
NULL AS FLG_CANCELLAZIONE,
@IdInvio AS ID_INVIO,
ISNULL(@rNumber,0) + ROW_NUMBER() OVER(ORDER BY P.ID_PROGETTO ASC) AS NR_RIGA_INVIO,
'FESR20142020' AS CODICE_FONDO   
FROM vPROGETTO P 
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN BANDO_PROGRAMMAZIONE BP ON
B.ID_BANDO = BP.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
BP.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
INNER JOIN IOT T ON
P.ID_PROGETTO = T.ID_PROGETTO
WHERE 
P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
AND 
PSR.CODICE = 'POR20142020'
AND 
PRG.ID NOT IN (17,18,19)
AND
P.COD_AGEA IS NOT NULL
--26/01/2018
--CLAUSOLA TEMPORANEA PER ESCLUDERE PROGETTO STRUMENTI FINANZIARI ARTIGIANCASSA
AND P.ID_PROGETTO <> 13301
--AND
--BR.ATTIVO = 1 AND BR.PROVINCIA IS NULL
--AND
--B.DATA_SCADENZA BETWEEN @DataDa AND @DataA
--ORDER BY P.ID_PROGETTO


SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo.IGRUE_IN01 WHERE ID_INVIO = @IdInvio

END

--WITH IOT AS
--(
--SELECT 
--ZP.ID ID_PRG,
--ZP.CODICE COD_PRG,
--ZP.DESCRIZIONE DESC_PRG,
--ZDP.ID_DIM_X_PROGRAMMAZIONE,
--ZD.CODICE,
--ZD.COD_DIM,
--ZD.DESCRIZIONE
--FROM 
--zPROGRAMMAZIONE ZP
--INNER JOIN zDIMENSIONI_X_PROGRAMMAZIONE ZDP ON 
--ZP.ID = ZDP.ID_PROGRAMMAZIONE
--INNER JOIN zDIMENSIONI ZD ON 
--ZDP.ID_DIMENSIONE = ZD.ID
--AND 
--ZD.COD_DIM IN ('IOC','IOS')
--)


--INSERT INTO IGRUE_MONIT.dbo.IGRUE_IN01
--(
--COD_LOCALE_PROGETTO,
--TIPO_INDICATORE_DI_OUTPUT,
--COD_INDICATORE,
--VAL_PROGRAMMATO,
--VALORE_REALIZZATO,
--FLG_CANCELLAZIONE,
----OPERAZIONE,
--ID_INVIO,
--NR_RIGA_INVIO,
----NR_RIGA_CANCELLAZIONE
--CODICE_FONDO
--)


--SELECT
--P.ID_PROGETTO AS COD_LOCALE_PROGETTO,
--'DPR' AS TIPO_INDICATORE_DI_OUTPUT,
--IOT.CODICE + '2014IT16RFOP013' AS COD_INDICATORE, 
--dbo.calcoloIndicatoriGetUltimoValoreProgrammato(P.ID_PROGETTO, IOT.ID_DIM_X_PROGRAMMAZIONE, NULL) AS VAL_PROGRAMMATO,
--dbo.calcoloIndicatoriGetUltimoValoreRealizzato(P.ID_PROGETTO, IOT.ID_DIM_X_PROGRAMMAZIONE, NULL) AS VALORE_REALIZZATO,
--NULL AS FLG_CANCELLAZIONE,
--@IdInvio AS ID_INVIO,
--ISNULL(@rNumber,0) + ROW_NUMBER() OVER(ORDER BY P.ID_PROGETTO ASC) AS NR_RIGA_INVIO,
--'FESR20142020' AS CODICE_FONDO   
--FROM vPROGETTO P 
--INNER JOIN vBANDO B ON
--P.ID_BANDO = B.ID_BANDO
--INNER JOIN BANDO_PROGRAMMAZIONE BP ON
--B.ID_BANDO = BP.ID_BANDO
--INNER JOIN zPROGRAMMAZIONE PRG ON
--BP.ID_PROGRAMMAZIONE = PRG.ID
--INNER JOIN zPSR_ALBERO PA ON
--PRG.COD_TIPO = PA.CODICE
--INNER JOIN zPSR PSR ON
--PA.COD_PSR = PSR.CODICE
----INNER JOIN zPROGRAMMAZIONE AZIONI ON
----B.ID_PROGRAMMAZIONE = AZIONI.ID
--LEFT OUTER JOIN IOT ON
--PRG.ID = IOT.ID_PRG
--WHERE 
--P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R') 
--AND 
--PSR.CODICE = 'POR20142020'
--AND PRG.ID NOT IN (17,18,19)
--AND
--P.COD_AGEA IS NOT NULL
----AND
----BR.ATTIVO = 1 AND BR.PROVINCIA IS NULL
----AND
----B.DATA_SCADENZA BETWEEN @DataDa AND @DataA

--SELECT ISNULL(MAX(NR_RIGA_INVIO),0) FROM IGRUE_MONIT.dbo.IGRUE_IN01 WHERE ID_INVIO = @IdInvio

