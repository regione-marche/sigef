CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniUpdate]
(
	@IdDichiarazione INT, 
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(10)
)
AS
	UPDATE CATALOGO_DICHIARAZIONI
	SET
		DESCRIZIONE = @Descrizione, 
		MISURA = @Misura
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniUpdate]
(
	@IdDichiarazione INT, 
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(10)
)
AS
	UPDATE CATALOGO_DICHIARAZIONI
	SET
		DESCRIZIONE = @Descrizione, 
		MISURA = @Misura
	WHERE 
		(ID_DICHIARAZIONE = @IdDichiarazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatalogoDichiarazioniUpdate';

