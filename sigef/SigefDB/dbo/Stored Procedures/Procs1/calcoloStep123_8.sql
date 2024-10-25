CREATE  PROCEDURE [dbo].[calcoloStep123_8]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT 
AS
BEGIN
--
 
--  123 - verifica % spese tecniche per fasce di spesa di investimento:
 --Per progetti i cui costi materiali sopra indicati superano l’importo di € 500.000,00 al netto dell’IVA, 
-- le spese tecniche progettuali sono ammissibili in misura pari al 60% del costo dell’intero progetto.
-- FATTO!!! 
--declare @IdProgetto int,
-- @FASE_ISTRUTTORIA INT  
--
--set @IdProgetto=7400
--set @FASE_ISTRUTTORIA=0

DECLARE  @count int, 
					@COUNT_INV INT,   
					@RESULT INT

SET @RESULT=0  --- NON VERIFICATO

 SET  @count = (SELECT COUNT(*)
				FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
				WHERE  ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 ) 
						OR(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA=1 ) ) AND I.COD_TIPO_INVESTIMENTO = 1  and id_variante is null
						AND (P.ID_PROGETTO=@IdProgetto )  
				GROUP BY  i.ID_PROGETTO
				HAVING  SUM(COSTO_INVESTIMENTO) > 500000  )
IF (@Count > 0) 
BEGIN 
SET @COUNT_INV = 	( SELECT    COUNT(*) FROM   ( SELECT  COUNT(*)   	AS CONT
												FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
												WHERE ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 ) OR(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA=1 ) )
																 AND I.COD_TIPO_INVESTIMENTO = 1  AND  id_variante is null
																 AND (P.ID_PROGETTO=@IdProgetto )
												GROUP BY I.ID_PROGETTO, SPESE_GENERALI, COSTO_INVESTIMENTO, QUOTA_SPESE_GENERALI
												HAVING    SPESE_GENERALI >CAST( (COSTO_INVESTIMENTO * ( (QUOTA_SPESE_GENERALI/100)* 0.6)  ) AS DECIMAL (10,2))) AS T )

	IF  (ISNULL(@COUNT_INV,0) >0 ) SET @RESULT=0 
	ELSE SET @RESULT=1 
END
ELSE SET @RESULT=1 
	
SELECT @RESULT

END
