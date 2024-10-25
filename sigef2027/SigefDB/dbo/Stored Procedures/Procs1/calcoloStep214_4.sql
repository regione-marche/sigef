﻿-- Il progetto rispetta i massimali di aiuto ammessi ai sensi della d.g.r. n. 788/09 per tipologia di investimento (1V/A = 50.000; 2V/A = 56.000; 3V/A = 55.000)
-- UNICO BENEFICIARIO ASSAM CUAA= 01491360424

CREATE PROCEDURE [dbo].[calcoloStep214_4]
@IdProgetto int
AS
BEGIN

DECLARE 
@RESULT INT,@CUAA VARCHAR(16)

SET @RESULT =1 --PONGO LO STEP NN VERIFICATO
SELECT @CUAA= IMP.CUAA FROM PROGETTO P INNER JOIN IMPRESA IMP ON P.ID_IMPRESA =IMP.ID_IMPRESA  WHERE ID_PROGETTO = @IdProgetto
  
IF (@CUAA  = '01491360424')
	BEGIN
		IF( (SELECT SUM (ISNULL(COSTO_INVESTIMENTO,0)) FROM PIANO_INVESTIMENTI PI
									INNER JOIN VPROGETTO P ON P.ID_PROGETTO = PI.ID_PROGETTO 
				WHERE ID_CODIFICA_INVESTIMENTO IN (904, 907) AND PI.ID_PROGETTO = @IdProgetto AND
								((P.COD_STATO ='P' and ID_INVESTIMENTO_ORIGINALE IS NULL and ID_VARIANTE is null  ) OR 
	 							(P.COD_STATO !='P' AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL  AND ID_VARIANTE is null  ) )) > 60000) SET @RESULT  = 0  
	
		ELSE IF((SELECT SUM (ISNULL(COSTO_INVESTIMENTO,0)) FROM PIANO_INVESTIMENTI PI
											INNER JOIN VPROGETTO P ON P.ID_PROGETTO = PI.ID_PROGETTO 
						WHERE ID_CODIFICA_INVESTIMENTO IN (905, 908)  AND PI.ID_PROGETTO = @IdProgetto AND ( (P.COD_STATO ='P' and ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE is null ) 
										OR (P.COD_STATO !='P' AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE is null ) )) >70000 ) SET @RESULT =  0
		
       ELSE IF ((SELECT SUM (ISNULL(COSTO_INVESTIMENTO,0)) FROM PIANO_INVESTIMENTI PI
				INNER JOIN VPROGETTO P ON P.ID_PROGETTO = PI.ID_PROGETTO 
				WHERE ID_CODIFICA_INVESTIMENTO IN (906, 909) AND PI.ID_PROGETTO = @IdProgetto AND ( (P.COD_STATO ='P' AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE is null  ) 
								OR (P.COD_STATO !='P' AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE is null  ) )) > 60000 ) SET @RESULT = 0  

	END
 ELSE SET @RESULT = 0 

 SELECT   @RESULT AS RESULT
	
END
