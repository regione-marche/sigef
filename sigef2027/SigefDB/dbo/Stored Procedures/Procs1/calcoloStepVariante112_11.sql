﻿CREATE PROCEDURE [dbo].[calcoloStepVariante112_11]
@ID_VARIANTE int
AS
 
--DECLARE @ID_VARIANTE int
--SET @ID_VARIANTE=97
DECLARE @RESULT INT
SET @RESULT =0

DECLARE @ID_PROGETTO INT, 
		@SPESA_AMMESSA_FINANZIATA DECIMAL(18,2),
		@SPESA_VARIANTE DECIMAL(18,2)
		
SET @ID_PROGETTO=(SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)
SET @SPESA_AMMESSA_FINANZIATA=(SELECT SUM(ISNULL(COSTO_INVESTIMENTO,0))+ SUM (ISNULL(SPESE_GENERALI,0))
								FROM PIANO_INVESTIMENTI 
								WHERE ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND 
										ID_PROGETTO IN (SELECT ID_PROGETTO FROM PROGETTO WHERE ID_PROG_INTEGRATO = @ID_PROGETTO) AND COD_TIPO_INVESTIMENTO=1 )
 
SET @SPESA_VARIANTE =  (SELECT SUM(ISNULL(COSTO_INVESTIMENTO,0))+ SUM (ISNULL(SPESE_GENERALI,0))
						FROM PIANO_INVESTIMENTI 
						WHERE  ID_VARIANTE = @ID_VARIANTE AND COD_TIPO_INVESTIMENTO=1 AND ISNULL(COD_VARIAZIONE,'x') !='A' )
IF(@SPESA_VARIANTE >= (@SPESA_AMMESSA_FINANZIATA * 0.5 ))SET @RESULT = 1
ELSE SET @RESULT =0

SELECT @RESULT AS RESULT