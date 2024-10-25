﻿CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_M311_B451]
(
	@ID_DOMANDA_PAGAMENTO INT
)
AS

--DECLARE @ID_DOMANDA_PAGAMENTO INT;SET @ID_DOMANDA_PAGAMENTO=251
 
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

--  311 B  AZIONE D - 2013 -  sistemazioni di terreno <10% DEGLI INVESTIMENTI FISSI - COSTO SENZA SPESE TECNICHE
DECLARE @COSTO_ESTERNO DECIMAL(18,2), @COSTO_FISSI DECIMAL(18,2) 
SELECT @COSTO_FISSI =SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP INV
	INNER JOIN DETTAGLIO_INVESTIMENTI DI ON DI.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO AND DI.ID_DETTAGLIO_INVESTIMENTO = INV.ID_DETTAGLIO_INVESTIMENTO
WHERE COD_TIPO_INVESTIMENTO=1 AND DI.COD_DETTAGLIO IN ('A','B')

SELECT @COSTO_ESTERNO =SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP INV
	INNER JOIN CODIFICA_INVESTIMENTO C ON C.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO 
WHERE COD_TIPO_INVESTIMENTO=1 AND C.CODICE IN ('SI') 

IF(@COSTO_ESTERNO > @COSTO_FISSI*0.10)BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare rendicontato sulla sistemazione del terreno super il 10% del costo degli interventi.'	
END

-------------------------------------------------------------------------------------------------------
-- aumento occupazione (da attività connesse - ore impianto energia)
DECLARE @ORE_ATTUALE DECIMAL(18,2),@ORE_ANNO_PROGETTO DECIMAL(18,2)
SELECT @ORE_ATTUALE = ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0)
FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO AND ID_ATTIVITA_CONNESSA IS NOT NULL AND ANNO IN (SELECT MAX(ANNO) FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO)
SELECT @ORE_ANNO_PROGETTO =ISNULL(SUM(ISNULL(SAU,0) * ISNULL(ORE_UNITARIE,0)),0)
FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO AND ID_ATTIVITA_CONNESSA IS NOT NULL AND ANNO IN (SELECT MIN(ANNO) FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO)

IF @ORE_ATTUALE IS NULL BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - E` necessario inserire la PLV post-investimento (anno del SALDO attuale).'
END
ELSE BEGIN
	IF (ISNULL(@ORE_ATTUALE,0 ) - ISNULL(@ORE_ANNO_PROGETTO,0) <=0) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`incremento di occupazione non presente.'	
	END
END


 
/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
