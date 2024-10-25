CREATE PROCEDURE [dbo].[VerificaRendicontazionePagamentoSaldo_M112_B107]
(
	@ID_DOMANDA_PAGAMENTO INT
)
AS
 
--DECLARE @ID_DOMANDA_PAGAMENTO INT;SET @ID_DOMANDA_PAGAMENTO=1222
--DEFINIZIONI
DECLARE @ID_VARIANTE INT,@ID_PROGETTO INT,@ID_PROGETTO_CORRELATO INT,@DATA_MODIFICA_PAGAMENTO DATETIME,@ID_INVESTIMENTO INT,
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
	[COD_VARIAZIONE] [char](1), [NON_COFINANZIATO] [bit] NULL , 
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
--------------------------------------------------------------------
--111 - Verifica massimali da intervento su corsi di formazione 
DECLARE @ID_PROGETTO_CORRELATO_111 INT
-- TROVO IL PROGETTO CORRELATO MISURA 111
SELECT DISTINCT @ID_PROGETTO_CORRELATO_111 = p.ID_PROGETTO FROM PROGETTO P
			INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.1.A'
WHERE ID_PROG_INTEGRATO = @ID_PROGETTO

---------------------------------------------------------------------------
--114 - E' stato selezionato il consulente prescelto a sistema (requisiti soggettivi mis 114)?
DECLARE @ID_PROGETTO_CORRELATO_114 INT
-- TROVO IL PROGETTO CORRELATO MISURA 114
SELECT DISTINCT @ID_PROGETTO_CORRELATO_114 = p.ID_PROGETTO FROM PROGETTO P
			INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.4.'
WHERE ID_PROG_INTEGRATO = @ID_PROGETTO 
 
 -----------------------------------------------------------------------------------------------
-- 112 VERICA CHE L'AMMONTARE RENDICONTATO NON RIDUCA IL COSTO TOTALE DEGLI INVESTIMENTI SOTTO IL 50%

DECLARE @COSTO_TOTALE_INVESTIMENTI_DA_GRADUATORIA DECIMAL(18,2),@RENDICONTATO_TOTALE_INVESTIMENTI DECIMAL(18,2)

SELECT @RENDICONTATO_TOTALE_INVESTIMENTI=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
SELECT @COSTO_TOTALE_INVESTIMENTI_DA_GRADUATORIA=COSTO_TOTALE FROM GRADUATORIA_PROGETTI WHERE ID_PROGETTO=@ID_PROGETTO
IF @RENDICONTATO_TOTALE_INVESTIMENTI<(@COSTO_TOTALE_INVESTIMENTI_DA_GRADUATORIA/2) BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare rendicontato non può essere inferiore al 50% della spesa ammessa a finanziamento.'
END

------------------------------------------------------------------------------
-- 112 - Verifica sostenibilità investimento: rata annua reintegrazione < 40% PLV post-investimento (VIENE CALCOLATA LA PLV ANNO DEL SALDO)

DECLARE @RATA_INTEGRAZIONE DECIMAL(10,2),@PLV DECIMAL(10,2)
SELECT @RATA_INTEGRAZIONE=SUM(CASE D.MOBILE WHEN 1 THEN IMPORTO_TOTALE_RENDICONTATO/10 ELSE IMPORTO_TOTALE_RENDICONTATO/30 END)
	FROM @INVESTIMENTI_TEMP I LEFT JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO
	WHERE COD_TIPO_INVESTIMENTO=1 AND ID_PROGETTO NOT IN (@ID_PROGETTO_CORRELATO_111,@ID_PROGETTO_CORRELATO_114)
	
SELECT @PLV=SUM(PLV) FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO AND ANNO--=YEAR(@DATA_MODIFICA_PAGAMENTO)
	IN (SELECT MAX(ANNO) FROM PLV_IMPRESA WHERE PREVISIONALE=0 AND ID_PROGETTO=@ID_PROGETTO)
