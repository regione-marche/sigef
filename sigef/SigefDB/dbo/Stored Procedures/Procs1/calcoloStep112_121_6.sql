﻿CREATE PROCEDURE [dbo].[calcoloStep112_121_6]
@IdProgetto int, @fase_istruttoria int=0
AS
	-- 112 - 121 - verifica massimale investimento fotovoltaico:
	-- a) La somma degli investimenti aventi come specifica "fotovoltaico" non può superare i 100000€
    -- b) Costo ammissibile sul fotovoltatico non può superare il 30% del costo 
DECLARE @RESULT INT
--SET @RESULT =1
/* 
 
DECLARE @IdProgetto INT
SET @IdProgetto=356*/

-- TROVO IL PROGETTO INTEGRATO

DECLARE @ID_PROG_CORRENTE_121 INT, @ID_BANDO_121 INT 

SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO, @ID_BANDO_121=P.ID_BANDO FROM PROGETTO P
		INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto
DECLARE @COSTO_INVESTIMENTI_FOTOVOLTAICI DECIMAL(18,2)=0,  @COSTO_INVESTIMENTI_TOTALE DECIMAL(18,2)=0
		, @COSTO_INVESTIMENTO DECIMAL(18,2), @ID_SPECIFICA INT

DECLARE INVESTIMENTO CURSOR FOR
(SELECT COSTO_INVESTIMENTO,ID_SPECIFICA_INVESTIMENTO FROM PIANO_INVESTIMENTI I
INNER JOIN PROGETTO P ON I.ID_PROGETTO=P.ID_PROGETTO
	WHERE I.ID_PROGETTO=@ID_PROG_CORRENTE_121 AND COD_TIPO_INVESTIMENTO = 1 AND 
((@fase_istruttoria =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)OR(@fase_istruttoria = 1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND  ID_VARIANTE IS NULL )))

OPEN INVESTIMENTO
FETCH NEXT FROM INVESTIMENTO
INTO @COSTO_INVESTIMENTO, @ID_SPECIFICA
WHILE @@FETCH_STATUS = 0
BEGIN
	SET @COSTO_INVESTIMENTI_TOTALE=@COSTO_INVESTIMENTI_TOTALE+@COSTO_INVESTIMENTO 
	IF( @ID_SPECIFICA= 2572)
	BEGIN
		SET @COSTO_INVESTIMENTI_FOTOVOLTAICI=@COSTO_INVESTIMENTI_FOTOVOLTAICI+@COSTO_INVESTIMENTO		 
	END
	FETCH NEXT FROM INVESTIMENTO
	INTO @COSTO_INVESTIMENTI_TOTALE, @ID_SPECIFICA
END
CLOSE INVESTIMENTO
DEALLOCATE INVESTIMENTO

SET @RESULT=CASE WHEN @COSTO_INVESTIMENTI_FOTOVOLTAICI>100000 OR
				      @COSTO_INVESTIMENTI_FOTOVOLTAICI>(@COSTO_INVESTIMENTI_TOTALE*0.3)THEN 0
				ELSE 1 END
SELECT @RESULT