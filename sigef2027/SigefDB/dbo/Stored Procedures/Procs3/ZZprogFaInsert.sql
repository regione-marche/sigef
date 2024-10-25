CREATE PROCEDURE [dbo].[ZZprogFaInsert]
(
	@IdProgrammazione INT, 
	@CodFa VARCHAR(255), 
	@TipoContributo VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	SET @DotFinanziaria = ISNULL(@DotFinanziaria,((0)))
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO zPROG_FA
	(
		ID_PROGRAMMAZIONE, 
		COD_FA, 
		TIPO_CONTRIBUTO, 
		DOT_FINANZIARIA, 
		ATTIVO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdProgrammazione, 
		@CodFa, 
		@TipoContributo, 
		@DotFinanziaria, 
		@Attivo, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID, @DotFinanziaria AS DOT_FINANZIARIA, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogFaInsert]
(
	@IdProgrammazione INT, 
	@CodFa VARCHAR(255), 
	@TipoContributo VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	SET @DotFinanziaria = ISNULL(@DotFinanziaria,((0)))
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO zPROG_FA
	(
		ID_PROGRAMMAZIONE, 
		COD_FA, 
		TIPO_CONTRIBUTO, 
		DOT_FINANZIARIA, 
		ATTIVO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdProgrammazione, 
		@CodFa, 
		@TipoContributo, 
		@DotFinanziaria, 
		@Attivo, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID, @DotFinanziaria AS DOT_FINANZIARIA, @Attivo AS ATTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogFaInsert';

