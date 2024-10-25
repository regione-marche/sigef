CREATE PROCEDURE [dbo].[ZZfocusAreaInsert]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Trasversale BIT
)
AS
	SET @DotFinanziaria = ISNULL(@DotFinanziaria,((0)))
	SET @Trasversale = ISNULL(@Trasversale,((0)))
	INSERT INTO zFOCUS_AREA
	(
		CODICE, 
		COD_PSR, 
		DESCRIZIONE, 
		DOT_FINANZIARIA, 
		TRASVERSALE
	)
	VALUES
	(
		@Codice, 
		@CodPsr, 
		@Descrizione, 
		@DotFinanziaria, 
		@Trasversale
	)
	SELECT @DotFinanziaria AS DOT_FINANZIARIA, @Trasversale AS TRASVERSALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZfocusAreaInsert]
(
	@Codice VARCHAR(255), 
	@CodPsr VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Trasversale BIT
)
AS
	SET @DotFinanziaria = ISNULL(@DotFinanziaria,((0)))
	SET @Trasversale = ISNULL(@Trasversale,((0)))
	INSERT INTO zFOCUS_AREA
	(
		CODICE, 
		COD_PSR, 
		DESCRIZIONE, 
		DOT_FINANZIARIA, 
		TRASVERSALE
	)
	VALUES
	(
		@Codice, 
		@CodPsr, 
		@Descrizione, 
		@DotFinanziaria, 
		@Trasversale
	)
	SELECT @DotFinanziaria AS DOT_FINANZIARIA, @Trasversale AS TRASVERSALE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZfocusAreaInsert';

