CREATE VIEW [dbo].[vCertSp_Dettaglio_Data]
AS
SELECT  0                                       AS IdCertSp_Dettaglio,
        0                                       AS IdCertSp,
        0                                       AS Id_Domanda_Pagamento,
        d.Id_Progetto,
        d.Asse,
        d.Selezionata,
        d.Esito,
        d.DataEsito,
        MAX(d.Id_File)                          AS Id_File,
        d.CostoTotale,
        d.ImportoAmmesso,
        MAX(d.ImportoConcesso)                  AS ImportoConcesso,
        d.Beneficiario,
        SUM(d.SpesaAmmessa)                     AS SpesaAmmessa,
        MAX(d.ImportoContributoPubblico)        AS ImportoContributoPubblico,
        d.SpesaAmmessa_Incrementale             AS SpesaAmmessa_Incrementale,
        SUM(d.ImportoContributoPubblico_Incrementale)   AS ImportoContributoPubblico_Incrementale,
        MAX(d.Note)                             AS Note,
        MAX(d.Operatore)                        AS Operatore,
        MAX(d.DataInserimento)                  AS DataInserimento,
        MAX(d.DataModifica)                     AS DataModifica,
        MAX(d.QuotaUe)                          AS QuotaUe,
        MAX(d.QuotaStato)                       AS QuotaStato,
        MAX(d.QuotaRegione)                     AS QuotaRegione,
        MAX(d.QuotaPrivato)                     AS QuotaPrivato,
        t.CodPsr,
        t.DataFine,
        t.Definitivo,
        t.Tipo,
        prt.COD_AGEA                            AS Codice_Cup,
        cn.Cod_Cup_Natura                       AS Cup_Natura_Codice,
        cn.Descrizione                          AS Cup_Natura_Descrizione,
        -- dbo.fnProgettoTitolo(d.Id_Progetto)     AS TitoloProgetto,
        NULL                                    AS TitoloProgetto,
        NULL                                    AS TipoDomanda,
        azione.Codice                           AS Azione,
        ti.Codice                               AS Intervento,
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
GROUP BY    d.Id_Progetto,
            d.Asse,
            d.Selezionata,
            d.Esito,
            d.DataEsito,
            d.CostoTotale,
            d.ImportoAmmesso,
            d.Beneficiario,
            d.SpesaAmmessa_Incrementale,
            t.CodPsr,
            t.DataFine,
            t.Definitivo,
            t.Tipo,
            prt.COD_AGEA,
            cn.Cod_Cup_Natura,
            cn.Descrizione,
            -- dbo.fnProgettoTitolo(d.Id_Progetto),
            azione.Codice,
            ti.Codice,
            prt.Id_Bando
