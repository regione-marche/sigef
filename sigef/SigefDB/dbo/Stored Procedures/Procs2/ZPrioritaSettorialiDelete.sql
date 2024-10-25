CREATE PROCEDURE [dbo].[ZPrioritaSettorialiDelete]
(
	@IdPrioritaSettoriale INT
)
AS
	DELETE PRIORITA_SETTORIALI
	WHERE 
		(ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPrioritaSettorialiDelete]
(
	@IdPrioritaSettoriale INT
)
AS
	DELETE PRIORITA_SETTORIALI
	WHERE 
		(ID_PRIORITA_SETTORIALE = @IdPrioritaSettoriale)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaSettorialiDelete';

