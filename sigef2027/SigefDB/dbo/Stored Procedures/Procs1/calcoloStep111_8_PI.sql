CREATE  PROCEDURE [dbo].[calcoloStep111_8_PI]
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0 
AS
BEGIN

-- MASSIMALE PER CORSO FORMATIVO

DECLARE @Result int, @ID_CODIFICA_INVESTIMENTO INT , @COSTO DECIMAL (18,2) , @CODICE CHAR(2)
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
    
 DECLARE CORSO CURSOR FOR
  ( 
		SELECT SUM(COSTO_INVESTIMENTO) AS COSTO , CODICE
		FROM VPIANO_INVESTIMENTI PI WHERE ID_PROGETTO =@IdProgetto AND
		 ((ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA = 0 )OR
		 ( ID_INVESTIMENTO_ORIGINALE IS NOT  NULL AND @FASE_ISTRUTTORIA = 1 )  )
		GROUP BY CODICE
   ) 
 
 
OPEN CORSO
FETCH NEXT FROM CORSO 
INTO   @COSTO   ,  @CODICE
WHILE @@FETCH_STATUS = 0
	BEGIN
	IF (@CODICE IN ( '61' )) -- MIN 400,00 750,00
		BEGIN 
			IF(@COSTO<400  OR @COSTO >750  ) SET @Result =0
		END
	 ELSE 
		BEGIN
						IF (@CODICE IN ('62', '63','64','65','66')) -- 366.67 687,50
							BEGIN
								IF(@COSTO< 366.67  OR @COSTO >687.50 ) SET @Result =0
							END
					ELSE BEGIN IF (@CODICE IN ('67')) -- 334,00 --->  625,00
												BEGIN
													IF(@COSTO< 334  OR @COSTO >625 ) SET @Result =0
												END
								END
		END 			

	FETCH NEXT FROM CORSO
INTO @COSTO   ,  @CODICE 
END

CLOSE CORSO
DEALLOCATE CORSO 
 
SELECT @Result AS RESULT


END
