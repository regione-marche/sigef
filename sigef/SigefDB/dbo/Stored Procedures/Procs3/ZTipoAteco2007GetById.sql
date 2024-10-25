CREATE PROCEDURE [dbo].[ZTipoAteco2007GetById]
(
	@CodTipoAteco2007 VARCHAR(255)
)
AS
	SELECT *
	FROM vTIPO_ATECO2007
	WHERE 
		(COD_TIPO_ATECO2007 = @CodTipoAteco2007)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoAteco2007GetById';

