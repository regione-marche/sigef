CREATE PROCEDURE [dbo].[ZTipoAteco2007Update]
(
	@CodTipoAteco2007 VARCHAR(255), 
	@Sezione VARCHAR(255), 
	@Divisione VARCHAR(255), 
	@Classe VARCHAR(255), 
	@Gruppo VARCHAR(255), 
	@Categoria VARCHAR(255), 
	@Sottocategoria VARCHAR(255), 
	@Descrizione NVARCHAR(255), 
	@Eliminato BIT
)
AS
	UPDATE TIPO_ATECO2007
	SET
		Sezione = @Sezione, 
		Divisione = @Divisione, 
		Classe = @Classe, 
		Gruppo = @Gruppo, 
		Categoria = @Categoria, 
		Sottocategoria = @Sottocategoria, 
		Descrizione = @Descrizione, 
		ELIMINATO = @Eliminato
	WHERE 
		(COD_TIPO_ATECO2007 = @CodTipoAteco2007)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoAteco2007Update';

