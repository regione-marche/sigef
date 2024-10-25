CREATE PROCEDURE [dbo].[ZRnaProcedimentiERegolamentiUpdate]
(
	@IdProcedimentiRegolamenti INT, 
	@CodTipoProcedimento INT, 
	@DescrizioneProcedura VARCHAR(255), 
	@CodiceRegolamento VARCHAR(255), 
	@Descrizione VARCHAR(max), 
	@CodiceSettore VARCHAR(255), 
	@Settore VARCHAR(255)
)
AS
	UPDATE RNA_PROCEDIMENTI_E_REGOLAMENTI
	SET
		COD_TIPO_PROCEDIMENTO = @CodTipoProcedimento, 
		DESCRIZIONE_PROCEDURA = @DescrizioneProcedura, 
		CODICE_REGOLAMENTO = @CodiceRegolamento, 
		DESCRIZIONE = @Descrizione, 
		CODICE_SETTORE = @CodiceSettore, 
		SETTORE = @Settore
	WHERE 
		(ID_PROCEDIMENTI_REGOLAMENTI = @IdProcedimentiRegolamenti)