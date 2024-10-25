CREATE FUNCTION [dbo].[fnCalcoloParametriDiRischioIr3] 
(
	@Id_Domanda_Pagamento   INT
)
RETURNS INT
AS
BEGIN
    DECLARE @risk INT
    -- Ritorna valore di rischiosita': 1 Bassa, 2 Media, 3 Alta
    DECLARE @NR_PROGETTI_FINANZIATI INT = 0

    /*SELECT @NR_PROGETTI_FINANZIATI  = COUNT(*) 
    FROM vPROGETTO P 
         INNER JOIN 
         PROGETTO P2 ON P.ID_IMPRESA = P2.ID_IMPRESA
         INNER JOIN 
         DOMANDA_DI_PAGAMENTO D ON P2.ID_PROGETTO = D.ID_PROGETTO
    WHERE D.ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO 
      AND P.ORDINE_FASE          > 3 
      AND ORDINE_STATO           = 1*/

    SELECT @NR_PROGETTI_FINANZIATI = dbo.fnContaProgettiDomanda(Progetto.Id_Impresa)
    FROM Domanda_di_Pagamento
         INNER JOIN
         Progetto ON Domanda_di_Pagamento.Id_Progetto = Progetto.Id_Progetto
    WHERE Domanda_di_Pagamento.Id_Domanda_Pagamento = @Id_Domanda_Pagamento

    -- 4 o piu' progetti finanziati
    IF @NR_PROGETTI_FINANZIATI > 3 
    BEGIN
        SET @risk = 3
    END
    -- 2 o 3 progetti finanziati
    ELSE IF @NR_PROGETTI_FINANZIATI > 1 
    BEGIN
        SET @risk = 2
    END
    -- 1 progetto finanziato
    ELSE 
    BEGIN
        SET @risk = 1
    END
    
    
    RETURN (@risk);
END
