CREATE PROCEDURE [dbo].[ZTipoAteco2007Insert]
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
	INSERT INTO TIPO_ATECO2007
	(
		COD_TIPO_ATECO2007, 
		Sezione, 
		Divisione, 
		Classe, 
		Gruppo, 
		Categoria, 
		Sottocategoria, 
		Descrizione, 
		ELIMINATO
	)
	VALUES
	(
		@CodTipoAteco2007, 
		@Sezione, 
		@Divisione, 
		@Classe, 
		@Gruppo, 
		@Categoria, 
		@Sottocategoria, 
		@Descrizione, 
		@Eliminato
	)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoAteco2007Insert';

