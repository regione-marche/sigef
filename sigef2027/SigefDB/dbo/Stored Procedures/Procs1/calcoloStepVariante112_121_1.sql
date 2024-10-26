﻿CREATE  PROCEDURE [dbo].[calcoloStepVariante112_121_1]
 @ID_VARIANTE INT
AS
-- 
--  112 - 121 - verifica % spese tecniche per fasce di spesa di investimento: 
--  < 200.000,00 € -> 10%  
--  >= 200.000,00 € e < 500.000,00 € -> 6%  
--  >= 500.000,00 € -> 3%
DECLARE @IdProgetto INT
--SET @IdProgetto=356*/
SET @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)

-- TROVO IL PROGETTO 

DECLARE @ID_PROG_CORRENTE_121 INT, @ID_BANDO_121 INT 

SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO, @ID_BANDO_121=P.ID_BANDO FROM PROGETTO P
	INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

DECLARE @COSTO_INVESTIMENTO DECIMAL(18,2), @SPESE_TECNICHE DECIMAL(18,2)
DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2), @QUOTA_CONTRIBUTO DECIMAL(18,2)
DECLARE @QUOTA_SPESE_TECNICHE DECIMAL(18,2)

DECLARE @RESULT INT
SET @RESULT=1 -- LO IMPONGO VERIFICATO

DECLARE INVESTIMENTO CURSOR FOR
(
	SELECT COSTO_INVESTIMENTO,SPESE_GENERALI,CONTRIBUTO_RICHIESTO,QUOTA_CONTRIBUTO_RICHIESTO,QUOTA_SPESE_GENERALI 
	FROM VPIANO_INVESTIMENTI PI 	 
	WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND PI .ID_PROGETTO=@ID_PROG_CORRENTE_121 
			AND COD_TIPO_INVESTIMENTO = 1 --AND MOBILE=0
)
OPEN INVESTIMENTO
FETCH NEXT FROM INVESTIMENTO
INTO @COSTO_INVESTIMENTO,@SPESE_TECNICHE ,@CONTRIBUTO_RICHIESTO,@QUOTA_CONTRIBUTO,@QUOTA_SPESE_TECNICHE
WHILE @@FETCH_STATUS = 0
BEGIN

	SET @QUOTA_SPESE_TECNICHE=CASE 
		WHEN @COSTO_INVESTIMENTO>500000 AND @QUOTA_SPESE_TECNICHE>3 THEN 3
		WHEN @COSTO_INVESTIMENTO>200000 AND @QUOTA_SPESE_TECNICHE>6 THEN 6
		ELSE @QUOTA_SPESE_TECNICHE
	END
	IF((@CONTRIBUTO_RICHIESTO*100/@QUOTA_CONTRIBUTO-@COSTO_INVESTIMENTO)>(@COSTO_INVESTIMENTO*@QUOTA_SPESE_TECNICHE/100))
	BEGIN
 		SET @RESULT=0
		BREAK
	END
	FETCH NEXT FROM INVESTIMENTO
	INTO @COSTO_INVESTIMENTO,@SPESE_TECNICHE ,@CONTRIBUTO_RICHIESTO,@QUOTA_CONTRIBUTO,@QUOTA_SPESE_TECNICHE
END
CLOSE INVESTIMENTO
DEALLOCATE INVESTIMENTO

SELECT @RESULT AS RESULT
