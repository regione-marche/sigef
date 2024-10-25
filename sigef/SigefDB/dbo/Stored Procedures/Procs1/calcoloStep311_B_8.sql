CREATE  PROCEDURE [dbo].[calcoloStep311_B_8]
@IdProgetto int
AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40%  @RICAVO_LORDO
DECLARE @result int , @RataIntegrazione decimal(10,2), @RICAVO_LORDO decimal(10,2)
 
SET @RataIntegrazione = (SELECT ISNULL(SUM((CASE I.MOBILE
												 WHEN 1 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 10 
												 WHEN 0 THEN (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 ELSE (I.COSTO_INVESTIMENTO + I.SPESE_GENERALI) / 30
												 END)) , 0)
								FROM PROGETTO P 
									INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO)
								WHERE ((FLAG_DEFINITIVO=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR (FLAG_DEFINITIVO = 1 AND I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))  
                                      AND I.COD_TIPO_INVESTIMENTO = 1 AND (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto)                                   
							 )

SET @RICAVO_LORDO = (SELECT ISNULL( VALORE,0) AS RICAVO_LORDO FROM  PRIORITA_X_PROGETTO 
                     WHERE  ID_PROGETTO = @IdProgetto AND ID_PRIORITA  = 197)

IF (@RataIntegrazione <= (@RICAVO_LORDO * 0.4)) SET @result = 1
ELSE SET @result = 0

SELECT @result AS RESULT

END
