﻿CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento112_valutazione]
@ID_DOMANDA_PAGAMENTO INT
 AS
BEGIN
-- COMPILAZIONE OBBLIGATORIA QUADRI BP PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
 
DECLARE @RESULT INT, @COPERTURA DECIMAL (10,2), @FABBISOGNO DECIMAL(10,2) 
SET @RESULT =1 --PONGO LO STEP VERIFICATO
 
IF (( SELECT  COUNT (*) FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO )>=3 )
	BEGIN 
		
		DECLARE PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO CURSOR  FOR 
		 (SELECT  SUM ( ISNULL (COSTO_INVESTIMENTO,0) + ISNULL (SPESE_GESTIONE,0) + ISNULL (RIMBORSO_DEBITO,0 )) AS FABBISOGNO , 
							SUM( ISNULL (MEZZI_PROPRI,0) + ISNULL (RISORSE_TERZI,0) + ISNULL (CONTRIBUTI_PUBBLICI,0) + ISNULL (ENTRATA_GESTIONE,0) + ISNULL (ALTRE_COPERTURE,0) )AS COPERTURA  
		 FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO WHERE  ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO   GROUP BY  ANNO ) 

OPEN PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
FETCH NEXT FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
INTO @FABBISOGNO,@COPERTURA
	WHILE @@FETCH_STATUS = 0
	BEGIN
	IF( @FABBISOGNO <0 OR @COPERTURA<0 )
	BEGIN 
		SET @RESULT=0
		BREAK
	END
	ELSE 	 
	IF( @COPERTURA - @FABBISOGNO <0  )
		BEGIN
		SET @RESULT=0
		BREAK
		END	
FETCH NEXT FROM PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
INTO @FABBISOGNO,@COPERTURA
END
CLOSE PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO
DEALLOCATE PIANO_DI_SVILUPPO_DOMANDA_PAGAMENTO

END
ELSE SET @RESULT =0
SELECT @RESULT AS RESULT
END