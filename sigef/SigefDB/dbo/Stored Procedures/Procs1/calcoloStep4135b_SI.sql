CREATE PROCEDURE [dbo].[calcoloStep4135b_SI]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
	
-- Rispetto tetto massimo investimenti pari a 150.000€ per i progetti presentati per i bandi misura 4135b1 e 4135b2
-- progetti solo per uno dei due bandi

DECLARE @RESULT int, @TOTALE decimal(10,2),
		@CONTA249 int,
		@CONTA255 int,
		@ID_IMPRESA INT

SET @RESULT = 1 -- PONGO LO STEP IN STATO   VERIFICATO
SET @TOTALE = 0 		
SET @CONTA249 = 0 	
SET @CONTA255 = 0 	


SELECT @ID_IMPRESA = ID_IMPRESA  FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto 
SET @CONTA249 = (SELECT COUNT(P.ID_PROGETTO) FROM PROGETTO P
	INNER JOIN PROGETTO_STORICO PS ON PS.ID_PROGETTO = P.ID_PROGETTO 
WHERE ID_IMPRESA = @ID_IMPRESA and ID_BANDO in (249) AND ( ( COD_STATO ='P' AND P.ID_PROGETTO = @IdProgetto )OR( COD_STATO ='L' AND P.ID_PROGETTO != @IdProgetto)))

                 
SET @CONTA255 = (SELECT COUNT(P.ID_PROGETTO) FROM PROGETTO P
	INNER JOIN PROGETTO_STORICO PS ON PS.ID_PROGETTO = P.ID_PROGETTO 
WHERE ID_IMPRESA = @ID_IMPRESA and ID_BANDO in (255) AND ( ( COD_STATO ='P' AND P.ID_PROGETTO = @IdProgetto )OR( COD_STATO ='L' AND P.ID_PROGETTO != @IdProgetto)))

SELECT @TOTALE = DBO.calcoloCostoTotaleProgetto (@IdProgetto, @FASE_ISTRUTTORIA , null)

IF(@CONTA249 >= 1  AND @CONTA255 >=1 ) SET @RESULT =0
ELSE IF( @TOTALE > 150000) SET @RESULT=0

SELECT @RESULT
END
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
