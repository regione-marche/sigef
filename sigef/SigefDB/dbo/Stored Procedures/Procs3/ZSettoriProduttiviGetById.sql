CREATE PROCEDURE [dbo].[ZSettoriProduttiviGetById]
(
	@IdSettoreProduttivo INT
)
AS
	SELECT *
	FROM SETTORI_PRODUTTIVI
	WHERE 
		(ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE  PROCEDURE [dbo].[ZSettoriProduttiviGetById]
(
	@IdSettoreProduttivo INT
)
AS
	SELECT *
	FROM SETTORI_PRODUTTIVI
	WHERE 
		(ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSettoriProduttiviGetById';

