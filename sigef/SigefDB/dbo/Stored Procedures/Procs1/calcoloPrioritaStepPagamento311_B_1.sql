CREATE  PROCEDURE [dbo].[calcoloPrioritaStepPagamento311_B_1]
(
 @IdProgetto INT, 
@IdDomandaPagamento int
) 
AS
BEGIN

-- 311 B  - investimenti realizzati per i settori prioritari ed in territori preferenziali
 
DECLARE @Punteggio decimal(10,2)
DECLARE @TipoAreaMax varchar(2)
DECLARE @ID_FASCICOLO int


SET @ID_FASCICOLO = ( select isNull (ID_FASCICOLO,( SELECT    MAX(F.ID_FASCICOLO) AS Expr1  
								FROM PROGETTO INNER JOIN FASCICOLO_AZIENDALE AS F ON PROGETTO .ID_IMPRESA = F.ID_IMPRESA
								WHERE (PROGETTO.ID_PROGETTO = @IdProgetto) ) ) 
								FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto )

SET @TipoAreaMax = ( SELECT  top(1)     COMUNI.TIPO_AREA
						FROM   CATASTO_TERRENI INNER JOIN
						COMUNI ON CATASTO_TERRENI.ID_COMUNE = COMUNI.ID_COMUNE
						WHERE     (CATASTO_TERRENI.ID_CATASTO IN
                          (SELECT DISTINCT ID_CATASTO
                            FROM          vTERRITORIO
                            WHERE      (ID_FASCICOLO = @ID_FASCICOLO) and TIPO_AREA is not null))
						GROUP BY COMUNI.TIPO_AREA
						ORDER BY  SUM(CATASTO_TERRENI.SUPERFICIE_CATASTALE) DESC )

 -- 1. DETERMINAZIONE DEL TIPO DI AREA CON PIU' INVESTIMENTI

DECLARE @IdSettoreProduttivo int , @Costo_Investimento decimal(10,2)
DECLARE @COSTO_INVESTIMENTO_MAX DECIMAL (10,2), @IdSettoreProduttivoMax int


--SPESA NELLA DOMANDA ATTUALE + LA SPESA DELLE DOMANDE PRECEDENTI
-- NESSUN ANTICIPO PER LA MISURA 311 B) pabs

-- ISTRUTTORIA SOLO SPESA AMMESSA
DECLARE SETTORE_PRODUTTIVO CURSOR FOR
  (
	SELECT      PIANO_INVESTIMENTI.ID_SETTORE_PRODUTTIVO,  SUM(  isnull(PR.CONTRIBUTO_AMMESSO,0)) AS SPESA  
                   
FROM         PAGAMENTI_BENEFICIARIO AS PB INNER JOIN
                      PAGAMENTI_RICHIESTI AS PR ON PB.ID_PAGAMENTO_RICHIESTO = PR.ID_PAGAMENTO_RICHIESTO INNER JOIN
                      PIANO_INVESTIMENTI ON PR.ID_INVESTIMENTO = PIANO_INVESTIMENTI.ID_INVESTIMENTO
WHERE     (PR.ID_DOMANDA_PAGAMENTO IN
                          (SELECT     ID_DOMANDA_PAGAMENTO
                            FROM          DOMANDA_DI_PAGAMENTO
                            WHERE      (APPROVATA = 1) AND (ID_PROGETTO = @IdProgetto) AND (ANNULLATA = 0) OR
                                                   (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento)))
GROUP BY  PIANO_INVESTIMENTI.ID_SETTORE_PRODUTTIVO
)

 SET  @COSTO_INVESTIMENTO_MAX=0
OPEN SETTORE_PRODUTTIVO
FETCH NEXT FROM SETTORE_PRODUTTIVO 
INTO @IdSettoreProduttivo,  @Costo_Investimento
WHILE @@FETCH_STATUS = 0
BEGIN
	
	IF(@Costo_Investimento>(@COSTO_INVESTIMENTO_MAX ))
	BEGIN 
		SET @COSTO_INVESTIMENTO_MAX = @Costo_Investimento
		SET @IdSettoreProduttivoMaX = @IdSettoreProduttivo
	END
	FETCH NEXT FROM SETTORE_PRODUTTIVO
INTO @IdSettoreProduttivo,  @Costo_Investimento
END

