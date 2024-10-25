CREATE PROCEDURE [dbo].[ZSettoriProduttiviInsert]
(
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO SETTORI_PRODUTTIVI
	(
		DESCRIZIONE
	)
	VALUES
	(
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_SETTORE_PRODUTTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSettoriProduttiviInsert]
(
	@IdBando INT, 
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO SETTORI_PRODUTTIVI
	(
		ID_BANDO, 
		DESCRIZIONE
	)
	VALUES
	(
		@IdBando, 
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_SETTORE_PRODUTTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSettoriProduttiviInsert';