IF @PLV IS NULL BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - E` necessario inserire la PLV post-investimento (anno del SALDO attuale).'
END
IF @RATA_INTEGRAZIONE>(ISNULL(@PLV,0)*0.4) BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - La rata annua di reintegrazione supera il 40% della PLV aziendale inserita.'
 END
 
-------------------------------------------------------------------------------
-- 112 - Verifica che la PLV anno corrente non sia meno del 50% di quella prevista in domanda di aiuto
DECLARE @PLV_PREVISTA DECIMAL(10,2)
SELECT @PLV_PREVISTA=SUM(PLV) FROM PLV_IMPRESA WHERE PREVISIONALE=1 AND ID_PROGETTO=@ID_PROGETTO
IF ISNULL(@PLV,0)<(ISNULL(@PLV_PREVISTA,0)/2) BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - La PLV aziendale inserita è inferiore al 50% di quella prevista in domanda di aiuto.'
END

--------------------------------------------------------------------------------------------------
-- 112 - L'ammontare del mutuo non deve essere superiore a 200.000 €

IF (SELECT SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE COD_TIPO_INVESTIMENTO=2)>200000 BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare del mutuo non deve essere superiore a 200.000 €.'
END
 
-------------------------------------------------------------------------------
--Verifica raggiungimento del minimo (10.000 €) sul premio in conto capitale

DECLARE @MAX_AIUTO DECIMAL(15,2),@MIN_AIUTO DECIMAL(15,2),@COD_AIUTO INT,@PUNTEGGIO DECIMAL(10,6),@COEFFICENTE DECIMAL(10,6),
@FINALE DECIMAL(20,6),@AMMONTARE_PREMIO_CONTO_CAPITALE DECIMAL(18,2)
SELECT @COD_AIUTO=COD_TIPO_INVESTIMENTO,@MIN_AIUTO=ISNULL(IMPORTO_MIN,0),@MAX_AIUTO=ISNULL(IMPORTO_MAX,1000000000) FROM PROGETTO AS P 
INNER JOIN BANDO_TIPO_INVESTIMENTI AS B ON P.ID_BANDO=B.ID_BANDO AND COD_TIPO_INVESTIMENTO=3 WHERE P.ID_PROGETTO=@ID_PROGETTO


DECLARE TOTALE CURSOR FOR 
SELECT OB.PUNTEGGIO,COEFFICENTE_SPESA=CASE 
	WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)>150000 THEN 1 WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)>100000 THEN 0.8
	WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)>75000 THEN 0.6 WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)>50000 THEN 0.4
	WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)>25000 THEN 0.2 WHEN SUM(I.IMPORTO_TOTALE_RENDICONTATO)<25000 
	AND OB.ID_OBIETTIVO IN (1,4) THEN 0.1 ELSE 0 END
FROM @INVESTIMENTI_TEMP AS I
INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON I.ID_INVESTIMENTO=PXI.ID_INVESTIMENTO 
AND ID_PRIORITA IN (102,103,94) -- ID DELLE PRIORITA PER IL CALCOLO DEL PREMIO, VARIA A SECONDA DELLE DISPOSIZIONI DI MISURA
INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE=VP.ID_VALORE
INNER JOIN zOBBP_PREMIO OB ON VP.ID_VALORE=OB.ID_VALORE_PRIORITA
WHERE I.ID_PROGETTO!=@ID_PROGETTO --SOLO GLI INVESTIMENTI DELLE MISURE CORRELATE CONCORRONO AL PREMIO
GROUP BY OB.ID_VALORE_PRIORITA,OB.PUNTEGGIO,OB.ID_OBIETTIVO	
OPEN TOTALE
FETCH NEXT FROM TOTALE INTO @PUNTEGGIO,@COEFFICENTE
WHILE @@FETCH_STATUS = 0 BEGIN
	SET @FINALE=ISNULL(@FINALE,0)+@PUNTEGGIO*@COEFFICENTE
	IF(@FINALE>=1) BREAK	
	FETCH NEXT FROM TOTALE INTO @PUNTEGGIO,@COEFFICENTE
END
CLOSE TOTALE
DEALLOCATE TOTALE

SET @AMMONTARE_PREMIO_CONTO_CAPITALE=@MAX_AIUTO*ISNULL(@FINALE,0)
IF @AMMONTARE_PREMIO_CONTO_CAPITALE>@MAX_AIUTO SET @AMMONTARE_PREMIO_CONTO_CAPITALE=@MAX_AIUTO
ELSE IF @AMMONTARE_PREMIO_CONTO_CAPITALE<@MIN_AIUTO BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare del premio in conto capitale non raggiunge il minimo (10.000 €) previsto dal bando.'
END

---------------------------------------------------------------------------------
--verifica % spese tecniche per fasce di spesa di investimento fisso:    < 200.000,00 € -> 10%  >= 200.000,00 € e < 500.000,00 € -> 6%  >= 500.000,00 € -> 3%
-- impossibile
-- ma se ha rendicontato sugli investimenti non c'e' bisogno

----------------------------------------------------------------------------------
--112-121- verifica punteggio minimo = 0,2 per criteri A-B-C
DECLARE @ID_PROGETTO_CORRELATO_121 INT,@ID_SCHEDA_VALUTAZIONE_121 INT,@PUNTEGGIO_MINIMO_121 DECIMAL(18,6),@COSTO_INVESTIMENTI_121 DECIMAL(10,2),
	@PesoPrioritaA decimal(10,2), @ValoreMAXPrioritaA decimal(10,2), @PesoPrioritaB decimal(10,2),
	@ValoreMAXPrioritaB decimal(10,2), @PesoPrioritaC decimal(10,2), @ValoreMAXPrioritaC decimal(10,2),
	@PunteggioPrioritaA decimal(10,4), @PunteggioPrioritaB decimal(10,4), @PunteggioPrioritaC decimal(10,4)

-- TROVO IL PROGETTO CORRELATO 121
 
-- TROVO IL PROGETTO CORRELATO 121
 SELECT DISTINCT @ID_PROGETTO_CORRELATO_121 = p.ID_PROGETTO FROM PROGETTO P
			INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @ID_PROGETTO
SELECT @COSTO_INVESTIMENTI_121=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 
	AND COD_TIPO_INVESTIMENTO=1
	
IF(@COSTO_INVESTIMENTI_121>0) BEGIN
	SELECT @ID_SCHEDA_VALUTAZIONE_121=ID_SCHEDA_VALUTAZIONE FROM BANDO B INNER JOIN PROGETTO P ON B.ID_BANDO=P.ID_BANDO 
		WHERE P.ID_PROGETTO=@ID_PROGETTO_CORRELATO_121

	-- A: Investimenti relativi a tipologie indicate come priorità di settore
	SELECT @PesoPrioritaA=ISNULL(PESO,0),@ValoreMAXPrioritaA=ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA 
		WHERE ID_PRIORITA=22 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_121
	-- B: 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
	SELECT @PesoPrioritaB=ISNULL(PESO,0),@ValoreMAXPrioritaB=ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA 
		WHERE ID_PRIORITA=23 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_121
	-- C: 121 - investimenti realizzati per i settori prioritari ed in territori preferenziali
	SELECT @PesoPrioritaC=ISNULL(PESO,0),@ValoreMAXPrioritaC=ISNULL(VALORE_MAX,0) FROM vSCHEDA_X_PRIORITA 
		WHERE ID_PRIORITA=112 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_121

	-- CALCOLO LE PRIORITA'
	
	-- 121 - Investimenti relativi a tipologie indicate come prioritarie dal PSR per i settori produttivi di cui al cap.5		
	DECLARE @COSTO_INVESTIMENTI_PRIORITARI_121 DECIMAL(10,2)
	SELECT @COSTO_INVESTIMENTI_PRIORITARI_121=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 AND ID_PRIORITA_SETTORIALE IS NOT NULL AND COD_TIPO_INVESTIMENTO=1	

	IF @COSTO_INVESTIMENTI_121=0 SET @PunteggioPrioritaA=0
	ELSE IF @COSTO_INVESTIMENTI_PRIORITARI_121>=(@COSTO_INVESTIMENTI_121*0.7) SET @PunteggioPrioritaA=1 
	ELSE IF @COSTO_INVESTIMENTI_PRIORITARI_121>=(@COSTO_INVESTIMENTI_121 * 0.4) SET @PunteggioPrioritaA=0.8
	ELSE IF @COSTO_INVESTIMENTI_PRIORITARI_121>=(@COSTO_INVESTIMENTI_121 * 0.2) SET @PunteggioPrioritaA=0.4
	ELSE SET @PunteggioPrioritaA=0

	-- 121 - Investimenti di ammodernamento o ricostruzione con tecniche di risparmio energetico (escluso l`acquisto di macchine e attrezzature agricole)
	
	SELECT @COSTO_INVESTIMENTI_PRIORITARI_121=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 AND COD_TIPO_INVESTIMENTO=1 AND ID_INVESTIMENTO IN 
		(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA=23)
 
	IF @COSTO_INVESTIMENTI_121=0 SET @PunteggioPrioritaB=0
	ELSE IF @COSTO_INVESTIMENTI_PRIORITARI_121/@COSTO_INVESTIMENTI_121>=0.75 SET @PunteggioPrioritaB=1
	ELSE IF @COSTO_INVESTIMENTI_PRIORITARI_121/@COSTO_INVESTIMENTI_121>=0.5 SET @PunteggioPrioritaB=0.5
	ELSE SET @PunteggioPrioritaB=0

	-- 121 - Investimenti prioritari per il settore di destinazione
	--EXEC @PunteggioPrioritaC = calcoloPrioritaVariante112_121_2  @ID_VARIANTE, @ID_PROG_CORRENTE
	
	DECLARE @TIPO_AREA_PREVALENTE varchar (2)
	IF @ID_FASCICOLO IS NOT NULL BEGIN
	
		SELECT TOP 1 @TIPO_AREA_PREVALENTE=TIPO_AREA FROM CATASTO_TERRENI T INNER JOIN COMUNI C ON T.ID_COMUNE = C.ID_COMUNE
		WHERE T.ID_CATASTO IN (SELECT DISTINCT ID_CATASTO FROM vTERRITORIO WHERE ID_FASCICOLO=@ID_FASCICOLO
			AND TIPO_AREA IS NOT NULL) GROUP BY C.TIPO_AREA ORDER BY SUM(T.SUPERFICIE_CATASTALE) DESC 

		-- 1. DETERMINAZIONE DEL TIPO DI AREA CON PIU' INVESTIMENTI
		DECLARE @TipoArea varchar(2),@IdSettoreProduttivo int,@Costo_Investimento decimal(10,2),@COSTO_INVESTIMENTO_MAX DECIMAL (10,2),
			@TipoAreaMax varchar(2),@IdSettoreProduttivoMax int

		-- LISTA SETTORI PRODUTTIVI, TIPO AREA, COSTO INVESTIMENTI
		SELECT TOP 1 @IdSettoreProduttivoMaX=ID_SETTORE_PRODUTTIVO,@TipoAreaMax=TIPO_AREA,@COSTO_INVESTIMENTO_MAX=SUM(Costo)
		FROM (SELECT SUM(I.IMPORTO_TOTALE_RENDICONTATO) AS Costo, ISNULL(C.TIPO_AREA, @TIPO_AREA_PREVALENTE) AS TIPO_AREA, 
			-- Modifica per settore produttivo OVINO - CAPRINO
			'ID_SETTORE_PRODUTTIVO' = CASE WHEN I.ID_SETTORE_PRODUTTIVO = 216 THEN 20 ELSE I.ID_SETTORE_PRODUTTIVO END
			 FROM  @INVESTIMENTI_TEMP I LEFT JOIN
			 (SELECT ID_LOCALIZZAZIONE, ID_INVESTIMENTO, ID_CATASTO FROM LOCALIZZAZIONE_INVESTIMENTO
						  WHERE ID_LOCALIZZAZIONE IN
								 (SELECT MAX(ID_LOCALIZZAZIONE) AS ID_LOCALIZZAZIONE FROM @INVESTIMENTI_TEMP I2 
								  INNER JOIN LOCALIZZAZIONE_INVESTIMENTO AS L2 ON I2.ID_INVESTIMENTO = L2.ID_INVESTIMENTO
								  WHERE I2.ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 GROUP BY I2.ID_INVESTIMENTO)
						  ) AS LOC ON LOC.ID_INVESTIMENTO = I.ID_INVESTIMENTO 
			  LEFT JOIN CATASTO_TERRENI T ON T.ID_CATASTO = LOC.ID_CATASTO 						  
			  LEFT JOIN vComuni C ON T.ID_COMUNE = C.ID_COMUNE           
			   WHERE I.ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 
			  GROUP BY I.ID_SETTORE_PRODUTTIVO, C.TIPO_AREA) AS Q1
		GROUP BY ID_SETTORE_PRODUTTIVO, TIPO_AREA ORDER BY SUM(Costo) DESC

		SET @TipoAreaMax=ISNULL(@TipoAreaMax,@TIPO_AREA_PREVALENTE)

		-- 3. ASSEGNAZIONE PUNTEGGIO
		IF (@TipoAreaMax IS NULL OR @IdSettoreProduttivoMaX IS NULL) SET @PunteggioPrioritaC = 0
		ELSE BEGIN

		   -- CARNI BOVINE Zona A
		   IF ((@IdSettoreProduttivoMaX = 7  )AND @TipoAreaMax = 'A') SET @PunteggioPrioritaC = 0.3
		   -- CARNI BOVINE Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- CARNI BOVINE Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C2') SET @PunteggioPrioritaC = 0.6
		   -- CARNI BOVINE Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreaMax = 'C3') SET @PunteggioPrioritaC = 1
		   -- CARNI BOVINE Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 7   ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 1

		   -- CARNI SUINE Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.3
		   -- CARNI SUINE Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- CARNI SUINE Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 1
		   -- CARNI SUINE Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 11   ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.6
		   -- CARNI SUINE Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 11  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.6


		   -- Oleicolo oppure Olivicolo Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  )  AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.6
		   -- Oleicolo Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 1
		   -- Oleicolo Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 1
		   -- Oleicolo Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.6
		   -- Oleicolo Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 27 or @IdSettoreProduttivoMaX = 29  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.3


		   -- Vitivinicolo Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 43  )  AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.6
		   -- Vitivinicolo Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- Vitivinicolo Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 1
		   -- Vitivinicolo Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.6
		   -- Vitivinicolo Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 43  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.3

		   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216  ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.3
		   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.3
		   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.6
		   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216  )  AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 1
		   -- LATTE E PRODOTTI LATTIERO-CASEARI Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 20  or @IdSettoreProduttivoMaX = 216   )  AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 1

		   -- PRODUZIONI DI NICCHIA Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.3
		   -- PRODUZIONI DI NICCHIA Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 37  )AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.3
		   -- PRODUZIONI DI NICCHIA Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.6
		   -- PRODUZIONI DI NICCHIA Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 1
		   -- PRODUZIONI DI NICCHIA Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 37  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 1

		   -- OrtoFrutta Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 31  )  AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.36
		   -- OrtoFrutta Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- OrtoFrutta Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.6
		   -- OrtoFrutta Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.36
		   -- OrtoFrutta Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 31  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.18

		   -- FLOROVIVAISMO Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 16  )  AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.36
		   -- FLOROVIVAISMO Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- FLOROVIVAISMO Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.36
		   -- FLOROVIVAISMO Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 16  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.18
		   -- FLOROVIVAISMO Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 16 ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.18

		   -- SEMENTIERO Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- SEMENTIERO Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 40  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.6
		   -- SEMENTIERO Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.6
		   -- SEMENTIERO Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.36
		   -- SEMENTIERO Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 40   ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.18

		   -- AVICOLO (CARNI E UOVA) Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- AVICOLO (CARNI E UOVA) Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.18
		   -- AVICOLO (CARNI E UOVA) Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.36
		   -- AVICOLO (CARNI E UOVA) Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.36
		   -- AVICOLO (CARNI E UOVA) Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 3  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.18

		   -- LEGUMINOSE DA GRANELLA Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 23  )  AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- LEGUMINOSE DA GRANELLA Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.36
		   -- LEGUMINOSE DA GRANELLA Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.36
		   -- LEGUMINOSE DA GRANELLA Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.6
		   -- LEGUMINOSE DA GRANELLA Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 23  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.36

		   -- CARNI OVINE OPPURE OVINO E CAPRINO (PER II SCADENZA ) Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- CARNI OVINE Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34    ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.18
		   -- CARNI OVINE Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.18
		   -- CARNI OVINE Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34   ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.36
		   -- CARNI OVINE Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 9 or @IdSettoreProduttivoMaX = 34    ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.6

		   -- FORAGGERE Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- FORAGGERE Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.18
		   -- FORAGGERE Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.36
		   -- FORAGGERE Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.6
		   -- FORAGGERE Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 19  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.6

		   -- CEREALI Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 13  )AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.18
		   -- CEREALI Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 13  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.3
		   -- CEREALI Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 13  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.3
		   -- CEREALI Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 13   ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.09
		   -- CEREALI Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 13   ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.09   

		   -- OLEAGINOSE Zona A
		   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'A') SET @PunteggioPrioritaC = 0.09
		   -- OLEAGINOSE Zona C1
		   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C1') SET @PunteggioPrioritaC = 0.18
		   -- OLEAGINOSE Zona C2
		   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C2') SET @PunteggioPrioritaC = 0.3
		   -- OLEAGINOSE Zona C3
		   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'C3') SET @PunteggioPrioritaC = 0.09
		   -- OLEAGINOSE Zona D
		   ELSE IF ((@IdSettoreProduttivoMaX = 24  ) AND @TipoAreamAX = 'D') SET @PunteggioPrioritaC = 0.09

		   ELSE SET @PunteggioPrioritaC = 0
		END
	END 
	ELSE  SET @PunteggioPrioritaC = 0

	-- CALCOLO PUNTEGGIO PRIORITA' A+B+C
	SET @PUNTEGGIO_MINIMO_121=@PunteggioPrioritaA*@PesoPrioritaA/@ValoreMAXPrioritaA + @PunteggioPrioritaB*@PesoPrioritaB/@ValoreMAXPrioritaB
		+ @PunteggioPrioritaC*@PesoPrioritaC/@ValoreMAXPrioritaC
 	IF @PUNTEGGIO_MINIMO_121<0.2 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Il punteggio calcolato per la Misura 121 sui criteri A-B-C non raggiunge il minimo di 0,2.'
	END
