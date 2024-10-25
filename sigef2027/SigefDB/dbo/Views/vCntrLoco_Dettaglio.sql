
CREATE VIEW [dbo].[vCntrLoco_Dettaglio]
AS
SELECT  d.IdLoco_Dettaglio,
        d.IdLoco,
        d.Id_Domanda_Pagamento,
        d.Id_Progetto,
        d.Asse,
        d.Selezionata,
        d.Esito,
        d.DataEsito,
        d.CostoTotale,
        d.ImportoAmmesso,
        d.ImportoConcesso,
        d.NrOperazioniB,
        d.Beneficiario,
        d.SpesaAmmessa,
        d.ImportoContributoPubblico,
        d.SpesaAmmessa_Incrementale,
        d.ImportoContributoPubblico_Incrementale,
        d.Esclusione,
        d.RischioIR,
        d.RischioCR,
        d.RischioComp,
        d.Operatore,
        d.DataInserimento,
        d.DataModifica,
        d.Azione,
        d.Intervento,
        t.CodPsr,
        t.DataFine,
        t.Definitivo,
        --cr.Codice_Cup,
        p.COD_AGEA AS Codice_Cup,
        cn.Cod_Cup_Natura   AS Cup_Natura_Codice,
        cn.Descrizione      AS Cup_Natura_Descrizione,
        dbo.fnProgettoTitolo(d.Id_Progetto) AS TitoloProgetto,
        ddp.Cod_Tipo        AS TipoDomanda
FROM    dbo.CntrLoco_Testa t
        INNER JOIN
        dbo.CntrLoco_Dettaglio d ON t.IdLoco = d.IdLoco
        --LEFT JOIN
        --dbo.Cup_Richieste cr ON d.Id_Progetto = cr.Id_Progetto
        --                AND cr.Esito_Elaborazione_Cup = 'OK'
        LEFT JOIN
        dbo.Dati_Monitoraggio_Fesr dm ON d.Id_Progetto = dm.Id_Progetto
            LEFT JOIN
            dbo.Tipo_Cup_Natura cn ON dm.Cup_Natura = cn.Cod_Cup_Natura
        INNER JOIN
        dbo.Domanda_di_Pagamento ddp ON d.Id_Domanda_Pagamento = ddp.Id_Domanda_Pagamento
        INNER JOIN 
        vPROGETTO p on d.Id_Progetto = p.ID_PROGETTO

