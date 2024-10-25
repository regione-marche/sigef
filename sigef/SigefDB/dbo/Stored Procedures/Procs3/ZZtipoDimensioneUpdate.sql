
CREATE PROCEDURE [dbo].[ZZtipoDimensioneUpdate]
(
	@CodDim VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Ordine INT
)
AS
	UPDATE zTIPO_DIMENSIONE
	SET
		DESCRIZIONE = @Descrizione, 
		ORDINE = @Ordine
	WHERE 
		(COD_DIM = @CodDim)


