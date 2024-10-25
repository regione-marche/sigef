CREATE PROCEDURE [dbo].[calcoloPrioritaRequisitoPagamento121_2]
@ID_DOMANDA_PAGAMENTO INT , 
@ID_PROG_CORRENTE INT -- @ID_PROG_CORRENTE PER LA 121 è L'ID PROGETTO PER IL MULTIMISURA è L'ID PROGETTO INTEGRATO
AS
BEGIN

-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico 
-- (escluso l`acquisto di macchine e attrezzature agricole)
DECLARE @Punteggio decimal(10,2)
DECLARE @Investimenti decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)

 

-- Investimenti Fase PAGAMENTO


  SET @Investimenti =  (SELECT SUM ( ISNULL(PB.IMPORTO_AMMESSO,PB.IMPORTO_RICHIESTO) )  FROM 
							PAGAMENTI_BENEFICIARIO PB 
							INNER JOIN PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO= PR.ID_PAGAMENTO_RICHIESTO
							WHERE PR.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI 
                                               WHERE ID_PRIORITA = 23) AND  ( ID_DOMANDA_PAGAMENTO IN 
							( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
						     WHERE (APPROVATA =1 AND ID_PROGETTO= @ID_PROG_CORRENTE   AND ANNULLATA =0 
								)OR ID_DOMANDA_PAGAMENTO =@ID_DOMANDA_PAGAMENTO)) )


  SET @TotaleInvestimenti = (SELECT SUM ( ISNULL(PB.IMPORTO_AMMESSO,PB.IMPORTO_RICHIESTO) )  FROM 
							PAGAMENTI_BENEFICIARIO PB 
							INNER JOIN PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO= PR.ID_PAGAMENTO_RICHIESTO
							WHERE ( ID_DOMANDA_PAGAMENTO IN 
							( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
						     WHERE (APPROVATA =1 AND ID_PROGETTO= @ID_PROG_CORRENTE  AND ANNULLATA = 0
							 )OR ID_DOMANDA_PAGAMENTO =@ID_DOMANDA_PAGAMENTO)) )
                    


IF (@TotaleInvestimenti = 0 )SET @Punteggio = 0
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) >= 75) SET @Punteggio = 1
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) >= 50) SET @Punteggio = 0.5
ELSE SET @Punteggio = 0


SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)


END
