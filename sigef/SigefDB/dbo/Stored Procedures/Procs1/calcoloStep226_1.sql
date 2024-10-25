CREATE PROCEDURE [dbo].[calcoloStep226_1]
@IdProgetto int
AS
BEGIN
 
-- 226  Superamento percentuale massima di Spese Tecniche ammessa da bando nel caso di progettazione interna
-- ID_PRIORITA = 156 - 226 a) - Progettazione e direzione lavori interna
 
DECLARE @RESULT int,
		@SPESE_GENERALI DECIMAL(10,2),
		@COSTO_INVESTIMENTO DECIMAL (10,2)

SET @RESULT = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
IF((SELECT  COUNT(*) from PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 156 AND ID_PROGETTO = @IdProgetto )>0)
BEGIN	
	DECLARE SPESE CURSOR  FOR 
	(SELECT     SPESE_GENERALI, COSTO_INVESTIMENTO
	 FROM         PIANO_INVESTIMENTI WHERE ID_PROGETTO= @IdProgetto AND ID_INVESTIMENTO_ORIGINALE IS NULL )

			OPEN SPESE
			FETCH NEXT FROM SPESE
			INTO @SPESE_GENERALI,@COSTO_INVESTIMENTO
			WHILE @@FETCH_STATUS = 0
			BEGIN
				 IF( @SPESE_GENERALI  > (@COSTO_INVESTIMENTO * 0.02 ) )
				BEGIN
					SET @RESULT=0
					BREAK
				END
			FETCH NEXT FROM SPESE
			INTO @SPESE_GENERALI,@COSTO_INVESTIMENTO
		END
		CLOSE SPESE
		DEALLOCATE SPESE
	
END
SELECT @RESULT
END
