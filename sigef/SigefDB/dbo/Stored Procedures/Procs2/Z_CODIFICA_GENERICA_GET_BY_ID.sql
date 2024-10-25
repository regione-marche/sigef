CREATE PROCEDURE [dbo].[Z_CODIFICA_GENERICA_GET_BY_ID]
(
	@ID INT
)
AS
	SELECT *
	FROM VCODIFICA_GENERICA
	WHERE 
		(ID = @ID)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Z_CODIFICA_GENERICA_GET_BY_ID';

