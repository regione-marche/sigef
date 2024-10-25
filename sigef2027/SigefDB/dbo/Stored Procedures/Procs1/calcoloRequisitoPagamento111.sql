create   PROCEDURE [dbo].[calcoloRequisitoPagamento111]
@IdProgetto int
AS
BEGIN

-- rispetto del livello minimo per gli indicatori 

DECLARE @RESULT  int
SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
 
-- 199 N. siti rilevazione meterologica (per anno) 
 
  DECLARE  @NUM  int
  SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 224 )
 IF ( @NUM < 62 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- 200 N. aziende agricole per rilievi agro-fenologici (per anno) 
  SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 225  )
 IF ( @NUM < 90 ) SET @RESULT =0
 
--------------------------------------------------------------------------------------------------------------
--201 N. siti di rilevazione agro-fenologica 
  SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 226  )
 IF ( @NUM < 120 ) SET @RESULT =0
  --------------------------------------------------------------------------------------------------------------
--- 202 N. siti di monitoraggio fitopatologico 
    SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 227  )
	IF ( @NUM < 120 ) SET @RESULT =0
  
--------------------------------------------------------------------------------------------------------------
--203 N. siti per rilievo indici di maturazione 
 SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 203  )
	IF ( @NUM < 80 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
 -- 204 N. di bollettini pubblicati 
 SET  @NUM = ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 204  )
	IF ( @NUM < 200 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--205 N. di incontri collegiali con soggetti della formazione 
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 205  )
	IF ( @NUM < 3 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--206 N. di incontri collegiali con soggetti della consulenza 
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 206  )
	IF ( @NUM < 3 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--207 N. di incontri collegiali con soggetti dell`informazione
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 207 )
	IF ( @NUM < 3 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- 208 N. di seminari 
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 208  )
	IF ( @NUM < 2) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- 209 N. di notiziari pubblicati 
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 209  )
	IF ( @NUM < 180 ) SET @RESULT =0


--------------------------------------------------------------------------------------------------------------
--210 N. di siti web aggiornati  
SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 210  )
	IF ( @NUM < 1 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- 211 N. di pubblicazioni realizzate 
	SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 211  )
	IF ( @NUM < 4 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--212 N. di utenti registrati al sito web e raggiunti con i bollettini metereologici 
SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 212  )
	IF ( @NUM < 1100 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--213 N. utenti raggiunti con i notiziari agro-metereologici 
   SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 213  )
	IF ( @NUM < 2500 ) SET @RESULT =0
--------------------------------------------------------------------------------------------------------------
--214 N. di partecipanti agli incontricollegiali nell`ambito della formazione 
 SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 214 )
	IF ( @NUM < 12 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--215 N. di partecipanti agli incontri collegiali nell`ambito della consulenza 
 SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 215 )
	IF ( @NUM < 10 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
--216 N. di partecipanti agli incontri collegiali nell`ambitop dell`informazione 
 SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 216 )
	IF ( @NUM < 23 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------
-- 217 N. di partecipanti ai seminari 
 SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 217 )
	IF ( @NUM < 50 ) SET @RESULT =0

--------------------------------------------------------------------------------------------------------------

-- 218 N. di contatti registrati al sito web 
 SET  @NUM =  ( SELECT VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 218 )
	IF ( @NUM < 100000 ) SET @RESULT =0



SELECT @Result AS RESULT


END
