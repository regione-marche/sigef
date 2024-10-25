-- =============================================

CREATE FUNCTION [dbo].[calcoloCodiceABarreFidejussione]
(
	@CONFERMA BIT=0
)
RETURNS CHAR(11)
AS
BEGIN
	DECLARE @RET_CODE CHAR(10)
	IF(@CONFERMA=0) BEGIN
		SET @RET_CODE=CAST(9401080000+ISNULL((SELECT MAX(CAST(SUBSTRING(ISNULL(BARCODE,'9401082000'),7,4) AS INT))+1 AS CODICE FROM FIDEJUSSIONI)
			,2000) AS CHAR(10))
	END
	ELSE BEGIN
		SET @RET_CODE=CAST(9402080000+ISNULL((SELECT MAX(CAST(SUBSTRING(ISNULL(BARCODE_CONFERMA_VALIDITA,'9402082000'),7,4) AS INT))+1 AS CODICE FROM FIDEJUSSIONI)
			,2000) AS CHAR(10))
	END
	
	DECLARE @SEED CHAR(10)
	DECLARE @COUNTER INT 
	DECLARE @CIFRA INT 
	DECLARE @PINT INT 
	DECLARE @PDEC INT
	DECLARE @SUM DECIMAL(10,2)
	DECLARE @P1 CHAR(1)
	DECLARE @CHECKDGT CHAR(1)	
	DECLARE @CODICIONE CHAR(11)	
	
	SET @SEED = @RET_CODE
	SET @COUNTER = 1
	--vengono sostituite le cifre di posizione (2,4,6,8,10) ovvero indice (1,3,5,7,9) con: 
    --la somma della parte decimale e intera del doppio della cifra stessa divisa per 10
	WHILE @COUNTER <=5
	BEGIN
		SET @P1 = SUBSTRING(@SEED,@COUNTER*2,1) --cifre nelle posizioni 2,4,6,8,10
		SET @CIFRA = CAST(@P1 AS INT)*2
		SET @PINT = FLOOR(@CIFRA/10)
		SET @PDEC = @CIFRA%10
		SET @CIFRA = @PINT + @PDEC
		SET @SEED = STUFF(@SEED, @COUNTER*2, 1,CAST(@CIFRA AS CHAR(1)))
		SET @COUNTER = @COUNTER +1
		--IF @COUNTER > 10 BREAK
	END
	-- reinizializzo le variabili per il ciclo successivo
	SET @SUM = 0
	SET @COUNTER = 1
	SET @CIFRA = 0
	-- Sommo tutte le cifre che compongono il codice agea modificato
	WHILE @COUNTER <= 10
	BEGIN
		SET @CIFRA = CAST(SUBSTRING(@SEED,@COUNTER,1) AS INT)
		SET @SUM = @SUM + @CIFRA
		SET @COUNTER = @COUNTER + 1
	END
	--reinizializzazione della variabile di appoggio
	SET @CIFRA = 0
	-- se la divisione della somma ottenuta per dieci è un intero, allora il checkdigit è 0
	-- altrimenti checkdigit = 10 - la parte decimale di @SUM/10
	IF @SUM%10 <> 0 
	BEGIN
		SET @CIFRA = 10 - (@SUM%10)
	END
	SET @CHECKDGT = CAST(@CIFRA AS CHAR(1))
	RETURN @RET_CODE + @CHECKDGT
END
