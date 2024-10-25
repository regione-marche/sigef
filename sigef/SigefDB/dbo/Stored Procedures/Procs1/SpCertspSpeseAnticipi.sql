CREATE PROCEDURE [dbo].[SpCertspSpeseAnticipi]
(
    @COD_PSR                  VARCHAR(20),
    @ID_PADRE                 INT = 0,
    @ATTIVAZIONE_BANDI        BIT = NULL,
    @ATTIVAZIONE_FA           BIT = NULL,
    @ATTIVAZIONE_OB_MISURA    BIT = NULL,
    @ATTIVAZIONE_INVESTIMENTI BIT = NULL,
    @ATTIVAZIONE_FF           BIT = NULL
)
AS

-- Test della stored
-- DECLARE   @COD_PSR                  VARCHAR(20) = 'POR20142020',
--           @ID_PADRE                 INT = 0,
--           @ATTIVAZIONE_BANDI        BIT = NULL,
--           @ATTIVAZIONE_FA           BIT = NULL,
--           @ATTIVAZIONE_OB_MISURA    BIT = NULL,
--           @ATTIVAZIONE_INVESTIMENTI BIT = NULL,
--           @ATTIVAZIONE_FF           BIT = NULL
---------------------------------


IF @COD_PSR IS NULL AND @ID_PADRE > 0 
BEGIN
    SELECT @COD_PSR = COD_PSR 
    FROM vzPROGRAMMAZIONE 
    WHERE ID = @ID_PADRE;
END;

