CREATE PROCEDURE [dbo].[SpCertspStrumentiFinanziari]
(
  @COD_PSR                  VARCHAR(20),
  @COD_TIPO_PAGAMENTO       CHAR(3)   = null,
  @ID_PADRE                 INT       = 0,
  @ATTIVAZIONE_BANDI        BIT       = NULL,
  @ATTIVAZIONE_FA           BIT       = NULL,
  @ATTIVAZIONE_OB_MISURA    BIT       = NULL,
  @ATTIVAZIONE_INVESTIMENTI BIT       = NULL,
  @ATTIVAZIONE_FF           BIT       = NULL,
  @DATA_INIZIO              DATETIME  = NULL,
  @DATA_FINE                DATETIME  = NULL
)
AS

-- Test della stored
-- DECLARE @COD_PSR                  VARCHAR(20) = 'POR20142020',
--         @COD_TIPO_PAGAMENTO       CHAR(3)   = null,
--         @ID_PADRE                 INT       = 0,
--         @ATTIVAZIONE_BANDI        BIT       = NULL,
--         @ATTIVAZIONE_FA           BIT       = NULL,
--         @ATTIVAZIONE_OB_MISURA    BIT       = NULL,
--         @ATTIVAZIONE_INVESTIMENTI BIT       = NULL,
--         @ATTIVAZIONE_FF           BIT       = NULL,
--         @DATA_INIZIO              DATETIME  = '20160701',
--         @DATA_FINE                DATETIME  = '20170630'
---------------------------------


IF @COD_PSR IS NULL AND @ID_PADRE > 0 
BEGIN
    SELECT @COD_PSR = COD_PSR 
    FROM vzPROGRAMMAZIONE 
    WHERE ID = @ID_PADRE;
END;
		
WITH CTE_PROGRAMMAZIONE AS 
( -- Albero della Programmazione
	SELECT rootTree.ID,
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
         CONVERT(VARCHAR(MAX), rootTree.PathSequence) AS PathLabel
  FROM (SELECT ID,
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
               char(64 + ROW_NUMBER() OVER(ORDER BY COD_PSR + CAST(LIVELLO AS VARCHAR(5)) + CODICE)) AS PathSequence
        FROM VZPROGRAMMAZIONE 
        WHERE COD_PSR  = @COD_PSR 
          AND ID_PADRE = ISNULL(@ID_PADRE, 0)
       ) rootTree -- Anchor/root term
  UNION ALL
  SELECT subTree.ID,
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
         PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX), subTree.PathSequence)
  FROM (SELECT P.ID,
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
               cte.PathLabel,
               PathSequence = char(64 + ROW_NUMBER() OVER(ORDER BY P.COD_PSR + CAST(P.LIVELLO AS VARCHAR(5)) + P.CODICE))
        FROM CTE_PROGRAMMAZIONE cte 
             INNER JOIN 
             VZPROGRAMMAZIONE P ON CTE.ID = P.ID_PADRE 
        WHERE @COD_PSR  IS NULL 
           OR P.COD_PSR = @COD_PSR
       ) subTree
),
DOMANDE_PRESENTATE AS 
(
    SELECT  v.Asse_Codice,
            SUM(v.Contributo_Richiesto)                       AS Contributo_Richiesto_Totale,
            SUM(v.Importo_Contributo_Pubblico_Incrementale)   AS Contributo_Ammesso_Totale,
            SUM(v.Importo_Liquidato)                          AS Contributo_Pagato_Totale
    FROM vCertSpLiv_1 v
            INNER JOIN
            Bando_Config bcfg ON v.ID_BANDO = bcfg.ID_BANDO
    WHERE v.Cod_Psr = @COD_PSR
        AND CONVERT(VarChar(8), v.Data_VerDocum, 112) >= @DATA_INIZIO
        AND CONVERT(VarChar(8), v.Data_VerDocum, 112) <= @DATA_FINE
        -- Parametro imput
        AND (@COD_TIPO_PAGAMENTO IS NULL OR v.Domanda_Tipo = @COD_TIPO_PAGAMENTO)
        -- Strumenti Finanziari
        AND bcfg.COD_TIPO = 'TPAPPALTO'
        AND bcfg.VALORE   = '04'
        AND bcfg.ATTIVO   = 1
    GROUP BY v.Asse_Codice
)

