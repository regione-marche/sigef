CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_B356]
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
--La proposta progettuale che verrà presentata prevede almeno tre delle tipologie di intervento previste.
--Rispetto dei limiti del costo totale progetto.
--Costo attività realizzate da personale interno nel limite massimo del 5% del costo totale progetto.
--* Costo investimenti intervento A nel limite massimo del 10% del costo totale progetto.
--* Costo Degustazioni nel limite massimo del 5% del costo totale intervento C.
---------------------------------------------------------------------------------------------------

DECLARE @COSTO_INVESTIMENTI DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE COD_TIPO_INVESTIMENTO=1

-----====================================================================================================================-----
-- PARTE COMUNE
DECLARE @COSTO_A DECIMAL(18,2), @COSTO_DEG DECIMAL(18,2), @COSTO_ECON DECIMAL(18,2), @COSTO_INERNO DECIMAL(18,2), @COSTO_PRO3 DECIMAL(18,2)

--SELECT ID_PROGETTO FROM @INVESTIMENTI_TEMP

-----====================================================================================================================-----

----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
--Costo investimenti intervento A nel limite massimo del 10% del costo totale progetto.

SELECT @COSTO_A=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO = 356 AND CODICE = 'A')

IF ((isnull(@COSTO_A,0)*100) / @COSTO_INVESTIMENTI) > 10 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo investimenti intervento A nel limite massimo del 10% del costo totale progetto'
END
		
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
--Costo Degustazioni nel limite massimo del 5% del costo totale intervento C.
SELECT @COSTO_DEG=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_DETTAGLIO_INVESTIMENTO IN 
		(SELECT ID_DETTAGLIO_INVESTIMENTO FROM DETTAGLIO_INVESTIMENTI DI inner join
				CODIFICA_INVESTIMENTO CI ON DI.ID_CODIFICA_INVESTIMENTO = CI.ID_CODIFICA_INVESTIMENTO
		 WHERE COD_DETTAGLIO = 'C2' AND ID_BANDO = 356 AND CODICE = 'C')

IF ((isnull(@COSTO_DEG,0)*100) / @COSTO_INVESTIMENTI) > 5 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo Degustazioni nel limite massimo del 5% del costo totale intervento C.'
END

----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
--Costo attività realizzate da personale interno nel limite massimo del 5% del costo totale progetto.
SELECT @COSTO_INERNO =SUM(IMPORTO_TOTALE_RENDICONTATO) 
FROM @INVESTIMENTI_TEMP INV INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON INV.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA = 1125
WHERE ID_PROGETTO = @ID_PROGETTO


IF ((isnull(@COSTO_INERNO,0)*100) / @COSTO_INVESTIMENTI) > 5 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Costo attivita realizzate del personale interno nel limite massimo del 5% del costo totale. '
END

----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
--La proposta progettuale che verrà presentata prevede almeno tre delle tipologie di intervento previste.
SELECT @COSTO_PRO3 = COUNT(DISTINCT ID_CODIFICA_INVESTIMENTO) FROM @INVESTIMENTI_TEMP

IF isnull(@COSTO_PRO3,0) < 3 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - La proposta progettuale presentata deve prevedere almeno tre delle tipologie di intervento previste.'
END
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------

---
-- Rispetto dei limiti del costo totale progetto.
-- minimo costo porgetto 150.000€
-- max costo progetto <= 350.000 se non raggruppati
-- max costo progetto <= 500.000 se raggruppati
-- priorità a livello di domanda Tipo di Beneficiario id :1126	
---


DECLARE @TIPO_BENEFICIARIO int, @CODICE_PRIORITA varchar(10)

SET @CODICE_PRIORITA = (SELECT CODICE FROM PRIORITA_X_PROGETTO PXP
							INNER JOIN VALORI_PRIORITA VP ON PXP.ID_PRIORITA = VP.ID_PRIORITA AND PXP.ID_VALORE = VP.ID_VALORE
						WHERE PXP.ID_PRIORITA = 1126 AND ID_PROGETTO = @ID_PROGETTO) 

IF (@CODICE_PRIORITA IS NULL) 
BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Tipo di Beneficiario non presente.'
END
 
ELSE BEGIN 
	IF(@COSTO_INVESTIMENTI >= 150000 AND ((@COSTO_INVESTIMENTI <= 500000 AND @CODICE_PRIORITA = 'a') OR (@COSTO_INVESTIMENTI <= 350000 AND @CODICE_PRIORITA = 'b')))
	SET @TIPO_RISULTATO='S' 
	ELSE
		BEGIN
			SET @TIPO_RISULTATO='N'
			SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Rispetto dei limiti del costo totale progetto.'
		END
END	
----------------------------------------------------------------------------------------------------------------

/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
