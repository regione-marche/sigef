﻿
CREATE PROCEDURE SpGetPermessiOperatoreSuDomandaPagamento
(
	@ID_DOMANDA_PAGAMENTO INT,
	@ID_UTENTE INT
)
AS
	
	--DECLARE @ID_DOMANDA_PAGAMENTO INT,@ID_UTENTE INT
	--SET @ID_DOMANDA_PAGAMENTO=251
	--SET @ID_UTENTE=2

	-- RECUPERO L'OPERATORE DI INSERIMENTO DELLA DOMANDA
	DECLARE @ID_PROGETTO INT,@ID_OPERATORE_INSERIMENTO INT,@COD_ENTE VARCHAR(10),@SEGNATURA VARCHAR(100),@DATA_ULTIMA_MODIFICA DATETIME,
		@ANNULLATA BIT,@ID_IMPRESA INT,@IMPRESA_ATTIVA BIT,@ORDINE_FASE INT,@ORDINE_STATO INT,
		@SEGNATURA_APPROVAZIONE VARCHAR(100),@PROVINCIA CHAR(2)
	SELECT TOP 1 @ID_PROGETTO=D.ID_PROGETTO,@ID_OPERATORE_INSERIMENTO=U.ID_UTENTE,@COD_ENTE=D.COD_ENTE,@PROVINCIA=US.PROVINCIA,
		@DATA_ULTIMA_MODIFICA=DATA_MODIFICA,@ANNULLATA=ANNULLATA,@ID_IMPRESA=I.ID_IMPRESA,@IMPRESA_ATTIVA=S.ATTIVA,
		@ORDINE_FASE=ORDINE_FASE,@ORDINE_STATO=ORDINE_STATO,@SEGNATURA=D.SEGNATURA,@SEGNATURA_APPROVAZIONE=D.SEGNATURA_APPROVAZIONE
	FROM DOMANDA_DI_PAGAMENTO D INNER JOIN vPROGETTO P ON D.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN IMPRESA I ON P.ID_IMPRESA=I.ID_IMPRESA INNER JOIN IMPRESA_STORICO S ON I.ID_STORICO_ULTIMO=S.ID_STORICO_IMPRESA
	INNER JOIN PERSONA_FISICA F ON D.CF_OPERATORE=F.CODICE_FISCALE INNER JOIN UTENTI U ON F.ID_PERSONA=U.ID_PERSONA_FISICA
	INNER JOIN UTENTI_STORICO US ON U.ID_UTENTE=US.ID_UTENTE
	WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO 
	--AND US.DATA<=D.DATA_MODIFICA 
	ORDER BY US.DATA DESC
	
	DECLARE @PERMESSO INT,@IN_LAVORAZIONE BIT=0,@ISTRUTTORIA_IN_CORSO BIT=0
	SET @PERMESSO=0	--0=NON ABILITATO, 1=SOLA VISUALIZZAZIONE, 2=ABILITA INSERIMENTO, 3=ABILITA L'ISTRUTTORIA, 4=VISUALIZZAZIONE ISTRUTTORIA
	IF @SEGNATURA IS NULL SET @IN_LAVORAZIONE=1
	ELSE BEGIN
		IF @ANNULLATA=0 BEGIN
			IF @SEGNATURA_APPROVAZIONE IS NULL SET @ISTRUTTORIA_IN_CORSO=1
			ELSE BEGIN
				-- SE ISTRUTTORIA FIRMATA, CONTROLLO LA REVISIONE (IL RIESAME ACCETTATO ANNULLA SIA LA SEGNATURA CHE IL FLAG APPROVATO)
				DECLARE @REVISIONE_APPROVATA BIT,@SEGNATURA_SECONDA_APPROVAZIONE VARCHAR(100)
				
				--SELECT @REVISIONE_APPROVATA=R.APPROVATA,@SEGNATURA_SECONDA_APPROVAZIONE=D.SEGNATURA_SECONDA_APPROVAZIONE 
				--FROM CTE_TESTATA_VALIDAZIONE R INNER JOIN DOMANDA_DI_PAGAMENTO D ON R.ID_DOMANDA_PAGAMENTO=D.ID_DOMANDA_PAGAMENTO
				--WHERE D.ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO	

				SELECT @REVISIONE_APPROVATA = R.APPROVATA,
					@SEGNATURA_SECONDA_APPROVAZIONE = D.SEGNATURA_SECONDA_APPROVAZIONE 
				FROM CTE_TESTATA_VALIDAZIONE R 
					JOIN DOMANDA_DI_PAGAMENTO D ON R.ID_DOMANDA_PAGAMENTO = D.ID_DOMANDA_PAGAMENTO
				WHERE 1 = 1
					AND D.ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO
					
				IF @@ROWCOUNT=1 AND @REVISIONE_APPROVATA=0 AND @SEGNATURA_SECONDA_APPROVAZIONE IS NULL SET @ISTRUTTORIA_IN_CORSO=1
			END
		END
	END
	
	IF @ID_UTENTE=@ID_OPERATORE_INSERIMENTO SET @PERMESSO=2
	ELSE BEGIN
	
		-- RECUPERO L'OPERATORE CORRENTE
		DECLARE @ID_PF_OPERATORE_CORRENTE INT,@COD_ENTE_OPERATORE_CORRENTE VARCHAR(10),@COD_TIPO_ENTE_OPERATORE_CORRENTE VARCHAR(10),
			@PROVINCIA_OPERATORE_CORRENTE CHAR(2)
		SELECT @ID_PF_OPERATORE_CORRENTE=ID_PERSONA_FISICA,@COD_TIPO_ENTE_OPERATORE_CORRENTE=COD_TIPO_ENTE,
			@PROVINCIA_OPERATORE_CORRENTE=PROVINCIA,@COD_ENTE_OPERATORE_CORRENTE=COD_ENTE FROM vUTENTI WHERE ID_UTENTE=@ID_UTENTE
		
		-- COMPAGINE AZIENDALE (SOLO VISIONE, NON FACCIO MODIFICARE DA UN UTENTE DIVERSO DALL'UTENTE DI INSERIMENTO)
		IF (SELECT COUNT(*) FROM vPERSONE_X_IMPRESE WHERE ID_IMPRESA=@ID_IMPRESA AND ID_PERSONA=@ID_PF_OPERATORE_CORRENTE
			/*AND POTERE_DI_FIRMA=1*/ AND ATTIVO=1)>0 SET @PERMESSO=1
		-- REGIONALI O AMMINISTRATORI, O PER ENTI EMETTITORI DEL BANDO
		ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('%','RM','ADC') OR (@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('GAL','PR') AND 
			(SELECT COUNT(*) FROM BANDO B INNER JOIN PROGETTO P ON B.ID_BANDO=P.ID_BANDO WHERE P.ID_PROGETTO=@ID_PROGETTO 
			AND B.COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE)>0) BEGIN
			SET @PERMESSO=4
			IF (SELECT COUNT(*) FROM COLLABORATORI_X_BANDO WHERE ID_PROGETTO=@ID_PROGETTO AND ID_UTENTE=@ID_UTENTE AND ATTIVO =1)>0 
				SET @PERMESSO=3
		END
		-- ENTI IN CONSULTAZIONE, BANCHE E CFS
		ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='EE' OR (@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('IB','CFS') 
			AND (SELECT COUNT(*) FROM MANDATI_IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA AND TIPO_MANDATO='PSR' 
			AND COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE AND ATTIVO=1)>0) SET @PERMESSO=1
		-- CAA
		ELSE IF @COD_ENTE IS NOT NULL BEGIN
			IF @COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE BEGIN
				SET @PERMESSO=1
				IF @PROVINCIA=@PROVINCIA_OPERATORE_CORRENTE OR @PROVINCIA_OPERATORE_CORRENTE IS NULL SET @PERMESSO=2					
			END
			ELSE IF (SELECT COUNT(*) FROM IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA AND COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE)>0
				SET @PERMESSO=2
		END
		-- SE L'UTENTE HA UN MANDATO DI IMPRESA ED E' ATTIVO
		ELSE IF (SELECT COUNT(*) 
				FROM MANDATI_IMPRESA 
				WHERE ID_IMPRESA = @ID_IMPRESA 
					AND TIPO_MANDATO='PSR' 
					AND ID_UTENTE_ABILITATO = @ID_UTENTE 
					AND ATTIVO = 1) > 0 
			SET @PERMESSO=2
	END
	
	DECLARE @ID_ISTRUTTORE INT
	SELECT @ID_ISTRUTTORE = ID_UTENTE  FROM COLLABORATORI_X_BANDO WHERE ID_PROGETTO=@ID_PROGETTO AND ATTIVO =1
	IF (@ID_UTENTE=@ID_OPERATORE_INSERIMENTO AND @ID_UTENTE= @ID_ISTRUTTORE) 
	BEGIN
		IF @SEGNATURA IS NULL SET @PERMESSO = 2
		ELSE SET @PERMESSO = 3
	
	END

	-- CONTROLLO STATO DELLA DOMANDA
	IF @PERMESSO=2 AND @IN_LAVORAZIONE=0 SET @PERMESSO=1
	ELSE IF @PERMESSO=3 AND @ISTRUTTORIA_IN_CORSO=0 SET @PERMESSO=4	
	-- CONTROLLO LO STATO DEL PROGETTO, ALMENO FINANZIABILE E IN STATO POSITIVO, E IMPRESA CESSATA
	IF @ORDINE_STATO=2 OR @ORDINE_FASE>8 OR @ORDINE_FASE<4 OR @IMPRESA_ATTIVA=0 BEGIN
		IF @PERMESSO=3 SET @PERMESSO=4
		ELSE IF @PERMESSO=2 SET @PERMESSO=1	
	END	
	SELECT @PERMESSO
GO