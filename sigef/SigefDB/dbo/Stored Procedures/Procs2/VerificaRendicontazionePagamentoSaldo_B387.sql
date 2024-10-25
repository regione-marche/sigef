CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_B387]
(
	@ID_DOMANDA_PAGAMENTO INT
)
AS

--DECLARE @ID_DOMANDA_PAGAMENTO INT;SET @ID_DOMANDA_PAGAMENTO=...
--DEFINIZIONI
DECLARE @ID_VARIANTE INT,@ID_PROGETTO INT,@DATA_MODIFICA_PAGAMENTO DATETIME,@ID_INVESTIMENTO INT,
@IMPORTO_RENDICONTATO_ATTUALE DECIMAL(18,2),@CONTRIBUTO_RENDICONTATO_ATTUALE DECIMAL(18,2),@ID_FASCICOLO INT,
--ESITO VERIFICA
@TIPO_RISULTATO CHAR(1),@MESSAGGIO_RISULTATO VARCHAR(3000)
SET @TIPO_RISULTATO='S'
SET @MESSAGGIO_RISULTATO=''

--TROVO PROGETTO E ULTIMA VARIANTE RELATIVA A QUESTA DOMANDA DI PAGAMENTO
SELECT @DATA_MODIFICA_PAGAMENTO=DATA_MODIFICA,@ID_PROGETTO=D.ID_PROGETTO,@ID_FASCICOLO=ID_FASCICOLO FROM DOMANDA_DI_PAGAMENTO D
	INNER JOIN PROGETTO P ON D.ID_PROGETTO=P.ID_PROGETTO WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO
SELECT @ID_VARIANTE=MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA=1 AND ANNULLATA=0 
	AND DATA_MODIFICA<@DATA_MODIFICA_PAGAMENTO

--CREO PIANO INVESTIMENTI VIRTUALE
DECLARE @INVESTIMENTI_TEMP TABLE ([ID_INVESTIMENTO] [int] NOT NULL,
	[ID_PROGETTO] [int] NULL,
	[ID_PROGRAMMAZIONE] [int] NULL,
	[DESCRIZIONE] [varchar](2000) NULL,
	[DATA_VARIAZIONE] [datetime] NULL,
	[OPERATORE_VARIAZIONE] [varchar](16) NULL,
	[COD_TIPO_INVESTIMENTO] [int] NULL,
	[COD_STP] [char](2) NULL,
	[ID_UNITA_MISURA] [int] NULL,
	[QUANTITA] [decimal](10, 2) NULL,
	[COSTO_INVESTIMENTO] [decimal](15, 2) NULL,
	[SPESE_GENERALI] [decimal](15, 2) NULL,
	[CONTRIBUTO_RICHIESTO] [decimal](15, 2) NULL,
	[QUOTA_CONTRIBUTO_RICHIESTO] [decimal](10, 2) NULL,
	[TASSO_ABBUONO] [decimal](10, 2) NULL,
	[ID_SETTORE_PRODUTTIVO] [int] NULL,
	[ID_PRIORITA_SETTORIALE] [int] NULL,
	[ID_OBIETTIVO_MISURA] [int] NULL,
	[ID_CODIFICA_INVESTIMENTO] [int] NULL,
	[ID_DETTAGLIO_INVESTIMENTO] [int] NULL,
	[ID_SPECIFICA_INVESTIMENTO] [int] NULL,
	[AMMESSO] [bit] NULL,
	[ISTRUTTORE] [varchar](16) NULL,
	[ID_INVESTIMENTO_ORIGINALE] [int] NULL,
	[DATA_VALUTAZIONE] [datetime] NULL,
	[VALUTAZIONE_INVESTIMENTO] [ntext] NULL,
	[ID_VARIANTE] [int] NULL,
	[COD_VARIAZIONE] [char](1),
	[NON_COFINANZIATO] [bit] NULL, 
	IMPORTO_TOTALE_RENDICONTATO DECIMAL(18,2),
	CONTRIBUTO_TOTALE_RENDICONTATO DECIMAL(18,2))	

INSERT INTO @INVESTIMENTI_TEMP
SELECT I.*,	dbo.calcoloTotaleImportoRendicontatoInvestimento(I.ID_INVESTIMENTO,@ID_DOMANDA_PAGAMENTO) AS IMPORTO_TOTALE_RENDICONTATO,
	dbo.calcoloTotaleContributoRendicontatoInvestimento(I.ID_INVESTIMENTO,@ID_DOMANDA_PAGAMENTO) AS CONTRIBUTO_TOTALE_RENDICONTATO 
