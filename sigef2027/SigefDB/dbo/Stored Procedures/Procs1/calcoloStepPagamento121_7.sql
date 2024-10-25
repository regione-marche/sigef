CREATE  PROCEDURE [dbo].[calcoloStepPagamento121_7]
 @IdProgetto INT , @IdDomandaPagamento INT  
AS
BEGIN

	-- 121 (zucchero) - verifica massimale investimento fotovoltaico:
	-- a) Ciascun investimento avente come specifica "fotovoltaico" non può superare i 400000€
    -- b) Ciascun contributo ammissibile non può superare il 30% della somma di tutti gli investimenti

	DECLARE @Count_a int
	DECLARE @Count_b int
	DECLARE @TotaleInvestimenti decimal(10,2), @ID_PROGETTO INT
--DECLARE  @IdProgetto INT = 2457 , @IdDomandaPagamento INT =1692
	-- Numero di investimenti "fotovoltaico" che superano i 400000€
	SET @Count_a = (SELECT count(ID_INVESTIMENTO)  FROM 
							   PAGAMENTI_BENEFICIARIO PB 
						INNER JOIN PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO= PR.ID_PAGAMENTO_RICHIESTO
						WHERE ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PIANO_INVESTIMENTI 
												 WHERE   COD_TIPO_INVESTIMENTO = 1 AND (ID_SPECIFICA_INVESTIMENTO = 236 or  ID_SPECIFICA_INVESTIMENTO = 757  or  ID_SPECIFICA_INVESTIMENTO = 2452))
						AND ( ID_DOMANDA_PAGAMENTO IN ( 
									SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE (APPROVATA =1 AND ID_PROGETTO= @IdProgetto AND ANNULLATA =0
						)OR ID_DOMANDA_PAGAMENTO =@IdDomandaPagamento   )   )
						GROUP BY ID_INVESTIMENTO
						HAVING SUM(ISNULL(PB.IMPORTO_AMMESSO,PB.IMPORTO_RICHIESTO))> 400000 )
					
	
	-- Totale investimenti
	SET @TotaleInvestimenti = (SELECT SUM ( ISNULL(IMPORTO_AMMISSIBILE,0) )  FROM 
							DOMANDA_DI_PAGAMENTO_ESPORTAZIONE
								WHERE ( ID_DOMANDA_PAGAMENTO IN 
								( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
						    	 WHERE (APPROVATA =1 AND ID_PROGETTO= @IdProgetto  AND ANNULLATA =0
								)OR ID_DOMANDA_PAGAMENTO =@IdDomandaPagamento)) )
--SELECT @TotaleInvestimenti
--SELECT @Count_b
	-- Numero di investimenti in cui il contributo ammissibile supera il 30% del totale di tutti gli investimenti
	SET @Count_b = (SELECT count(ID_INVESTIMENTO)  FROM  
					 PAGAMENTI_RICHIESTI PR  
						WHERE ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PIANO_INVESTIMENTI 
												 WHERE   COD_TIPO_INVESTIMENTO = 1 AND  (  ID_SPECIFICA_INVESTIMENTO = 236 or  ID_SPECIFICA_INVESTIMENTO = 757 or  ID_SPECIFICA_INVESTIMENTO = 2452))
						AND ( ID_DOMANDA_PAGAMENTO IN ( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE 
								(APPROVATA =1 AND ID_PROGETTO= @IdProgetto AND ANNULLATA =0
								)OR ID_DOMANDA_PAGAMENTO =@IdDomandaPagamento   )   )
						GROUP BY ID_INVESTIMENTO
						HAVING SUM(ISNULL(PR.CONTRIBUTO_AMMESSO,PR.CONTRIBUTO_RICHIESTO))> (@TotaleInvestimenti * 0.3) )
		
	-- Se almeno uno dei due count è > 0 allora il controllo da esito negativo
	IF (@Count_a > 0 OR @Count_b > 0) SELECT 0 AS RESULT
	ELSE SELECT 1 AS RESULT

END
