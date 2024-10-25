CREATE PROCEDURE [dbo].[ZZdimensioniInsert]
(
	@Codice VARCHAR(255), 
	@CodDim VARCHAR(255), 
	@Descrizione VARCHAR(1000), 
	@Metodo VARCHAR(255), 
	@Valore DECIMAL(18,2), 
	@Richiedibile VARCHAR(255), 
	@Um VARCHAR(255), 
	@ProceduraCalcolo VARCHAR(255), 
	@Ordine INT, 
	@ValoreBase DECIMAL(18,2)
)
AS
	INSERT INTO zDIMENSIONI
	(
		CODICE, 
		COD_DIM, 
		DESCRIZIONE, 
		METODO, 
		VALORE, 
		RICHIEDIBILE, 
		UM, 
		PROCEDURA_CALCOLO, 
		ORDINE, 
		VALORE_BASE
	)
	VALUES
	(
		@Codice, 
		@CodDim, 
		@Descrizione, 
		@Metodo, 
		@Valore, 
		@Richiedibile, 
		@Um, 
		@ProceduraCalcolo, 
		@Ordine, 
		@ValoreBase
	)
	SELECT SCOPE_IDENTITY() AS ID


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniInsert';

