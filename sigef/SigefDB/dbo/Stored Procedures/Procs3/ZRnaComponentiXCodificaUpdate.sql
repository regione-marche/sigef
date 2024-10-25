CREATE PROCEDURE [dbo].[ZRnaComponentiXCodificaUpdate]
(
	@IdComponentiXCodifica INT, 
	@IdCodificaInvestimento INT, 
	@IdRnaProcedimentiERegolamenti INT, 
	@IdRnaObiettivo INT
)
AS
	UPDATE RNA_COMPONENTI_X_CODIFICA
	SET
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		ID_RNA_PROCEDIMENTI_E_REGOLAMENTI = @IdRnaProcedimentiERegolamenti, 
		ID_RNA_OBIETTIVO = @IdRnaObiettivo
	WHERE 
		(ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodifica)