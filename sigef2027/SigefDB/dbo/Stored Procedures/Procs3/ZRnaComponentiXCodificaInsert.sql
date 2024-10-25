CREATE PROCEDURE [dbo].[ZRnaComponentiXCodificaInsert]
(
	@IdCodificaInvestimento INT, 
	@IdRnaProcedimentiERegolamenti INT, 
	@IdRnaObiettivo INT
)
AS
	INSERT INTO RNA_COMPONENTI_X_CODIFICA
	(
		ID_CODIFICA_INVESTIMENTO, 
		ID_RNA_PROCEDIMENTI_E_REGOLAMENTI, 
		ID_RNA_OBIETTIVO
	)
	VALUES
	(
		@IdCodificaInvestimento, 
		@IdRnaProcedimentiERegolamenti, 
		@IdRnaObiettivo
	)
	SELECT SCOPE_IDENTITY() AS ID_COMPONENTI_X_CODIFICA