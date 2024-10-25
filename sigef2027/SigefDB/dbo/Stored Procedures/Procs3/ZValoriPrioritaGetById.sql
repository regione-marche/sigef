CREATE PROCEDURE [dbo].[ZValoriPrioritaGetById]
(
	@IdValore INT
)
AS
	SELECT *
	FROM VALORI_PRIORITA
	WHERE 
		(ID_VALORE = @IdValore)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZValoriPrioritaGetById]
(
	@IdValore INT
)
AS
	SELECT *
	FROM VALORI_PRIORITA
	WHERE 
		(ID_VALORE = @IdValore)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZValoriPrioritaGetById';

