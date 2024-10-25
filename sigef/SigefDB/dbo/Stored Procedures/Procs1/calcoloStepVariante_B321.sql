create PROCEDURE [dbo].[calcoloStepVariante_B321]
@ID_VARIANTE int
AS
BEGIN

---=== Rispetto massimale investimento (80.000€ zona C3 - 120.000€ zona D) ===--

--- ID PRIORITA' () 986 PLURIVALORE CHE IDENTIFICA LA ZONA 
--- ZONA D ---> ID_VALORE 1006
--- ZONA C3 --> ID_VALORE 1007

DECLARE @Result int,
		@COSTO_TOT_PROGETTO decimal(18,2), 
		@IdProgetto int,
		@ZONA INT
		

SET @Result = 1 -- Impongo lo Step  verificato

set @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE =@ID_VARIANTE )

SET @ZONA = (select ID_VALORE from priorita_x_progetto WHERE ID_PROGETTO = @IdProgetto and ID_PRIORITA = 986)

SELECT @COSTO_TOT_PROGETTO=SUM(ISNULL(COSTO_INVESTIMENTO,0))  + SUM(ISNULL(SPESE_GENERALI,0)) FROM PIANO_INVESTIMENTI
				 WHERE ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A'

IF ((@ZONA = '1006' AND @COSTO_TOT_PROGETTO <= 120000) OR (@ZONA = '1007' AND @COSTO_TOT_PROGETTO <= 80000))
	  SET @result = 1
ELSE
	SET @result = 0			

SELECT @result AS RESULT
END
