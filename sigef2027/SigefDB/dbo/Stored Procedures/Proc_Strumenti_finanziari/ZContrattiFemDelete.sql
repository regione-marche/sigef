CREATE PROCEDURE [dbo].[ZContrattiFemDelete]
(
	@IdContrattoFem INT
)
AS
	DELETE CONTRATTI_FEM
	WHERE 
		(ID_CONTRATTO_FEM = @IdContrattoFem)

GO