CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniGetById]
(
	@IdDichiarazione INT
)
AS
	SELECT *
	FROM CATALOGO_DICHIARAZIONI
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniGetById]
(
	@IdDichiarazione INT
)
AS
	SELECT *
	FROM CATALOGO_DICHIARAZIONI
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatalogoDichiarazioniGetById';

