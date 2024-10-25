CREATE VIEW [dbo].[vCertSp_Dettaglio]
AS
SELECT  d.IdCertSp_Dettaglio,
        d.IdCertSp,
        d.Id_Domanda_Pagamento,
        d.Id_Progetto,
        d.Asse,
        d.Selezionata,
        d.Esito,
        d.DataEsito,
        d.Id_File,
        d.CostoTotale,
        d.ImportoAmmesso,
        d.ImportoConcesso,
        d.Beneficiario,
        d.SpesaAmmessa,
        d.ImportoContributoPubblico,
        d.SpesaAmmessa_Incrementale,
        d.ImportoContributoPubblico_Incrementale,
        d.Note,
        d.Operatore,
        d.DataInserimento,
        d.DataModifica,
        d.QuotaUe,
        d.QuotaStato,
        d.QuotaRegione,
        d.QuotaPrivato,
        t.CodPsr,
        t.DataFine,
        t.Definitivo,
        t.Tipo,
        prt.COD_AGEA AS Codice_Cup,
        cn.Cod_Cup_Natura   AS Cup_Natura_Codice,
        cn.Descrizione      AS Cup_Natura_Descrizione,
        -- dbo.fnProgettoTitolo(d.Id_Progetto) AS TitoloProgetto,
        NULL                AS TitoloProgetto,
        ddp.Cod_Tipo        AS TipoDomanda,
        azione.Codice       AS Azione,
        ti.Codice           AS Intervento,
        prt.Id_Bando
FROM dbo.CertSp_Testa t
     INNER JOIN
     dbo.CertSp_Dettaglio d ON t.IdCertSp = d.IdCertSp
     INNER JOIN
     dbo.vProgetto prt ON d.Id_Progetto = prt.Id_Progetto
     LEFT JOIN
        dbo.vBando_Programmazione bprm ON prt.Id_Bando = bprm.Id_Bando
                                      AND Id_Programmazione NOT IN (17, 18, 19)
        INNER JOIN
        dbo.zProgrammazione ti ON bprm.Id_Programmazione = ti.id
        INNER JOIN
        dbo.zProgrammazione azione ON ti.Id_Padre = azione.Id
        INNER JOIN
        dbo.zProgrammazione asse ON azione.Id_Padre = asse.Id
    LEFT JOIN
    dbo.Dati_Monitoraggio_Fesr dm ON d.Id_Progetto = dm.Id_Progetto
        LEFT JOIN
        dbo.Tipo_Cup_Natura cn ON dm.Cup_Natura = cn.Cod_Cup_Natura
    INNER JOIN
    dbo.Domanda_di_Pagamento ddp ON d.Id_Domanda_Pagamento = ddp.Id_Domanda_Pagamento

