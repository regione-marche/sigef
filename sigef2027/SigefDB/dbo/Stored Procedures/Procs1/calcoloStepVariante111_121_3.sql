CREATE  PROCEDURE [dbo].[calcoloStepVariante111_121_3]
  @ID_VARIANTE  INT
AS
BEGIN

-- MASSIMALE PER CORSO FORMATIVO

DECLARE @Result int, @CODICE char(2) , @COSTO DECIMAL (18,2)
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
    
 DECLARE CORSO CURSOR FOR
  ( 
		SELECT SUM(COSTO_INVESTIMENTO) AS COSTO,CODICE
		FROM vPIANO_INVESTIMENTI PI WHERE ID_VARIANTE =@ID_VARIANTE AND ISNULL(COD_VARIAZIONE , 'X')!= 'A'
		GROUP BY  CODICE
   ) 
 
OPEN CORSO
FETCH NEXT FROM CORSO 
INTO @COSTO , @CODICE 
WHILE @@FETCH_STATUS = 0
	BEGIN
	IF (@CODICE IN ('41','42','43','44','45', '46','47','60','49','61','62',
					'50','51','52','53' )) -- MIN 150;  MAX  281,25
		BEGIN IF(@COSTO<150 OR @COSTO >281.25) SET @Result =0 END
	 ELSE 
	 BEGIN IF (@CODICE IN ('54')) 
	       BEGIN IF(@COSTO<150 OR @COSTO >281.30) SET @Result =0 END 
	       ELSE 
	       BEGIN IF (@CODICE IN ('56')) 
				 BEGIN IF(@COSTO<140 OR @COSTO >262.50) SET @Result =0 END 
				 ELSE 
				 BEGIN IF (@CODICE IN ('55'))
					   BEGIN IF(@COSTO<141.67 OR @COSTO >265.63) SET @Result =0 END
					   ELSE 
					   BEGIN IF (@CODICE IN ('57'))
							BEGIN IF(@COSTO<141.67 OR @COSTO >265.63) SET @Result =0 END
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
