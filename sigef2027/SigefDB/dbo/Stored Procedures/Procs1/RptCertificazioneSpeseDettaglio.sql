CREATE PROCEDURE dbo.RptCertificazioneSpeseDettaglio
(
    @DataFine   DATETIME,
    @DataLotto  DATETIME
)
AS

DECLARE @CodPsr VARCHAR(15);
SET @CodPsr = 'POR20142020';

/*
-- Inizio "solo per test"
DECLARE @DataFine   DATETIME;
DECLARE @DataLotto  DATETIME;
SET @DataFine  = '20170630';
SET @DataLotto = '20180630';
-- Fine "solo per test"
*/

SELECT  Asse,
        Id_Progetto,
        Codice_Cup,
        Beneficiario,
        Id_Domanda_Pagamento,
        ImportoContributoPubblico_Incrementale  AS ImportoContributo,
        SpesaAmmessa                            AS ImportoRendicontato
FROM vCertSp_Dettaglio
WHERE DataFine      >  @DataFine
    AND DataFine    <= @DataLotto
    AND Definitivo  =  'TRUE'
    AND Selezionata =  'TRUE'
    AND CodPsr      =  @CodPsr
ORDER BY Id_Progetto,
         Id_Domanda_Pagamento