CREATE FUNCTION [dbo].[fnCalcoloParametriDiRischioIr1] 
(
	@Id_Domanda_Pagamento   INT
)
RETURNS INT
AS
BEGIN
    -- Ritonra valore rischiosita': 1 Bassa, 2 Media, 3 Alta
    DECLARE @risk INT
    DECLARE @COD_FORMA_GIURIDICA    VARCHAR(10),
            @CF                     CHAR(11)
    
    SELECT  @COD_FORMA_GIURIDICA    = COD_FORMA_GIURIDICA,
            @CF                     = CUAA
    FROM vIMPRESA I 
         INNER JOIN 
         PROGETTO P ON I.ID_IMPRESA = P.ID_IMPRESA
         INNER JOIN 
         DOMANDA_DI_PAGAMENTO D ON P.ID_PROGETTO = D.ID_PROGETTO
    WHERE D.ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO

    -- ente Regione Marche
    IF @CF = '80008630420' 
    BEGIN
        SET @risk = 1
    END
    -- altri enti pubblici
    ELSE IF SUBSTRING(ISNULL(@COD_FORMA_GIURIDICA,''), 1, 1) = '2' 
    BEGIN
        SET @risk =  2 
    END
    ELSE 
    BEGIN
        SET @risk =  3
    END
    
    RETURN (@risk);

END
