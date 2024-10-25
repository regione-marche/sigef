﻿
CREATE PROCEDURE [dbo].[SpGetPermessiOperatoreSuGestioneLavori]
( 
	@ID_PROGETTO INT,
	@ID_UTENTE INT
)
AS
	 
	--DECLARE @ID_PROGETTO INT,@ID_UTENTE INT
	--SET @ID_PROGETTO=400
	--SET @ID_UTENTE=387
	
	-- 0: NON ABILITATO 1: SOLA VISUALIZZAZIONE 2: MODIFICA 3: MODIFICA 4: VISUALIZZAZIONE ISTRUTTORIA
	DECLARE @RETURN_VALUE INT
	SET @RETURN_VALUE=0
	
	-- RECUPERO L'OPERATORE CORRENTE
	DECLARE @ID_PF_OPERATORE_CORRENTE INT,@COD_ENTE_OPERATORE_CORRENTE VARCHAR(10),@COD_TIPO_ENTE_OPERATORE_CORRENTE VARCHAR(10)
	SELECT @COD_ENTE_OPERATORE_CORRENTE=COD_ENTE,@COD_TIPO_ENTE_OPERATORE_CORRENTE=COD_TIPO_ENTE,@ID_PF_OPERATORE_CORRENTE=ID_PERSONA_FISICA
	FROM vUTENTI U WHERE ID_UTENTE=@ID_UTENTE
	
	-- RECUPERO ENTI,BANDO E IMPRESA
	DECLARE @COD_ENTE_EMETTITORE_BANDO VARCHAR(10),@ID_IMPRESA INT,@COD_ENTE_IMPRESA VARCHAR(10),@ID_BANDO INT,
		@COD_STATO_BANDO CHAR(1),@IMPRESA_ATTIVA BIT
	SELECT @COD_ENTE_EMETTITORE_BANDO=B.COD_ENTE,@ID_IMPRESA=I.ID_IMPRESA,@COD_ENTE_IMPRESA=I.COD_ENTE,@ID_BANDO=P.ID_BANDO,
		@COD_STATO_BANDO=B.COD_STATO,@IMPRESA_ATTIVA=S.ATTIVA
	FROM PROGETTO P INNER JOIN vBANDO B ON P.ID_BANDO=B.ID_BANDO
	INNER JOIN IMPRESA I ON P.ID_IMPRESA=I.ID_IMPRESA INNER JOIN IMPRESA_STORICO S ON I.ID_STORICO_ULTIMO=S.ID_STORICO_IMPRESA
	WHERE P.ID_PROGETTO=@ID_PROGETTO
	
	-- RAPPRESENTATI LEGALI O ALTRI RUOLI CON POTERE DI FIRMA
	IF (SELECT COUNT(*) FROM vPERSONE_X_IMPRESE WHERE ID_IMPRESA=@ID_IMPRESA AND ID_PERSONA=@ID_PF_OPERATORE_CORRENTE AND ATTIVO=1
		AND POTERE_DI_FIRMA=1)>0 SET @RETURN_VALUE=2
	-- RUOLI AZIEDALI SENZA POTERE DI FIRMA
	ELSE IF (SELECT COUNT(*) FROM vPERSONE_X_IMPRESE WHERE ID_IMPRESA=@ID_IMPRESA AND ID_PERSONA=@ID_PF_OPERATORE_CORRENTE AND ATTIVO=1
		AND POTERE_DI_FIRMA=0)>0 SET @RETURN_VALUE=1
	-- CAA: CONTROLLO IL MANDATO DELL'IMPRESA
	ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='CAA' AND (SELECT COUNT(*) FROM MANDATI_IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA 
		AND ATTIVO=1 AND TIPO_MANDATO='PSR' AND COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE)>0 SET @RETURN_VALUE=2
	-- BANCHE ED ENTI ESTERNI: CONTROLLO IL MANDATO DELL'IMPRESA
	ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='EE' OR (@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('IB','GDF','CFS') 
		AND (SELECT COUNT(*) FROM MANDATI_IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA AND ATTIVO=1 AND TIPO_MANDATO='PSR' 
		AND COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE)>0) SET @RETURN_VALUE=1
	-- REGIONALI,PF CONTROLLI, AMMINISTRAZIONE E ENTI EMETTITORI DEL BANDO
	ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('%','RM','AdC') OR (@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('GAL','PR') AND 
		@COD_ENTE_EMETTITORE_BANDO=@COD_ENTE_OPERATORE_CORRENTE) BEGIN
		SET @RETURN_VALUE=4
		IF (SELECT COUNT(*) FROM COLLABORATORI_X_BANDO WHERE ID_PROGETTO=@ID_PROGETTO AND ID_UTENTE=@ID_UTENTE AND ATTIVO=1)>0 
			SET @RETURN_VALUE=3
	END
	-- MEMBRO DEL COMITATO DI VALUTAZIONE
	ELSE IF (SELECT COUNT(*) FROM BANDO_VALUTATORI V WHERE V.ID_UTENTE = @ID_UTENTE AND V.ATTIVO = 1 AND V.ID_BANDO = @ID_BANDO) > 0
		SET @RETURN_VALUE=4
	-- ENTI BENEFICIARI
	ELSE IF @COD_ENTE_OPERATORE_CORRENTE IS NOT NULL AND @COD_ENTE_IMPRESA=@COD_ENTE_OPERATORE_CORRENTE SET @RETURN_VALUE=2
	-- CONSULENTI
	ELSE IF @COD_ENTE_OPERATORE_CORRENTE IS NULL BEGIN		
		IF (SELECT COUNT(*) FROM MANDATI_IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA AND ATTIVO=1 AND ID_UTENTE_ABILITATO=@ID_UTENTE
			 AND TIPO_MANDATO='PSR')>0 SET @RETURN_VALUE=2
	END
		
	DECLARE @BANDO_GRADBLOCCHI INT 
	SELECT @BANDO_GRADBLOCCHI = COUNT(*) FROM BANDO_CONFIG WHERE ID_BANDO = @ID_BANDO AND COD_TIPO ='ATTGRADBLOCCHI' AND ATTIVO = 1
	IF(@BANDO_GRADBLOCCHI = 0 AND @COD_STATO_BANDO='L') BEGIN 
		IF @RETURN_VALUE=3 SET @RETURN_VALUE=4
		ELSE IF @RETURN_VALUE=2 SET @RETURN_VALUE=1		
	END
		
	-- IMPRESE CESSATE
	IF @IMPRESA_ATTIVA=0 BEGIN	
		IF @RETURN_VALUE=2 SET @RETURN_VALUE=1
		ELSE IF @RETURN_VALUE=3 SET @RETURN_VALUE=4
	END
	SELECT @RETURN_VALUE