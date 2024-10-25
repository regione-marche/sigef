CREATE PROCEDURE [dbo].[ZContrattiFemGetById]
(
	@IdContrattoFem INT
)
AS
	SELECT *
	FROM VCONTRATTI_FEM
	WHERE 
		(ID_CONTRATTO_FEM = @IdContrattoFem)

GO