CREATE PROCEDURE [dbo].[SpCertspSpeseBenediciariEPubbliche]
(
  @COD_PSR                  VARCHAR(20),
  @ID_PADRE                 INT      = 0,
  @ATTIVAZIONE_BANDI        BIT      = NULL,
  @ATTIVAZIONE_FA           BIT      = NULL,
  @ATTIVAZIONE_OB_MISURA    BIT      = NULL,
  @ATTIVAZIONE_INVESTIMENTI BIT      = NULL,
  @ATTIVAZIONE_FF           BIT      = NULL,
  @DATA_INIZIO              DATETIME = NULL,
  @DATA_FINE                DATETIME = NULL
)
AS

-- Test della stored
-- DECLARE @COD_PSR                  VARCHAR(20)   = 'POR20142020';
-- DECLARE @ID_PADRE                 INT           = 0;
-- DECLARE @ATTIVAZIONE_BANDI        BIT           = NULL;
-- DECLARE @ATTIVAZIONE_FA           BIT           = NULL;
-- DECLARE @ATTIVAZIONE_OB_MISURA    BIT           = NULL;
-- DECLARE @ATTIVAZIONE_INVESTIMENTI BIT           = NULL;
-- DECLARE @ATTIVAZIONE_FF           BIT           = NULL; 
-- DECLARE @DATA_INIZIO              DATETIME      = '20160701';
-- DECLARE @DATA_FINE                DATETIME      = '20170630';
---------------------------------


IF @COD_PSR IS NULL AND @ID_PADRE > 0 
BEGIN
    SELECT @COD_PSR = COD_PSR 
    FROM vzPROGRAMMAZIONE 
    WHERE ID = @ID_PADRE;
END;
		
WITH CTE_PROGRAMMAZIONE AS 
(  -- Albero della Programmazione
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
        WHERE COD_PSR   = @COD_PSR 
          AND ID_PADRE  = ISNULL(@ID_PADRE, 0)
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
SELECT  Asse_Codice,
        SUM(Contributo_Richiesto)                       AS CONTRIBUTO_RICHIESTO_TOTALE,
        SUM(Spesa_Ammessa_Incrementale)                 AS CONTRIBUTO_AMMISSIBILE_TOTALE,
        SUM(Importo_Contributo_Pubblico_Incrementale)   AS CONTRIBUTO_PAGATO_TOTALE
FROM vCertSpLiv_1
WHERE Cod_Psr = @COD_PSR
  --AND CONVERT(VarChar(8), Data_Approvazione, 112) >= @DATA_INIZIO
  --AND CONVERT(VarChar(8), Data_Approvazione, 112) <= @DATA_FINE
  AND CONVERT(VarChar(8), Data_VerDocum, 112) >= @DATA_INIZIO
  AND CONVERT(VarChar(8), Data_VerDocum, 112) <= @DATA_FINE
  AND ((Asse_Codice <> '7' AND Motivo_Esclusione <> 'Anticipo'
                           AND Motivo_Esclusione <> 'Realizzazione finanziaria inferiore al 35%')
       OR
       (Asse_Codice = '7')
      )
GROUP BY Asse_Codice
)

SELECT X.*, 
       ISNULL(Y.CONTRIBUTO_RICHIESTO_TOTALE, 0)     AS CONTRIBUTO_RICHIESTO_TOTALE, 
       ISNULL(Y.CONTRIBUTO_AMMISSIBILE_TOTALE, 0)   AS CONTRIBUTO_AMMISSIBILE_TOTALE,
       ISNULL(Y.CONTRIBUTO_PAGATO_TOTALE, 0)        AS CONTRIBUTO_PAGATO_TOTALE
FROM (SELECT *, 
             CTE.TIPO + ' ' + CTE.CODICE AS ASSE 
      FROM CTE_PROGRAMMAZIONE CTE
      WHERE Livello = 1
     ) AS X 
     LEFT JOIN 
     (SELECT ASSE_CODICE, 
             CONTRIBUTO_RICHIESTO_TOTALE, 
             CONTRIBUTO_AMMISSIBILE_TOTALE,
             CONTRIBUTO_PAGATO_TOTALE
      FROM DOMANDE_PRESENTATE DP
     ) AS Y ON X.CODICE = Y.Asse_Codice
ORDER BY X.PathLabel