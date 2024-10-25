-- SALDO
--=== Richiesta di saldo  entro il 31 luglio 2015 oltre eventuali proroghe per la sola rendicontazione su SIAR ===--

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B455]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

DECLARE  @RESULT INT , @C INT, @PROROGA_30 INT, @DATA_RICHIESTA_SALDO DATETIME
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		

--- 521	Richiesta di saldo  entro il 31 luglio 2015 oltre eventuali proroghe per la sola rendicontazione su SIAR
--- 522	Richiesta di proroga di max 30 gg. approvata dal Gal per la sola rendicontazione su SIAR

--declare @ID_DOMANDA_PAGAMENTO int = 


SELECT @PROROGA_30=CASE WHEN COUNT(*)>0 THEN 30 ELSE 0 END  FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 522
SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO


SET @RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY, DATEADD(DD, @PROROGA_30,'2015-07-31'), @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)


 --SELECT @C = count(*) 
 --FROM domanda_di_pagamento 
 --WHERE data_modifica < '2015-08-01'
	--  AND ID_DOMANDA_PAGAMENTO =@ID_DOMANDA_PAGAMENTO
 
 --IF (@C > 0)SET @RESULT = 1 	
 --ELSE SET @RESULT = 0 	
END
SELECT @RESULT
