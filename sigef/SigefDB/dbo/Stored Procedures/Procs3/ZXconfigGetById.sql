CREATE PROCEDURE [dbo].[ZXconfigGetById]
(
	@TipoConfigurazione VARCHAR(255)
)
AS
	SELECT *
	FROM XCONFIG
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZXconfigGetById]
(
	@TipoConfigurazione VARCHAR(50)
)
AS
	SELECT *
	FROM XCONFIG
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZXconfigGetById';

