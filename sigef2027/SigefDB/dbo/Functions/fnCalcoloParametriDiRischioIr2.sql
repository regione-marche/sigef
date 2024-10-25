CREATE FUNCTION [dbo].[fnCalcoloParametriDiRischioIr2] 
(
	@Id_Domanda_Pagamento   INT
)
RETURNS INT
AS
BEGIN
    -- Ritorna valore di rischiosita': 1 Bassa, 2 Media, 3 Alta
    DECLARE @risk INT
    
    DECLARE @COD_FORMA_GIURIDICA    VARCHAR(10),
        @CF                     CHAR(11),
        @ID_BANDO               INT

    SELECT  @COD_FORMA_GIURIDICA    = COD_FORMA_GIURIDICA,
            @CF                     = CUAA,
            @ID_BANDO               = P.ID_BANDO
    FROM vIMPRESA I 
         INNER JOIN 
         PROGETTO P ON I.ID_IMPRESA = P.ID_IMPRESA
         INNER JOIN 
         DOMANDA_DI_PAGAMENTO D ON P.ID_PROGETTO = D.ID_PROGETTO
    WHERE D.ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

    -- ente Regione Marche con Appalto
    IF @CF = '80008630420'
       AND
       (   SELECT  COUNT(*) 
           FROM    BANDO_CONFIG 
           WHERE ID_BANDO  = @ID_BANDO 
               AND COD_TIPO  = 'TPAPPALTO' 
               AND ATTIVO    = 1 
               AND VALORE    IN ('01','02', '03')
       ) > 0    
    BEGIN 
        SET @risk = 1 
    END
    -- ente Regione Marche senza Appalto
    ELSE IF @CF = '80008630420'
    BEGIN
        SET @risk = 2
    END
    -- altri enti pubblici individuati NON con Procedura Diretta
    ELSE IF SUBSTRING(ISNULL(@COD_FORMA_GIURIDICA, ''), 1, 1) = '2' 
            AND 
            (   SELECT  COUNT(*) 
                FROM    BANDO_CONFIG 
                WHERE ID_BANDO  = @ID_BANDO 
                  AND COD_TIPO  = 'TPPROCATT' 
                  AND ATTIVO    = 1 
                  AND VALORE    IN ('5','6')
            ) = 0 
    BEGIN
        SET @risk = 2
    END
    -- altri enti pubblici individuati CON Procedura Diretta
    -- impresa o alto privato
    ELSE 
    BEGIN
        SET @risk = 3
    END
    
    RETURN (@risk);
END
