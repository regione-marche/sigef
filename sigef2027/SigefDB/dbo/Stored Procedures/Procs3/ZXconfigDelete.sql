CREATE PROCEDURE [dbo].[ZXconfigDelete]
(
	@TipoConfigurazione VARCHAR(255)
)
AS
	DELETE XCONFIG
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZXconfigDelete]
(
	@TipoConfigurazione VARCHAR(50)
)
AS
	DELETE XCONFIG
	WHERE 
		(TIPO_CONFIGURAZIONE = @TipoConfigurazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZXconfigDelete';

