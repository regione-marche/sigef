CREATE   PROCEDURE [dbo].[calcoloStep111_4]
@IdProgetto int
AS
BEGIN

-- MASSIMALE PER CORSO FORMATIVO

DECLARE @Result int, @CODICE CHAR(2) , @COSTO DECIMAL (18,2)
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
    
 DECLARE CORSO CURSOR FOR
  ( 
		SELECT SUM(COSTO_INVESTIMENTO) AS COSTO , CODICE
		FROM VPIANO_INVESTIMENTI PI  
		WHERE ID_PROGETTO =@IdProgetto AND ID_INVESTIMENTO_ORIGINALE IS NULL
		GROUP BY CODICE
   ) 
 
 
OPEN CORSO
FETCH NEXT FROM CORSO 
INTO   @COSTO   ,  @CODICE 
WHILE @@FETCH_STATUS = 0
	BEGIN
	IF (@CODICE IN ( 1,3,2, 4,5,7,8,9,10,12,13,14,15,16,17 )) -- MIN 400;  MAX  750
		BEGIN 
			IF(@COSTO<400 OR @COSTO >750 ) SET @Result =0
		END
	 ELSE 
		BEGIN
						IF (@CODICE IN (6))
							BEGIN
								IF(@COSTO<324 OR @COSTO >607.50) SET @Result =0
							END
						ELSE 
								BEGIN
								 IF( @CODICE IN (11 ) )
										BEGIN
												IF(@COSTO<387.50 OR @COSTO >726.56) SET @Result =0
										END
								ELSE
									BEGIN 
											IF( @CODICE IN (18,19 ) )
											BEGIN 
														IF(@COSTO<389.47 OR @COSTO >730.25) SET @Result =0
											END
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
