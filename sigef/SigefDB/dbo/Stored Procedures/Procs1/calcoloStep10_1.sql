CREATE PROCEDURE [dbo].[calcoloStep10_1]
@IdProgetto int, @fase_istruttoria int =0
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
		WHERE ID_PROGETTO =@IdProgetto AND ((ID_INVESTIMENTO_ORIGINALE IS NULL and @fase_istruttoria =0 ) 
											OR(ID_INVESTIMENTO_ORIGINALE IS not NULL and @fase_istruttoria =1 ))
		GROUP BY CODICE
   ) 
 

OPEN CORSO
FETCH NEXT FROM CORSO 
INTO   @COSTO   ,  @CODICE 
WHILE @@FETCH_STATUS = 0
	BEGIN
	IF (@CODICE IN ('1'))  
		BEGIN IF(@COSTO<300 OR @COSTO >750 ) SET @Result =0 END
    ELSE BEGIN
		 IF (@CODICE IN ('2'))
		 BEGIN IF(@COSTO<262 OR @COSTO >655) SET @Result =0 END
		 ELSE BEGIN
			  IF(@CODICE IN ('3' ) )
			  BEGIN IF(@COSTO<310 OR @COSTO >775 ) SET @Result =0 END
			  ELSE BEGIN 
				   IF( @CODICE IN ('4'))
				   BEGIN IF(@COSTO<307 OR @COSTO >769) SET @Result =0 END
				   ELSE BEGIN 
						IF(@CODICE IN ('5','6','7','8'))
						BEGIN IF(@COSTO<310 OR @COSTO >775) SET @Result =0 END
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