CLOSE SETTORE_PRODUTTIVO
DEALLOCATE SETTORE_PRODUTTIVO 

   
-- 3. ASSEGNAZIONE PUNTEGGIO
IF (@TipoAreaMax IS NULL OR @IdSettoreProduttivoMaX IS NULL) SET @Punteggio = 0
ELSE BEGIN

   -- biogas per la produzione di energia elettrica e calore Zona A
   IF (@IdSettoreProduttivoMaX = 5 AND @TipoAreaMax = 'A') SET @Punteggio = 0.75
   -- biogas per la produzione di energia elettrica e calore Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 5 AND @TipoAreaMax = 'C1') SET @Punteggio = 1
   -- biogas per la produzione di energia elettrica e calore C2
   ELSE IF (@IdSettoreProduttivoMaX = 5 AND @TipoAreaMax = 'C2') SET @Punteggio = 1
   -- biogas per la produzione di energia elettrica e calore Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 5 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.75
   -- biogas per la produzione di energia elettrica e calore Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 5 AND @TipoAreaMax = 'D') SET @Punteggio = 0.50

   -- prodotti ligno-cellulosici per la produzione di energia termica ed elettrica con caldaie di piccole dimensioni (= 250 kWe)
	--Zona A
   ELSE IF (@IdSettoreProduttivoMaX = 36 AND @TipoAreaMax = 'A') SET @Punteggio = 0.19
    -- prodotti ligno-cellulosici per la produzione di energia termica ed elettrica con caldaie di piccole dimensioni (= 250 kWe)
	-- Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 36 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.37
   -- prodotti ligno-cellulosici per la produzione di energia termica ed elettrica con caldaie di piccole dimensioni (= 250 kWe)
   --  Zona C2
   ELSE IF (@IdSettoreProduttivoMaX = 36 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.37
   -- prodotti ligno-cellulosici per la produzione di energia termica ed elettrica con caldaie di piccole dimensioni (= 250 kWe)
   --   Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 36 AND @TipoAreaMax = 'C3') SET @Punteggio =  0.75
   -- prodotti ligno-cellulosici per la produzione di energia termica ed elettrica con caldaie di piccole dimensioni (= 250 kWe)
	--  Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 36 AND @TipoAreaMax = 'D') SET @Punteggio =  0.56


   -- prodotti ligno-cellulosici per la produzione di energia elettrica e termica con caldaie di medio/grandi dimensioni (> 250 kWe)
	-- Zona A
   ELSE IF (@IdSettoreProduttivoMaX = 35 AND @TipoAreaMax = 'A') SET @Punteggio = 0.12
   -- prodotti ligno-cellulosici per la produzione di energia elettrica e termica con caldaie di medio/grandi dimensioni (> 250 kWe)
-- Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 35 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.25
   -- prodotti ligno-cellulosici per la produzione di energia elettrica e termica con caldaie di medio/grandi dimensioni (> 250 kWe)
-- Zona C2
   ELSE IF (@IdSettoreProduttivoMaX = 35 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.25
   -- prodotti ligno-cellulosici per la produzione di energia elettrica e termica con caldaie di medio/grandi dimensioni (> 250 kWe)
-- Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 35 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.50
   -- prodotti ligno-cellulosici per la produzione di energia elettrica e termica con caldaie di medio/grandi dimensioni (> 250 kWe)
-- Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 35 AND @TipoAreaMax = 'D') SET @Punteggio = 0.37


   -- legno-energia per la produzione di biocombustibili (pellets) Zona A
   ELSE IF (@IdSettoreProduttivoMaX = 22 AND @TipoAreaMax = 'A') SET @Punteggio = 0.19
   -- legno-energia per la produzione di biocombustibili (pellets) Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 22 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.37
   -- legno-energia per la produzione di biocombustibili (pellets) Zona C2
   ELSE IF (@IdSettoreProduttivoMaX = 22 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.37
   -- legno-energia per la produzione di biocombustibili (pellets) Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 22 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.75
   -- legno-energia per la produzione di biocombustibili (pellets) Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 22 AND @TipoAreaMax = 'D') SET @Punteggio = 0.56

   -- olio-energia per la produzione di energia elettrica, termica e panello = 500 kWe
-- Zona A
   ELSE IF (@IdSettoreProduttivoMaX = 28 AND @TipoAreaMax = 'A') SET @Punteggio = 0.12
   -- olio-energia per la produzione di energia elettrica, termica e panello = 500 kWe
-- Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 28 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.50
   -- olio-energia per la produzione di energia elettrica, termica e panello = 500 kWe
-- Zona C2
   ELSE IF (@IdSettoreProduttivoMaX = 28 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.50
   -- olio-energia per la produzione di energia elettrica, termica e panello = 500 kWe 
-- Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 28 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.37
   -- olio-energia per la produzione di energia elettrica, termica e panello = 500 kWe
-- Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 28 AND @TipoAreaMax = 'D') SET @Punteggio = 0.12

   -- altre tipologie di impianti energetici Zona A
   ELSE IF (@IdSettoreProduttivo = 1 AND @TipoAreaMax = 'A') SET @Punteggio = 0.06
   -- altre tipologie di impianti energetici Zona C1
   ELSE IF (@IdSettoreProduttivoMaX = 1 AND @TipoAreaMax = 'C1') SET @Punteggio = 0.25
   -- altre tipologie di impianti energetici Zona C2
   ELSE IF (@IdSettoreProduttivoMaX = 1 AND @TipoAreaMax = 'C2') SET @Punteggio = 0.25
   -- altre tipologie di impianti energetici Zona C3
   ELSE IF (@IdSettoreProduttivoMaX = 1 AND @TipoAreaMax = 'C3') SET @Punteggio = 0.19
   -- altre tipologie di impianti energetici Zona D
   ELSE IF (@IdSettoreProduttivoMaX = 1 AND @TipoAreaMax = 'D') SET @Punteggio = 0.12

    ELSE SET @Punteggio = 0

END

SELECT @Punteggio AS PUNTEGGIO
 RETURN (@Punteggio *100)

END
