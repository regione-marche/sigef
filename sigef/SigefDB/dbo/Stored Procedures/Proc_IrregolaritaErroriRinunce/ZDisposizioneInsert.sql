CREATE PROCEDURE [dbo].[ZDisposizioneInsert]
(
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@IdTipoDisposizione INT, 
	@Numero VARCHAR(255), 
	@Anno INT, 
	@ArticoloParagrafo VARCHAR(255), 
	@DisposizioneNazionale VARCHAR(2000), 
	@IdRegistroIrregolarita INT, 
	@IdIrregolarita INT, 
	@Nazionale BIT, 
	@Regionale BIT
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @Nazionale = ISNULL(@Nazionale,((0)))
	SET @Regionale = ISNULL(@Regionale,((0)))
	INSERT INTO DISPOSIZIONE
	(
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		ID_TIPO_DISPOSIZIONE, 
		NUMERO, 
		ANNO, 
		ARTICOLO_PARAGRAFO, 
		DISPOSIZIONE_NAZIONALE, 
		ID_REGISTRO_IRREGOLARITA, 
		ID_IRREGOLARITA, 
		NAZIONALE, 
		REGIONALE
	)
	VALUES
	(
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@IdTipoDisposizione, 
		@Numero, 
		@Anno, 
		@ArticoloParagrafo, 
		@DisposizioneNazionale, 
		@IdRegistroIrregolarita, 
		@IdIrregolarita, 
		@Nazionale, 
		@Regionale
	)
	SELECT SCOPE_IDENTITY() AS ID_DISPOSIZIONE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @Nazionale AS NAZIONALE, @Regionale AS REGIONALE

GO