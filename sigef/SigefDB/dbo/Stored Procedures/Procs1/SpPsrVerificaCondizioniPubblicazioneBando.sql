
CREATE PROCEDURE [dbo].[SpPsrVerificaCondizioniPubblicazioneBando]
(
	@ID_BANDO INT 
)
AS

	DECLARE @RETVAL INT,@ERRORE VARCHAR(255)
	SET @RETVAL=0 -- VALORI POSSIBILI: 0 OK, 2 ERRORE , 1 WARNING
	
	DECLARE @ID_SCHEDA_VALUTAZIONE INT,@ID_MODELLO_DOMANDA INT
	
	SELECT @ID_SCHEDA_VALUTAZIONE=ID_SCHEDA_VALUTAZIONE,@ID_MODELLO_DOMANDA=ID_MODELLO_DOMANDA 
	FROM vBANDO WHERE ID_BANDO=@ID_BANDO AND COD_STATO='P'
	
		--------- ERRORI
	IF @@ROWCOUNT=0 BEGIN 
		SET @ERRORE='Il bando selezionato è già stato pubblicato. Impossibile continuare.'
		SET @RETVAL=2
	END
	ELSE IF @ID_SCHEDA_VALUTAZIONE IS NULL BEGIN 
		SET @ERRORE='Non è stata associata la scheda di Valutazione al bando. Impossibile continuare.'
		SET @RETVAL=2
	END
    ELSE IF(SELECT COUNT(*) FROM STEP_X_BANDO WHERE ID_BANDO = @ID_BANDO AND COD_FASE ='P') = 0 BEGIN 
		SET @ERRORE='Non è stata associata la check list di presentazione. Impossibile continuare.'
		SET @RETVAL=2
    END
	ELSE IF (SELECT COUNT(*)FROM BANDO_RESPONSABILI WHERE ID_BANDO = @ID_BANDO AND PROVINCIA IS NULL AND ATTIVO =1) = 0 BEGIN 
		SET @ERRORE='Non è stato definito il responsabile di procedimento regionale. Impossibile continuare.'
		SET @RETVAL=2
	END
	ELSE IF (SELECT COUNT(*)FROM BANDO_TIPO_INVESTIMENTI WHERE ID_BANDO = @ID_BANDO ) = 0 BEGIN 
		SET @ERRORE='Non è stato definito nessun tipologia finanziaria. Impossibile continuare.'
		SET @RETVAL=2
	
	END
	ELSE IF (SELECT COUNT(*)FROM BUSINESS_PLAN WHERE ID_BANDO = @ID_BANDO ) = 0 BEGIN 
		SET @ERRORE='Non è stato associato nessun quadro per definire il BusinessPlan. Impossibile continuare.'
		SET @RETVAL=2
	END	
	ELSE IF @ID_MODELLO_DOMANDA IS NULL BEGIN 
		SET @ERRORE='Non è stato definito nessun modello di domanda. Impossibile continuare.'
		SET @RETVAL=2
	END
	ELSE IF (SELECT COUNT(*)FROM QUADRI_X_DOMANDA WHERE ID_DOMANDA=@ID_MODELLO_DOMANDA ) = 0 BEGIN 
		SET @ERRORE='Non è stato incluso nessun quadro nel modello di domanda. Impossibile continuare.'
		SET @RETVAL=2
	END
    ELSE IF (SELECT COUNT(*)FROM DICHIARAZIONI_X_DOMANDA WHERE ID_DOMANDA=@ID_MODELLO_DOMANDA ) = 0 BEGIN 
		SET @ERRORE='Non è stata definita nessuna dichiarazione. Impossibile continuare.'
		SET @RETVAL=2
	END
	ELSE IF (SELECT COUNT(*) FROM BANDO B INNER JOIN VZPROGRAMMAZIONE P ON B.ID_PROGRAMMAZIONE=P.ID 
			INNER JOIN FASCICOLO_PALEO F ON F.COD_TIPO=P.COD_TIPO+' '+P.CODICE+' '+CAST(B.ID_BANDO AS VARCHAR(10)) AND F.ATTIVO=1 
			AND B.COD_ENTE=F.COD_ENTE AND F.PROVINCIA='AN' WHERE B.ID_BANDO=@ID_BANDO ) = 0 BEGIN 
		SET @ERRORE='Non è stato definito il FASCICOLO PALEO necessario alla protocollazione dei documenti. Impossibile continuare.'
		SET @RETVAL=2
	END
	ELSE IF (SELECT COUNT(*)FROM ALLEGATI_X_DOMANDA WHERE ID_DOMANDA=@ID_MODELLO_DOMANDA ) = 0 BEGIN 
		SET @ERRORE='Non è stato definito  nessun allegato. Continuare con la pubblicazione del bando ?.'
		SET @RETVAL=1
	END
	ELSE IF (SELECT COUNT(*)
			FROM BANDO_CONFIG
			WHERE 1 = 1
				AND ID_BANDO = @ID_BANDO
				AND ATTIVO = 1
				AND COD_TIPO = 'NATURACUP') = 0 BEGIN
		SET @ERRORE = 'Non è stato definita nessuna natura CUP specifica. Impossibile continuare.'
		SET @RETVAL = 2
	END
    SELECT @RETVAL AS RETVAL,@ERRORE AS ERRORE