SELECT X.*, 
       ISNULL(y.CONTRIBUTO_RICHIESTO_TOTALE, 0) AS CONTRIBUTO_RICHIESTO_TOTALE,
       ISNULL(y.CONTRIBUTO_AMMESSO_TOTALE, 0)   AS CONTRIBUTO_AMMESSO_TOTALE,
       ISNULL(y.CONTRIBUTO_PAGATO_TOTALE, 0)    AS CONTRIBUTO_PAGATO_TOTALE
FROM (SELECT *, 
             CTE.TIPO + ' ' + CTE.CODICE AS ASSE 
      FROM CTE_PROGRAMMAZIONE CTE
      WHERE (@ATTIVAZIONE_BANDI IS NULL        OR ATTIVAZIONE_BANDI         = @ATTIVAZIONE_BANDI)
        AND (@ATTIVAZIONE_FA IS NULL           OR ATTIVAZIONE_FA            = @ATTIVAZIONE_FA) 
        AND (@ATTIVAZIONE_OB_MISURA IS NULL    OR ATTIVAZIONE_OB_MISURA     = @ATTIVAZIONE_OB_MISURA)
        AND (@ATTIVAZIONE_INVESTIMENTI IS NULL OR ATTIVAZIONE_INVESTIMENTI  = @ATTIVAZIONE_INVESTIMENTI)
        AND (@ATTIVAZIONE_FF IS NULL           OR ATTIVAZIONE_FF            = @ATTIVAZIONE_FF)
     ) AS X 
     INNER JOIN 
     (
        SELECT z.TIPO + ' ' + z.CODICE  AS ASSE, 
               COALESCE(SUM(CONTRIBUTO_RICHIESTO_TOTALE),0) AS CONTRIBUTO_RICHIESTO_TOTALE, 
               COALESCE(SUM(CONTRIBUTO_AMMESSO_TOTALE), 0)  AS CONTRIBUTO_AMMESSO_TOTALE, 
               COALESCE(SUM(CONTRIBUTO_PAGATO_TOTALE),0)    AS CONTRIBUTO_PAGATO_TOTALE 
        FROM vzPROGRAMMAZIONE CTE
             INNER JOIN 
             vzPROGRAMMAZIONE z ON CTE.ID_PADRE          = Z.ID 
                               AND CTE.ATTIVAZIONE_BANDI = 1 
                               AND CTE.COD_PSR           = @COD_PSR
             LEFT OUTER JOIN 
            --  DOMANDE_PRESENTATE DP ON CTE.ID = DP.ID_PROGRAMMAZIONE
            DOMANDE_PRESENTATE DP ON z.Codice = DP.Asse_Codice
        WHERE (@ATTIVAZIONE_BANDI IS NULL         OR CTE.ATTIVAZIONE_BANDI        = @ATTIVAZIONE_BANDI)
          AND (@ATTIVAZIONE_FA IS NULL            OR CTE.ATTIVAZIONE_FA           = @ATTIVAZIONE_FA) 
          AND (@ATTIVAZIONE_OB_MISURA IS NULL     OR CTE.ATTIVAZIONE_OB_MISURA    = @ATTIVAZIONE_OB_MISURA)
          AND (@ATTIVAZIONE_INVESTIMENTI IS NULL  OR CTE.ATTIVAZIONE_INVESTIMENTI = @ATTIVAZIONE_INVESTIMENTI)
          AND (@ATTIVAZIONE_FF IS NULL            OR CTE.ATTIVAZIONE_FF           = @ATTIVAZIONE_FF)
        GROUP BY z.ID, 
                 Z.TIPO, 
                 Z.CODICE
	) AS Y ON X.ASSE = Y.ASSE
ORDER BY X.PathLabel