﻿CREATE PROCEDURE [dbo].[calcoloPrioritaM41_2]
    @IdProgetto int , 
	@fase_istruttoria bit =0,
	@IdVariante INT = NULL
 AS
BEGIN

/* Priorita A: M4.1  - Ubicazione in aree rurali D e C3 degli investimenti realizzati */

DECLARE @NUM_INVESTIMENTI_MOBILI INT,@NUM_INVESTIMENTI_FISSI INT, @TIPO_AREA VARCHAR(2),
		@ValorePrioritaA decimal(10,4) , @PREVALENZA_MISTO BIT
		
SELECT   @NUM_INVESTIMENTI_FISSI= [0] , @NUM_INVESTIMENTI_MOBILI=[1] 
FROM
(
  SELECT  INV.MOBILE  
  FROM vPIANO_INVESTIMENTI INV  
  WHERE ID_PROGETTO = @IdProgetto AND ((@fase_istruttoria =0 AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR
		(@fase_istruttoria =1 AND (@IdVariante IS NULL AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)
								OR(@IdVariante IS NOT NULL AND ID_VARIANTE =@IdVariante AND ISNULL(INV.COD_VARIAZIONE,'X') !='A' ))) 
 
 ) AS T PIVOT ( COUNT ( MOBILE ) FOR  MOBILE IN ([0],[1])) AS PivotTable 

IF(@NUM_INVESTIMENTI_FISSI>0 AND @NUM_INVESTIMENTI_MOBILI >0) BEGIN  
  SELECT TOP(1) @PREVALENZA_MISTO = INV.MOBILE  
  FROM vPIANO_INVESTIMENTI INV  
  WHERE ID_PROGETTO = @IdProgetto AND ((@fase_istruttoria =0 AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR
		(@fase_istruttoria =1 AND (@IdVariante IS NULL AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)
								OR(@IdVariante IS NOT NULL AND ID_VARIANTE =@IdVariante AND ISNULL(INV.COD_VARIAZIONE,'X') !='A' ))) 
  GROUP BY INV.MOBILE 
  ORDER BY SUM(COSTO_INVESTIMENTO )DESC 
  
  IF(@PREVALENZA_MISTO = 0) SET @NUM_INVESTIMENTI_MOBILI =0
  ELSE SET @NUM_INVESTIMENTI_FISSI =0
  
END

IF(@NUM_INVESTIMENTI_MOBILI =0)BEGIN  
	  SELECT TOP(1) @TIPO_AREA= C.TIPO_AREA 
	  FROM PIANO_INVESTIMENTI INV  
		  INNER JOIN VLOCALIZZAZIONE_INVESTIMENTO LOC ON LOC.ID_INVESTIMENTO = INV.ID_INVESTIMENTO 
		  INNER JOIN vCOMUNI C ON C.ID_COMUNE = LOC.ID_COMUNE 
	  WHERE ID_PROGETTO = @IdProgetto AND ((@fase_istruttoria =0 AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR
			(@fase_istruttoria =1 AND (@IdVariante IS NULL AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)
									OR(@IdVariante IS NOT NULL AND ID_VARIANTE =@IdVariante AND ISNULL(INV.COD_VARIAZIONE,'X') !='A' ))) 
END
ELSE IF(@NUM_INVESTIMENTI_FISSI=0)BEGIN  
     
      SELECT TOP(1) @TIPO_AREA= T.TIPO_AREA FROM PROGETTO P INNER JOIN VTERRITORIO T ON T.ID_FASCICOLO = P.ID_FASCICOLO  
	  WHERE ID_PROGETTO = @IdProgetto 
	  GROUP BY TIPO_AREA ORDER BY SUM(SUPERFICIE_CONDOTTA)DESC

END

IF(@TIPO_AREA IS NULL )SET @ValorePrioritaA =0
ELSE IF(@TIPO_AREA ='D')SET @ValorePrioritaA =1
ELSE IF(@TIPO_AREA ='C3')SET @ValorePrioritaA =0.8
ELSE SET @ValorePrioritaA =0

SELECT @ValorePrioritaA 
END