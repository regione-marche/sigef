﻿
CREATE PROCEDURE [dbo].[SpPsrRicercaBandiImpresa] 
(
	@ID_IMPRESA INT,
	@COD_ENTE VARCHAR(10)=NULL,
	@ID_PROGRAMMAZIONE INT=NULL,
	@DATA_SCADENZA_LEQ DATETIME = NULL,
	@ADESIONI BIT=0
)
AS
	SELECT B.*,Q1.NR_PROGETTI,Q1.ID_PROGETTO,Q1.COD_STATO AS COD_STATO_PROGETTO,Q1.STATO AS STATO_PROGETTO,
		Q1.ORDINE_FASE AS ORDINE_FASE_PROGETTO,Q1.ORDINE_STATO AS ORDINE_STATO_PROGETTO,Q1.FLAG_PREADESIONE 
	FROM vBANDO B 
	LEFT JOIN (
		SELECT ID_BANDO,COUNT(*) AS NR_PROGETTI,MAX(ID_PROGETTO) AS ID_PROGETTO,MAX(COD_STATO) AS COD_STATO,MAX(STATO) AS STATO,
			MAX(ORDINE_FASE) AS ORDINE_FASE,MAX(ORDINE_STATO) AS ORDINE_STATO,MAX(CAST(FLAG_PREADESIONE AS INT)) AS FLAG_PREADESIONE
		FROM vPROGETTO WHERE ID_IMPRESA=@ID_IMPRESA GROUP BY ID_BANDO
		--UNION ALL
		--SELECT ID_BANDO,COUNT(*),MAX(M.ID_MANIFESTAZIONE),NULL,MAX(STATO),MAX(ORDINE) AS ORDINE_FASE,MAX(ORDINE_STATO),0
		--FROM vSTATO_MANIFESTAZIONE M INNER JOIN IMPRESA I ON M.CUAA=I.CUAA
		--WHERE ID_IMPRESA=@ID_IMPRESA GROUP BY ID_BANDO
		) AS Q1 ON B.ID_BANDO=Q1.ID_BANDO	
	WHERE B.DISPOSIZIONI_ATTUATIVE=0 AND B.ORDINE_STATO>1 AND (@COD_ENTE IS NULL OR B.COD_ENTE=@COD_ENTE)
		AND (@ID_PROGRAMMAZIONE IS NULL OR B.ID_PROGRAMMAZIONE=@ID_PROGRAMMAZIONE)
		AND (@DATA_SCADENZA_LEQ IS NULL OR DATA_SCADENZA<DATEADD(DAY,1,@DATA_SCADENZA_LEQ))
		AND (@ADESIONI=0 OR (@ADESIONI=1 AND Q1.ID_BANDO IS NOT NULL))
		AND
		B.DATA_APERTURA <= GETDATE()
	ORDER BY B.DATA_SCADENZA DESC