WITH CTE_PROGRAMMAZIONE AS 
(
    -- Albero della Programmazione
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
            CONVERT(VARCHAR(MAX), rootTree.PathSequence) AS PathLabel
    FROM (SELECT    ID,
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
            PathLabel = subTree.PathLabel + CONVERT(VARCHAR(MAX), subTree.PathSequence)
    FROM (SELECT    P.ID,
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
-- TOTALE CONTRIBUTO E DOMANDE DI PAGAMENTO PRESENTATE
ANTICIPI AS 
( -- Essendo anticipi non sia applicano i Controlli in Loco
    SELECT  v.Asse_Codice,
            YEAR(v.Data_VerDocum)     AS Anno_Approvazione_Anticipo,
            -- YEAR(v.Data_Approvazione        AS Anno_Approvazione_Anticipo
            SUM(l.Quietanza_Importo)  AS Anticipi_Versati_Totali
    FROM vCertSpLiv_1 v
         INNER JOIN
         Domanda_Pagamento_Liquidazione l ON v.Id_Domanda_Pagamento = l.Id_Domanda_Pagamento
    WHERE l.Liquidato    = 1
      AND v.Domanda_Tipo = 'ANT'
      AND v.Cod_Psr      = @COD_PSR
    GROUP BY v.Asse_Codice,
             YEAR(v.Data_VerDocum)
),
PAGAMENTI AS
(
    SELECT  v.Asse_Codice,
            YEAR(v.Data_VerDocum)       AS Anno_Approvazione_Pagamento,
            SUM(l.Quietanza_Importo)    AS Pagamenti_Versati_Totali
    FROM vCertSpLiv_1 v 
         INNER JOIN
         Domanda_Pagamento_Liquidazione l ON v.Id_Domanda_Pagamento = l.Id_Domanda_Pagamento
    WHERE l.Liquidato    =  1
      AND v.Domanda_Tipo <> 'ANT'
      AND v.Cod_Psr      =  @COD_PSR
    GROUP BY v.Asse_Codice,
             YEAR(v.Data_VerDocum)
)

SELECT  X.*, 
        /*Y.ANTICIPI                    AS ANTICIPI,
        Y.IMPORTO_COPERTO_ANTICIPI    AS IMPORTO_COPERTO_ANTICIPI,
        Y.DISAVANZO                   AS DISAVANZO*/
        ISNULL(A.ANTICIPI_VERSATI_TOTALI, 0)       AS ANTICIPI,
        ISNULL(P.PAGAMENTI_VERSATI_TOTALI, 0)      AS IMPORTO_COPERTO_ANTICIPI,
        ISNULL(A.ANTICIPI_VERSATI_TOTALI, 0) - 
            ISNULL(P.PAGAMENTI_VERSATI_TOTALI, 0)  AS DISAVANZO
FROM (SELECT    *, 
                CTE.TIPO + ' ' + CTE.CODICE AS ASSE 
    FROM CTE_PROGRAMMAZIONE CTE
    WHERE (@ATTIVAZIONE_BANDI IS NULL         OR ATTIVAZIONE_BANDI        = @ATTIVAZIONE_BANDI)
      AND (@ATTIVAZIONE_FA IS NULL            OR ATTIVAZIONE_FA           = @ATTIVAZIONE_FA) 
      AND (@ATTIVAZIONE_OB_MISURA IS NULL     OR ATTIVAZIONE_OB_MISURA    = @ATTIVAZIONE_OB_MISURA)
      AND (@ATTIVAZIONE_INVESTIMENTI IS NULL  OR ATTIVAZIONE_INVESTIMENTI = @ATTIVAZIONE_INVESTIMENTI)
      AND (@ATTIVAZIONE_FF IS NULL            OR ATTIVAZIONE_FF           = @ATTIVAZIONE_FF)
    ) AS X 
    LEFT JOIN
    Anticipi a ON X.Codice = a.Asse_Codice
    LEFT JOIN
    Pagamenti p ON X.Codice = p.Asse_Codice
               AND (P.ANNO_APPROVAZIONE_PAGAMENTO IS NULL OR P.ANNO_APPROVAZIONE_PAGAMENTO >= A.ANNO_APPROVAZIONE_ANTICIPO) 
               AND (P.ANNO_APPROVAZIONE_PAGAMENTO IS NULL OR P.ANNO_APPROVAZIONE_PAGAMENTO - A.ANNO_APPROVAZIONE_ANTICIPO < 4)
    /*INNER JOIN 
    (SELECT z.TIPO + ' ' + z.CODICE  AS ASSE, 
            ISNULL(SUM(A.ANTICIPI_VERSATI_TOTALI), 0)       AS ANTICIPI, 
            ISNULL(SUM(P.PAGAMENTI_VERSATI_TOTALI), 0)      AS IMPORTO_COPERTO_ANTICIPI,
            ISNULL(SUM(A.ANTICIPI_VERSATI_TOTALI), 0) - 
                ISNULL(SUM(P.PAGAMENTI_VERSATI_TOTALI), 0)  AS DISAVANZO
    FROM vzPROGRAMMAZIONE CTE
         INNER JOIN 
         vzPROGRAMMAZIONE z ON CTE.ID_PADRE          = Z.ID 
                           AND CTE.ATTIVAZIONE_BANDI = 1 
                           AND CTE.COD_PSR           = @COD_PSR
         LEFT OUTER JOIN
         -- ANTICIPI A ON CTE.ID = A.ID_PROGRAMMAZIONE
         ANTICIPI A ON z.Codice = A.Asse_Codice
         LEFT OUTER JOIN
         -- PAGAMENTI P ON A.ID_PROGETTO = P.ID_PROGETTO
        PAGAMENTI P ON z.Codice = P.Asse_Codice
                   AND (P.ANNO_APPROVAZIONE_PAGAMENTO IS NULL OR P.ANNO_APPROVAZIONE_PAGAMENTO >= A.ANNO_APPROVAZIONE_ANTICIPO) 
                   AND (P.ANNO_APPROVAZIONE_PAGAMENTO IS NULL OR P.ANNO_APPROVAZIONE_PAGAMENTO - A.ANNO_APPROVAZIONE_ANTICIPO < 4)
    WHERE (@ATTIVAZIONE_BANDI IS NULL            OR CTE.ATTIVAZIONE_BANDI         = @ATTIVAZIONE_BANDI)
      AND (@ATTIVAZIONE_FA IS NULL               OR CTE.ATTIVAZIONE_FA            = @ATTIVAZIONE_FA) 
      AND (@ATTIVAZIONE_OB_MISURA IS NULL        OR CTE.ATTIVAZIONE_OB_MISURA     = @ATTIVAZIONE_OB_MISURA)
      AND (@ATTIVAZIONE_INVESTIMENTI IS NULL     OR CTE.ATTIVAZIONE_INVESTIMENTI  = @ATTIVAZIONE_INVESTIMENTI)
      AND (@ATTIVAZIONE_FF IS NULL               OR CTE.ATTIVAZIONE_FF            = @ATTIVAZIONE_FF)
    GROUP BY --z.ID, 
             Z.TIPO, 
             z.CODICE
    ) AS Y ON X.ASSE = Y.ASSE*/
--ORDER BY X.PathLabel
WHERE x.Livello = '1'
ORDER BY X.Asse