﻿CREATE PROCEDURE [dbo].[calcoloStep431_2]
@IdProgetto int
AS
BEGIN
 
--- massimale di aiuto per l'intervento B
 
 
DECLARE @RESULT int,@CONTRIBUTO_RICHIESTO_PROGETTO_B DECIMAL (10,2),
	    @CONTRIBUTO_RICHIESTO_PASSATO_B DECIMAL (10,2),
	    @QUOTA_CONTRIBUTO_TOTALE_B DECIMAL(10,2), @ID_IMPRESA INT, @CUAA VARCHAR(16)

SET @RESULT = 0  -- Impongo lo Step NON verificato
--------------------------------------------------------------------------------------------------------------
SELECT @ID_IMPRESA = P.ID_IMPRESA , @CUAA = imp.CUAA  
FROM PROGETTO P INNER JOIN IMPRESA IMP ON IMP.ID_IMPRESA = P.ID_IMPRESA  WHERE ID_PROGETTO = @IdProgetto 

 
SET @CONTRIBUTO_RICHIESTO_PROGETTO_B = (SELECT SUM(PI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
										FROM PIANO_INVESTIMENTI PI INNER JOIN
											PROGETTO ON PI.ID_PROGETTO = PROGETTO.ID_PROGETTO
										WHERE (PI.ID_PROGETTO = @IdProgetto) AND PI.ID_PROGRAMMAZIONE = 326 AND
											((PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND PROGETTO.FLAG_DEFINITIVO =0 ) 
											OR (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND PROGETTO.FLAG_DEFINITIVO =1 AND ID_VARIANTE IS NULL )))

--ID_BANDO = 100
SET @CONTRIBUTO_RICHIESTO_PASSATO_B = (SELECT SUM(CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
									   FROM PIANO_INVESTIMENTI inv
										INNER JOIN PROGETTO p ON inv.ID_PROGETTO = p.ID_PROGETTO
									   WHERE ID_INVESTIMENTO_ORIGINALE IS NOT NULL  AND  ID_PROGRAMMAZIONE = 326  AND 
											 p.ID_PROGETTO <> @IdProgetto and  ID_IMPRESA = @ID_IMPRESA AND ID_BANDO = 106  )      
 

 SET @QUOTA_CONTRIBUTO_TOTALE_B = (ISNULL(@CONTRIBUTO_RICHIESTO_PROGETTO_B,0) + ISNULL(@CONTRIBUTO_RICHIESTO_PASSATO_B,0)   )

 --select @QUOTA_CONTRIBUTO_TOTALE_B
 
-- A	Alta Valmarecchia    TOTALE  € 852.045,08 	 
IF (@CUAA =  '01119560439'   AND      @QUOTA_CONTRIBUTO_TOTALE_B <=  213011.27 )
	 SET @RESULT = 1
-- B	Montefeltro Sviluppo 	 TOTALE  € 836.048,86 

ELSE IF ((@CUAA = '01377860414' )    AND  @QUOTA_CONTRIBUTO_TOTALE_B   <=  209012.22   )  
	  SET @RESULT = 1

-- C	Sibilla 	   € 920.633,20 
ELSE IF (@CUAA = '01451540437'  AND @QUOTA_CONTRIBUTO_TOTALE_B   <=  230158.30  )  
	  SET @RESULT = 1

--D1	Flaminia Cesano 	 € 655.201,44 
ELSE IF (@CUAA = '01377760416'   AND  @QUOTA_CONTRIBUTO_TOTALE_B  <=  163800.36  ) 
	  SET @RESULT = 1

--D2	Piceno     € 660.202,29 

ELSE IF (@CUAA = '01502360447' AND  @QUOTA_CONTRIBUTO_TOTALE_B  <=  165050.57  )  
	  SET @RESULT = 1

-- E	Fermano Leader  € 674.050,97 


ELSE IF (@CUAA = '01944950441'   AND  @QUOTA_CONTRIBUTO_TOTALE_B  <=  168512.74   )  
	  SET @RESULT = 1
 
 
 SELECT @RESULT
 END