﻿


CREATE PROCEDURE [dbo].[SpGetListaProgettiInGraduatoria]
(
	@ID_BANDO INT
)
AS
	--DECLARE @ID_BANDO INT = 244
	SELECT G.*,PSTO.SEGNATURA,PSTO.ID_ATTO,A.NUMERO,A.DATA,A.REGISTRO,A.COD_DEFINIZIONE,A.AW_DOCNUMBER,A.AW_DOCNUMBER_NUOVO
	FROM GRADUATORIA_PROGETTI G 
	INNER JOIN vPROGETTO P ON G.ID_PROGETTO = P.ID_PROGETTO AND P.COD_STATO <> 'B' AND P.ORDINE_FASE BETWEEN 3 AND 90
	LEFT JOIN (
		SELECT ID_PROGETTO,MIN(DATA) DATA_MIN,COD_STATO FROM vPROGETTO_STORICO WHERE ORDINE_FASE = 4 GROUP BY ID_PROGETTO,COD_STATO) PS
		ON G.ID_PROGETTO = PS.ID_PROGETTO AND ((G.FINANZIABILITA = 'N' AND PS.COD_STATO = 'N') OR (G.FINANZIABILITA != 'N' AND PS.COD_STATO = 'F'))
	LEFT JOIN PROGETTO_STORICO PSTO ON G.ID_PROGETTO = PSTO.ID_PROGETTO AND PS.DATA_MIN = PSTO.DATA AND PSTO.COD_STATO IN ('F', 'N')
	LEFT JOIN ATTI A ON PSTO.ID_ATTO=A.ID_ATTO
	WHERE G.ID_BANDO=@ID_BANDO ORDER BY G.ORDINE