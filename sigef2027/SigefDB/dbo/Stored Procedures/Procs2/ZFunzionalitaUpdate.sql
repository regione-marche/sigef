CREATE PROCEDURE [dbo].[ZFunzionalitaUpdate]
(
	@CodFunzione INT, 
	@Descrizione VARCHAR(255), 
	@FlagMenu BIT, 
	@DescMenu VARCHAR(255), 
	@Livello INT, 
	@Padre INT, 
	@Link VARCHAR(255), 
	@Ordine INT
)
AS
	UPDATE FUNZIONALITA
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_MENU = @FlagMenu, 
		DESC_MENU = @DescMenu, 
		LIVELLO = @Livello, 
		PADRE = @Padre, 
		LINK = @Link, 
		ORDINE = @Ordine
	WHERE 
		(COD_FUNZIONE = @CodFunzione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZFunzionalitaUpdate]
(
	@CodFunzione INT, 
	@Descrizione VARCHAR(255), 
	@FlagMenu BIT, 
	@DescMenu VARCHAR(50), 
	@Livello INT, 
	@Padre INT, 
	@Link VARCHAR(255), 
	@Ordine INT
)
AS
	UPDATE FUNZIONALITA
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_MENU = @FlagMenu, 
		DESC_MENU = @DescMenu, 
		LIVELLO = @Livello, 
		PADRE = @Padre, 
		LINK = @Link, 
		ORDINE = @Ordine
	WHERE 
		(COD_FUNZIONE = @CodFunzione)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFunzionalitaUpdate';

