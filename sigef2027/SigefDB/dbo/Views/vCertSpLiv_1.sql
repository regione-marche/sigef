/*
    USE SigefSviluppo
    USE SigefTest
    USE SigefProduzione
*/
/*
    Carico tutte le domande, le esclusioni (es. Asse 7) vengono fatte dall'applicativo in fase di 
    selezione.
    I dati necessari per decidere se includere o escludere una domanda di pagamento sono riportati
    in colonna.
*/
CREATE VIEW vCertSpLiv_1
AS

WITH EROGAZIONI_DETTAGLI AS (
SELECT ER.ID_EROGAZIONE,
	ER.ID_DOMANDA_PAGAMENTO,
	SUM(ISNULL(PAG.IMPORTO_AMMESSO, 0)) AS SOMMA_PAGAMENTI_AMMESSI_SINGOLA_EROGAZIONE,
	SOMMA_DECRETI_AMMESSI
FROM VEROGAZIONE_FEM ER
	LEFT JOIN VCONTRATTI_FEM_PAGAMENTI PAG ON PAG.ID_EROGAZIONE_FEM = ER.ID_EROGAZIONE
WHERE ER.DEFINITIVO = 1
GROUP BY ER.ID_EROGAZIONE, ER.ID_DOMANDA_PAGAMENTO, ER.SOMMA_DECRETI_AMMESSI
)

SELECT  bprm.Cod_Psr,
        d.Id_Domanda_Pagamento,
        d.Data_Approvazione,
        rdp.Data_Validazione                        AS Data_VerDocum,
        asse.Codice                                 AS Asse_Codice,
        prt.Id_Bando,
        ti.Codice                                   AS Intervento,
        azione.CODICE                               AS Azione,
        prt.Id_Progetto,
        DMF.CUP_NATURA                              AS Tipo_Operazione,
        dbo.fnProgettoTitolo(prt.Id_Progetto)       AS Descrizione,
        prt.Stato                                   AS Stato,
        NULL                                        AS Comune,
        dbo.calcoloCostoTotaleProgetto(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione))
                                                    AS Costo_Totale,                    -- Calcolato a livello di progetto
        dbo.calcoloContributoTotaleProgetto(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione)) + 
            ISNULL(dbo.calcoloPremioContoCapitale(d.Id_Progetto, 1, dbo.fnIdVariante(prt.Id_Progetto, rdp.Data_Validazione)), 0) 
                                                    AS Importo_Ammesso,                 -- Calcolato a livello di progetto    

        dbo.fnContaProgettiDomanda(imp.Id_Impresa)  AS Operazioni_Beneficiario,
        NULL                                        AS Contributo_Richiesto,
        imp.Ragione_Sociale                         AS Beneficiario,
        pric.ImpAmmesso_tot                         AS Spesa_Ammessa,
        PrjT.CostoInvestimentoRichiesto             AS Spesa_Ammessa_Incrementale,
        dpe.Importo_Ammesso                         AS Importo_Contributo_Pubblico_Incrementale,
        NULL                                        AS Importo_Liquidato,
        NULL                                        AS Operazione_Esclusa,
        NULL                                        AS Motivo_Esclusione,
        dbo.fnCalcoloParametriDiRischioIR(d.Id_Domanda_Pagamento)
                                                    AS RischioIR,
        dbo.fnCalcoloParametriDiRischioCR(d.Id_Domanda_Pagamento)
                                                    AS RischioCR,
        CASE 
            -- Rischio Basso
            WHEN (  dbo.fnCalcoloParametriDiRischioIR(d.Id_Domanda_Pagamento) 
                    * 
                    dbo.fnCalcoloParametriDiRischioCR(d.Id_Domanda_Pagamento)
                 ) < 0.17 THEN 'Bassa'
            -- Rischio Medio
            WHEN (( dbo.fnCalcoloParametriDiRischioIR(d.Id_Domanda_Pagamento) 
                    * 
                    dbo.fnCalcoloParametriDiRischioCR(d.Id_Domanda_Pagamento) >= 0.17
                  )
                  AND
                  (dbo.fnCalcoloParametriDiRischioIR(d.Id_Domanda_Pagamento) 
                   * 
                   dbo.fnCalcoloParametriDiRischioCR(d.Id_Domanda_Pagamento) < 0.65)
                  ) THEN 'Media'
            -- Rischio Alto
            WHEN dbo.fnCalcoloParametriDiRischioIR(d.Id_Domanda_Pagamento) 
                 * 
                 dbo.fnCalcoloParametriDiRischioCR(d.Id_Domanda_Pagamento) >= 0.65 THEN 'Alta'
        END                                         AS Rischio,
        d.Cod_Tipo                                  AS Domanda_Tipo
