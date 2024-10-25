CREATE PROCEDURE [dbo].[ZTipoSanzioniParametriDelete]
(
	@Codice INT
)
AS
	DELETE TIPO_SANZIONI_PARAMETRI
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoSanzioniParametriDelete';

