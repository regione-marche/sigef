CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoDelete]
(
	@IdBandoXSettoreProduttivo INT
)
AS
	DELETE BANDO_X_SETTORE_PRODUTTIVO
	WHERE 
		(ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoDelete]
(
	@IdBandoXSettoreProduttivo INT
)
AS
	DELETE BANDO_X_SETTORE_PRODUTTIVO
	WHERE 
		(ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoXSettoreProduttivoDelete';

