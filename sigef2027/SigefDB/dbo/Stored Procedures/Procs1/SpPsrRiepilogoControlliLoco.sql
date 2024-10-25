﻿CREATE PROCEDURE [dbo].[SpPsrRiepilogoControlliLoco]
(
	@ID_PROGRAMMAZIONE INT=NULL,
	@ANNO INT =NULL
)
AS
	DECLARE @LOTTI_CREATI INT,@LOTTI_ESTRATTI INT,@LOTTI_CONCLUSI INT,@TOTALE_DOMANDE INT,@TOTALE_DOMANDE_LOTTI INT,
	@TOTALE_DOMANDE_CONTROLLATE INT,@CONTRIBUTO_RICHIESTO_TOTALE DECIMAL(18,2),@CONTRIBUTO_RICHIESTO_TOTALE_LOTTI DECIMAL(18,2),
	@CONTRIBUTO_RICHIESTO_CONTROLLATO DECIMAL(18,2),@CONTRIBUTO_AMMESSO_TOTALE DECIMAL(18,2),@CONTRIBUTO_AMMESSO_TOTALE_LOTTI DECIMAL(18,2),
	@CONTRIBUTO_AMMESSO_CONTROLLATO DECIMAL(18,2),@CONTRIBUTO_PAGATO_TOTALE DECIMAL(18,2),@CONTRIBUTO_PAGATO_TOTALE_LOTTI DECIMAL(18,2),
	@CONTRIBUTO_PAGATO_CONTROLLATO DECIMAL(18,2),@CONTRIBUTO_PAGATO_ANNO_TOTALE DECIMAL(18,2),@CONTRIBUTO_PAGATO_ANNO_TOTALE_LOTTI DECIMAL(18,2),
	@CONTRIBUTO_PAGATO_ANNO_CONTROLLATO DECIMAL(18,2)

	SELECT @LOTTI_CREATI=COUNT(*) FROM CONTROLLI_LOCO_LOTTO -- creati visualizzo tutti
	SELECT @LOTTI_ESTRATTI=COUNT(*) FROM CONTROLLI_LOCO_LOTTO WHERE NUMERO_ESTRAZIONI>0 
		AND (@ID_PROGRAMMAZIONE IS NULL OR ID_PROGRAMMAZIONE = @ID_PROGRAMMAZIONE) AND (@ANNO IS NULL OR YEAR(DATA_ESTRAZIONE)=@ANNO)
	SELECT @LOTTI_CONCLUSI=COUNT(*) FROM (
		SELECT C.ID_LOTTO,MAX(D.DATA_MODIFICA) AS MAX_DATA 
		FROM CONTROLLI_LOCO_LOTTO C INNER JOIN CONTROLLI_DOMANDE_PAGAMENTO D ON C.ID_LOTTO=D.ID_LOTTO
		WHERE C.CONTROLLO_CONCLUSO=1 AND D.CONTROLLO_CONCLUSO=1 AND (@ANNO IS NULL OR YEAR(D.DATA_MODIFICA)=@ANNO)
		AND (@ID_PROGRAMMAZIONE IS NULL OR ID_PROGRAMMAZIONE = @ID_PROGRAMMAZIONE) GROUP BY C.ID_LOTTO) Q1
		
	-- TOTALE CONTRIBUTO E DOMANDE DI PAGAMENTO PRESENTATE
	SELECT @TOTALE_DOMANDE=COUNT(*),@CONTRIBUTO_RICHIESTO_TOTALE=SUM(Q1.CRICHIESTO),@CONTRIBUTO_AMMESSO_TOTALE=SUM(Q2.CAMMESSO),
		@CONTRIBUTO_PAGATO_TOTALE=SUM(Q2.CLIQUIDATO),@CONTRIBUTO_PAGATO_ANNO_TOTALE=0--SUM(Q3.CLIQUIDATO_ANNO)
	FROM DOMANDA_DI_PAGAMENTO D
	INNER JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(CONTRIBUTO_RICHIESTO) AS CRICHIESTO FROM PAGAMENTI_RICHIESTI GROUP BY ID_DOMANDA_PAGAMENTO
		) Q1 ON D.ID_DOMANDA_PAGAMENTO=Q1.ID_DOMANDA_PAGAMENTO
	LEFT JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_AMMESSO) AS CAMMESSO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO 
		FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE GROUP BY ID_DOMANDA_PAGAMENTO
		) Q2 ON D.ID_DOMANDA_PAGAMENTO=Q2.ID_DOMANDA_PAGAMENTO
	--LEFT JOIN (
	--	SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO_ANNO
	--	FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE E INNER JOIN AGEA_DECRETI A ON E.ID_DECRETO_AGEA=A.ID
	--	WHERE YEAR(A.DATA)=@ANNO GROUP BY ID_DOMANDA_PAGAMENTO) Q3 ON D.ID_DOMANDA_PAGAMENTO=Q3.ID_DOMANDA_PAGAMENTO
	WHERE SEGNATURA IS NOT NULL AND ANNULLATA=0 AND (APPROVATA IS NULL OR APPROVATA=1)
	
	-- TOTALE CONTRIBUTO E DOMANDE DI PAGAMENTO NEI LOTTI
	SELECT @TOTALE_DOMANDE_LOTTI=COUNT(*),@CONTRIBUTO_RICHIESTO_TOTALE_LOTTI=SUM(Q1.CRICHIESTO),
		@CONTRIBUTO_AMMESSO_TOTALE_LOTTI=SUM(Q2.CAMMESSO),@CONTRIBUTO_PAGATO_TOTALE_LOTTI=SUM(Q2.CLIQUIDATO),
		@CONTRIBUTO_PAGATO_ANNO_TOTALE_LOTTI=0--SUM(Q3.CLIQUIDATO_ANNO)
	FROM CONTROLLI_DOMANDE_PAGAMENTO D INNER JOIN CONTROLLI_LOCO_LOTTO L ON D.ID_LOTTO=L.ID_LOTTO
	INNER JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(CONTRIBUTO_RICHIESTO) AS CRICHIESTO FROM PAGAMENTI_RICHIESTI GROUP BY ID_DOMANDA_PAGAMENTO
		) Q1 ON D.ID_DOMANDA_PAGAMENTO=Q1.ID_DOMANDA_PAGAMENTO
	LEFT JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_AMMESSO) AS CAMMESSO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO
		FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE GROUP BY ID_DOMANDA_PAGAMENTO
		) Q2 ON D.ID_DOMANDA_PAGAMENTO=Q2.ID_DOMANDA_PAGAMENTO
	--LEFT JOIN (
	--	SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO_ANNO
	--	FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE E INNER JOIN AGEA_DECRETI A ON E.ID_DECRETO_AGEA=A.ID
	--	WHERE YEAR(A.DATA)=@ANNO GROUP BY ID_DOMANDA_PAGAMENTO) Q3 ON D.ID_DOMANDA_PAGAMENTO=Q3.ID_DOMANDA_PAGAMENTO
	WHERE (@ANNO IS NULL OR YEAR(DATA_ESTRAZIONE)=@ANNO) AND (@ID_PROGRAMMAZIONE IS NULL OR ID_PROGRAMMAZIONE = @ID_PROGRAMMAZIONE)
		
	-- TOTALE CONTRIBUTO E DOMANDE DI PAGAMENTO CONTROLLATE
	SELECT @TOTALE_DOMANDE_CONTROLLATE=COUNT(*),@CONTRIBUTO_RICHIESTO_CONTROLLATO=SUM(Q1.CRICHIESTO),
		@CONTRIBUTO_AMMESSO_CONTROLLATO=SUM(Q2.CAMMESSO),@CONTRIBUTO_PAGATO_CONTROLLATO=SUM(Q2.CLIQUIDATO),
		@CONTRIBUTO_PAGATO_ANNO_CONTROLLATO=0--SUM(Q3.CLIQUIDATO_ANNO)
	FROM CONTROLLI_DOMANDE_PAGAMENTO D INNER JOIN CONTROLLI_LOCO_LOTTO L ON D.ID_LOTTO=L.ID_LOTTO
	INNER JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(CONTRIBUTO_RICHIESTO) AS CRICHIESTO FROM PAGAMENTI_RICHIESTI GROUP BY ID_DOMANDA_PAGAMENTO
		) Q1 ON D.ID_DOMANDA_PAGAMENTO=Q1.ID_DOMANDA_PAGAMENTO
	LEFT JOIN (
		SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_AMMESSO) AS CAMMESSO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO
		FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE GROUP BY ID_DOMANDA_PAGAMENTO
		) Q2 ON D.ID_DOMANDA_PAGAMENTO=Q2.ID_DOMANDA_PAGAMENTO
	--LEFT JOIN (
	--	SELECT ID_DOMANDA_PAGAMENTO,SUM(IMPORTO_LIQUIDATO) AS CLIQUIDATO_ANNO
	--	FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE E INNER JOIN AGEA_DECRETI A ON E.ID_DECRETO_AGEA=A.ID
	--	WHERE YEAR(A.DATA)=@ANNO GROUP BY ID_DOMANDA_PAGAMENTO) Q3 ON D.ID_DOMANDA_PAGAMENTO=Q3.ID_DOMANDA_PAGAMENTO
	WHERE D.CONTROLLO_CONCLUSO=1 AND (@ANNO IS NULL OR YEAR(DATA_ESTRAZIONE)=@ANNO)
		AND (@ID_PROGRAMMAZIONE IS NULL OR ID_PROGRAMMAZIONE = @ID_PROGRAMMAZIONE)

	SELECT ISNULL(@LOTTI_CREATI,0) AS LOTTI_CREATI,ISNULL(@LOTTI_ESTRATTI,0) AS LOTTI_CAMPIONATI,ISNULL(@LOTTI_CONCLUSI,0) AS LOTTI_CONCLUSI,
		ISNULL(@TOTALE_DOMANDE,0) AS TOTALE_DOMANDE,ISNULL(@TOTALE_DOMANDE_LOTTI,0) AS TOTALE_DOMANDE_LOTTI,
		ISNULL(@TOTALE_DOMANDE_CONTROLLATE,0) AS TOTALE_DOMANDE_CONTROLLATE,
		ISNULL(@CONTRIBUTO_RICHIESTO_TOTALE,0) AS CONTRIBUTO_RICHIESTO_TOTALE,
		ISNULL(@CONTRIBUTO_RICHIESTO_TOTALE_LOTTI,0) AS CONTRIBUTO_RICHIESTO_TOTALE_LOTTI,
		ISNULL(@CONTRIBUTO_RICHIESTO_CONTROLLATO,0) AS CONTRIBUTO_RICHIESTO_CONTROLLATO,
		ISNULL(@CONTRIBUTO_AMMESSO_TOTALE,0) AS CONTRIBUTO_AMMESSO_TOTALE,
		ISNULL(@CONTRIBUTO_AMMESSO_TOTALE_LOTTI,0) AS CONTRIBUTO_AMMESSO_TOTALE_LOTTI,
		ISNULL(@CONTRIBUTO_AMMESSO_CONTROLLATO,0) AS CONTRIBUTO_AMMESSO_CONTROLLATO,
		ISNULL(@CONTRIBUTO_PAGATO_TOTALE,0) AS CONTRIBUTO_PAGATO_TOTALE,
		ISNULL(@CONTRIBUTO_PAGATO_TOTALE_LOTTI,0) AS CONTRIBUTO_PAGATO_TOTALE_LOTTI,
		ISNULL(@CONTRIBUTO_PAGATO_CONTROLLATO,0) AS CONTRIBUTO_PAGATO_CONTROLLATO,
		ISNULL(@CONTRIBUTO_PAGATO_ANNO_TOTALE,0) AS CONTRIBUTO_PAGATO_ANNO_TOTALE,
		ISNULL(@CONTRIBUTO_PAGATO_ANNO_TOTALE_LOTTI,0) AS CONTRIBUTO_PAGATO_ANNO_TOTALE_LOTTI,
		ISNULL(@CONTRIBUTO_PAGATO_ANNO_CONTROLLATO,0) AS CONTRIBUTO_PAGATO_ANNO_CONTROLLATO
