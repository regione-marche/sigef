create PROCEDURE [dbo].[calcoloPrioritaRequisitoPagamento311_1]
@IdProgetto int , 
@ID_DOMANDA_PAGAMENTO int
 AS
BEGIN

DECLARE @Punteggio decimal(10,2)


--311 - Numero finale strutture

-- Controllo dell'esistenza di investimenti destinati a migliorare i servizi agrituristici delle aziende
-- ID Priorità: 29
DECLARE @InvestimentiServiziExists int
SET @InvestimentiServiziExists = (SELECT COUNT(PI.ID_INVESTIMENTO) 
                                  FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
								  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
                                         AND ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                                                 FROM PRIORITA_X_INVESTIMENTI 
                                                                 WHERE ID_PRIORITA = 29))
IF (@InvestimentiServiziExists > 0)
	BEGIN
     
	   DECLARE @InvestimentiPerServizi decimal(10,2),
						  @TotaleInvestimenti decimal(10,2), @IMPORTO_AMMESSO   decimal(10,2),  @IMPORTO_DOMANDA_ATTUALE  decimal(10,2),
						@TotaleInvestimentiPrioritaAmmesso  decimal(10,2), @TotaleInvestimentiPriorita  decimal(10,2)
	   DECLARE @CodiceValore varchar(10)

SET @IMPORTO_AMMESSO = ( 
						SELECT  SUM( ISNULL( PB.IMPORTO_AMMESSO,0 ))
						 FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
								  PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
						 WHERE ID_DOMANDA_PAGAMENTO  IN (SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO 
															WHERE ID_PROGETTO = @IdProgetto AND APPROVATA = 1  AND ANNULLATA=0
														  ) 
						 AND SPESA_TECNICA_RICHIESTA =0 
					   )	

SET @IMPORTO_DOMANDA_ATTUALE =  ( SELECT  SUM( ISNULL( PB.IMPORTO_RICHIESTO,0 ))
								  FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
										  PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
								  WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND SPESA_TECNICA_RICHIESTA =0 )  
 
SET @TotaleInvestimenti = ISNULL(@IMPORTO_AMMESSO,0) + ISNULL( @IMPORTO_DOMANDA_ATTUALE,0)
  
	SET @TotaleInvestimentiPrioritaAmmesso = (
										SELECT  SUM (ISNULL(PB.IMPORTO_AMMESSO,0))
										FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
												PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
										WHERE   SPESA_TECNICA_RICHIESTA =0 AND ID_INVESTIMENTO IN
										(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA =29  )																	    
										AND ID_DOMANDA_PAGAMENTO IN 
										( SELECT ID_DOMANDA_PAGAMENTO FROM DOMANDA_DI_PAGAMENTO WHERE APPROVATA = 1 AND ID_PROGETTO= @IdProgetto  AND ANNULLATA =0
											)									  
									  )

	SET @TotaleInvestimentiPriorita = (										 
										SELECT  SUM (ISNULL(PB.IMPORTO_RICHIESTO,0))
										FROM    PAGAMENTI_BENEFICIARIO PB INNER JOIN
												PAGAMENTI_RICHIESTI PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO
										WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  AND SPESA_TECNICA_RICHIESTA =0 AND ID_INVESTIMENTO IN
										(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA =29  )
									  )

 SET @InvestimentiPerServizi =  ISNULL(@TotaleInvestimentiPrioritaAmmesso,0) + ISNULL(@TotaleInvestimentiPriorita,0)

 	  -- 311 - Numero finale strutture (ID PRIORITA: 59)				        	  
	  SET @CodiceValore = (SELECT CODICE 
                           FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON (PP.ID_VALORE = VP.ID_VALORE)
	                       WHERE PP.ID_PROGETTO = @IdProgetto AND PP.ID_PRIORITA = 59)


      -- 3. Calcolo il punteggio	 
     IF (@CodiceValore IS NULL) SET @Punteggio = 0
	 ELSE
       BEGIN
	   
		 -- Quota investimenti per servizi > 30% del costo totale con 3 o più strutture
		 IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 1

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale con 3 o più strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.3) AND @CodiceValore = '3') SET @Punteggio = 0.8

		 -- Quota investimenti per servizi > 20% e < 30% sul costo totale e 2 strutture
			-- solo quota > 20 %
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.2) AND @CodiceValore = '2') SET @Punteggio = 0.65

		 -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 3 o più strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.2) AND @CodiceValore = '3') SET @Punteggio = 0.5

	     -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 2 strutture
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND
				  @InvestimentiPerServizi <= (@TotaleInvestimenti * 0.2) AND @CodiceValore = '2') SET @Punteggio = 0.4

		 -- Quota investimenti per servizi > 15% e 1 struttura
	     ELSE IF (@InvestimentiPerServizi > (@TotaleInvestimenti * 0.15) AND @CodiceValore = '1') SET @Punteggio = 0.3
            
		 ELSE SET @Punteggio = 0
                 
       END

	END

ELSE SET @Punteggio = 0

SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END
