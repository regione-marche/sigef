CREATE FUNCTION [dbo].[fnIdVariante]
(
	@IdProgetto    INT,
	@DataModifica  DATETIME
)
RETURNS INT
AS
BEGIN
    DECLARE @IdVariante INT
    SET @IdVariante = NULL
    
    /*
    -- Test del codice
    DECLARE @IdProgetto     INT
    DECLARE	@DataModifica   DATETIME
    SET @IdProgetto     = 12013
    SET	@DataModifica   = '20180704'
    --
    */
    
    SELECT @IdVariante = MAX(Id_Variante) 
    FROM Varianti 
    WHERE Id_Progetto   = @IdProgetto
      AND Approvata     = 1 
      AND Annullata     = 0
      AND Data_Modifica < @DataModifica

    -- Test del codice
    -- SELECT @IdVariante
    
    RETURN @IdVariante
END