CREATE PROCEDURE [dbo].[ZRataDelete]
(
	@IdRata INT
)
AS
	DELETE RATA
	WHERE 
		(ID_RATA = @IdRata)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRataDelete';

