CREATE PROCEDURE [dbo].[ZTestataControlliLocoDelete]
(
	@IdTestata INT
)
AS
	DELETE TESTATA_CONTROLLI_LOCO
	WHERE 
		(ID_TESTATA = @IdTestata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoDelete';

