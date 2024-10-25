CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoInsert]
(
	@IdBando INT, 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT
)
AS
	INSERT INTO BANDO_X_SETTORE_PRODUTTIVO
	(
		ID_BANDO, 
		ID_SETTORE_PRODUTTIVO, 
		ID_PRIORITA_SETTORIALE
	)
	VALUES
	(
		@IdBando, 
		@IdSettoreProduttivo, 
		@IdPrioritaSettoriale
	)
	SELECT SCOPE_IDENTITY() AS ID_BANDO_X_SETTORE_PRODUTTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoXSettoreProduttivoInsert]
(
	@IdBando INT, 
	@IdSettoreProduttivo INT, 
	@IdPrioritaSettoriale INT
)
AS
	INSERT INTO BANDO_X_SETTORE_PRODUTTIVO
	(
		ID_BANDO, 
		ID_SETTORE_PRODUTTIVO, 
		ID_PRIORITA_SETTORIALE
	)
	VALUES
	(
		@IdBando, 
		@IdSettoreProduttivo, 
		@IdPrioritaSettoriale
	)
	SELECT SCOPE_IDENTITY() AS ID_BANDO_X_SETTORE_PRODUTTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoXSettoreProduttivoInsert';

