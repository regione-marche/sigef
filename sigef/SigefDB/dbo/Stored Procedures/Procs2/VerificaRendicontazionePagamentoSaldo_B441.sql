CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_B441]
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

--Elaborazione di studi e ricerche ORIGINALI (20% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b)
--Acquisto di beni  immobili e terreni (10% del costo totale degli investimenti di cui alla tipologia di intervento b)
--Spese tecniche (10% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b)
--Sistemazioni aree verdi (10% del totale delle spese previste per la tipologia di intervento b)
--Costo interventi tipologia di intervento b) ammissibile all`aiuto <= € 150.000,00
--Si impegna alla realizzazione di studi e ricerche originali in presenza di interventi di tipo a)
--Lavori in economia (massimo 20% del costo totale del progetto)

---------------------------------------------------------------------------------------------------
-- UTILIZZATO IN + CONTROLLI

DECLARE @COSTO_INVESTIMENTI DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE COD_TIPO_INVESTIMENTO=1
----------------------------------------------------------------------------------------------------------------


---Elaborazione di studi e ricerche ORIGINALI (20% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b)
DECLARE @SPESE_STUDI_RICERCHE DECIMAL(18,2)
DECLARE @SPESE_INV_MATERIALI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @SPESE_STUDI_RICERCHE=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 441 AND CODICE = 'A')
	
	SELECT @SPESE_INV_MATERIALI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 441 AND CODICE IN ('B'))
					
	IF isnull(@SPESE_STUDI_RICERCHE,0)>(@SPESE_INV_MATERIALI*0.20) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Elaborazione di studi e ricerche ORIGINALI (20% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b).'
	END
END
----------------------------------------------------------------------------------------------------------------
-- UTILIZZATO IN + CONTROLLI

	DECLARE @COSTO_INT_B DECIMAL(18,2)	                                                                     
	SET @COSTO_INT_B = (SELECT SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
															   WHERE ID_CODIFICA_INVESTIMENTO IN 
															         (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO 
															                                          WHERE ID_BANDO = 441 AND CODICE = 'B'))

--- Costo interventi tipologia di intervento b) ammissibile all`aiuto <= € 150.000,00 ---
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	
			IF (isnull(@COSTO_INT_B,0) > 150000) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo interventi tipologia di intervento b) ammissibile all`aiuto <= € 150.000,00.'
	END
END
															                                          
----------------------------------------------------------------------------------------------------------------

----Acquisto di beni immobili e terreni (10% del costo totale degli investimenti di cui alla tipologia di intervento b)
DECLARE @COSTO_BENI_TERRENI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTO_BENI_TERRENI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN (SELECT ID_DETTAGLIO_INVESTIMENTO FROM CODIFICA_INVESTIMENTO CI INNER JOIN 
		                                                                          DETTAGLIO_INVESTIMENTI DI on CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO
		                                                                     WHERE ID_BANDO = 441 AND DI.COD_DETTAGLIO = 'Bb')

			IF isnull(@COSTO_BENI_TERRENI,0)>(@COSTO_INT_B*0.10) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Acquisto di beni immobili e terreni (10% del costo totale degli investimenti di cui alla tipologia di intervento b).'
	END
END

-----------------------------------------------------------------------------------------------------------------

----Spese tecniche (10% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b)
DECLARE @COSTO_SPESE_TECNICHE DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTO_SPESE_TECNICHE=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN (SELECT ID_DETTAGLIO_INVESTIMENTO FROM CODIFICA_INVESTIMENTO CI INNER JOIN 
		                                                                          DETTAGLIO_INVESTIMENTI DI on CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO
		                                                                     WHERE ID_BANDO = 441 AND DI.COD_DETTAGLIO = 'Bf')

			IF isnull(@COSTO_SPESE_TECNICHE,0)>(@COSTO_INT_B*0.10) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Spese tecniche (10% del totale degli investimenti materiali ed immateriali che verranno realizzati con la tipologia di intervento b).'
	END
END


-----------------------------------------------------------------------------------------------------------------

----Sistemazioni aree verdi (10% del totale delle spese previste per la tipologia di intervento b)
DECLARE @COSTO_AREE_VERDI DECIMAL(18,2)
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTO_AREE_VERDI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN (SELECT ID_DETTAGLIO_INVESTIMENTO FROM CODIFICA_INVESTIMENTO CI INNER JOIN 
		                                                                          DETTAGLIO_INVESTIMENTI DI on CI.ID_CODIFICA_INVESTIMENTO = DI.ID_CODIFICA_INVESTIMENTO
		                                                                     WHERE ID_BANDO = 441 AND DI.COD_DETTAGLIO = 'Bd')

			IF isnull(@COSTO_AREE_VERDI,0)>(@COSTO_INT_B*0.10) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Sistemazioni aree verdi (10% del totale delle spese previste per la tipologia di intervento b).'
	END
END

-----------------------------------------------------------------------------------------------------------------

-- Lavori in economia (massimo 20% del costo totale del progetto)
DECLARE @COSTI_LAVORI_ECONOMIA int
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN
	SELECT @COSTI_LAVORI_ECONOMIA=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP IT
			INNER JOIN SPECIFICA_INVESTIMENTI SPI ON IT.ID_SPECIFICA_INVESTIMENTO= SPI.ID_SPECIFICA_INVESTIMENTO AND IT.ID_DETTAGLIO_INVESTIMENTO = SPI.ID_DETTAGLIO_INVESTIMENTO
	WHERE SPI.COD_SPECIFICA = 'a'
					
	IF isnull(@COSTI_LAVORI_ECONOMIA,0)>(@COSTO_INVESTIMENTI*0.20) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Lavori in economia (massimo 20% del costo totale del progetto).'
	END
END

-----------------------------------------------------------------------------------------------------------------

-- Si impegna alla realizzazione di studi e ricerche originali in presenza di interventi di tipo a)

	DECLARE @CONTA_INT_A INT, @DICHIARA INT   
IF isnull(@COSTO_INVESTIMENTI,0)>0 BEGIN                                                                   
	SET @CONTA_INT_A = (SELECT COUNT(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
															   WHERE ID_CODIFICA_INVESTIMENTO IN 
															         (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO 
															                                          WHERE ID_BANDO = 441 AND CODICE = 'A'))
															                                          
															                                          
	SELECT @DICHIARA = (SELECT COUNT(ID_DICHIARAZIONE) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO = @ID_PROGETTO AND ID_DICHIARAZIONE = 491)
	
	IF (ISNULL(@CONTA_INT_A,0) >= 1 AND @DICHIARA = 0) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Si è impegnato alla realizzazione di studi e ricerche originali in presenza di interventi di tipo a).'
	END
END
															                                          
/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
