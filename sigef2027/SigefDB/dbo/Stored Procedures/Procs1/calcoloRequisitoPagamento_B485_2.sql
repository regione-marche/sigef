-- SALDO
--=== Richiesta di saldo  entro il 31 luglio 2015 oltre eventuali proroghe per la sola rendicontazione su SIAR ===--

CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento_B485_2]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN


DECLARE  @RESULT INT , @C INT, @DATA_RICHIESTA_SALDO DATETIME, @DATA_FINE_LAVORI DATETIME, @DATA_FINE_LAVORI_RESULT INT, @DATA_RICHIESTA_SALDO_RESULT INT
SET @RESULT = 0 -- IMPONGO LO STEP NON VERIFICATO		


--541	Fine lavori e richiesta di saldo entro il 31/08/2015

--205	Data inizio interventi programmati
--540	Richiesta proroga di 15 giorni per l`avvio degli interventi
--542	Data inizio interventi programmati (15 gg. dalla data del ricevimento della comunicazione di finanziabilità oltre eventuali proroghe)

--239	Eseguito il controllo di ammissibilità dopo aver compilato la rendicontazione richiesta
--242	Breve relazione sugli interventi eseguiti oggetto di richiesta SALDO
--260	Data fine interventi programmati

-- 204	Data di ricezione della comunicazione di finanziabilità

--declare @ID_DOMANDA_PAGAMENTO int = 

SELECT @DATA_FINE_LAVORI = VAL_DATA FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO AND ID_REQUISITO = 260

SELECT @DATA_RICHIESTA_SALDO = DATA_MODIFICA FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

	SET @DATA_FINE_LAVORI_RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,'2015-08-31', @DATA_FINE_LAVORI)<=0 THEN 1 ELSE 0 END)
	SET @DATA_RICHIESTA_SALDO_RESULT=(SELECT 'DIFF'= CASE WHEN DATEDIFF(DAY,'2015-08-31', @DATA_RICHIESTA_SALDO)<=0 THEN 1 ELSE 0 END)


IF (@DATA_FINE_LAVORI_RESULT > 0 and @DATA_RICHIESTA_SALDO_RESULT > 0 )SET @RESULT = 1 
ELSE SET @RESULT = 0

END
SELECT @RESULT