END

----------------------------------------------------------------------------------------------
-- 112 - 121 - verifica massimale investimento fotovoltaico:
-- a) La somma degli investimenti aventi come specifica "fotovoltaico" non può superare i 400000€
-- b) Il contributo ammissibile sul fotovoltatico non può superare il 30% del contributo ammissibile totale

DECLARE @COSTO_INVESTIMENTI_FOTOVOLTAICI DECIMAL(18,2),@COSTO_INVESTIMENTI_TOTALE_121 DECIMAL(18,2)
SELECT @COSTO_INVESTIMENTI_TOTALE_121=SUM(IMPORTO_TOTALE_RENDICONTATO),
	@COSTO_INVESTIMENTI_FOTOVOLTAICI=SUM(CASE WHEN ID_SPECIFICA_INVESTIMENTO IN (238,326,879,1395) THEN IMPORTO_TOTALE_RENDICONTATO ELSE 0 END)
	FROM @INVESTIMENTI_TEMP I WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 AND COD_TIPO_INVESTIMENTO=1
IF (@COSTO_INVESTIMENTI_FOTOVOLTAICI>400000 OR @COSTO_INVESTIMENTI_FOTOVOLTAICI>(@COSTO_INVESTIMENTI_TOTALE_121*0.3)) BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare rendicontato sugli investimenti riguardanti il fotovoltaico supera €40.000 o il 30% del totale su tutti gli investimenti.'	
END
	
