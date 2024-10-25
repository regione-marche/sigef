CREATE PROCEDURE [dbo].[ZZfocusAreaUpdate]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Trasversale BIT
)
AS
	UPDATE zFOCUS_AREA
	SET
		COD_PSR = @CodPsr, 
		DESCRIZIONE = @Descrizione, 
		DOT_FINANZIARIA = @DotFinanziaria, 
		TRASVERSALE = @Trasversale
	WHERE 
		(CODICE = @Codice)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaUpdate]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Trasversale BIT
)
AS
	UPDATE zFOCUS_AREA
	SET
		COD_PSR = @CodPsr, 
		DESCRIZIONE = @Descrizione, 
		DOT_FINANZIARIA = @DotFinanziaria, 
		TRASVERSALE = @Trasversale
	WHERE 
		(CODICE = @Codice)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaUpdate';

