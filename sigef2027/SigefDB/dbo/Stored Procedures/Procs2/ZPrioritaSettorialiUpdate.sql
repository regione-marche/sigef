CREATE PROCEDURE [dbo].[ZPrioritaSettorialiUpdate]
(
	@IdPrioritaSettoriale INT, 
	@Descrizione VARCHAR(1000)
)
AS
	UPDATE PRIORITA_SETTORIALI
	SET
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPrioritaSettorialiUpdate]
(
	@IdPrioritaSettoriale INT, 
	@IdSettoreProduttivo INT, 
	@Descrizione VARCHAR(1000)
)
AS
	UPDATE PRIORITA_SETTORIALI
	SET
		ID_SETTORE_PRODUTTIVO = @IdSettoreProduttivo, 
		DESCRIZIONE = @Descrizione
	WHERE 
		(ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaSettorialiUpdate';

