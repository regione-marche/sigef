CREATE FUNCTION [dbo].[fnCalcoloParametriDiRischioCr]
(
	@Id_Domanda_Pagamento   INT
)
RETURNS DECIMAL(5, 2)
AS
BEGIN
    DECLARE @risk DECIMAL(5, 2)
    
    -- Ritorna valore di rischiosita': 0,17 Bassa; 0,28 Media; 1 Alta
    DECLARE @Bassa  DECIMAL(5, 2)   = 0.17,
            @Media  DECIMAL(5, 2)   = 0.28,
            @Alta   DECIMAL(5, 2)   = 1

    DECLARE @Amme   DECIMAL(18, 2),         -- Importo Ammesso
            @NAmm   DECIMAL(18, 2),         -- Importo Non Ammesso
            @Rend   DECIMAL(18, 2),         -- Importo Rendicontato
            @Perc   INT

    SELECT  @Rend = ISNULL(SUM(dpe.Importo_Ammissibile), 0),   -- Importo finanziario della spesa rendicontata
            @Amme = ISNULL(SUM(dpe.Importo_Ammesso), 0)        -- Importo finanziario della spesa ammessa
    FROM vRevisione_DPagamento_Esito rdp
         INNER JOIN
         Domanda_di_Pagamento_Esportazione dpe ON rdp.Id_Domanda_pagamento = dpe.Id_Domanda_Pagamento
    WHERE rdp.Esito_Positivo = 'FALSE'
      AND rdp.Id_Domanda_Pagamento = @Id_Domanda_Pagamento
    
    -- Importo finanziario della spesa non ammessa
    SET @NAmm = @Rend - @Amme;

    -- Calcolo percentuale
    IF @Rend = 0
    BEGIN
        SET @Perc = 0;
    END
    ELSE
    BEGIN
        SET @Perc = ((@NAmm * 100) / @Rend);
    END

    IF @Perc > 30
    BEGIN
        SET @risk = @Alta;
    END
    ELSE IF @Perc <= 30 AND @Perc > 10
    BEGIN
        SET @risk = @Media;
    END
    ELSE IF @Perc <= 10
    BEGIN
        SET @risk = @Bassa;
    END

    RETURN (@risk);
END
