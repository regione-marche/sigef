CREATE PROCEDURE [dbo].[SpCertspSpeseCostiEffett]
(
	@Cod_Psr     VARCHAR(20),
	@Data_Inizio DATETIME = NULL,
	@Data_Fine   DATETIME = NULL
)
AS	

WITH
Domande_Presentate AS 
(
    -- Totale Contributo e Domande Di Pagamento Presentate
    SELECT  b.Id_Bando, 
            b.Id_Programmazione,  
            d.Id_Progetto, 
            d.Cod_Tipo, 
            pr.Tipo + ' ' + Pr.Codice         AS Azione,
            impr.Forma,
            -- ISNULL(SUM(q1.cRichiesto), 0)  AS Contributo_Richiesto_Totale,
            ISNULL(SUM(q1.Imp_Ammesso), 0)    AS Importo_Ammesso_Totale, 
            ISNULL(SUM(q2.cAmmissibile),0)    AS Contributo_Ammissibile_Totale, 
            ISNULL(SUM(q2.Spesa_Pubblica), 0) AS Contributo_Pagato_Totale
    FROM Domanda_Di_Pagamento d
         INNER JOIN ( SELECT Id_Domanda_Pagamento,
                             ISNULL(SUM(Contributo_Richiesto), 0) AS cRichiesto,
                             ISNULL(SUM(Importo_Ammesso), 0)      AS Imp_Ammesso 
                      FROM Pagamenti_Richiesti 
                      GROUP BY Id_Domanda_Pagamento
                    ) q1 ON d.Id_Domanda_Pagamento = q1.Id_Domanda_Pagamento
         LEFT JOIN ( -- unione tra aiuti di stato e contributi per enti pubblici.
                     SELECT Id_Domanda_Pagamento,
                            ISNULL(SUM(Importo_Ammissibile), 0) AS cAmmissibile,
                            ISNULL(SUM(Importo_Ammesso), 0)     AS Spesa_Pubblica
                     FROM Domanda_Di_Pagamento_Esportazione 
                     WHERE Id_Domanda_Pagamento NOT IN ( SELECT Id_Domanda_Pagamento 
                                                         FROM Domanda_Pagamento_Liquidazione )
                     GROUP BY Id_Domanda_Pagamento
                     UNION
                     SELECT e.Id_Domanda_Pagamento,
                            ISNULL(SUM(e.Importo_Ammissibile), 0) AS cAmmissibile,
                            ISNULL(SUM(l.Quietanza_Importo), 0)   AS Spesa_Pubblica
                     FROM Domanda_Di_Pagamento_Esportazione e 
                          INNER JOIN 
                          Domanda_Pagamento_Liquidazione L ON e.Id_Domanda_Pagamento = L.Id_Domanda_Pagamento 
                                                          AND l.Liquidato = 1 
                     GROUP BY E.Id_Domanda_Pagamento
                   ) q2 ON d.Id_Domanda_Pagamento = q2.Id_Domanda_Pagamento
         INNER JOIN 
         Progetto p ON d.Id_Progetto = p.Id_Progetto
         INNER JOIN 
         Bando b ON p.Id_Bando = b.Id_Bando
         INNER JOIN 
         vzProgrammazione AS pr ON b.Id_Programmazione = pr.Id
         LEFT JOIN
         CTE_TESTATA_VALIDAZIONE rdp ON d.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento
         LEFT JOIN
         Lotto_di_Revisione ldr ON rdp.Id_Lotto = ldr.Id_Lotto
         OUTER APPLY (SELECT TOP 1
                             imprSt.Id_Impresa,
                             LEFT(imprSt.Cod_Forma_Giuridica, 1) AS Forma
                      FROM Impresa_Storico imprSt 
                      WHERE imprSt.Id_Impresa = p.Id_Impresa
                      ORDER BY imprSt.Data_Inizio_Validita DESC
                     ) AS impr
    WHERE d.Segnatura IS NOT NULL 
      AND d.Annullata = 0 
      AND (d.Approvata IS NULL OR d.Approvata = 1)
      -- 14/12/2017 allineo con SpCertspSpeseBenediciariEPubbliche
      AND (@Data_Inizio IS NULL OR d.Data_Approvazione >  @Data_Inizio) 
      AND (@Data_Fine   IS NULL OR d.Data_Approvazione <= @Data_Fine)
      /* 
      AND ( -- Privato
            (     (@Data_Inizio IS NULL OR d.Data_Approvazione > @Data_Inizio)
              AND (@Data_Fine IS NULL OR d.Data_Approvazione < @Data_Fine) 
              AND impr.Forma = 1
            )
            OR
            -- Pubblico
            (     (@Data_Inizio IS NULL OR ldr.Data_Modifica > @Data_Inizio)
              AND (@Data_Fine IS NULL OR ldr.Data_Modifica < @Data_Fine) 
              AND impr.Forma = 2
              AND (ldr.Revisione_Conclusa IS NULL OR ldr.Revisione_Conclusa = 1)
            )
          )
      */
      AND (@Cod_Psr IS NULL OR pr.Cod_Psr = @Cod_Psr)
    GROUP BY b.Id_Bando, 
             b.Id_Programmazione,
             d.Id_Progetto,
             d.Cod_Tipo,
             pr.Tipo,
             pr.Codice,
             impr.Forma
), 