FROM PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON P.ID_PROGETTO=I.ID_PROGETTO
WHERE ISNULL(P.ID_PROG_INTEGRATO,P.ID_PROGETTO)=@ID_PROGETTO AND
	((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND AMMESSO=1 AND ID_VARIANTE IS NULL) OR
	(ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X')!='A')) ORDER BY COD_TIPO_INVESTIMENTO
	
	
/**********************************************************************************************************/
--INIZIO CONTROLLO STEP
--Il progetto ammissibile dovrà prevedere un investimento minimo di 50.000 €

--Verificato che le Spese  per l’acquisizione di servizi relativi alla predisposizione, comunicazione,
--- gestione operativa del piano promozionale max 10% del totale investimento

--Verificato che le Spese per la realizzazione di incontri, seminari, convegni ecc. comprese le spese 
--- per il noleggio di attrezzature strettamente funzionali alla realizzazione delle attività, max 5% del totale investimento

--Attività realizzate da personale interno per un costo ammissibile massimo del 10% del costo totale del progetto

---------------------------------------------------------------------------------------------------

DECLARE @COSTO_INVESTIMENTI DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE COD_TIPO_INVESTIMENTO=1
----------------------------------------------------------------------------------------------------------------

-- Il progetto ammissibile dovrà prevedere un investimento minimo di 50.000 €
IF (isnull(@COSTO_INVESTIMENTI,0) < 50000)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo totale investimenti >= 50.000€'
END
---------------------------------------------------------------------------------------------------
--Verificato che le Spese  per l’acquisizione di servizi relativi alla predisposizione, comunicazione,
--- gestione operativa del piano promozionale max 10% del totale investimento
DECLARE @COSTO_SERVIZI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTO_SERVIZI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN (SELECT ID_DETTAGLIO_INVESTIMENTO FROM CODIFICA_INVESTIMENTO CI INNER JOIN 
		                                                                          DETTAGLIO_INVESTIMENTI DI on CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO
		                                                                     WHERE ID_BANDO = 387 AND DI.COD_DETTAGLIO = '1')
		                                                                     
		IF (((isnull(@COSTO_SERVIZI,0) * 100) / @COSTO_INVESTIMENTI) > 10 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Spese per l’acquisizione di servizi relativi alla predisposizione, comunicazione, gestione operativa del piano promozionale max 10% del totale investimento.'
	END
END

---------------------------------------------------------------------------------------------------
--Verificato che le Spese per la realizzazione di incontri, seminari, convegni ecc. comprese le spese 
--- per il noleggio di attrezzature strettamente funzionali alla realizzazione delle attività, max 5% del totale investimento
DECLARE @COSTO_INCONTRI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTO_INCONTRI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN (SELECT ID_DETTAGLIO_INVESTIMENTO FROM CODIFICA_INVESTIMENTO CI INNER JOIN 
		                                                                          DETTAGLIO_INVESTIMENTI DI on CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO
		                                                                     WHERE ID_BANDO = 387 AND DI.COD_DETTAGLIO = '2')
		                                                                     
		IF (((isnull(@COSTO_INCONTRI,0) * 100) / @COSTO_INVESTIMENTI) > 5 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Spese per la realizzazione di incontri, seminari, convegni ecc. comprese le spese per il noleggio di attrezzature strettamente funzionali alla realizzazione delle attività, max 5% del totale investimento.'
	END
END

---------------------------------------------------------------------------------------------------
--Attività realizzate da personale interno per un costo ammissibile massimo del 10% del costo totale del progetto
DECLARE @COSTI_INTERNI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTI_INTERNI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP T
			INNER JOIN SPECIFICA_INVESTIMENTI SPI on SPI.ID_SPECIFICA_INVESTIMENTO = T.ID_SPECIFICA_INVESTIMENTO 
	WHERE SPI.COD_SPECIFICA in ('01')
					
	IF (((isnull(@COSTI_INTERNI,0) * 100) / @COSTO_INVESTIMENTI) > 10 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Attività realizzate da personale interno per un costo ammissibile massimo del 10% del costo totale del progetto.'
	END
END

/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
