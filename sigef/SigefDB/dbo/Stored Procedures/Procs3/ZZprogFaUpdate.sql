CREATE PROCEDURE [dbo].[ZZprogFaUpdate]
(
	@Id INT, 
	@IdProgrammazione INT, 
	@CodFa VARCHAR(255), 
	@TipoContributo VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE zPROG_FA
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		COD_FA = @CodFa, 
		TIPO_CONTRIBUTO = @TipoContributo, 
		DOT_FINANZIARIA = @DotFinanziaria, 
		ATTIVO = @Attivo, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZZprogFaUpdate]
(
	@Id INT, 
	@IdProgrammazione INT, 
	@CodFa VARCHAR(255), 
	@TipoContributo VARCHAR(255), 
	@DotFinanziaria DECIMAL(18,2), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE zPROG_FA
	SET
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		COD_FA = @CodFa, 
		TIPO_CONTRIBUTO = @TipoContributo, 
		DOT_FINANZIARIA = @DotFinanziaria, 
		ATTIVO = @Attivo, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZprogFaUpdate';