Dati_Appalto AS
(
    SELECT  b.Id_Bando, 
            p.Codice + '-' + p.Descrizione AS Tipo_Appalto
    FROM Bando_Config b
         INNER JOIN 
         Bando_Config_Tipo_Parametri p ON b.Valore   = p.Codice 
                                      AND b.Cod_Tipo = p.Cod_Tipo
    WHERE b.Cod_Tipo = 'TPAPPALTO' 
      AND b.Attivo = 1
)

SELECT  pr.Id,
        pr.Cod_Tipo,
        pr.Codice,
        pr.Descrizione,
        pr.Id_Padre,
        pr.Cod_Psr,
        pr.Tipo,
        pr.Livello,
        pr.Attivazione_Bandi,
        pr.Attivazione_Fa,
        pr.Attivazione_Ob_Misura,
        pr.Attivazione_Investimenti,
        pr.Attivazione_Ff, 
        dp.*,
        tdp.Descrizione     AS Tipo_Dompag, 
        da.Tipo_Appalto,
        CASE 
            WHEN da.Tipo_Appalto IS NULL THEN 0 
            ELSE b.Importo 
        END                 AS Importo_Appalto,
        CASE 
            WHEN da.Tipo_Appalto IS NULL THEN 0 
            ELSE dp.Contributo_Ammissibile_Totale 
        END                 AS Contributo_Ammissibile_Appalto,
        CASE 
            WHEN da.Tipo_Appalto IS NULL THEN '' 
            ELSE (SELECT TOP 1 
                         bp.Codice + '-' + bp.Descrizione
                  FROM Bando_Config bc
                       INNER JOIN 
                       Bando_Config_Tipo_Parametri bp ON bc.Valore   = bp.Codice 
                                                     AND bc.Cod_Tipo = bp.Cod_Tipo
                  WHERE bc.Cod_Tipo = 'TPPROCAGG' 
                    AND bc.Attivo   = 1 
                    AND bc.Id_Bando = dp.Id_Bando
                  ) 
        END             AS Tipo_Procagg_Appalto,
        CASE 
            WHEN da.Tipo_Appalto IS NULL THEN '' 
            ELSE im.Codice_Fiscale 
        END             AS Impresa_Appalto
FROM Domande_Presentate AS dp
	 INNER JOIN 
     Tipo_Domanda_Pagamento AS tdp ON dp.Cod_Tipo = tdp.Cod_Tipo
     INNER JOIN 
     vBando AS b ON dp.Id_Bando = b.Id_Bando
	 INNER JOIN 
     Progetto prg ON dp.Id_Progetto = prg.Id_Progetto
	 INNER JOIN 
     Impresa AS IM ON prg.Id_Impresa = IM.Id_Impresa
	 INNER JOIN 
     vzProgrammazione AS pr ON b.Id_Programmazione = pr.Id
	 LEFT OUTER JOIN 
     Dati_Appalto AS DA ON dp.Id_Bando = da.Id_Bando
ORDER BY dp.Azione, 
         prg.Id_Progetto
GO


