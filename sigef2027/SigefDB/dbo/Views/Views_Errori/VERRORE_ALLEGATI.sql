﻿-- DROP VIEW VERRORE_ALLEGATI;
CREATE VIEW VERRORE_ALLEGATI
AS
	SELECT ERR_A.* ,
		FIL.TIPO AS TIPO_FILE,
		FIL.NOME_FILE,
		FIL.NOME_COMPLETO AS NOME_COMPLETO_FILE,
		FIL.CONTENUTO AS CONTENUTO_FILE,
		FIL.DIMENSIONE AS DIMENSIONE_FILE,
		FIL.HASH_CODE AS HASH_CODE_FILE
	FROM ERRORE_ALLEGATI ERR_A
		JOIN ERRORE ERR ON ERR_A.ID_ERRORE = ERR.ID_ERRORE
		LEFT JOIN ARCHIVIO_FILE FIL ON ERR_A.ID_ALLEGATO = FIL.ID
;
GO