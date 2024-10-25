CREATE PROCEDURE [dbo].[ZFidejussioniGetById]
(
	@IdFidejussione INT
)
AS
	SELECT *
	FROM FIDEJUSSIONI
	WHERE 
		(ID_FIDEJUSSIONE = @IdFidejussione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFidejussioniGetById]
(
	@IdFidejussione INT
)
AS
	SELECT *
	FROM FIDEJUSSIONI
	WHERE 
		(ID_FIDEJUSSIONE = @IdFidejussione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFidejussioniGetById';

