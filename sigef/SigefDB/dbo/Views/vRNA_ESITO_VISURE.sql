﻿CREATE VIEW vRNA_ESITO_VISURE AS 
SELECT 
	P.ID_BANDO,
	P.ID_PROGETTO,
	LOG_V.ID_IMPRESA,
	LOG_V.ID_RICHIESTA,
	LOG_V.TIPO_VISURA,
	LOG_V.CODICE_ESITO,
	LOG_V.DATA_AGGIORNAMENTO,
	LOG_V.CODICE_STATO_RICHIESTA
FROM
	PROGETTO P INNER JOIN
	RNA_LOG_VISURE LOG_V ON LOG_V.ID_PROGETTO = P.ID_PROGETTO
GO




