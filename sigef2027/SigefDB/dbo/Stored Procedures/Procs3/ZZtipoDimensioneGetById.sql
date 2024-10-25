
CREATE PROCEDURE [dbo].[ZZtipoDimensioneGetById]
(
	@CodDim VARCHAR(255)
)
AS
	SELECT *
	FROM zTIPO_DIMENSIONE
	WHERE 
		(COD_DIM = @CodDim)


