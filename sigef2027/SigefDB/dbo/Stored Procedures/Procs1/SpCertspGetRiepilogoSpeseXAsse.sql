
CREATE PROCEDURE [dbo].[SpCertspGetRiepilogoSpeseXAsse]
(
    @COD_PSR                    VARCHAR(20),
    @COD_TIPO_PAGAMENTO         CHAR(3) = null,
    @ID_PADRE                   INT = 0,
    @ATTIVAZIONE_BANDI          BIT = NULL,
    @ATTIVAZIONE_FA             BIT = NULL,
    @ATTIVAZIONE_OB_MISURA      BIT = NULL,
    @ATTIVAZIONE_INVESTIMENTI   BIT = NULL,
    @ATTIVAZIONE_FF             BIT = NULL,
    @DATA_INIZIO                DATETIME = NULL,
    @DATA_FINE                  DATETIME = NULL
)
AS

-- Test del codice
/*DECLARE @COD_PSR                    VARCHAR(20) = 'POR20142020',
        @COD_TIPO_PAGAMENTO         CHAR(3)     = null,
        @ID_PADRE                   INT         = 0,
        @ATTIVAZIONE_BANDI          BIT         = null,
        @ATTIVAZIONE_FA             BIT         = null,
        @ATTIVAZIONE_OB_MISURA      BIT         = null,
        @ATTIVAZIONE_INVESTIMENTI   BIT         = null,
        @ATTIVAZIONE_FF             BIT         = null,
        @DATA_INIZIO                DATETIME    = null,
        @DATA_FINE                  DATETIME    = null;
*/

----  N O T A    I M P O R T A N T E  ----
-- : provvisorio, da togliere!
IF @DATA_INIZIO IS NULL
BEGIN
    SET @DATA_INIZIO = CONVERT(datetime, '20160601', 112);
END
IF @DATA_FINE IS NULL
BEGIN
    SET @DATA_FINE = CONVERT(datetime, '20170630', 112);
END


IF @COD_PSR IS NULL AND @ID_PADRE > 0 
BEGIN
    SELECT @COD_PSR = COD_PSR 
    FROM vzPROGRAMMAZIONE 
    WHERE ID = @ID_PADRE;
END;
		
WITH CTE_PROGRAMMAZIONE AS 
(
    SELECT  rootTree.ID,
            rootTree.COD_TIPO,
            rootTree.CODICE,
            rootTree.DESCRIZIONE,
            rootTree.ID_PADRE,
            rootTree.COD_PSR,
            rootTree.TIPO,
            rootTree.LIVELLO,
            rootTree.ATTIVAZIONE_BANDI,
            rootTree.ATTIVAZIONE_FA,
            rootTree.ATTIVAZIONE_OB_MISURA,
            rootTree.ATTIVAZIONE_INVESTIMENTI,
            rootTree.ATTIVAZIONE_FF,
            rootTree.IMPORTO_DOTAZIONE,
            CONVERT(VARCHAR(MAX),rootTree.PathSequence) AS PathLabel
    FROM (  SELECT  ID,
                    COD_TIPO,
                    CODICE,
                    DESCRIZIONE,
                    ID_PADRE,
                    COD_PSR,
                    TIPO,
                    LIVELLO,
                    ATTIVAZIONE_BANDI,
                    ATTIVAZIONE_FA,
                    ATTIVAZIONE_OB_MISURA,
                    ATTIVAZIONE_INVESTIMENTI,
                    ATTIVAZIONE_FF,
                    IMPORTO_DOTAZIONE,
                    char(64 + ROW_NUMBER() OVER(ORDER BY COD_PSR + CAST(LIVELLO AS VARCHAR(5)) + CODICE)) AS PathSequence
            FROM VZPROGRAMMAZIONE 
            WHERE COD_PSR = @COD_PSR 
              AND ID_PADRE = @ID_PADRE
        ) rootTree -- Anchor/root term
    UNION ALL
    SELECT  subTree.ID,
            subTree.COD_TIPO,
            subTree.CODICE,
            subTree.DESCRIZIONE,
            subTree.ID_PADRE,
            subTree.COD_PSR,
            subTree.TIPO,
            subTree.LIVELLO,
            subTree.ATTIVAZIONE_BANDI,
            subTree.ATTIVAZIONE_FA,
            subTree.ATTIVAZIONE_OB_MISURA,
            subTree.ATTIVAZIONE_INVESTIMENTI,
            subTree.ATTIVAZIONE_FF,
            subTree.IMPORTO_DOTAZIONE,
            PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX), subTree.PathSequence)
    FROM (  SELECT  P.ID,
                    P.COD_TIPO,
                    P.CODICE,
                    P.DESCRIZIONE,
                    P.ID_PADRE,
                    P.COD_PSR,
                    P.TIPO,
                    P.LIVELLO,
                    P.ATTIVAZIONE_BANDI,
                    P.ATTIVAZIONE_FA,
                    P.ATTIVAZIONE_OB_MISURA,
                    P.ATTIVAZIONE_INVESTIMENTI,
                    P.ATTIVAZIONE_FF,
                    P.IMPORTO_DOTAZIONE,
                    cte.PathLabel,
                    PathSequence = char(64 + ROW_NUMBER() OVER(ORDER BY P.COD_PSR + CAST(P.LIVELLO AS VARCHAR(5)) + P.CODICE))
            FROM CTE_PROGRAMMAZIONE cte 
                 INNER JOIN 
                 VZPROGRAMMAZIONE P ON CTE.ID = P.ID_PADRE 
            WHERE @COD_PSR IS NULL 
               OR P.COD_PSR = @COD_PSR
        ) subTree
),
DOMANDE_PRESENTATE AS 
(
	-- TOTALE CONTRIBUTO E DOMANDE DI PAGAMENTO PRESENTATE
    SELECT  B.ID_PROGRAMMAZIONE, 
            ISNULL(SUM(CRICHIESTO), 0)  AS CONTRIBUTO_RICHIESTO_TOTALE, 
            ISNULL(SUM(CAMMESSO),   0)  AS CONTRIBUTO_AMMESSO_TOTALE,
            ISNULL(SUM(CLIQUIDATO), 0)  AS CONTRIBUTO_PAGATO_TOTALE
    FROM DOMANDA_DI_PAGAMENTO D
         INNER JOIN 
         (  SELECT  ID_DOMANDA_PAGAMENTO,
                    ISNULL(SUM(CONTRIBUTO_RICHIESTO), 0) AS CRICHIESTO 
            FROM PAGAMENTI_RICHIESTI 
            GROUP BY ID_DOMANDA_PAGAMENTO
         ) Q1 ON D.ID_DOMANDA_PAGAMENTO = Q1.ID_DOMANDA_PAGAMENTO
         LEFT JOIN 
         (  SELECT  ID_DOMANDA_PAGAMENTO,
                    ISNULL(SUM(IMPORTO_AMMESSO),   0)   AS CAMMESSO,
                    ISNULL(SUM(IMPORTO_LIQUIDATO), 0)   AS CLIQUIDATO 
            FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE 
            GROUP BY ID_DOMANDA_PAGAMENTO
         ) Q2 ON D.ID_DOMANDA_PAGAMENTO = Q2.ID_DOMANDA_PAGAMENTO
         INNER JOIN 
         PROGETTO P ON D.ID_PROGETTO = P.ID_PROGETTO
         INNER JOIN 
         BANDO B ON P.ID_BANDO = B.ID_BANDO
    WHERE SEGNATURA IS NOT NULL 
      AND ANNULLATA = 0 
      AND (APPROVATA IS NULL            OR APPROVATA            =1) 
      AND (@COD_TIPO_PAGAMENTO IS NULL  OR D.COD_TIPO           =  @COD_TIPO_PAGAMENTO)
      AND (@DATA_INIZIO IS NULL         OR D.DATA_APPROVAZIONE  >  @DATA_INIZIO) 
      AND (@DATA_FINE IS NULL           OR D.DATA_APPROVAZIONE  <= @DATA_FINE)  
GROUP BY B.ID_PROGRAMMAZIONE
)

