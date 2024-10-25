CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_B448]
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
--Costo acquisto terreni <= 10% totale progetto
--Costo totale investimento <= 150.000

---------------------------------------------------------------------------------------------------

DECLARE @COSTO_INVESTIMENTI DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE COD_TIPO_INVESTIMENTO=1
----------------------------------------------------------------------------------------------------------------

-- Almeno una iniziativa tra le tipologie di azione di cui ai punti 4,5,6.
DECLARE @INIZIATIVE INT

SELECT @INIZIATIVE = SUM(ISNULL(valore,0)) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO and ID_PRIORITA IN (581,586,587)
IF (isnull(@INIZIATIVE,0) < 1)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Almeno una iniziativa tra le tipologie di azione di cui ai punti 4,5,6.'
END
----------------------------------------------------------------------------------------------------------------

-- Costo spese generali <= 2% totale investimenti

DECLARE @SPESE_GENERALI DECIMAL (18,2)

IF isnull(@COSTO_INVESTIMENTI,0)>0 
BEGIN
	SELECT @SPESE_GENERALI = SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 448 AND CODICE = 'F')

	IF (((isnull(@SPESE_GENERALI,0) * 100) / @COSTO_INVESTIMENTI) > 2 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo spese generali <= 2% totale investimenti'
	END
END


----------------------------------------------------------------------------------------------------------------

-- Costo ricognizione <= 15% totale investimenti

DECLARE @SPESE_RICOGNIZIONE DECIMAL (18,2)

IF isnull(@COSTO_INVESTIMENTI,0)>0 
BEGIN
	SELECT @SPESE_RICOGNIZIONE = SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 448 AND CODICE = 'A')

	IF (((isnull(@SPESE_RICOGNIZIONE,0) * 100) / @COSTO_INVESTIMENTI) > 15 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo ricognizione <= 15% totale investimenti'
	END
END


----------------------------------------------------------------------------------------------------------------

-- Attivazione di entrambe le tipologie di intervento di cui ai punti 9 e 10
DECLARE @TIPOLOGIE_9_10 INT

SELECT @TIPOLOGIE_9_10 = COUNT(ID_PROGETTO) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO and ID_PRIORITA in (574,577)
IF (isnull(@TIPOLOGIE_9_10,0) != 2)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Attivazione di entrambe le tipologie di intervento di cui ai punti 9 e 10.'
END
----------------------------------------------------------------------------------------------------------------


-- Almeno una iniziativa tra le tipologie di cui a punti 7 e 8.
DECLARE @INIZIATIVE_7_8 INT

SELECT @INIZIATIVE_7_8 = SUM(ISNULL(valore,0)) from priorita_x_progetto WHERE ID_PROGETTO=@ID_PROGETTO  and ID_PRIORITA IN (584,585)
IF (isnull(@INIZIATIVE_7_8,0) < 1)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Almeno una iniziativa tra le tipologie di cui a punti 7 e 8'
END
----------------------------------------------------------------------------------------------------------------


-- Numero incontri informativi collegiali (minimo 1 per anno).
DECLARE @INIZIATIVE_1252 INT

SELECT @INIZIATIVE_1252 = ISNULL(valore,0) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO and ID_PRIORITA = 1252
IF (isnull(@INIZIATIVE_1252,0) < 1)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Numero incontri informativi collegiali (minimo 1 per anno)'
END
----------------------------------------------------------------------------------------------------------------


-- Numero seminari informativi (minimo 1 per anno)
DECLARE @INIZIATIVE_1253 INT

SELECT @INIZIATIVE_1253 = ISNULL(valore,0) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO and ID_PRIORITA = 1253
IF (isnull(@INIZIATIVE_1253,0) < 1)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Numero seminari informativi (minimo 1 per anno)'
END
----------------------------------------------------------------------------------------------------------------


-- Coordinamento Organizzativo <= 5% Totale Investimenti

DECLARE @SPESE_COORD DECIMAL (18,2)

IF isnull(@COSTO_INVESTIMENTI,0)>0 
BEGIN
	SELECT @SPESE_COORD  = SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 448 AND CODICE = 'D')

	IF (((isnull(@SPESE_COORD,0) * 100) / @COSTO_INVESTIMENTI) > 5 ) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Coordinamento Organizzativo <= 5% Totale Investimenti'
	END
END


----------------------------------------------------------------------------------------------------------------


-- Numero convegni (minimo 1 per anno)
DECLARE @INIZIATIVE_583 INT

SELECT @INIZIATIVE_583 = ISNULL(valore,0) from priorita_x_progetto WHERE ID_PROGETTO = @ID_PROGETTO and ID_PRIORITA = 583
IF (isnull(@INIZIATIVE_583,0) < 1)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Numero convegni (minimo 1 per anno)'
END
----------------------------------------------------------------------------------------------------------------


/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
