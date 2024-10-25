CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoUpdate]
(
	@IdBandoXSettoreProduttivo INT, 
	@IdBando INT, 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT
)
AS
	UPDATE BANDO_X_SETTORE_PRODUTTIVO
	SET
		ID_BANDO = @IdBando, 
		ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo, 
		ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale
	WHERE 
		(ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoUpdate]
(
	@IdBandoXSettoreProduttivo INT, 
	@IdBando INT, 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT
)
AS
	UPDATE BANDO_X_SETTORE_PRODUTTIVO
	SET
		ID_BANDO = @IdBando, 
		ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo, 
		ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale
	WHERE 
		(ID_BANDO_X_SETTORE_PRODUTTIVO = @IdBandoXSettoreProduttivo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoXSettoreProduttivoUpdate';

