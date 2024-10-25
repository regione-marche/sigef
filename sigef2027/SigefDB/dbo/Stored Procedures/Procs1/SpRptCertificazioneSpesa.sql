CREATE PROCEDURE [dbo].[SpRptCertificazioneSpesa]
(	
    @DataFinale DATETIME,
    @DataLotto  DATETIME,
    @Filtro     VARCHAR(50) = NULL
) 
AS
DECLARE @CodPsr VARCHAR(8000);
SET @CodPsr = 'POR20142020';

/*
DECLARE @DataFinale DATETIME;
DECLARE @DataLotto DATETIME;
DECLARE @Filtro VARCHAR(50);

SET @DataFinale = '20170630';
SET @DataLotto  = '20180630';
SET @Filtro = NULL;
*/

WITH cte AS (
SELECT d.*,
        p.Data_Approvazione,
        ROW_NUMBER() OVER(PARTITION BY d.Id_Progetto ORDER BY p.Data_Approvazione DESC, d.Id_Domanda_Pagamento DESC, d.DataFine DESC) AS [r]
FROM vCertSp_Dettaglio d
        INNER JOIN
        Domanda_di_Pagamento p ON d.Id_Domanda_Pagamento = p.Id_Domanda_Pagamento
WHERE d.DataFine >  @DataFinale
  AND d.DataFine <= @DataLotto
  AND d.CodPsr   =  @CodPsr
)

SELECT  Asse,
        Azione,
        Intervento,
        Id_Bando                    AS Bando, 
        Id_Progetto                 AS 'Id Progetto', 
        Codice_Cup                  AS 'Codice CUP', 
        Cup_Natura_Descrizione      AS 'Tipo Operazione', 
        Beneficiario, 
        CostoTotale                 AS 'Costo investimento ammesso', 
        ImportoAmmesso              AS 'Contributo concesso', 
        ImportoConcesso             AS 'Importo rendicontato ammesso (totale periodo contabile)', 
        ImportoContributoPubblico   AS 'Contributo rendicontato concesso (totale periodo contabile)', 
        QuotaUe                     AS Ue, 
        QuotaStato                  AS Stato, 
        QuotaRegione                AS Regione, 
        QuotaPrivato                AS 'Quota a carico del privato', 
        CASE 
            WHEN Selezionata = 1 THEN 'Sì'
            ELSE 'No'
        END                         AS Selezionata
FROM Cte
WHERE r = 1
  AND ( 1 = CASE 
                WHEN @Filtro IS NULL                        THEN 1
                WHEN @Filtro = 1                            THEN 1 --Tutti
                WHEN @Filtro = 2  AND selezionata = 1       THEN 1 --SelezionateSi
                WHEN @Filtro = 3  AND selezionata = 0       THEN 1 --SelezionateNo
                WHEN @Filtro = 4  AND Id_File IS NOT NULL   THEN 1 --ChecklistSi
                WHEN @Filtro = 5  AND Id_File IS NULL       THEN 1 --ChecklistNo
                WHEN @Filtro = 6  AND Asse = 1              THEN 1 --Asse1
                WHEN @Filtro = 7  AND Asse = 2              THEN 1 --Asse2
                WHEN @Filtro = 8  AND Asse = 3              THEN 1 --Asse3
                WHEN @Filtro = 9  AND Asse = 4              THEN 1 --Asse4
                WHEN @Filtro = 10 AND Asse = 5              THEN 1 --Asse5
                WHEN @Filtro = 11 AND Asse = 6              THEN 1 --Asse6
                WHEN @Filtro = 12 AND Asse = 7              THEN 1 --Asse7
            END)
ORDER BY Id_Progetto