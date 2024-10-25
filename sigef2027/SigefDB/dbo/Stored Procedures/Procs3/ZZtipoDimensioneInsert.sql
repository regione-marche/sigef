
CREATE PROCEDURE [dbo].[ZZtipoDimensioneInsert]
(
	@CodDim VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Ordine INT
)
AS
	INSERT INTO zTIPO_DIMENSIONE
	(
		COD_DIM, 
		DESCRIZIONE, 
		ORDINE
	)
	VALUES
	(
		@CodDim, 
		@Descrizione, 
		@Ordine
	)


