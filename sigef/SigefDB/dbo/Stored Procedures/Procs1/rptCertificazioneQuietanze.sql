CREATE PROCEDURE dbo.rptCertificazioneQuietanze
(
    @DataInizio DATE,
    @DataFine   DATE
)
AS

SELECT crt.CodPsr,
       crt.IdCertSp,
       crd.Asse,
       crd.Id_Progetto,
       crd.Id_Domanda_Pagamento,
       rdp.Data_Validazione AS DomandaPagamento_Data,
       liq.Quietanza_Importo,
       liq.Quietanza_Data
FROM CertSp_Testa AS crt
     INNER JOIN
     CertSp_Dettaglio AS crd ON crt.IdCertSp = crd.IdCertSp
        INNER JOIN
        Domanda_Pagamento_Liquidazione AS liq ON crd.Id_Domanda_Pagamento = liq.Id_Domanda_Pagamento
        INNER JOIN 
        CTE_TESTATA_VALIDAZIONE AS rdp ON crd.Id_Domanda_Pagamento = rdp.Id_Domanda_Pagamento
WHERE 1 = 1
  AND liq.Liquidato   = 'TRUE'
  AND CAST(rdp.Data_Validazione AS Date) >= @DataInizio
  AND CAST(rdp.Data_Validazione AS Date) <= @DataFine
  AND crd.Selezionata = 'TRUE'
GO


