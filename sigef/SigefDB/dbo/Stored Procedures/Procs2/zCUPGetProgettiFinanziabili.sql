﻿CREATE PROCEDURE [dbo].[zCUPGetProgettiFinanziabili]

AS
BEGIN

SELECT 
P.ID_PROGETTO,
P.COD_STATO
FROM vPROGETTO P
INNER JOIN vBANDO B ON
P.ID_BANDO = B.ID_BANDO
INNER JOIN zPROGRAMMAZIONE PRG ON
B.ID_PROGRAMMAZIONE = PRG.ID
INNER JOIN zPSR_ALBERO PA ON
PRG.COD_TIPO = PA.CODICE
INNER JOIN zPSR PSR ON
PA.COD_PSR = PSR.CODICE
INNER JOIN vIMPRESA I ON
P.ID_IMPRESA = I.ID_IMPRESA
WHERE 
--P.COD_STATO IN ('F','V','S','O','T','X','C','Y','E','R')
--P.COD_STATO IN ('F') 
P.ORDINE_FASE>3 AND P.ORDINE_STATO=1
AND 
PSR.CODICE = 'POR20142020'
AND 
P.COD_AGEA IS NULL
AND 
I.COD_FORMA_GIURIDICA NOT IN
(
--'1.6',
'2',
'2.1',
'2.2',
'2.3.',
'2.4',
--'2.4.10',
'2.4.20',
'2.4.30',
'2.4.40',
'2.4.50',
'2.4.60',
'2.5',
'2.6.10',
'2.6.20',
'2.7',
'2.7.11',
'2.7.12',
'2.7.40',
'2.7.51',
'2.7.52',
'2.7.53',
'2.7.54',
'2.7.55',
'2.7.90'
) 

END

