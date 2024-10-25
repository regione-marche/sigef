CREATE PROCEDURE [dbo].[calcoloPrioritaVariante121_3]
 @ID_VARIANTE INT , @ID_PROG_CORRENTE INT -- @ID_PROG_CORRENTE PER LA 121 è L'ID PROGETTO PER IL MULTIMISURA è L'ID PROGETTO INTEGRATO
AS
BEGIN

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5
 -- ID_PRIORITA= 22

DECLARE @Investimenti decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)


SET @Investimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
					 FROM PIANO_INVESTIMENTI PI  
					 WHERE  PI.ID_VARIANTE=@ID_VARIANTE  AND    isnull(COD_VARIAZIONE,'x')!='A' AND PI.ID_PROGETTO=@ID_PROG_CORRENTE AND 
			         PI.ID_PRIORITA_SETTORIALE IS NOT NULL AND COD_TIPO_INVESTIMENTO =1 ) 

SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0) 
						   FROM PIANO_INVESTIMENTI PI  
						   WHERE PI.ID_VARIANTE=@ID_VARIANTE  AND isnull(COD_VARIAZIONE,'x')!='A' AND  COD_TIPO_INVESTIMENTO =1  AND PI.ID_PROGETTO=@ID_PROG_CORRENTE   )

DECLARE @Punteggio decimal(10,2)

IF(@TotaleInvestimenti = 0 )SET @Punteggio = 0
ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.7)) SET @Punteggio = 1 

ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.4) AND
         @Investimenti < (@TotaleInvestimenti * 0.7)) SET @Punteggio = 0.8

ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.2) AND
         @Investimenti < (@TotaleInvestimenti * 0.4)) SET @Punteggio = 0.4

ELSE SET @Punteggio = 0

SELECT @Punteggio AS PUNTEGGIO	
RETURN (@Punteggio * 100)

END
