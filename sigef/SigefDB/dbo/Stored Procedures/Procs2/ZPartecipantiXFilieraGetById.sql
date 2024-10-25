CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraGetById]
(
	@IdPartecipante INT
)
AS
	SELECT *
	FROM PARTECIPANTI_X_FILIERA
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPartecipantiXFilieraGetById]
(
	@IdPartecipante INT
)
AS
	SELECT *
	FROM PARTECIPANTI_X_FILIERA
	WHERE 
		(ID_PARTECIPANTE = @IdPartecipante)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPartecipantiXFilieraGetById';

