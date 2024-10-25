﻿CREATE  PROCEDURE [dbo].[calcoloStepPagamento112_7]
(
  @IdProgetto INT,
  @IdDomandaPagamento  INT 
)
AS
BEGIN
/*DECLARE @ID_DOMANDA_PAGAMENTO int =1287*/
DECLARE @ID_PROGETTO INT, @CODICE INT,@RESULT INT,@PROROGA_12 INT =0,
		@DATA_PRESENTAZIONE DATETIME,@DATA_GRADUATORIA DATETIME, @PROROGA_6 INT=0
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		 
--la data specificata di fine interventi programmati deve essere > della data di inizio rendicontazione perchè è un saldo
-- proroga di 6 mesi id_requisito = 156
--144 DATA APPROVAZIONE GRADUATORIA
--156 PROROGA 6 MESI
--157 ENTRO TRE MESI
SELECT @DATA_GRADUATORIA= VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_REQUISITO =144
IF (@DATA_GRADUATORIA IS NULL) SET @RESULT =0
ELSE BEGIN
	SELECT @DATA_PRESENTAZIONE =DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO =@IdDomandaPagamento
	SELECT @PROROGA_6=CASE WHEN COUNT(*)>0 THEN 6 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_REQUISITO =156
	SELECT @PROROGA_12=CASE WHEN COUNT(*)>0 THEN 12 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND ID_REQUISITO =168
	IF(@PROROGA_6 >0 AND @PROROGA_12>0)SET @PROROGA_6=0 
	ELSE SET @RESULT=(SELECT 'DIFF'=CASE WHEN DATEDIFF(DAY, DATEADD(MM,33+@PROROGA_6 + @PROROGA_12  ,(@DATA_GRADUATORIA)), @DATA_PRESENTAZIONE)<=0 THEN 1 ELSE 0 END)
	/*SELECT @DATA_GRADUATORIA,@DATA_PRESENTAZIONE,@PROROGA,DATEADD(MM,33+@PROROGA ,(@DATA_GRADUATORIA))*/
END
SELECT @RESULT
END
