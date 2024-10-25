﻿CREATE  PROCEDURE [dbo].[calcoloStepVariante123_12]
(
@ID_VARIANTE INT
)
AS
BEGIN
 
--CONTROLLO ULA  PROGETTO 

DECLARE @ID_IMPRESA INT ,@result int ,@IdProgetto INT
SET @RESULT =1 --PONGO LO STEP VERIFICATO
-- CONTRIBUTO RICHIESTO AMMISSIBILE PER LE DOMANDE AMMISSIBILI DELL'IMPRESA (il contriburo va calcolato solo per le domande del PSR e non per i bandi PABS )
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2),@CONTRIBUTO_RICHIESTO_TOT DECIMAL(18,2),
		 @ID_PROG INT , @STATO CHAR(1), @ID_BANDO INT, @COD_PSR VARCHAR(20), @CODICE VARCHAR(20)
 
SELECT @ID_IMPRESA =ID_IMPRESA , @IdProgetto=PROGETTO.ID_PROGETTO FROM PROGETTO 
WHERE ID_PROGETTO = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE =@ID_VARIANTE)  

DECLARE PROGETTI CURSOR FOR 
SELECT  ID_PROGETTO, STATO,  (CONTRIBUTO + PREMIO)  AS CONTRIBUTO 
FROM (SELECT V.ID_VARIANTE, ISNULL(SP.ID_PROG_INTEGRATO,SP.ID_PROGETTO) AS ID_PROGETTO, STATO, SP.ID_BANDO,  
		 dbo.calcoloContributoTotaleProgetto(ISNULL(SP.ID_PROGETTO,SP.ID_PROGETTO), FLAG_DEFINITIVO, v.ID_VARIANTE) AS CONTRIBUTO , 
		 dbo.calcoloPremioContoCapitale( SP.ID_PROGETTO,FLAG_DEFINITIVO  , v.ID_VARIANTE)  AS PREMIO
	  FROM  vPROGETTO SP  
			 LEFT JOIN (SELECT TOP(1) ID_VARIANTE , ID_PROGETTO FROM  VARIANTI WHERE  APPROVATA = 1 ORDER BY ID_VARIANTE DESC) AS V ON V.ID_PROGETTO = SP.ID_PROGETTO
					    WHERE SP.ID_PROGETTO IN  (SELECT ID_PROGETTO FROM vPROGETTO WHERE ID_IMPRESA= @ID_IMPRESA AND FLAG_PREADESIONE =0  AND COD_STATO NOT IN ('P','Q','B', 'R','N', 'E') OR ID_PROGETTO = @IdProgetto   )  
			GROUP BY SP.ID_PROGETTO , STATO, SP.ID_BANDO, SP.ID_PROG_INTEGRATO, V.ID_VARIANTE, FLAG_DEFINITIVO) AS PROG
GROUP BY ID_PROGETTO, STATO , CONTRIBUTO, PREMIO 

SET @CONTRIBUTO_RICHIESTO_TOT =0

OPEN PROGETTI
FETCH NEXT FROM PROGETTI 
INTO  @ID_PROG , @STATO , @CONTRIBUTO_RICHIESTO 
WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT  TOP(1) @COD_PSR = COD_PSR , @CODICE = PR.CODICE FROM BANDO B INNER JOIN vzPROGRAMMAZIONE PR ON PR.ID= B.ID_PROGRAMMAZIONE  
	WHERE ID_BANDO = ( SELECT  ID_BANDO  FROM  PROGETTO  WHERE  ID_PROGETTO = @ID_PROG ) 
	IF( @COD_PSR LIKE 'PSR%' AND @CODICE NOT LIKE '2.%' )SET @CONTRIBUTO_RICHIESTO_TOT  = ISNULL(@CONTRIBUTO_RICHIESTO_TOT,0) + ISNULL(@CONTRIBUTO_RICHIESTO,0)
FETCH NEXT FROM PROGETTI 
INTO  @ID_PROG , @STATO,@CONTRIBUTO_RICHIESTO 
END
CLOSE PROGETTI
DEALLOCATE PROGETTI 

IF(@CONTRIBUTO_RICHIESTO_TOT > 3000000 ) SET @RESULT =0 END
SELECT @RESULT  AS RESULT
