CREATE PROCEDURE rptCertificazioneAnomalieQuietanza
AS 
/* 19/07/2018

Vengono selezionate le domande di pagamento che hanno superato i controlli di 1° livello documentale: Domanda_di_Pagamento.Segnatura IS NOT NULL, Domanda_di_Pagamento.Annullata = 'FALSE', CTE_TESTATA_VALIDAZIONE.Approvata = 'TRUE'

Selezione dei record per Privati
- Importo quietanza non presente
- Importo quietanza <> Contributo Concesso (Domanda_di_Pagamento_Esportazione.Importo_Ammesso)
- Data quietanza non presente
- Data quietanza > CTE_TESTATA_VALIDAZIONE.Data_Validazione
- Domanda_di_Pagamento.Data_Approvazione > CTE_TESTATA_VALIDAZIONE.Data_Validazione
- Mandato_Numero non presente

Selezione dei record per gli Enti Pubblici
- Domanda_di_Pagamento.Data_Approvazione > CTE_TESTATA_VALIDAZIONE.Data_Validazione
- Mandato_Numero non presente

 20/01/2020
Sostituito Revisione_domanda_pagamento con CTE_TESTATA_VALIDAZIONE
*/

BEGIN

-- Privati
SELECT  ddp.Id_Progetto,
        ddp.Id_Domanda_Pagamento,
        ddp.Cod_Tipo,
        CONVERT(date, ddp.Data_Approvazione)        AS Data_Approvazione_Domanda,
        CONVERT(date, rdp.Data_Validazione)         AS Data_Validazione_Documentale,
        CONVERT(date, dpl.DataQuietanza)            AS DataQuietanza,
        dpe.Importo_Ammesso     					AS ContributoConcesso,
        dpl.ImportoQuietanza,
        CASE 
            WHEN (dpl.ImportoQuietanza IS NULL)
                 THEN 'Importo quietanza non presente'
            WHEN (dpl.ImportoQuietanza <> dpe.Importo_Ammesso)
                 THEN 'Importo quietanza diverso dall''importo concesso'
            WHEN (CONVERT(date, ddp.Data_Approvazione) > CONVERT(date, rdp.Data_Validazione))
                 THEN 'Data approvazione successiva alla data validazione'
            WHEN dpl.DataQuietanza IS NULL
                 THEN 'Manca la data di quietanza'
            WHEN CONVERT(date, rdp.Data_Validazione) < CONVERT(date, dpl.DataQuietanza)
                 THEN 'Data quietanza successiva alla data validazione'
            WHEN mnd.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'Manca numero mandato di pagamento'
        END                                         AS MotivoAnomalia,
        CASE
            WHEN clc.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'X'
            ELSE ''
        END                                         AS ControlliLoco,
        CASE
            WHEN csp.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'X'
            ELSE ''
        END                                         AS CertifSpesa,
        'Privato'                                   AS FormaGiuridica
FROM vDomanda_di_Pagamento AS ddp
     INNER JOIN
     -- Verifica 1° livello documentale
     CTE_TESTATA_VALIDAZIONE AS rdp ON ddp.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento
     INNER JOIN
     Domanda_di_Pagamento_Esportazione AS dpe ON ddp.Id_Domanda_Pagamento = dpe.Id_Domanda_Pagamento
     INNER JOIN
     vProgetto AS prg ON ddp.Id_Progetto = prg.Id_Progetto
        INNER JOIN
        vImpresa AS imp ON prg.Id_Impresa = imp.Id_Impresa
		LEFT JOIN
        vBando_Programmazione AS bprm ON prg.Id_Bando = bprm.Id_Bando
									 AND bprm.Id_Programmazione NOT IN (17, 18, 19)
     LEFT JOIN
     -- Quietanza di pagamento
     (  SELECT Id_Domanda_Pagamento,
               SUM(Quietanza_Importo)   AS ImportoQuietanza,
               MAX(Quietanza_Data)      AS DataQuietanza
        FROM Domanda_Pagamento_Liquidazione
        GROUP BY Id_Domanda_Pagamento
     ) AS dpl ON ddp.Id_Domanda_Pagamento = dpl.Id_Domanda_Pagamento
     LEFT JOIN
     -- Presenza mandato di pagamento
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM Domanda_Pagamento_Liquidazione
        WHERE Mandato_Numero IS NULL
           --OR Mandato_Numero = 'x'
     ) AS mnd ON ddp.Id_Domanda_Pagamento = mnd.Id_Domanda_Pagamento
     LEFT JOIN
     -- Controlli in loco
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM vCntrLoco_Dettaglio
        WHERE Definitivo    = 'TRUE'
     ) AS clc ON ddp.Id_Domanda_Pagamento = clc.Id_Domanda_Pagamento
     -- Certificazione di Spesa
     LEFT JOIN
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM vCertSp_Dettaglio
        WHERE Definitivo    = 'TRUE'
          AND Selezionata   = 'TRUE'
     ) AS csp ON ddp.Id_Domanda_Pagamento = csp.Id_Domanda_Pagamento
