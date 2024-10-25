CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_121_6]
(
@ID_VARIANTE INT ,
@IdProgetto int 
)
AS
BEGIN

-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico 
-- (escluso l`acquisto di macchine e attrezzature agricole)
DECLARE @Punteggio decimal(10,2)
DECLARE @Investimenti decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)


SET @Investimenti = 
(
SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI I WHERE I.ID_PROGETTO=@IdProgetto
AND I.ID_INVESTIMENTO IN (SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA = 23)
AND I.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
)

SET @TotaleInvestimenti = 
(
SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI I WHERE I.ID_PROGETTO=@IdProgetto 
AND I.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A'  
)

IF (@TotaleInvestimenti = 0)  SET @Punteggio = 0 
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) > 75) SET @Punteggio = 1
ELSE IF (((@Investimenti/@TotaleInvestimenti)*100) > 50) SET @Punteggio = 0.5
ELSE SET @Punteggio = 0
 
RETURN (@Punteggio * 100)



END
