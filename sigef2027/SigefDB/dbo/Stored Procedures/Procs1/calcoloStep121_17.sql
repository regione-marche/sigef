﻿CREATE PROCEDURE [dbo].[calcoloStep121_17]
	@IdProgetto int,
	@fase_istruttoria bit=0
AS
BEGIN
-- 121 - verifica CODIFICHE RICHIEDIBILI SOLO DAI GIOVANI IV SCADENZA 
DECLARE @ID_IMPRESA INT ,@C_INV INT, @RESULT INT =0
SELECT @ID_IMPRESA=ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO =@IdProgetto

	SELECT @C_INV = COUNT(*) FROM VPIANO_INVESTIMENTI INV 
	WHERE ID_PROGETTO = @IdProgetto AND CODICE IN ('A') AND
		  ((@fase_istruttoria =0 AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
			OR(@fase_istruttoria =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL))

	IF(ISNULL(@C_INV,0)>0)	BEGIN
		IF( (SELECT COUNT(*) FROM vPROGETTO WHERE ID_BANDO = 135 AND ID_IMPRESA=@ID_IMPRESA AND COD_STATO IN ('N')) >0)SET @RESULT= 1
			ELSE SET @RESULT=0
		END
	ELSE SET @RESULT= 1
SELECT @RESULT 
END