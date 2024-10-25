CREATE PROCEDURE [dbo].[ZFunzionalitaInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagMenu BIT, 
	@DescMenu VARCHAR(255), 
	@Livello INT, 
	@Padre INT, 
	@Link VARCHAR(255), 
	@Ordine INT
)
AS
	INSERT INTO FUNZIONALITA
	(
		DESCRIZIONE, 
		FLAG_MENU, 
		DESC_MENU, 
		LIVELLO, 
		PADRE, 
		LINK, 
		ORDINE
	)
	VALUES
	(
		@Descrizione, 
		@FlagMenu, 
		@DescMenu, 
		@Livello, 
		@Padre, 
		@Link, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS COD_FUNZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZFunzionalitaInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagMenu BIT, 
	@DescMenu VARCHAR(50), 
	@Livello INT, 
	@Padre INT, 
	@Link VARCHAR(255), 
	@Ordine INT
)
AS
	INSERT INTO FUNZIONALITA
	(
		DESCRIZIONE, 
		FLAG_MENU, 
		DESC_MENU, 
		LIVELLO, 
		PADRE, 
		LINK, 
		ORDINE
	)
	VALUES
	(
		@Descrizione, 
		@FlagMenu, 
		@DescMenu, 
		@Livello, 
		@Padre, 
		@Link, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS COD_FUNZIONE
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFunzionalitaInsert';

