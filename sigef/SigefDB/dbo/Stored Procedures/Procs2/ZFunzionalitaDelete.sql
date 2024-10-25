CREATE PROCEDURE [dbo].[ZFunzionalitaDelete]
(
	@CodFunzione INT
)
AS
	DELETE FUNZIONALITA
	WHERE 
		(COD_FUNZIONE = @CodFunzione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZFunzionalitaDelete]
(
	@CodFunzione INT
)
AS
	DELETE FUNZIONALITA
	WHERE 
		(COD_FUNZIONE = @CodFunzione)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFunzionalitaDelete';

