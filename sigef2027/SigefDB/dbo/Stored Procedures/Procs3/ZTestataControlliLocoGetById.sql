CREATE PROCEDURE [dbo].[ZTestataControlliLocoGetById]
(
	@IdTestata INT
)
AS
	SELECT *
	FROM VTESTATA_CONTROLLI_LOCO
	WHERE 
		(ID_TESTATA = @IdTestata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTestataControlliLocoGetById';

