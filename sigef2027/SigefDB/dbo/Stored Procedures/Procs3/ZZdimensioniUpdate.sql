CREATE PROCEDURE [dbo].[ZZdimensioniUpdate]
(
	@Id INT, 
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
	UPDATE zDIMENSIONI
	SET
		CODICE = @Codice, 
		COD_DIM = @CodDim, 
		DESCRIZIONE = @Descrizione, 
		METODO = @Metodo, 
		VALORE = @Valore, 
		RICHIEDIBILE = @Richiedibile, 
		UM = @Um, 
		PROCEDURA_CALCOLO = @ProceduraCalcolo, 
		ORDINE = @Ordine, 
		VALORE_BASE = @ValoreBase
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniUpdate';

