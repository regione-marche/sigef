CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraDelete]
(
	@IdPartecipante INT
)
AS
	DELETE PARTECIPANTI_X_FILIERA
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraDelete]
(
	@IdPartecipante INT
)
AS
	DELETE PARTECIPANTI_X_FILIERA
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiXFilieraDelete';