SELECT  X.*, 
        y.CONTRIBUTO_RICHIESTO_TOTALE, 
        y.CONTRIBUTO_AMMESSO_TOTALE, 
        y.CONTRIBUTO_PAGATO_TOTALE 
FROM (  SELECT  *, 
                CTE.TIPO + ' ' + CTE.CODICE AS ASSE 
        FROM CTE_PROGRAMMAZIONE CTE
	    WHERE (@ATTIVAZIONE_BANDI IS NULL           OR ATTIVAZIONE_BANDI        = @ATTIVAZIONE_BANDI)
		  AND (@ATTIVAZIONE_FA IS NULL              OR ATTIVAZIONE_FA           = @ATTIVAZIONE_FA) 
		  AND (@ATTIVAZIONE_OB_MISURA IS NULL       OR ATTIVAZIONE_OB_MISURA    = @ATTIVAZIONE_OB_MISURA)
		  AND (@ATTIVAZIONE_INVESTIMENTI IS NULL    OR ATTIVAZIONE_INVESTIMENTI = @ATTIVAZIONE_INVESTIMENTI)
		  AND (@ATTIVAZIONE_FF IS NULL              OR ATTIVAZIONE_FF           = @ATTIVAZIONE_FF)
		) AS X 
	 INNER JOIN 
     (  SELECT  z.TIPO + ' ' + z.CODICE                         AS ASSE, 
                COALESCE(SUM(CONTRIBUTO_RICHIESTO_TOTALE), 0)    AS CONTRIBUTO_RICHIESTO_TOTALE, 
                COALESCE(SUM(CONTRIBUTO_AMMESSO_TOTALE),   0)    AS CONTRIBUTO_AMMESSO_TOTALE, 
                COALESCE(SUM(CONTRIBUTO_PAGATO_TOTALE),    0)    AS CONTRIBUTO_PAGATO_TOTALE 
        FROM vzPROGRAMMAZIONE CTE
             INNER JOIN 
             vzPROGRAMMAZIONE z ON CTE.ID_PADRE          = Z.ID 
                               AND CTE.ATTIVAZIONE_BANDI = 1 
                               AND CTE.COD_PSR           = @COD_PSR
             LEFT OUTER JOIN 
             DOMANDE_PRESENTATE DP ON CTE.ID = DP.ID_PROGRAMMAZIONE
        WHERE (@ATTIVAZIONE_BANDI IS NULL           OR CTE.ATTIVAZIONE_BANDI        = @ATTIVAZIONE_BANDI)
	      AND (@ATTIVAZIONE_FA IS NULL              OR CTE.ATTIVAZIONE_FA           = @ATTIVAZIONE_FA) 
	      AND (@ATTIVAZIONE_OB_MISURA IS NULL       OR CTE.ATTIVAZIONE_OB_MISURA    = @ATTIVAZIONE_OB_MISURA)
	      AND (@ATTIVAZIONE_INVESTIMENTI IS NULL    OR CTE.ATTIVAZIONE_INVESTIMENTI = @ATTIVAZIONE_INVESTIMENTI)
	      AND (@ATTIVAZIONE_FF IS NULL              OR CTE.ATTIVAZIONE_FF           = @ATTIVAZIONE_FF)
        GROUP BY z.ID, 
                Z.TIPO, 
                Z.CODICE
	 ) AS Y ON X.ASSE = Y.ASSE
ORDER BY X.PathLabel