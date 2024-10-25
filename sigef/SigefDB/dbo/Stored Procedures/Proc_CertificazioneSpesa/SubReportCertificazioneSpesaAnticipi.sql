-- DROP PROCEDURE SubReportCertificazioneSpesaAnticipi;
CREATE PROCEDURE SubReportCertificazioneSpesaAnticipi
(
	@dataLotto		DATETIME,
	@codPsr			VARCHAR(100),
	@soloDefinitivi BIT
)
AS
	/*
DECLARE @dataLotto		DATETIME;
DECLARE @codPsr			VARCHAR(100);
DECLARE @soloDefinitivi BIT; 

SET @dataLotto		= '20181219';
SET @codPsr			= 'POR20142020';
SET @soloDefinitivi = 0;
*/

SELECT  vcd.Asse,
        SUM(vcd.ImportoContributoPubblico_Incrementale)             AS ContributoRendicontato,
        SUM(ISNULL(dps2.Importo_Recupero_Anticipo, 0))              AS ImportoCoperto3Anni,
        SUM(ISNULL(vcd.ImportoContributoPubblico_Incrementale, 0) - 
            ISNULL(dps2.Importo_Recupero_Anticipo, 0))              AS ImportoOltre3Anni
FROM    -- Anticipi
        vCertSp_Dettaglio AS vcd
        INNER JOIN 
        Domanda_Di_Pagamento_Esportazione AS dpe2 ON vcd.Id_Domanda_Pagamento = dpe2.Id_Domanda_Pagamento
        LEFT JOIN 
        (   SELECT  Id_Domanda_Pagamento,
                    MAX(Quietanza_Data)     AS Data_Quietanza
            FROM Domanda_Pagamento_Liquidazione
            WHERE Quietanza_Data <= @dataLotto
            GROUP BY Id_Domanda_Pagamento
        ) AS dpl2 ON dpe2.Id_Domanda_Pagamento = dpl2.Id_Domanda_Pagamento
        -- Recupero anticipi (Sal, Sld) entro i 3 anni
        OUTER APPLY
        (   SELECT  dpe1.Id_Progetto,
                    SUM(dpe1.Importo_Recupero_Anticipo)     AS Importo_Recupero_Anticipo
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
            GROUP BY dpe1.Id_Progetto
        ) AS dps2
        -- Esclusione Strumenti Finanziari
        LEFT JOIN 
        BANDO_CONFIG bc ON vcd.Id_Bando = bc.Id_Bando
                        AND bc.Attivo    = 1
                        AND bc.Cod_Tipo  = 'TPAPPALTO'
                        AND bc.Valore    = '04'
WHERE 1 = 1
	AND vcd.TipoDomanda   = 'ANT'
    AND vcd.Selezionata   = 'TRUE'
	AND ((@soloDefinitivi IS NULL OR @soloDefinitivi = 0)
		OR (@soloDefinitivi = 1 AND vcd.Definitivo  =  'TRUE'))
    AND vcd.DataFine      <= @dataLotto
    AND bc.Valore         IS NULL
GROUP BY vcd.Asse

-- EXEC SubReportCertificazioneSpesaAnticipi '20181219', 'POR20142020', 0
-- EXEC SubReportCertificazioneSpesaAnticipi @dataLotto, @codPsr, @soloDefinitivi