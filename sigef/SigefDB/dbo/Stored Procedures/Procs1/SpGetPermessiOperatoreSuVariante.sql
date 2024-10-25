﻿
CREATE PROCEDURE SpGetPermessiOperatoreSuVariante
(
	@ID_VARIANTE INT,
	@ID_UTENTE INT
)
AS
	
	--DECLARE @ID_VARIANTE INT,@ID_UTENTE INT
	--SET @ID_VARIANTE=237
	--SET @ID_UTENTE=11
	
	-- RECUPERO L'OPERATORE DI INSERIMENTO DELLA VARIANTE E DATI GENERALI
	DECLARE @ID_PROGETTO INT,@ID_UTENTE_INSERIMENTO INT,@COD_ENTE VARCHAR(10),@PROVINCIA CHAR(2),@SEGNATURA VARCHAR(100),
		@SEGNATURA_ISTRUTTORIA VARCHAR(100),@DATA_ULTIMA_MODIFICA DATETIME,@ANNULLATA BIT,@COD_TIPO CHAR(2),@ORDINE_FASE INT,
		@ORDINE_STATO INT,@ID_IMPRESA INT,@IMPRESA_ATTIVA BIT,@COD_ENTE_BANDO VARCHAR(10), @ID_BANDO INT
	SELECT TOP 1 @ID_PROGETTO=V.ID_PROGETTO,@ID_UTENTE_INSERIMENTO=U.ID_UTENTE,@COD_ENTE=V.COD_ENTE,@PROVINCIA=US.PROVINCIA,
		@SEGNATURA=V.SEGNATURA,@SEGNATURA_ISTRUTTORIA=SEGNATURA_APPROVAZIONE,@DATA_ULTIMA_MODIFICA=DATA_MODIFICA,@ANNULLATA=ANNULLATA,
		@COD_TIPO=COD_TIPO,@ID_IMPRESA=I.ID_IMPRESA,@ORDINE_FASE=ORDINE_FASE,@ORDINE_STATO=ORDINE_STATO,@COD_ENTE_BANDO=B.COD_ENTE,
		@IMPRESA_ATTIVA=S.ATTIVA, @ID_BANDO = B.ID_BANDO
	FROM VARIANTI V INNER JOIN vPROGETTO P ON V.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN IMPRESA I ON P.ID_IMPRESA=I.ID_IMPRESA INNER JOIN IMPRESA_STORICO S ON I.ID_STORICO_ULTIMO=S.ID_STORICO_IMPRESA
	INNER JOIN BANDO B ON P.ID_BANDO=B.ID_BANDO INNER JOIN PERSONA_FISICA F ON V.OPERATORE=F.CODICE_FISCALE 
	INNER JOIN UTENTI U ON F.ID_PERSONA=U.ID_PERSONA_FISICA	INNER JOIN UTENTI_STORICO US ON U.ID_UTENTE=US.ID_UTENTE 
	WHERE ID_VARIANTE=@ID_VARIANTE AND V.DATA_MODIFICA>US.DATA ORDER BY US.DATA DESC

	-- RECUPERO L'OPERATORE CORRENTE
	DECLARE @ID_PF_OPERATORE_CORRENTE INT,@COD_ENTE_OPERATORE_CORRENTE VARCHAR(10),@COD_TIPO_ENTE_OPERATORE_CORRENTE VARCHAR(10),
		@PROVINCIA_OPERATORE_CORRENTE CHAR(2)
	SELECT @COD_ENTE_OPERATORE_CORRENTE=COD_ENTE,@COD_TIPO_ENTE_OPERATORE_CORRENTE=COD_TIPO_ENTE,
		@PROVINCIA_OPERATORE_CORRENTE=PROVINCIA,@ID_PF_OPERATORE_CORRENTE=ID_PERSONA_FISICA	FROM vUTENTI WHERE ID_UTENTE=@ID_UTENTE
	------------------------------------------
	-- 0=NON ABILITATO,1=SOLA VISUALIZZAZIONE,2=ABILITA INSERIMENTO,3=ABILITA L'ISTRUTTORIA,4=VISUALIZZAZIONE ISTRUTTORIA
	DECLARE @PERMESSO INT=0 	
	IF @COD_TIPO IN ('VI','AR') BEGIN
		
		--INVECE DELLA PROVINCIA DELL'OPERATORE PRENDO QUELLA DEI COLLABORATORI X BANDO
		SELECT @PROVINCIA=PROVINCIA FROM COLLABORATORI_X_BANDO WHERE ID_PROGETTO=@ID_PROGETTO AND ATTIVO=1	
		
		DECLARE @IN_ISTRUTTORIA BIT=0
		IF @COD_TIPO='AR' AND @SEGNATURA_ISTRUTTORIA IS NULL AND @ANNULLATA=0 SET @IN_ISTRUTTORIA=1
		IF @COD_TIPO='VI' BEGIN
			DECLARE @SEGNATURA_APPROVAZIONE_DOMANDA_PAGAMENTO VARCHAR(100),@SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO VARCHAR(100),
				@REVISIONE_APPROVATA BIT
			SELECT @SEGNATURA_APPROVAZIONE_DOMANDA_PAGAMENTO=SEGNATURA_APPROVAZIONE,@REVISIONE_APPROVATA=R.APPROVATA,
				@SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO=SEGNATURA_SECONDA_APPROVAZIONE
			FROM DOMANDA_DI_PAGAMENTO D LEFT JOIN CTE_TESTATA_VALIDAZIONE R ON D.ID_DOMANDA_PAGAMENTO=R.ID_DOMANDA_PAGAMENTO
			WHERE D.ID_VARIAZIONE_ACCERTATA=@ID_VARIANTE			
			IF @SEGNATURA_APPROVAZIONE_DOMANDA_PAGAMENTO IS NULL OR (@REVISIONE_APPROVATA=0 AND 
				@SEGNATURA_SECONDA_APPROVAZIONE_DOMANDA_PAGAMENTO IS NULL) SET @IN_ISTRUTTORIA=1
		END
		
		-- COMPAGINE AZIENDALE (SOLO VISIONE)
		IF (SELECT COUNT(*) FROM vPERSONE_X_IMPRESE WHERE ID_IMPRESA=@ID_IMPRESA AND ID_PERSONA=@ID_PF_OPERATORE_CORRENTE
			AND ATTIVO=1)>0 SET @PERMESSO=1
		-- REGIONALI O AMMINISTRATORI, O PER ENTI EMETTITORI DEL BANDO
		ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('%','RM','ADC') OR 
			(@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('GAL','PR') AND @COD_ENTE_BANDO=@COD_ENTE_OPERATORE_CORRENTE) BEGIN
				SET @PERMESSO=4	
				IF @IN_ISTRUTTORIA=1 AND (@ID_UTENTE=@ID_UTENTE_INSERIMENTO OR (SELECT COUNT(*) FROM COLLABORATORI_X_BANDO 
					WHERE ID_PROGETTO=@ID_PROGETTO AND ID_UTENTE=@ID_UTENTE AND ATTIVO=1)>0) SET @PERMESSO=3
		END
		-- MEMBRO DEL COMITATO DI VALUTAZIONE
		ELSE IF (SELECT COUNT(*) FROM BANDO_VALUTATORI V WHERE V.ID_UTENTE = @ID_UTENTE AND V.ATTIVO = 1 AND V.ID_BANDO = @ID_BANDO) > 0
			SET @PERMESSO=4
		-- GLI ENTI DI INSERIMENTO VEDONO QUESTO TIPO DI VARIANTI SOLO SE ISTRUTTORIA CONCLUSA
		ELSE IF @IN_ISTRUTTORIA=0 BEGIN
			--CAA (LE BANCHE NON VEDONO QUESTO TIPO DI VARIANTI)
			IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='CAA' AND (SELECT COUNT(*) FROM MANDATI_IMPRESA
				WHERE COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE AND ID_IMPRESA=@ID_IMPRESA AND TIPO_MANDATO='PSR')>0
				AND (@PROVINCIA_OPERATORE_CORRENTE IS NULL OR @PROVINCIA_OPERATORE_CORRENTE=@PROVINCIA) SET @PERMESSO=1
			--CONSULENTI
			ELSE IF @COD_ENTE_OPERATORE_CORRENTE IS NULL AND (SELECT COUNT(*) FROM MANDATI_IMPRESA M WHERE ID_UTENTE_ABILITATO=@ID_UTENTE
				AND ATTIVO=1 AND ID_IMPRESA=@ID_IMPRESA AND TIPO_MANDATO='PSR')>0 SET @PERMESSO=1
		END
	END
	ELSE BEGIN
		-- UTENTE DI INSERIMENTO (AGRONOMI) E GAL O COMUNI COME BENEFICIARI
		IF (@ID_UTENTE=@ID_UTENTE_INSERIMENTO and  @COD_TIPO_ENTE_OPERATORE_CORRENTE IS NULL ) OR (SELECT COUNT(*) FROM IMPRESA WHERE ID_IMPRESA=@ID_IMPRESA
				AND COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE)>0 SET @PERMESSO=2
		ELSE BEGIN
			-- COMPAGINE AZIENDALE (SOLO VISIONE, NON FACCIO MODIFICARE DA UN UTENTE DIVERSO DALL'UTENTE DI INSERIMENTO)
			IF (SELECT COUNT(*) FROM vPERSONE_X_IMPRESE WHERE ID_IMPRESA=@ID_IMPRESA AND ID_PERSONA=@ID_PF_OPERATORE_CORRENTE
				/*AND POTERE_DI_FIRMA=1*/ AND ATTIVO=1)>0 SET @PERMESSO=1
			-- REGIONALI O AMMINISTRATORI, O PER ENTI EMETTITORI DEL BANDO
			ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('%','RM','ADC') OR 
				(@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('GAL','PR') AND @COD_ENTE_BANDO=@COD_ENTE_OPERATORE_CORRENTE) BEGIN
				SET @PERMESSO=1
				IF @SEGNATURA IS NOT NULL BEGIN
					SET @PERMESSO=4	
					IF @SEGNATURA_ISTRUTTORIA IS NULL AND @ANNULLATA=0 AND (SELECT COUNT(*) FROM COLLABORATORI_X_BANDO 
						WHERE ID_PROGETTO=@ID_PROGETTO AND ID_UTENTE=@ID_UTENTE AND ATTIVO=1)>0 SET @PERMESSO=3
				END
			END
			-- MEMBRO DEL COMITATO DI VALUTAZIONE
			ELSE IF (SELECT COUNT(*) FROM BANDO_VALUTATORI V WHERE V.ID_UTENTE = @ID_UTENTE AND V.ATTIVO = 1 AND V.ID_BANDO = @ID_BANDO) > 0
				SET @PERMESSO=4
			-- CAA
			ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='CAA' AND @COD_ENTE=@COD_ENTE_OPERATORE_CORRENTE BEGIN
				SET @PERMESSO=1
				IF @PROVINCIA=@PROVINCIA_OPERATORE_CORRENTE OR @PROVINCIA_OPERATORE_CORRENTE IS NULL SET @PERMESSO=2
			END
			-- BANCHE E CFS
			ELSE IF @COD_TIPO_ENTE_OPERATORE_CORRENTE='EE' OR (@COD_TIPO_ENTE_OPERATORE_CORRENTE IN ('IB','CFS') 
				AND (SELECT COUNT(*) FROM MANDATI_IMPRESA M WHERE ID_IMPRESA=@ID_IMPRESA AND TIPO_MANDATO='PSR' 
				AND ATTIVO=1)>0) SET @PERMESSO=1
		END
		IF @PERMESSO=2 AND @SEGNATURA IS NOT NULL SET @PERMESSO=1
	END
	
	-- CONTROLLO LO STATO DEL PROGETTO, ALMENO FINANZIABILE E IN STATO POSITIVO, O IMPRESE CESSATE
	IF @ORDINE_STATO=2 OR @ORDINE_FASE>8 OR @ORDINE_FASE<4 OR @IMPRESA_ATTIVA=0 BEGIN
		IF @PERMESSO=3 SET @PERMESSO=4
		ELSE IF @PERMESSO=2 SET @PERMESSO=1	
	END
	SELECT @PERMESSO
GO