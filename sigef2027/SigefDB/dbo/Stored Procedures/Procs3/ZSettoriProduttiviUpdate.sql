CREATE PROCEDURE [dbo].[ZSettoriProduttiviUpdate]
(
	@IdSettoreProduttivo INT, 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE SETTORI_PRODUTTIVI
	SET
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE  PROCEDURE [dbo].[ZSettoriProduttiviUpdate]
(
	@IdSettoreProduttivo INT, 
	@IdBando INT, 
	@Descrizione VARCHAR(255)
)
AS
	UPDATE SETTORI_PRODUTTIVI
	SET
		ID_BANDO = @IdBando, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSettoriProduttiviUpdate';

