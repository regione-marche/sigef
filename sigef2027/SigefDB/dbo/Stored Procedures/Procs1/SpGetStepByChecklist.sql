﻿CREATE PROCEDURE [dbo].[SpGetStepByChecklist]
(
	@ID_CHECK_LIST INT,
	@COD_FASE CHAR(1)=NULL,
	@MISURA VARCHAR(20)=NULL,
	@DESCRIZIONE VARCHAR(1000)=NULL
)
AS
	-- USATA NELLA PAGINA DI DETTAGLIO DELLA SCHEDA DI VALUTAZIONE
		
	--DECLARE @ID_CHECK_LIST INT,@MISURA VARCHAR(50);SET @ID_CHECK_LIST=7;--SET @MISURA='1'

	SELECT C.ID_CHECK_LIST,C.DESCRIZIONE AS CHECK_LIST,C.FLAG_TEMPLATE,S.ID_STEP,S.DESCRIZIONE AS STEP,S.AUTOMATICO,S.QUERY_SQL,
		S.CODE_METHOD,S.URL,S.VAL_MASSIMO,S.VAL_MINIMO,S.QUERY_SQL_POST,S.FASE_PROCEDURALE,S.ORDINE AS ORDINE_FASE_PROCEDURALE, 
		S.COD_FASE,S.MISURA,X.ORDINE,X.OBBLIGATORIO,X.PESO,X.INCLUDI_VERBALE_VIS,ISNULL(X.ORDINE,9999)
	FROM CHECK_LIST C INNER JOIN CHECK_LIST_X_STEP X ON C.ID_CHECK_LIST=X.ID_CHECK_LIST 
	INNER JOIN vSTEP S ON X.ID_STEP=S.ID_STEP 
	WHERE C.ID_CHECK_LIST=@ID_CHECK_LIST 
	UNION 
	SELECT C.ID_CHECK_LIST,C.DESCRIZIONE AS CHECK_LIST,C.FLAG_TEMPLATE,S.ID_STEP,S.DESCRIZIONE AS STEP,S.AUTOMATICO,S.QUERY_SQL,
		S.CODE_METHOD,S.URL,S.VAL_MASSIMO,S.VAL_MINIMO,S.QUERY_SQL_POST,S.FASE_PROCEDURALE,S.ORDINE AS ORDINE_FASE_PROCEDURALE, 
		S.COD_FASE,S.MISURA,X.ORDINE,X.OBBLIGATORIO,X.PESO,X.INCLUDI_VERBALE_VIS,ISNULL(X.ORDINE,9999)
	FROM vSTEP S LEFT JOIN CHECK_LIST_X_STEP X ON S.ID_STEP=X.ID_STEP AND X.ID_CHECK_LIST=@ID_CHECK_LIST 
	LEFT JOIN CHECK_LIST C ON X.ID_CHECK_LIST=C.ID_CHECK_LIST 
	WHERE (@MISURA IS NULL OR MISURA LIKE '%'+@MISURA+'%') AND (@COD_FASE IS NULL OR S.COD_FASE=@COD_FASE) 
		AND (@DESCRIZIONE IS NULL OR S.DESCRIZIONE LIKE '%'+@DESCRIZIONE+'%')
	ORDER BY ISNULL(X.ORDINE,9999),S.ID_STEP