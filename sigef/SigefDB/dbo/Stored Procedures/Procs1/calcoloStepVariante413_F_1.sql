CREATE PROCEDURE [dbo].[calcoloStepVariante413_F_1]
@ID_VARIANTE int
AS
BEGIN
-- totale investimenti maggiore del massimo da bando (90.000 € e 35.000 € per i B&B)

DECLARE @Result int,
		@COSTO_INV decimal(18,2), 
		@BB INT,
		@IdProgetto int

SET @Result = 1 -- Impongo lo Step  verificato

set @IdProgetto = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE =@ID_VARIANTE )

SELECT @COSTO_INV=SUM(ISNULL(COSTO_INVESTIMENTO,0))  + SUM(ISNULL(SPESE_GENERALI,0)) FROM PIANO_INVESTIMENTI
				 WHERE ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x') != 'A'
				 
 SELECT @BB=COUNT(ID_PRIORITA) FROM PRIORITA_X_PROGETTO PP WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA = 537
   
IF(ISNULL(@BB, 0) >0 )
	BEGIN
		IF (@COSTO_INV > 35000) SET @Result=0
	END
ELSE 
BEGIN
		IF (@COSTO_INV >90000) SET @Result=0
	END
SELECT @Result AS RESULT
END
