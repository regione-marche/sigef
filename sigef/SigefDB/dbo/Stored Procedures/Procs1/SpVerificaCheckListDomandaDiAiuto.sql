﻿CREATE PROCEDURE [dbo].[SpVerificaCheckListDomandaDiAiuto]
(
	@ID_PROGETTO INT,
	@ID_DOMANDA_PAGAMENTO INT=NULL,
	@COD_FASE CHAR(1),
	@OPERATORE CHAR(16)
)
AS
	/*DECLARE @ID_PROGETTO INT,@ID_DOMANDA_PAGAMENTO INT,@COD_FASE CHAR(1),@OPERATORE CHAR(16)
	SET @ID_PROGETTO=515
	SET @COD_FASE='P'
	SET @OPERATORE=''*/

	DECLARE STEP_DI_CONTROLLO CURSOR FOR
	SELECT C.ID_STEP,OBBLIGATORIO,AUTOMATICO,QUERY_SQL,VAL_MINIMO,VAL_MASSIMO,COD_ESITO,DATA FROM PROGETTO P
	INNER JOIN STEP_X_BANDO X ON P.ID_BANDO=X.ID_BANDO AND X.COD_FASE=@COD_FASE
	INNER JOIN CHECK_LIST_X_STEP C ON X.ID_CHECK_LIST=C.ID_CHECK_LIST
	INNER JOIN STEP S ON C.ID_STEP=S.ID_STEP
	LEFT JOIN ITER_PROGETTO I ON P.ID_PROGETTO=I.ID_PROGETTO AND S.ID_STEP=I.ID_STEP
	WHERE P.ID_PROGETTO=@ID_PROGETTO
	ORDER BY ORDINE 

	DECLARE @ID_STEP INT,@OBBLIGATORIO BIT,@AUTOMATICO BIT,@QUERY_SQL NVARCHAR(3000),@VAL_MIN DECIMAL(15,2),@VAL_MAX DECIMAL(15,2),
		@COD_ESITO CHAR(2),@DATA DATETIME,@RISULTATO_QUERY DECIMAL(15,2),@FASE_ISTRUTTORIA BIT,@NUOVO_STEP BIT,@ESITO_VERIFICA BIT
	SET @FASE_ISTRUTTORIA=CASE WHEN @COD_FASE='P' THEN 0 ELSE 1 END
	SET @NUOVO_STEP=0
	SET @ESITO_VERIFICA=1  -- 1: VERIFICATA, 0 NO

	-- MEMORIZZO IL RISULTATO DELLE QUERY IN MODO DA NON VISUALIZZARLO COME OUTPUT
	DECLARE @PROVA_TABELLA TABLE(ID INT IDENTITY(1,1) NOT NULL,RISULTATO DECIMAL(15,2))

	OPEN STEP_DI_CONTROLLO
	FETCH NEXT FROM STEP_DI_CONTROLLO INTO @ID_STEP,@OBBLIGATORIO,@AUTOMATICO,@QUERY_SQL,@VAL_MIN,@VAL_MAX,@COD_ESITO,@DATA
	WHILE @@FETCH_STATUS=0 BEGIN		
		-- ESEGUO SOLO GLI STEP AUTOMATICI, QUELLI MANUALI E QUELLI CON CODE_METHOD LI INTENDO GIA' ESEGUITI
		IF @AUTOMATICO=1 AND @QUERY_SQL IS NOT NULL BEGIN
			IF @DATA IS NULL SET @NUOVO_STEP=1
			-- PULISCO
			SET @RISULTATO_QUERY=NULL
			DELETE FROM @PROVA_TABELLA
			BEGIN TRY
				-- ESEGUO LA QUERY
				INSERT INTO @PROVA_TABELLA
				--exec sp_executesql @QUERY_SQL,N'@IdProgetto INT,@IdDomandaPagamento INT,@fase_istruttoria bit',@ID_PROGETTO,@ID_DOMANDA_PAGAMENTO,
				--	@FASE_ISTRUTTORIA				
				exec SpExecQuerySql @QUERY_SQL,@ID_PROGETTO,@ID_DOMANDA_PAGAMENTO,@FASE_ISTRUTTORIA			
				SELECT TOP 1 @RISULTATO_QUERY=RISULTATO FROM @PROVA_TABELLA ORDER BY ID DESC
				SET @COD_ESITO='SI'
				IF @VAL_MIN IS NOT NULL AND @RISULTATO_QUERY<@VAL_MIN SET @COD_ESITO='NO'
				IF @VAL_MAX IS NOT NULL AND @RISULTATO_QUERY>@VAL_MAX SET @COD_ESITO='NO'
			END TRY
			BEGIN CATCH
				--SELECT ERROR_MESSAGE()
				SET @COD_ESITO='NO'
			END CATCH		
					
			IF @NUOVO_STEP=1 INSERT INTO ITER_PROGETTO (ID_PROGETTO,ID_STEP,COD_ESITO,DATA,CF_OPERATORE)
				VALUES(@ID_PROGETTO,@ID_STEP,@COD_ESITO,GETDATE(),@OPERATORE)
			ELSE UPDATE ITER_PROGETTO SET COD_ESITO=@COD_ESITO,DATA=GETDATE(),CF_OPERATORE=@OPERATORE 
				WHERE ID_PROGETTO=@ID_PROGETTO AND ID_STEP=@ID_STEP
			
			IF @OBBLIGATORIO=1 AND @COD_ESITO='NO' SET @ESITO_VERIFICA=0
		END	
		IF @OBBLIGATORIO=1 AND (@COD_ESITO IS NULL OR @COD_ESITO='NO') SET @ESITO_VERIFICA=0	
		FETCH NEXT FROM STEP_DI_CONTROLLO INTO @ID_STEP,@OBBLIGATORIO,@AUTOMATICO,@QUERY_SQL,@VAL_MIN,@VAL_MAX,@COD_ESITO,@DATA
	END
	CLOSE STEP_DI_CONTROLLO
	DEALLOCATE STEP_DI_CONTROLLO
	RETURN @ESITO_VERIFICA