WHERE ddp.Segnatura     IS NOT NULL
  AND ddp.Annullata     = 'FALSE'
  AND rdp.Approvata     = 'TRUE'
  AND bprm.Cod_Psr		= 'POR20142020'
  AND LEFT(LTRIM(RTRIM(imp.Cod_Forma_Giuridica)), 1) <> '2'
  AND ( -- Importo quietanza
        dpl.ImportoQuietanza IS NULL
        OR
        dpl.ImportoQuietanza <> dpe.Importo_Ammesso
        OR
        -- Data quietanza
        dpl.DataQuietanza IS NULL
        OR
        CONVERT(date, dpl.DataQuietanza) > CONVERT(date, rdp.Data_Validazione)
        -- Data approvazione - data validazione
        OR
        CONVERT(date, ddp.Data_Approvazione) > CONVERT(date, rdp.Data_Validazione)
        -- Manca mandato numero
        OR
        mnd.Id_Domanda_Pagamento IS NOT NULL
      )
UNION

-- Enti pubblici
SELECT  ddp.Id_Progetto,
        ddp.Id_Domanda_Pagamento,
        ddp.Cod_Tipo,
        CONVERT(date, ddp.Data_Approvazione)        AS Data_Approvazione_Domanda,
        CONVERT(date, rdp.Data_Validazione)         AS Data_Validazione_Documentale,
        CONVERT(date, dpl.DataQuietanza)            AS DataQuietanza,
        dpe.Importo_Ammesso     					AS ContributoConcesso,
        dpl.ImportoQuietanza,
        CASE 
            WHEN (CONVERT(date, ddp.Data_Approvazione) > CONVERT(date, rdp.Data_Validazione))
                 THEN 'Data approvazione successiva alla data validazione'
            WHEN mnd.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'Manca numero mandato di pagamento'
        END                                         AS MotivoAnomalia,
        CASE
            WHEN clc.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'X'
            ELSE ''
        END                                         AS ControlliLoco,
        CASE
            WHEN csp.Id_Domanda_Pagamento IS NOT NULL
                 THEN 'X'
            ELSE ''
        END                                         AS CertifSpesa,
        'Pubblico'                                  AS FormaGiuridica
FROM vDomanda_di_Pagamento AS ddp
     INNER JOIN
     -- Verifica 1° livello documentale
     CTE_TESTATA_VALIDAZIONE AS rdp ON ddp.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento
     INNER JOIN
     Domanda_di_Pagamento_Esportazione AS dpe ON ddp.Id_Domanda_Pagamento = dpe.Id_Domanda_Pagamento
     INNER JOIN
     vProgetto AS prg ON ddp.Id_Progetto = prg.Id_Progetto
        INNER JOIN
        vImpresa AS imp ON prg.Id_Impresa = imp.Id_Impresa
		LEFT JOIN
        vBando_Programmazione AS bprm ON prg.Id_Bando = bprm.Id_Bando
									 AND bprm.Id_Programmazione NOT IN (17, 18, 19)
		LEFT JOIN
     -- Quietanza di pagamento
     (  SELECT Id_Domanda_Pagamento,
               SUM(Quietanza_Importo)   AS ImportoQuietanza,
               MAX(Quietanza_Data)      AS DataQuietanza
        FROM Domanda_Pagamento_Liquidazione
        GROUP BY Id_Domanda_Pagamento
     ) AS dpl ON ddp.Id_Domanda_Pagamento = dpl.Id_Domanda_Pagamento
     LEFT JOIN
     -- Presenza mandato di pagamento
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM Domanda_Pagamento_Liquidazione
        WHERE Mandato_Numero IS NULL
           --OR Mandato_Numero = 'x'
     ) AS mnd ON ddp.Id_Domanda_Pagamento = mnd.Id_Domanda_Pagamento
     LEFT JOIN
     -- Controlli in loco
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM vCntrLoco_Dettaglio
        WHERE Definitivo    = 'TRUE'
     ) AS clc ON ddp.Id_Domanda_Pagamento = clc.Id_Domanda_Pagamento
     -- Certificazione di Spesa
     LEFT JOIN
     (  SELECT  DISTINCT
                Id_Domanda_Pagamento
        FROM vCertSp_Dettaglio
        WHERE Definitivo    = 'TRUE'
          AND Selezionata   = 'TRUE'
     ) AS csp ON ddp.Id_Domanda_Pagamento = csp.Id_Domanda_Pagamento
WHERE ddp.Segnatura     IS NOT NULL
  AND ddp.Annullata     = 'FALSE'
  AND rdp.Approvata     = 'TRUE'
  AND bprm.Cod_Psr		= 'POR20142020'
  AND LEFT(LTRIM(RTRIM(imp.Cod_Forma_Giuridica)), 1) = '2'
  AND ( -- La quietanza non è richiesta per gli enti pubblici
        -- Data approvazione - data validazione
		CONVERT(date, ddp.Data_Approvazione) > CONVERT(date, rdp.Data_Validazione)        
        -- Manca mandato numero
        OR
        mnd.Id_Domanda_Pagamento IS NOT NULL
      )
ORDER BY ddp.Id_Progetto,
         ddp.Id_Domanda_Pagamento

END
GO


