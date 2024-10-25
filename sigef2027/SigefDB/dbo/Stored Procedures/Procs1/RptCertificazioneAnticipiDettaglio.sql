CREATE PROCEDURE dbo.RptCertificazioneAnticipiDettaglio
(
    @DataLotto  DATETIME
)
AS

/*
-- Inizio "solo per test"
DECLARE @DataLotto  DATETIME;
SET @DataLotto = '20180510';
-- Fine "solo per test"
*/

SELECT  vcd.Asse,
        vcd.Azione,
        vcd.Intervento,
        vcd.Id_Progetto,
        vcd.Codice_Cup,
        vcd.Id_Domanda_Pagamento,
        dps2.Id_Domanda_Pagamento                                   AS Id_Domanda_SAL_Saldo,
        dpl2.Data_Quietanza,
        dps2.Data_Quietanza                                         AS Data_Quietanza_Domanda_Pagamento,
        DATEDIFF(YEAR, dpl2.Data_Quietanza, dps2.Data_Quietanza)    AS Diff_Year,
        vcd.TitoloProgetto,
        vcd.Beneficiario,
        vcd.CostoTotale                                             AS Costo_investimento_ammesso,
        vcd.ImportoAmmesso                                          AS Contributo_concesso,
        vcd.ImportoContributoPubblico                               AS Contributo_rendicontato_concesso_totale_incrementale,
        vcd.ImportoContributoPubblico_Incrementale                  AS Contributo_rendicontato_concesso_delta_riferito_allo_specifico_lotto,
        ISNULL(dps2.Importo_Recupero_Anticipo, 0) + 
            ISNULL(dps3.Importo_Recupero_Anticipo, 0)               AS Importo_Recupero_Anticipo,        
        ISNULL(dps2.Importo_Recupero_Anticipo, 0)                   AS Importo_Anticipo_3_Anni,
        ISNULL(vcd.ImportoContributoPubblico_Incrementale, 0) - 
            ISNULL(dps2.Importo_Recupero_Anticipo, 0)               AS Importo_Anticipo_non_3_Anni,
        vcd.QuotaUe,
        vcd.QuotaStato,
        vcd.QuotaRegione,
        vcd.QuotaPrivato,
        dps3.Id_Domanda_Pagamento                                   AS Id_Domanda_Oltre3Anni,
        ISNULL(dps3.Importo_Recupero_Anticipo, 0)                   AS Importo_Recupero_Oltre3Anni
FROM    -- Anticipi
        vCertSp_Dettaglio AS vcd
        INNER JOIN 
        Domanda_Di_Pagamento_Esportazione AS dpe2 ON vcd.Id_Domanda_Pagamento = dpe2.Id_Domanda_Pagamento
        LEFT JOIN 
        (   SELECT  Id_Domanda_Pagamento,
                    MAX(Quietanza_Data)     AS Data_Quietanza
            FROM Domanda_Pagamento_Liquidazione
            WHERE Quietanza_Data <= @DataLotto
            GROUP BY Id_Domanda_Pagamento
        ) AS dpl2 ON dpe2.Id_Domanda_Pagamento = dpl2.Id_Domanda_Pagamento
        -- Recupero anticipi (Sal, Sld) entro i 3 anni
        OUTER APPLY
        (   SELECT  dpe1.Id_Progetto,
                    dpe1.Id_Domanda_Pagamento,
                    SUM(dpe1.Importo_Recupero_Anticipo)     AS Importo_Recupero_Anticipo,
                    dps1.Data_Quietanza
            FROM Domanda_Di_Pagamento AS dp1
                 INNER JOIN 
                 Domanda_Di_Pagamento_Esportazione AS dpe1 ON dp1.Id_Domanda_Pagamento = dpe1.Id_Domanda_Pagamento
                 INNER JOIN 
                 (  SELECT  dpl3.Id_Domanda_Pagamento,
                            MAX(dpl3.Quietanza_Data)                 AS Data_Quietanza
                    FROM Domanda_Pagamento_Liquidazione dpl3
                    WHERE dpl3.Richiesta_Mandato_Importo <> 0
                    GROUP BY Id_Domanda_Pagamento
                ) AS dps1 ON dpe1.Id_Domanda_Pagamento   = dps1.Id_Domanda_Pagamento
            WHERE dpe1.Importo_Recupero_Anticipo    <> 0
              AND dpe1.Importo_Recupero_Anticipo    IS NOT NULL              
              AND dpe1.Id_Progetto                  = dpe2.Id_Progetto
              AND dp1.Approvata                     = 1
              AND DATEDIFF(YEAR, dpl2.Data_Quietanza, dps1.Data_Quietanza) <= 3
            GROUP BY dpe1.Id_Progetto,
                     dpe1.Id_Domanda_Pagamento,
                     dps1.Data_Quietanza
        ) AS dps2
        -- Recupero anticipi (Sal, Sld) oltre i 3 anni
        OUTER APPLY
        (   SELECT  dpe01.Id_Progetto,
                    dpe01.Id_Domanda_Pagamento,
                    SUM(dpe01.Importo_Recupero_Anticipo)     AS Importo_Recupero_Anticipo,
                    dps01.Data_Quietanza
            FROM Domanda_Di_Pagamento AS dp01
                 INNER JOIN 
                 Domanda_Di_Pagamento_Esportazione AS dpe01 ON dp01.Id_Domanda_Pagamento = dpe01.Id_Domanda_Pagamento
                 INNER JOIN 
                 (  SELECT  dpl03.Id_Domanda_Pagamento,
                            MAX(dpl03.Quietanza_Data)                 AS Data_Quietanza
                    FROM Domanda_Pagamento_Liquidazione dpl03
                    WHERE dpl03.Richiesta_Mandato_Importo <> 0
                    GROUP BY Id_Domanda_Pagamento
                ) AS dps01 ON dpe01.Id_Domanda_Pagamento = dps01.Id_Domanda_Pagamento
            WHERE dpe01.Importo_Recupero_Anticipo    <> 0
              AND dpe01.Importo_Recupero_Anticipo    IS NOT NULL              
              AND dpe01.Id_Progetto                  = dpe2.Id_Progetto
              AND dp01.Approvata                     = 1
              AND DATEDIFF(YEAR, dpl2.Data_Quietanza, dps01.Data_Quietanza) > 3
            GROUP BY dpe01.Id_Progetto,
                     dpe01.Id_Domanda_Pagamento,
                     dps01.Data_Quietanza
        ) AS dps3
        -- Esclusione Strumenti Finanziari
        LEFT JOIN 
        BANDO_CONFIG bc ON vcd.Id_Bando = bc.Id_Bando
                       AND bc.Attivo    = 1
                       AND bc.Cod_Tipo  = 'TPAPPALTO'
                       AND bc.Valore    = '04'
WHERE vcd.TipoDomanda   = 'ANT'
  AND vcd.Selezionata   = 'TRUE'
  AND vcd.Definitivo    = 'TRUE'
  AND bc.Valore         IS NULL
  AND vcd.DataFine      <= @DataLotto
ORDER BY vcd.Asse,
         vcd.Id_Progetto, 
         vcd.Id_Domanda_Pagamento  