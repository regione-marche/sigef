--- verifica se è presente una sola delle due dichiarazioni in fatto di de minimis
--- e nel caso in cui l'azienda ha già chiesto aiuti verifica che abbia inserito il valore
--- nella priorità e che qeusto più quello richiesto non superi 200.000€

CREATE PROCEDURE [dbo].[calcoloStep122]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN

DECLARE @result int , @D1 int,  @D2 int, @REQ decimal(18,2), @CONTRIBUTO_RICHIESTO decimal(18,2), @PLV decimal(18,2)
SET @result = 0

SELECT @D1 = COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_DICHIARAZIONE IN (581) --- ha beneficiato
SELECT @D2 = COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_DICHIARAZIONE IN (582) --- non ha beneficiato

SELECT @REQ = (SELECT ISNULL (VALORE,0) from PRIORITA_X_PROGETTO WHERE  ID_PRIORITA = 707 AND  ID_PROGETTO = @IdProgetto) 

SELECT @CONTRIBUTO_RICHIESTO = (SELECT SUM(I.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO_RICHIESTO
							FROM  PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON P.ID_PROGETTO = I.ID_PROGETTO 
							WHERE  I.COD_TIPO_INVESTIMENTO = 1 AND
									((@FASE_ISTRUTTORIA=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
										OR
									 (@FASE_ISTRUTTORIA=1 AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL)
									) AND 
								  P.ID_PROGETTO= @IdProgetto)
							
SELECT @PLV = ISNULL(sum(PLV),0) FROM PLV_IMPRESA WHERE ID_PROGETTO = @IdProgetto and ID_ATTIVITA_CONNESSA is not null and PREVISIONALE = 1 --- RECUPERO PLV POST

IF( (ISNULL(@D2,0) = 1 AND ISNULL(@D1,0) = 0 AND (@REQ = 0 OR @REQ IS NULL))
	 OR
	(ISNULL(@D2,0) = 0 and ISNULL(@D1,0) = 1 and ISNULL(@REQ,0) > 0 and (ISNULL(@REQ,0) + (@CONTRIBUTO_RICHIESTO - @PLV)) <= 200000)
  )SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT
END
