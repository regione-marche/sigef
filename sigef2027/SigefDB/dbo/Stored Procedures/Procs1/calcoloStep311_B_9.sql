CREATE  PROCEDURE [dbo].[calcoloStep311_B_9]
@IdProgetto int
AS
BEGIN


-- 311 B  AZIONE c - verificata corretta compilazione quadro materie prime soltanto nel caso che si è Imprenditore Agricolo

DECLARE @Result int,
	 @AGRICOLO INT , 
		@QUANTITA_TOT decimal(15,2) , 
		@QUANTITA_PROPRIA decimal(10,2)

SET @Result = 1 -- Impongo lo Step  verificato

-- solo se è imprenditore agricolo

SET @AGRICOLO= (SELECT  count(*) FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 188 )
DECLARE @COUNT INT

SET @COUNT=   ( SELECT COUNT(*) FROM PRODOTTI_VENDITE where MATERIA_PRIMA=1 and Id_Progetto =@IdProgetto  )

IF (@AGRICOLO=0 AND @COUNT>0)
		SET @Result = 0
 


SELECT @Result AS RESULT

END
