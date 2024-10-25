CREATE PROCEDURE [dbo].[ZRnaProcedimentiERegolamentiDelete]
(
	@IdProcedimentiRegolamenti INT
)
AS
	DELETE RNA_PROCEDIMENTI_E_REGOLAMENTI
	WHERE 
		(ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamenti)