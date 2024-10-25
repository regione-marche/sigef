CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniInsert]
(
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(10)
)
AS
	INSERT INTO CATALOGO_DICHIARAZIONI
	(
		DESCRIZIONE, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_DICHIARAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniInsert]
(
	@Descrizione VARCHAR(1000), 
	@Misura VARCHAR(10)
)
AS
	INSERT INTO CATALOGO_DICHIARAZIONI
	(
		DESCRIZIONE, 
		MISURA
	)
	VALUES
	(
		@Descrizione, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_DICHIARAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatalogoDichiarazioniInsert';

