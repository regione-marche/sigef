CREATE PROCEDURE [dbo].[ZVoceGenericaGetById]
(
	@IdVoceGenerica INT
)
AS
	SELECT *
	FROM VVOCE_GENERICA
	WHERE 
		(ID_VOCE_GENERICA = @IdVoceGenerica)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceGenericaGetById';

