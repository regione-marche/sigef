CREATE PROCEDURE [dbo].[ZTipoRataInsert]
(
	@Descrizione VARCHAR(255)
)
AS
	INSERT INTO TIPO_RATA
	(
		DESCRIZIONE
	)
	VALUES
	(
		@Descrizione
	)
	SELECT SCOPE_IDENTITY() AS ID_TIPO_RATA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoRataInsert';

