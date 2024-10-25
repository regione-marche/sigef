--
--
CREATE   PROCEDURE [dbo].[calcoloRequisitoPagamento111_7]
@ID_DOMANDA_PAGAMENTO int
AS
BEGIN

-- rispetto del livello minimo per gli indicatori per l'anno rendicontato
--declare @ID_DOMANDA_PAGAMENTO int
--set @ID_DOMANDA_PAGAMENTO =1183
DECLARE @RESULT  int, @ID_BANDO INT
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
 SELECT @ID_BANDO = ID_BANDO FROM PROGETTO WHERE ID_PROGETTO IN (SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO)
--N. aziende agricole per rilievi agro-fenologici (per l'anno)	94
 
  DECLARE  @NUM  int
  SET  @NUM = ( SELECT VAL_NUMERICO   FROM DOMANDA_PAGAMENTO_REQUISITI  WHERE ID_REQUISITO = 94 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )

 IF ( @NUM < 90 ) SET @RESULT =0
--------------------------------------------------------------------------------------------------------------
--N. di bollettini pubblicati	78

  SET  @NUM = ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 78 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
 IF ( @NUM < 200 ) SET @RESULT =0
 
  --------------------------------------------------------------------------------------------------------------
--- N. di contatti registrati al sito web	92
IF(@ID_BANDO != 290)BEGIN
    SET  @NUM = ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 92 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 100000 ) SET @RESULT =0
  END
--------------------------------------------------------------------------------------------------------------
--N. di notiziari pubblicati	83

 SET  @NUM = ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 83 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 180 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
 -- N. di pubblicazioni realizzate	85

 SET  @NUM = ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 85  and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO )
	IF ( @NUM < 4 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--N. di siti web aggiornati	84

	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 84 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 1 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- N. di utenti registrati al sito web e raggiunti con i bollettini metereologici (per l'anno)	86
IF(@ID_BANDO != 290)BEGIN
	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 86 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 1100 ) SET @RESULT =0
END
--------------------------------------------------------------------------------------------------------------
--N. siti di monitoraggio fitopatologico i (per l'anno)	96

	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 96  and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO)
	IF ( @NUM < 120 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--N. siti di rilevazione agro-fenologica i (per l'anno)	95

	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 95 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 120) SET @RESULT =0

 
--------------------------------------------------------------------------------------------------------------
-- N. siti per rilievo indici di maturazione (per l'anno)	77

	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 77 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 80 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- N. siti rilevazione meterologica (per l'anno)	93

	SET  @NUM =  ( SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 93 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 62 ) SET @RESULT =0
 
--------------------------------------------------------------------------------------------------------------
--N. utenti raggiunti con i notiziari agro-metereologici	87

   SET  @NUM =  (SELECT VAL_NUMERICO FROM DOMANDA_PAGAMENTO_REQUISITI WHERE ID_REQUISITO = 87 and ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO  )
	IF ( @NUM < 2500 ) SET @RESULT =0
 
 
SELECT @Result AS RESULT


END
