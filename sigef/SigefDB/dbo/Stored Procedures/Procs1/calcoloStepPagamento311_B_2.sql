﻿CREATE  PROCEDURE [dbo].[calcoloStepPagamento311_B_2]
(
@IdProgetto INT,
  @IdDomandaPagamento  INT 
)
AS
BEGIN

-- 147 -  EFFICIENZA  ENERGETICA
 
DECLARE @CONTRIBUTO decimal(10,2)
DECLARE @Investimenti decimal(10,2)
DECLARE @ID_CODIFICA_INVESTIMENTO INT
 

 DECLARE CONTRIBUTO CURSOR FOR

			SELECT      PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO,  SUM(ISNULL( PR.CONTRIBUTO_AMMESSO,0)) AS SPESA  
			FROM         PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
								  PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
								  PIANO_INVESTIMENTI ON PR.ID_INVESTIMENTO = PIANO_INVESTIMENTI.ID_INVESTIMENTO
			WHERE     (PR.ID_DOMANDA_PAGAMENTO IN
									  (SELECT     ID_DOMANDA_PAGAMENTO
										FROM          DOMANDA_DI_PAGAMENTO
										WHERE      (APPROVATA = 1) AND (ID_PROGETTO = @IdProgetto) AND (ANNULLATA = 0) OR
															   (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)))
			GROUP BY  PIANO_INVESTIMENTI.ID_CODIFICA_INVESTIMENTO
			ORDER BY    SUM(PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO ) desc

	OPEN CONTRIBUTO
	FETCH NEXT FROM CONTRIBUTO INTO @CONTRIBUTO, @ID_CODIFICA_INVESTIMENTO
	CLOSE CONTRIBUTO
	DEALLOCATE CONTRIBUTO

DECLARE @Punteggio decimal (10,2)

set @Punteggio= (SELECT  TOP (1)   VALORI_PRIORITA.PUNTEGGIO 
									FROM PRIORITA_X_INVESTIMENTI INNER JOIN
									 VALORI_PRIORITA ON 
									 PRIORITA_X_INVESTIMENTI.ID_VALORE = VALORI_PRIORITA.ID_VALORE INNER JOIN
									 PIANO_INVESTIMENTI  P ON PRIORITA_X_INVESTIMENTI.ID_INVESTIMENTO = P.ID_INVESTIMENTO inner join
								     PAGAMENTI_RICHIESTI PR ON PR.ID_INVESTIMENTO = P.ID_INVESTIMENTO
									 WHERE P.ID_PROGETTO = @IdProgetto 
									AND P.ID_CODIFICA_INVESTIMENTO =@ID_CODIFICA_INVESTIMENTO 
									 AND PRIORITA_X_INVESTIMENTI.ID_PRIORITA = 147  AND PR.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento  	  )

 SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)

END