FROM vDomanda_di_Pagamento d
     -- Verifica documentale 1o livello
     INNER JOIN -- 20/01/2020 : sostituito Revisione_Domanda_Pagamento con CTE_TESTATA_VALIDAZIONE
     CTE_TESTATA_VALIDAZIONE rdp ON d.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento
     -- Verifica in loco 2o livello
     LEFT JOIN
     CntrLoco_Dettaglio cld ON d.Id_Domanda_Pagamento = cld.Id_Domanda_Pagamento      
     -- Bando e Programmazione
     INNER JOIN
     vProgetto prt ON d.Id_Progetto = prt.Id_Progetto
     LEFT JOIN
        vBando_Programmazione bprm ON prt.Id_Bando = bprm.Id_Bando
                                  AND Id_Programmazione NOT IN (17, 18, 19)
        INNER JOIN
        zProgrammazione ti ON bprm.Id_Programmazione = ti.id
        INNER JOIN
        zProgrammazione azione ON ti.Id_Padre = azione.Id
        INNER JOIN
        zProgrammazione asse ON azione.Id_Padre = asse.Id
     -- Beneficiario
     INNER JOIN     
     vImpresa imp ON prt.Id_Impresa = imp.Id_Impresa
     INNER JOIN
     DATI_MONITORAGGIO_FESR DMF ON DMF.ID_PROGETTO = PRT.ID_PROGETTO
     -- Importi domanda pagamento per domanda pagamento
     LEFT JOIN
     Domanda_di_Pagamento_Esportazione dpe ON d.Id_Domanda_Pagamento = dpe.Id_Domanda_Pagamento
     -- Importo ammesso
     LEFT JOIN
     (SELECT 
			DOM.ID_DOMANDA_PAGAMENTO, 
			CASE 
				WHEN COUNT(BC.ID) > 0 AND DOM.COD_TIPO = 'ANT'
					THEN SUM(ED.SOMMA_DECRETI_AMMESSI)
				WHEN COUNT(BC.ID) > 0
					THEN SUM(ISNULL(PRF.IMPORTO_AMMESSO, SOMMA_PAGAMENTI_AMMESSI_SINGOLA_EROGAZIONE))
				ELSE SUM(PR.IMPORTO_AMMESSO)
			END AS ImpAmmesso_tot,
			CASE 
				WHEN COUNT(BC.ID) > 0 AND DOM.COD_TIPO = 'ANT'
					THEN SUM(ED.SOMMA_DECRETI_AMMESSI)
				WHEN COUNT(BC.ID) > 0
					THEN SUM(ISNULL(PRF.IMPORTO_RICHIESTO, SOMMA_PAGAMENTI_AMMESSI_SINGOLA_EROGAZIONE))
				ELSE SUM(PR.IMPORTO_RICHIESTO)
			END AS ImpRichiesto_tot,
			CASE 
				WHEN COUNT(BC.ID) > 0 AND DOM.COD_TIPO = 'ANT'
					THEN SUM(ED.SOMMA_DECRETI_AMMESSI)
				WHEN COUNT(BC.ID) > 0
					THEN SUM(ISNULL(PRF.IMPORTO_RICHIESTO, SOMMA_PAGAMENTI_AMMESSI_SINGOLA_EROGAZIONE))
				ELSE SUM(PR.CONTRIBUTO_RICHIESTO)
			END AS ConRichiesto_tot
		FROM DOMANDA_DI_PAGAMENTO DOM 
			JOIN PROGETTO PROG 
				ON PROG.ID_PROGETTO = DOM.ID_PROGETTO
			LEFT JOIN VBANDO_CONFIG BC 
				ON PROG.ID_BANDO = BC.ID_BANDO AND BC.COD_TIPO = 'TPAPPALTO'
					AND BC.ATTIVO = 1 AND BC.VALORE_DESCRIZIONE = 'Strumenti finanziari'
			LEFT JOIN PAGAMENTI_RICHIESTI_FEM PRF ON DOM.ID_DOMANDA_PAGAMENTO = PRF.ID_DOMANDA_PAGAMENTO
			LEFT JOIN PAGAMENTI_RICHIESTI PR ON DOM.ID_DOMANDA_PAGAMENTO = PR.ID_DOMANDA_PAGAMENTO
			LEFT JOIN EROGAZIONI_DETTAGLI ED ON DOM.ID_DOMANDA_PAGAMENTO = ED.ID_DOMANDA_PAGAMENTO
		GROUP BY DOM.ID_DOMANDA_PAGAMENTO, DOM.COD_TIPO
      ) AS pric ON d.Id_Domanda_Pagamento = pric.Id_Domanda_Pagamento
      LEFT JOIN
      (
        SELECT  Id_Progetto,
                SUM(Costo_Investimento) AS CostoInvestimentoRichiesto
        FROM Piano_Investimenti
        WHERE Id_Investimento_Originale IS NULL
        GROUP BY Id_Progetto
      ) AS PrjT ON d.Id_Progetto = PrjT.Id_Progetto
WHERE -- Domanda di pagamento approvata
      d.Segnatura IS NOT NULL
  AND d.Annullata = 'FALSE'
  -- Verifica 1o livello documentale ok  
  -- Nota: il controllo fatto così fa il bypass di Selezionata_x_Revisione / Lotto_di_Revisione
  AND rdp.Approvata = 1
  -- Verifica 1o livello in loco: non deve essere presente
  AND cld.IdLoco_Dettaglio IS NULL

GO