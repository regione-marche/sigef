CREATE PROCEDURE [dbo].[ZVariantiSegnatureGetById]
(
	@IdVariante INT, 
	@CodTipo CHAR(3)
)
AS
	SELECT *
	FROM VARIANTI_SEGNATURE
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVariantiSegnatureGetById]
(
	@IdVariante INT, 
	@CodTipo CHAR(3)
)
AS
	SELECT *
	FROM VARIANTI_SEGNATURE
	WHERE 
		(ID_VARIANTE = @IdVariante) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiSegnatureGetById';

