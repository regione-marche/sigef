CREATE PROCEDURE [dbo].[ZIterProgettoUpdate]
(
	@IdProgetto INT, 
	@IdStep INT, 
	@CodEsito CHAR(2), 
	@Data DATETIME, 
	@CfOperatore VARCHAR(16), 
	@Note NTEXT, 
	@CodEsitoRevisore CHAR(2), 
	@DataRevisore DATETIME, 
	@Revisore VARCHAR(16), 
	@NoteRevisore NTEXT
)
AS
	UPDATE ITER_PROGETTO
	SET
		COD_ESITO = @CodEsito, 
		DATA = @Data, 
		CF_OPERATORE = @CfOperatore, 
		NOTE = @Note, 
		COD_ESITO_REVISORE = @CodEsitoRevisore, 
		DATA_REVISORE = @DataRevisore, 
		REVISORE = @Revisore, 
		NOTE_REVISORE = @NoteRevisore
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_STEP = @IdStep)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIterProgettoUpdate]
(
	@IdProgetto INT, 
	@IdStep INT, 
	@CodEsito CHAR(2), 
	@Data DATETIME, 
	@CfOperatore VARCHAR(16), 
	@Note NTEXT, 
	@Revisione BIT
)
AS
	UPDATE ITER_PROGETTO
	SET
		COD_ESITO = @CodEsito, 
		DATA = @Data, 
		CF_OPERATORE = @CfOperatore, 
		NOTE = @Note, 
		REVISIONE = @Revisione
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(ID_STEP = @IdStep)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIterProgettoUpdate';

