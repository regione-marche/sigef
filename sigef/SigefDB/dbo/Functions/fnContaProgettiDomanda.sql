CREATE FUNCTION fnContaProgettiDomanda
(
	@Id_Impresa   INT
)
RETURNS INT
AS
BEGIN
    DECLARE @ret INT = 0,
            @con INT;
    
    SELECT @con = COUNT(DISTINCT Progetto.Id_Progetto)
    FROM Progetto
		JOIN (SELECT DISTINCT d.Id_Progetto
				 FROM vDomanda_di_Pagamento d
					--JOIN CTE_TESTATA_VALIDAZIONE r  ON d.Id_Domanda_Pagamento = r.Id_Domanda_Pagamento
				 WHERE 1 = 1
					AND d.Segnatura IS NOT NULL
					AND d.Annullata = 'FALSE'
				) AS t1  ON Progetto.Id_Progetto = t1.Id_Progetto
         JOIN vBando_Programmazione ON Progetto.Id_Bando = vBando_Programmazione.Id_Bando
    WHERE 1 = 1
		AND Progetto.Id_Impresa = @Id_Impresa
		AND vBando_Programmazione.Cod_Psr = 'POR20142020'     

    IF @con IS NOT NULL
    BEGIN
        SET @ret = @con
    END

    RETURN (@ret);
END
GO


