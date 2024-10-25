﻿CREATE PROCEDURE [dbo].[calcoloStep226_3]
@IdProgetto int
AS
BEGIN
 
--- 226  Superamento tetto massimo di contributo ammesso da bando per la Comunità Montana
 
 
DECLARE @RESULT int,		 
		@CONTRIBUTO_RICHIESTO_PROGETTO DECIMAL (10,2),
		@CONTRIBUTO_RICHIESTO_PASSATO DECIMAL (10,2),
		@PLV_ATTIVITA_CONNESSA DECIMAL (10,2), 
		@PLV_ATTIVITA_CONNESSA_PASSATO DECIMAL (10,2),
		@QUOTA_CONTRIBUTO_TOTALE DECIMAL(10,2),
		@ID_IMPRESA INT, @CUAA VARCHAR(16)

SET @RESULT = 0  -- Impongo lo Step NON verificato
--------------------------------------------------------------------------------------------------------------
SELECT @ID_IMPRESA = P.ID_IMPRESA , @CUAA = imp.CUAA 
FROM PROGETTO P INNER JOIN IMPRESA IMP ON IMP.ID_IMPRESA = P.ID_IMPRESA  WHERE ID_PROGETTO = @IdProgetto 


SET  @CONTRIBUTO_RICHIESTO_PROGETTO = (SELECT SUM(PIANO_INVESTIMENTI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
										FROM PIANO_INVESTIMENTI 
											INNER JOIN PROGETTO ON PIANO_INVESTIMENTI.ID_PROGETTO = PROGETTO.ID_PROGETTO
										WHERE (PIANO_INVESTIMENTI.ID_PROGETTO = @IdProgetto) AND 
									((PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE IS NULL AND PROGETTO.FLAG_DEFINITIVO =0 ) 
									or (PIANO_INVESTIMENTI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND PROGETTO.FLAG_DEFINITIVO =1 AND ID_VARIANTE IS NULL)))

--ID_BANDO = 103

SET @CONTRIBUTO_RICHIESTO_PASSATO = (SELECT SUM(CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
									 FROM PIANO_INVESTIMENTI 
									 WHERE ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL  AND  ID_PROGETTO IN 
														( SELECT ID_PROGETTO FROM vPROGETTO  
															WHERE COD_STATO <> 'R' AND ID_IMPRESA =@ID_IMPRESA  AND FLAG_DEFINITIVO =1 AND  ID_PROGETTO <> @IdProgetto  AND ID_BANDO = 103) )      
 

SET @PLV_ATTIVITA_CONNESSA = ( SELECT SUM(ISNULL(PLV,0)) FROM PLV_IMPRESA 
							   WHERE ID_PROGETTO = @IdProgetto  AND PREVISIONALE =1  AND ID_ATTIVITA_CONNESSA IS NOT NULL )

SET @PLV_ATTIVITA_CONNESSA_PASSATO = ( SELECT SUM(ISNULL(PLV,0)) FROM PLV_IMPRESA 
							           WHERE ID_PROGETTO IN ( SELECT ID_PROGETTO FROM vPROGETTO 
																WHERE COD_STATO <> 'R' AND ID_IMPRESA =@ID_IMPRESA AND FLAG_DEFINITIVO =1 AND ID_PROGETTO <> @IdProgetto)
									   AND PREVISIONALE =1  AND ID_ATTIVITA_CONNESSA IS NOT NULL )

SET @QUOTA_CONTRIBUTO_TOTALE = (ISNULL(@CONTRIBUTO_RICHIESTO_PROGETTO,0) + ISNULL(@CONTRIBUTO_RICHIESTO_PASSATO,0) - ISNULL(@PLV_ATTIVITA_CONNESSA,0 ) - ISNULL(@PLV_ATTIVITA_CONNESSA_PASSATO,0))
--SELECT @CONTRIBUTO_RICHIESTO_PROGETTO as richiesto, @CONTRIBUTO_RICHIESTO_PASSATO as pass, @PLV_ATTIVITA_CONNESSA as PLV, @QUOTA_CONTRIBUTO_TOTALE

-- A	Alta Valmarecchia	150.150,00
IF (@CUAA = '80008330419'  AND   @QUOTA_CONTRIBUTO_TOTALE  <= 150150    )
	 SET @RESULT = 1
-- B	Montefeltro	137.150,00

ELSE IF ((@CUAA = '82005390412' OR @CUAA='01182940419' ) AND   @QUOTA_CONTRIBUTO_TOTALE   <= 137150 )  
	  SET @RESULT = 1
-- C	Alto e Medio Metauro	411.450,00

ELSE IF (@CUAA = '82004630412' AND   @QUOTA_CONTRIBUTO_TOTALE   <= 411450 )  
	  SET @RESULT = 1

--D1	Catria e Nerone	464.100,00

ELSE IF (@CUAA = '82005770415' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 464100 ) 
	  SET @RESULT = 1

--D2	Catria e Cesano	70.850,00 la D2 come detto è soppressa

ELSE IF (@CUAA = ' ' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 70850 )  
	  SET @RESULT = 1
-- E	Metauro	129.350,00

ELSE IF (@CUAA = '81002770410' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 129350 )  
	  SET @RESULT = 1

-- F	Esino – Frasassi	402.350,00

ELSE IF (@CUAA = '81002870426' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 402350 )  
	  SET @RESULT = 1
-- G	San Vicino	109.200,00 la G è soppressa ma con territorio trasferito alla ex H nell’ “Ambito 4”;

ELSE IF (@CUAA = '80005720430' AND @QUOTA_CONTRIBUTO_TOTALE  <= 109200 ) 
	  SET @RESULT = 1
--H	Alte Valli Potenza ed Esino	442.000,00

ELSE IF (@CUAA = '83006070433 ' AND   @QUOTA_CONTRIBUTO_TOTALE   <= (442000 +109200) )  
	  SET @RESULT = 1
-- I	Camerino	341.900,00

ELSE IF (@CUAA = '81001760438' AND   @QUOTA_CONTRIBUTO_TOTALE  <= 341900 ) 
	  SET @RESULT = 1
-- L	Monti Azzurri	136.500,00

ELSE IF (@CUAA = '83012360430 ' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 136500 ) 
	  SET @RESULT = 1

-- M	Sibillini	209.300,00

ELSE IF (@CUAA = '80003250448' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 209300 )  
	  SET @RESULT = 1
-- N	Tronto	245.700,00
ELSE IF (@CUAA = ' ' AND  @QUOTA_CONTRIBUTO_TOTALE  <= 245700 )  
	  SET @RESULT = 1

SELECT @RESULT
 END
