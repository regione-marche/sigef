﻿CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_M111_B478]
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
	((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
	(ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X')!='A')) ORDER BY COD_TIPO_INVESTIMENTO

/**********************************************************************************************************/
--INIZIO CONTROLLO STEP
---------------------------------------------------------------------------------------------------
DECLARE @COSTO DECIMAL(18,2), @CODICE VARCHAR(2), @Result INT=1
 
 DECLARE CORSO CURSOR FOR
  ( 
		SELECT SUM(IMPORTO_TOTALE_RENDICONTATO) AS COSTO, CO.CODICE
		FROM @INVESTIMENTI_TEMP inv
			INNER JOIN CODIFICA_INVESTIMENTO CO ON CO.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO 
        GROUP BY  CODICE
   ) 
 
OPEN CORSO
FETCH NEXT FROM CORSO 
INTO @COSTO , @CODICE 
WHILE @@FETCH_STATUS = 0
	BEGIN
	IF (@CODICE IN ('41','42','43','44','45', '46','47','60','49','61','62',
					'50','51','52','53' )) -- MIN 150;  MAX  281,25
		BEGIN IF(@COSTO<150 OR @COSTO >281.25) SET @Result =0 END
	 ELSE 
	 BEGIN IF (@CODICE IN ('54')) 
	       BEGIN IF(@COSTO<150 OR @COSTO >281.30) SET @Result =0 END 
	       ELSE 
	       BEGIN IF (@CODICE IN ('56')) 
				 BEGIN IF(@COSTO<140 OR @COSTO >262.50) SET @Result =0 END 
				 ELSE 
				 BEGIN IF (@CODICE IN ('55'))
					   BEGIN IF(@COSTO<141.67 OR @COSTO >265.63) SET @Result =0 END
					   ELSE 
					   BEGIN IF (@CODICE IN ('57'))
							BEGIN IF(@COSTO<141.67 OR @COSTO >265.63) SET @Result =0 END
					   END
				 END 
	       END
	       
	 END 			

	FETCH NEXT FROM CORSO
INTO @COSTO   ,  @CODICE 
END

CLOSE CORSO
DEALLOCATE CORSO   

IF (isnull(@Result,0) = 0 )BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Non sono verificati i massimali per i corsi di formazione'
END
 

/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO