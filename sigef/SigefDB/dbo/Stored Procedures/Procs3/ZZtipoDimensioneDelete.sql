
CREATE PROCEDURE [dbo].[ZZtipoDimensioneDelete]
(
	@CodDim VARCHAR(255)
)
AS
	DELETE zTIPO_DIMENSIONE
	WHERE 
		(COD_DIM = @CodDim)



