CREATE PROCEDURE [dbo].[ZDisposizioneUpdate]
(
	@IdDisposizione INT, 
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
	SET @DataModifica=getdate()
	UPDATE DISPOSIZIONE
	SET
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		ID_TIPO_DISPOSIZIONE = @IdTipoDisposizione, 
		NUMERO = @Numero, 
		ANNO = @Anno, 
		ARTICOLO_PARAGRAFO = @ArticoloParagrafo, 
		DISPOSIZIONE_NAZIONALE = @DisposizioneNazionale, 
		ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolarita, 
		ID_IRREGOLARITA = @IdIrregolarita, 
		NAZIONALE = @Nazionale, 
		REGIONALE = @Regionale
	WHERE 
		(ID_DISPOSIZIONE = @IdDisposizione)
	SELECT @DataModifica;

GO