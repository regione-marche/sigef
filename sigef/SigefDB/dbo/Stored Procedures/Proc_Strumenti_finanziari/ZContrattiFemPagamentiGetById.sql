CREATE PROCEDURE [dbo].[ZContrattiFemPagamentiGetById]
(
	@IdContrattoFemPagamenti INT
)
AS
	SELECT *
	FROM VCONTRATTI_FEM_PAGAMENTI
	WHERE 
		(ID_CONTRATTO_FEM_PAGAMENTI = @IdContrattoFemPagamenti)

GO