------------------------------------------------------------------------------------------------
-- 112-121- verifica aumento del rendimento globale dell'azienda
-- L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
-- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
-- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
-- ad una o più di esse -- Investimenti volti al miglioramento globale dell'azienda (ID_PRIORITA 102)

DECLARE @COSTO_INVESTIMENTI_PRIORITA_121 DECIMAL(18,2)
IF @COSTO_INVESTIMENTI_TOTALE_121>0 BEGIN
	SELECT @COSTO_INVESTIMENTI_PRIORITA_121=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_121 AND ID_INVESTIMENTO IN 
			(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA=102)
					
	IF @COSTO_INVESTIMENTI_PRIORITA_121<=(@COSTO_INVESTIMENTI_TOTALE_121/2) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Aumento del rendimento globale dell`azienda non verificato.'
	END
END

---------------------------------------------------------------------------------------------------
-- 121 - verifica totale investimenti in domanda >= 25.000,00 € 

IF (@COSTO_INVESTIMENTI_TOTALE_121>0 AND @COSTO_INVESTIMENTI_TOTALE_121 < 25000) BEGIN
	SET @TIPO_RISULTATO='N'
	SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - L`ammontare rendicontato sulla misura 121 deve essere superiore a 25.000 €.'
END

---------------------------------------------------------------------------------------------------
-- 112-311 Investimenti immateriali < 20.000 €

