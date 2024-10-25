CREATE PROCEDURE [dbo].[ZRnaProcedimentiERegolamentiGetById]
(
	@IdProcedimentiRegolamenti INT
)
AS
	SELECT *
	FROM RNA_PROCEDIMENTI_E_REGOLAMENTI
	WHERE 
		(ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamenti)