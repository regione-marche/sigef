CREATE PROCEDURE [dbo].[ZRnaProcedimentiERegolamentiInsert]
(
	@CodTipoProcedimento INT, 
	@DescrizioneProcedura VARCHAR(255), 
	@CodiceRegolamento VARCHAR(255), 
	@Descrizione VARCHAR(max), 
	@CodiceSettore VARCHAR(255), 
	@Settore VARCHAR(255)
)
AS
	INSERT INTO RNA_PROCEDIMENTI_E_REGOLAMENTI
	(
		COD_TIPO_PROCEDIMENTO, 
		DESCRIZIONE_PROCEDURA, 
		CODICE_REGOLAMENTO, 
		DESCRIZIONE, 
		CODICE_SETTORE, 
		SETTORE
	)
	VALUES
	(
		@CodTipoProcedimento, 
		@DescrizioneProcedura, 
		@CodiceRegolamento, 
		@Descrizione, 
		@CodiceSettore, 
		@Settore
	)
	SELECT SCOPE_IDENTITY() AS ID_PROCEDIMENTI_REGOLAMENTI