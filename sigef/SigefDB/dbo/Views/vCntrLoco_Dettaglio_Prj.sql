
CREATE VIEW [dbo].[vCntrLoco_Dettaglio_Prj]
AS
SELECT  0   AS IdLoco_Dettaglio,
        d.IdLoco,
        0                                   AS Id_Domanda_Pagamento,
        d.Id_Progetto,
        d.Asse,
        d.Selezionata,
        d.Esito,
        d.DataEsito,
        d.CostoTotale,
        d.ImportoAmmesso,
        MAX(d.ImportoConcesso)              AS ImportoConcesso,
        d.NrOperazioniB,
        d.Beneficiario,
        SUM(d.SpesaAmmessa)                 AS SpesaAmmessa,
        MAX(d.ImportoContributoPubblico)    AS ImportoContributoPubblico,
        d.SpesaAmmessa_Incrementale         AS SpesaAmmessa_Incrementale,
        SUM(d.ImportoContributoPubblico_Incrementale)   AS ImportoContributoPubblico_Incrementale,
        d.Esclusione,
        MAX(d.RischioIR)                    AS RischioIR,
        MAX(d.RischioCR)                    AS RischioCR,
        MAX(d.RischioComp)                  AS RischioComp,
        MAX(d.Operatore)                    AS Operatore,
        MAX(d.DataInserimento)              AS DataInserimento,
        MAX(d.DataModifica)                 AS DataModifica,
        d.Azione,
        d.Intervento,
        t.CodPsr,
        t.DataFine,
        t.Definitivo,
        --cr.Codice_Cup,
        p.COD_AGEA AS Codice_Cup,
        cn.Cod_Cup_Natura                   AS Cup_Natura_Codice,
        cn.Descrizione                      AS Cup_Natura_Descrizione,
        dbo.fnProgettoTitolo(d.Id_Progetto) AS TitoloProgetto,
        NULL                                AS TipoDomanda
FROM dbo.CntrLoco_Testa t
     INNER JOIN
     dbo.CntrLoco_Dettaglio d ON t.IdLoco = d.IdLoco
     LEFT JOIN
     dbo.Cup_Richieste cr ON d.Id_Progetto = cr.Id_Progetto
                         AND cr.Esito_Elaborazione_Cup = 'OK'
     LEFT JOIN
     dbo.Dati_Monitoraggio_Fesr dm ON d.Id_Progetto = dm.Id_Progetto
     LEFT JOIN
     dbo.Tipo_Cup_Natura cn ON dm.Cup_Natura = cn.Cod_Cup_Natura
     INNER JOIN 
     vPROGETTO p on d.Id_Progetto = p.ID_PROGETTO
GROUP BY    d.IdLoco,
            d.Id_Progetto,
            d.Asse,
            d.Selezionata,
            d.Esito,
            d.DataEsito,
            d.CostoTotale,
            d.ImportoAmmesso,
            d.NrOperazioniB,
            d.Beneficiario,
            d.SpesaAmmessa_Incrementale,
            d.Esclusione,
            d.Azione,
            d.Intervento,
            t.CodPsr,
            t.DataFine,
            t.Definitivo,
            --cr.Codice_Cup,
            p.COD_AGEA,
            cn.Cod_Cup_Natura,
            cn.Descrizione,
            dbo.fnProgettoTitolo(d.Id_Progetto)
