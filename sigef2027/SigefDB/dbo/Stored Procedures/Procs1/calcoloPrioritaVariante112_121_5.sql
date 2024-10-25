CREATE PROCEDURE [dbo].[calcoloPrioritaVariante112_121_5]
(
  @ID_VARIANTE INT,
  @IdProgetto int 
 
)
AS
BEGIN

-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5

DECLARE @Investimenti decimal(10,2)
DECLARE @TotaleInvestimenti decimal(10,2)

SET @Investimenti = 
(
SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI I WHERE I.ID_PROGETTO=@IdProgetto AND I.ID_PRIORITA_SETTORIALE IS NOT NULL 
AND I.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
)

SET @TotaleInvestimenti = 
(
SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI I WHERE I.ID_PROGETTO=@IdProgetto 
AND I.ID_VARIANTE = @ID_VARIANTE   AND isnull(COD_VARIAZIONE,'x')!='A' 
)

DECLARE @Punteggio decimal(10,2)
IF(@TotaleInvestimenti = 0 )SET @Punteggio = 0
 
ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.7)) SET @Punteggio = 1 

ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.4) AND
         @Investimenti < (@TotaleInvestimenti * 0.7)) SET @Punteggio = 0.8

ELSE IF (@Investimenti >= (@TotaleInvestimenti * 0.2) AND
         @Investimenti < (@TotaleInvestimenti * 0.4)) SET @Punteggio = 0.4

ELSE SET @Punteggio = 0

RETURN (@Punteggio * 100)

END
