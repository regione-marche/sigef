CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiDelete]
(
	@IdContrattoFemPagamenti INT
)
AS
	DELETE CONTRATTI_FEM_PAGAMENTI
	WHERE 
		(ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamenti)

GO