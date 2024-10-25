CREATE PROCEDURE [dbo].[calcoloPrioritaVariante121_2]
@ID_VARIANTE INT , @ID_PROG_CORRENTE INT -- @ID_PROG_CORRENTE PER LA 121 è L'ID PROGETTO PER IL MULTIMISURA è L'ID PROGETTO INTEGRATO
AS
BEGIN

-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico 
-- (escluso l`acquisto di macchine e attrezzature agricole)
DECLARE @Punteggio decimal(10,2)
DECLARE @Investimenti decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)

 

-- Investimenti Fase VARIANTE


  SET @Investimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
					   FROM PIANO_INVESTIMENTI PI  
					 WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND  isnull(COD_VARIAZIONE,'x')!='A'  AND COD_TIPO_INVESTIMENTO =1 
					AND PI.ID_PROGETTO= @ID_PROG_CORRENTE AND PI.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO 
                                               FROM PRIORITA_X_INVESTIMENTI 
                                               WHERE ID_PRIORITA = 23))


  SET @TotaleInvestimenti = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
				 FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
				 WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A'  AND COD_TIPO_INVESTIMENTO =1 	AND PI.ID_PROGETTO= @ID_PROG_CORRENTE)
                    


 

IF (@TotaleInvestimenti = 0 )SET @Punteggio = 0
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) >= 75) SET @Punteggio = 1
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) >= 50) SET @Punteggio = 0.5
ELSE SET @Punteggio = 0


SELECT @Punteggio AS PUNTEGGIO
RETURN (@Punteggio * 100)


END