/* non riesco a verificarlo*/

---------------------------------------------------------------------------------------------------
--112-311 VERIFICA PUNTEGGIO MINIMO = 0,08 (CRITERI B-I-J-K)
DECLARE @ID_PROGETTO_CORRELATO_311 INT,@ID_SCHEDA_VALUTAZIONE_311 INT,@COSTO_INVESTIMENTI_311 DECIMAL(18,2),
	@PUNTEGGIO_MINIMO_311 DECIMAL(18,6),@ID_BANDO_311 INT

SELECT DISTINCT @ID_PROGETTO_CORRELATO_311 = p.ID_PROGETTO , @ID_BANDO_311 = P.ID_BANDO  FROM PROGETTO P
			INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID = B.ID_PROGRAMMAZIONE AND CODICE = '3.1.1.A'
WHERE ID_PROG_INTEGRATO = @ID_PROGETTO

SELECT @ID_SCHEDA_VALUTAZIONE_311=ID_SCHEDA_VALUTAZIONE FROM BANDO B  WHERE ID_BANDO =@ID_BANDO_311

SELECT @COSTO_INVESTIMENTI_311=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_311
	AND COD_TIPO_INVESTIMENTO=1

IF @COSTO_INVESTIMENTI_311>0 BEGIN

 
	-- CALCOLO PRIORITA 311
	-----------------------------
	-- Priorità B (112 - 311 - investimenti destinati a migliorare i servizi agrituristici delle aziende) ID: 104
	DECLARE @PesoPrioritaB311 decimal(10,2),@ValoreMAXPrioritaB311 decimal(10,2),@PunteggioPrioritaB311 decimal(10,4)
	SELECT @PesoPrioritaB311=ISNULL(PESO,0),@ValoreMAXPrioritaB311=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
		WHERE ID_PRIORITA=104 AND ID_SCHEDA_VALUTAZIONE = @ID_SCHEDA_VALUTAZIONE_311
	--EXEC @ValorePrioritaB = calcoloPrioritaVariante112_311_1  @ID_VARIANTE, @ID_PROG_CORRENTE
	
	DECLARE @COSTO_INVESTIMENTI_SERVIZI_311 DECIMAL(18,2),@COD_VALORE_PRIORITA VARCHAR(10)
	-- Calcolo gli investimenti per servizi
	SELECT @COSTO_INVESTIMENTI_SERVIZI_311=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_311 AND COD_TIPO_INVESTIMENTO=1 AND ID_INVESTIMENTO IN 
			(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA=104)

	SET @PunteggioPrioritaB311 = 0
	IF @COSTO_INVESTIMENTI_SERVIZI_311>0 BEGIN     	   		
		-- 112 - 311 - Numero finale strutture (ID PRIORITA: 111)				        	  
		SELECT @COD_VALORE_PRIORITA=CODICE FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON PP.ID_VALORE = VP.ID_VALORE
			WHERE PP.ID_PROGETTO = @ID_PROGETTO_CORRELATO_311 AND PP.ID_PRIORITA = 111

		  -- 3. Calcolo il punteggio	 
		 IF @COD_VALORE_PRIORITA IS NOT NULL BEGIN		   
			 -- Quota investimenti per servizi > 30% del costo totale con 3 o più strutture
			 IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.3) AND @COD_VALORE_PRIORITA = '3') SET @PunteggioPrioritaB311 = 1
			 -- Quota investimenti per servizi > 20% e < 30% sul costo totale con 3 o più strutture
			 ELSE IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.2) AND
					  @COSTO_INVESTIMENTI_SERVIZI_311 <= (@COSTO_INVESTIMENTI_311 * 0.3) AND @COD_VALORE_PRIORITA = '3') SET @PunteggioPrioritaB311 = 0.8
			 -- Quota investimenti per servizi > 20% e < 30% sul costo totale e 2 strutture
			-- la quota deve essere > 20 %
			 ELSE IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.2)  AND @COD_VALORE_PRIORITA = '2') SET @PunteggioPrioritaB311 = 0.65
			 -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 3 o più strutture
			 ELSE IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.15) AND
					  @COSTO_INVESTIMENTI_SERVIZI_311 <= (@COSTO_INVESTIMENTI_311 * 0.2) AND @COD_VALORE_PRIORITA = '3') SET @PunteggioPrioritaB311 = 0.5
			 -- Quota investimenti per servizi > 15% e < 20% sul costo totale con 2 strutture
			 ELSE IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.15) AND
					  @COSTO_INVESTIMENTI_SERVIZI_311 <= (@COSTO_INVESTIMENTI_311 * 0.2) AND @COD_VALORE_PRIORITA = '2') SET @PunteggioPrioritaB311 = 0.4
			 -- Quota investimenti per servizi > 15% e 1 struttura
			 ELSE IF (@COSTO_INVESTIMENTI_SERVIZI_311 > (@COSTO_INVESTIMENTI_311 * 0.15) AND @COD_VALORE_PRIORITA = '1') SET @PunteggioPrioritaB311 = 0.3
		END
	END
	SET @PunteggioPrioritaB311 = @PunteggioPrioritaB311 * @PesoPrioritaB311 / @ValoreMAXPrioritaB311
	
	------------------------------
	-- Priorità I (112 - 311 - Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 105
	-- Priorità I (Investimenti strutturali realizzati con tecniche di bioedilizia) ID: 154 II SCADENZA
	DECLARE @PesoPrioritaI311 decimal(10,2),@ValoreMAXPrioritaI311 decimal(10,2),@ValorePrioritaI311 decimal(10,4),
		@PunteggioPrioritaI311 decimal(10,4),@InvestimentiFabbricati311 DECIMAL(18,2),@InvestimentiBioedilizia311 DECIMAL(18,2)

	 
		SELECT @PesoPrioritaI311=ISNULL(PESO,0),@ValoreMAXPrioritaI311=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
			WHERE ID_PRIORITA=154 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_311
		--EXEC @ValorePrioritaI =   calcoloPrioritaVariante112_311_3  @ID_VARIANTE, @ID_PROG_CORRENTE
		
		-- Calcolo gli investimenti per Codifica A e B
	 	SELECT @InvestimentiFabbricati311=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP I
	 			INNER JOIN vzPROGRAMMAZIONE PR ON PR.ID=I.ID_PROGRAMMAZIONE AND PR.CODICE IN ('3.1.1.a.A','3.1.1.a.B')
	 	 
		SELECT @InvestimentiBioedilizia311=SUM(IMPORTO_TOTALE_RENDICONTATO) FROM @INVESTIMENTI_TEMP WHERE ID_INVESTIMENTO IN 
			(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI WHERE ID_PRIORITA=154)
		 
		SET @ValorePrioritaI311 = 0
		IF @InvestimentiFabbricati311>=(0.65*@COSTO_INVESTIMENTI_311) BEGIN	  
			 -- Quota investimenti prioritari superiore all’80% sul costo totale
			 IF @InvestimentiBioedilizia311 > (@InvestimentiFabbricati311 * 0.8) SET @ValorePrioritaI311 = 1

			 --Quota investimenti prioritari > 65% e < 80% sul costo totale
			 ELSE IF @InvestimentiBioedilizia311 > (@InvestimentiFabbricati311 * 0.65) SET @ValorePrioritaI311 = 0.65

			 -- Quota investimenti prioritari > 50% e < 65% sul costo totale
			 ELSE IF @InvestimentiBioedilizia311 > (@InvestimentiFabbricati311 * 0.50) SET @ValorePrioritaI311 = 0.35	   
		END
	 
	SET @PunteggioPrioritaI311 = @ValorePrioritaI311 * @PesoPrioritaI311 / @ValoreMAXPrioritaI311
	
	-------------------------------
	-- Priorità J (112 - 311 - investimenti con riqualificazione architettonica riguardanti tutto il patrimonio aziendale) ID: 106
	DECLARE @PesoPrioritaJ311 decimal(10,2),@ValoreMAXPrioritaJ311 decimal(10,2),@ValorePrioritaJ311 decimal(10,4),
		@PunteggioPrioritaJ311 decimal(10,4)

	SELECT @PesoPrioritaJ311=ISNULL(PESO,0),@ValoreMAXPrioritaJ311=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
			WHERE ID_PRIORITA=106 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_311
	SELECT @ValorePrioritaJ311=COUNT(ID_PRIORITA) FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA=106 AND ID_PROGETTO=@ID_PROGETTO_CORRELATO_311
	SET @PunteggioPrioritaJ311 = @ValorePrioritaJ311 * @PesoPrioritaJ311 / @ValoreMAXPrioritaJ311
	
	--------------------------------
	-- Priorità K (112 - 311 - investimenti destinati all`utilizzo di fonti energetiche rinnovabili) ID: 107
	DECLARE @PesoPrioritaK311 decimal(10,2),@ValoreMAXPrioritaK311 decimal(10,2),@ValorePrioritaK311 decimal(10,4),
		@PunteggioPrioritaK311 decimal(10,4)

	SELECT @PesoPrioritaK311=ISNULL(PESO,0),@ValoreMAXPrioritaK311=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA 
			WHERE ID_PRIORITA=107 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_311
			
	SELECT @ValorePrioritaK311=CASE WHEN VP.CODICE = '1' THEN 0.8 WHEN VP.CODICE = '2' THEN 1 WHEN VP.CODICE = '3' THEN 0.4 
		WHEN VP.CODICE = '4' THEN 0.6 ELSE 0 END FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON PP.ID_VALORE = VP.ID_VALORE
		WHERE PP.ID_PROGETTO=@ID_PROGETTO_CORRELATO_311 AND PP.ID_PRIORITA=107

	SET @PunteggioPrioritaK311 = @ValorePrioritaK311 * @PesoPrioritaK311 / @ValoreMAXPrioritaK311
	
	SET @PUNTEGGIO_MINIMO_311=ISNULL(@PunteggioPrioritaB311,0)+ISNULL(@PunteggioPrioritaI311,0)+ISNULL(@PunteggioPrioritaJ311,0)
		+ISNULL(@PunteggioPrioritaK311,0)
	IF @PUNTEGGIO_MINIMO_311<0.08 BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Il punteggio calcolato per la Misura 311 sui criteri B-I-J-K non raggiunge il minimo di 0,8.'	
	END
END

-----------------------------------------------------------------------------------------
-- 112 - MANTENIMENTO PUNTEGGIO MINIMO GRADUATORIA

DECLARE @MINIMO_GRADUATORIA_NON_FIN DECIMAL(10,5),@PUNTEGGIO_DOMANDA_IN_GRADUATORIA DECIMAL(10,5),@NUOVO_PUNTEGGIO_DOMANDA DECIMAL(10,5),
	@ID_BANDO_112 INT,@ID_SCHEDA_VALUTAZIONE_112 INT
SELECT @ID_BANDO_112=P.ID_BANDO,@PUNTEGGIO_DOMANDA_IN_GRADUATORIA=PUNTEGGIO,@ID_SCHEDA_VALUTAZIONE_112=ID_SCHEDA_VALUTAZIONE FROM PROGETTO P 
	INNER JOIN BANDO B ON P.ID_BANDO=B.ID_BANDO INNER JOIN GRADUATORIA_PROGETTI G ON P.ID_PROGETTO=G.ID_PROGETTO AND P.ID_BANDO=G.ID_BANDO
	WHERE P.ID_PROGETTO=@ID_PROGETTO
SELECT TOP 1 @MINIMO_GRADUATORIA_NON_FIN=PUNTEGGIO FROM GRADUATORIA_PROGETTI WHERE ID_BANDO=@ID_BANDO_112 AND FINANZIABILITA='N' 
	ORDER BY PUNTEGGIO DESC
IF ISNULL(@MINIMO_GRADUATORIA_NON_FIN,0)>0 BEGIN
	
	DECLARE @PesoPriorita112A DECIMAL(18,4), @ValoreMAXPriorita112A DECIMAL(18,4), @ValorePriorita112A DECIMAL(18,4),
		@PesoPriorita112B DECIMAL(18,4), @ValoreMAXPriorita112B DECIMAL(18,4), @ValorePriorita112B DECIMAL(18,4),
		@PesoPriorita112C DECIMAL(18,4), @ValoreMAXPriorita112C DECIMAL(18,4), @ValorePriorita112C DECIMAL(18,4),
		@PesoPriorita112D DECIMAL(18,4), @ValoreMAXPriorita112D DECIMAL(18,4), @ValorePriorita112D DECIMAL(18,4),
		@PunteggioPriorita112A DECIMAL (18,6),@PunteggioPriorita112B DECIMAL (18,6),@PunteggioPriorita112C DECIMAL (18,6),
		@PunteggioPriorita112D DECIMAL (18,6)

	-- A  112 -  Qualità e livello degli obiettivi previsti dal business plan aziendale
	SELECT @PesoPriorita112A=ISNULL(PESO,0),@ValoreMAXPriorita112A=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA
		WHERE ID_PRIORITA=175 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_112
 	--EXEC @ValorePriorita112A =  calcoloPrioritaVariante112_3  @ID_VARIANTE, @IdProgetto
	
	DECLARE @PUNTEGGIO_121 DECIMAL (18,6),@PUNTEGGIO_311 DECIMAL (18,6),@PUNTEGGIO_111 DECIMAL (18,6),@PUNTEGGIO_114 DECIMAL (18,6)
 
	-- B Quota % degli investimenti per la misura 1.2.1. rispetto al totale della spesa strutturale
	DECLARE @QUOTA DECIMAL (10,5)
	SET @PUNTEGGIO_121=@PUNTEGGIO_MINIMO_121
 
	IF (@COSTO_INVESTIMENTI_121 = 0) SET  @QUOTA = 0
	ELSE SET @QUOTA = ( (@COSTO_INVESTIMENTI_121 )  /(@COSTO_INVESTIMENTI_121 + ISNULL(@COSTO_INVESTIMENTI_311,0)))
	SET @PUNTEGGIO_121 = ISNULL(@PUNTEGGIO_121,0)*@QUOTA	
 
	-- PUNTEGGIO MISURA 311
	SET @PUNTEGGIO_311=0
	IF @PUNTEGGIO_MINIMO_311>=0.08 SET @PUNTEGGIO_311=0.15	

	-- PUNTEGGIO MISURA 111
	SELECT @PUNTEGGIO_111=CASE WHEN COUNT(ID_INVESTIMENTO)>0 THEN 0.10 ELSE 0 END FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_111 AND IMPORTO_TOTALE_RENDICONTATO>0 AND ID_CODIFICA_INVESTIMENTO IN 
		(SELECT ID_CODIFICA_INVESTIMENTO FROM CODIFICA_INVESTIMENTO WHERE ID_BANDO IN (110) AND DESCRIZIONE LIKE '04%')

	-- PUNTEGGIO MISURA 114
	SELECT @PUNTEGGIO_114=CASE WHEN COUNT(ID_INVESTIMENTO)>0 THEN 0.10 ELSE 0 END FROM @INVESTIMENTI_TEMP
		WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO_114 AND IMPORTO_TOTALE_RENDICONTATO>0
	
	SET @ValorePriorita112A=ISNULL(@PUNTEGGIO_121,0)+ISNULL(@PUNTEGGIO_311,0)+ISNULL(@PUNTEGGIO_111,0)+ISNULL(@PUNTEGGIO_114,0)
	SET @PunteggioPriorita112A = @ValorePriorita112A * @PesoPriorita112A --/ @ValoreMAXPriorita112A
	 
 
	-- B.	 112 - insediamento effettuato da giovane imprenditrice
	SELECT @PesoPriorita112B=ISNULL(PESO,0),@ValoreMAXPriorita112B=ISNULL(VALORE_MAX,100) FROM vSCHEDA_X_PRIORITA
		WHERE ID_PRIORITA=95 AND ID_SCHEDA_VALUTAZIONE=@ID_SCHEDA_VALUTAZIONE_112
	SELECT @ValorePriorita112B=COUNT(ID_PRIORITA) FROM PRIORITA_X_PROGETTO PP WHERE PP.ID_PROGETTO=@ID_PROGETTO AND PP.ID_PRIORITA=95
	set @PunteggioPriorita112B = @ValorePriorita112B * @PesoPriorita112B --/ @ValoreMAXPriorita112B

	-- C.	 112 - insediamento effettuato nelle aree svantaggiate e montane (PUNTEGGIO SU FASCICOLO, NON E' MODIFICATO)
	SELECT @PunteggioPriorita112C=PUNTEGGIO FROM GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA=96 AND ID_PROGETTO=@ID_PROGETTO

	-- D  112 - insediamento con acquisizione in proprietà dell`azienda (PUNTEGGIO SU FASCICOLO, NON E' MODIFICATO)
	SELECT @PunteggioPriorita112D=PUNTEGGIO FROM GRADUATORIA_PROGETTI_DETTAGLIO WHERE ID_PRIORITA=97 AND ID_PROGETTO=@ID_PROGETTO	 
	 
	SET @NUOVO_PUNTEGGIO_DOMANDA=ISNULL(@PunteggioPriorita112A,0)+ISNULL(@PunteggioPriorita112B,0)+ISNULL(@PunteggioPriorita112C,0)
		+ISNULL(@PunteggioPriorita112D,0)		
		
	IF(@NUOVO_PUNTEGGIO_DOMANDA<=@MINIMO_GRADUATORIA_NON_FIN AND @NUOVO_PUNTEGGIO_DOMANDA<@PUNTEGGIO_DOMANDA_IN_GRADUATORIA) BEGIN
		SET @TIPO_RISULTATO='N'
		SET @MESSAGGIO_RISULTATO=@MESSAGGIO_RISULTATO+'<BR /> - Mantenimento del punteggio minimo di graduatoria NON VERIFICATO.'
	END
END

/*********************************************************************************************************/
IF @TIPO_RISULTATO='S' SET @MESSAGGIO_RISULTATO='VERIFICA DI AMMISSIBILITA DEGLI IMPORTI RENDICONTATI CONFERMATA'
ELSE SET @MESSAGGIO_RISULTATO='Si sono riscontrati i seguenti errori:'+@MESSAGGIO_RISULTATO
SELECT @TIPO_RISULTATO AS TIPO_RISULTATO, @MESSAGGIO_RISULTATO AS MESSAGGIO_RISULTATO
