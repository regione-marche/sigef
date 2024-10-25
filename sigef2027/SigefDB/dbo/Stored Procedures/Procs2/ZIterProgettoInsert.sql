CREATE PROCEDURE [dbo].[ZIterProgettoInsert]
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
	INSERT INTO ITER_PROGETTO
	(
		ID_PROGETTO, 
		ID_STEP, 
		COD_ESITO, 
		DATA, 
		CF_OPERATORE, 
		NOTE, 
		COD_ESITO_REVISORE, 
		DATA_REVISORE, 
		REVISORE, 
		NOTE_REVISORE
	)
	VALUES
	(
		@IdProgetto, 
		@IdStep, 
		@CodEsito, 
		@Data, 
		@CfOperatore, 
		@Note, 
		@CodEsitoRevisore, 
		@DataRevisore, 
		@Revisore, 
		@NoteRevisore
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIterProgettoInsert]
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
	INSERT INTO ITER_PROGETTO
	(
		ID_PROGETTO, 
		ID_STEP, 
		COD_ESITO, 
		DATA, 
		CF_OPERATORE, 
		NOTE, 
		REVISIONE
	)
	VALUES
	(
		@IdProgetto, 
		@IdStep, 
		@CodEsito, 
		@Data, 
		@CfOperatore, 
		@Note, 
		@Revisione
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIterProgettoInsert';

