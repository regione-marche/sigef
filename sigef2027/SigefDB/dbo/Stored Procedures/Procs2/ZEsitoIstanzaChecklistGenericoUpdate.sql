CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoUpdate]
(
	@IdEsitoGenerico INT, 
	@IdVoceGenerica INT, 
	@IdIstanzaGenerica INT, 
	@CodEsito VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@Note NTEXT, 
	@CodEsitoRevisore VARCHAR(255), 
	@DataRevisore DATETIME, 
	@Revisore VARCHAR(255), 
	@NoteRevisore NTEXT, 
	@EscludiDaComunicazione BIT, 
	@Valore VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE ESITO_ISTANZA_CHECKLIST_GENERICO
	SET
		ID_VOCE_GENERICA = @IdVoceGenerica, 
		ID_ISTANZA_GENERICA = @IdIstanzaGenerica, 
		COD_ESITO = @CodEsito, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		NOTE = @Note, 
		COD_ESITO_REVISORE = @CodEsitoRevisore, 
		DATA_REVISORE = @DataRevisore, 
		REVISORE = @Revisore, 
		NOTE_REVISORE = @NoteRevisore, 
		ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazione, 
		VALORE = @Valore
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoUpdate]
(
	@IdEsitoGenerico INT, 
	@IdVoceGenerica INT, 
	@IdIstanzaGenerica INT, 
	@CodEsito VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@Note NTEXT, 
	@CodEsitoRevisore VARCHAR(255), 
	@DataRevisore DATETIME, 
	@Revisore VARCHAR(255), 
	@NoteRevisore NTEXT, 
	@EscludiDaComunicazione BIT, 
	@Valore VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE ESITO_ISTANZA_CHECKLIST_GENERICO
	SET
		ID_VOCE_GENERICA = @IdVoceGenerica, 
		ID_ISTANZA_GENERICA = @IdIstanzaGenerica, 
		COD_ESITO = @CodEsito, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		NOTE = @Note, 
		COD_ESITO_REVISORE = @CodEsitoRevisore, 
		DATA_REVISORE = @DataRevisore, 
		REVISORE = @Revisore, 
		NOTE_REVISORE = @NoteRevisore, 
		ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazione, 
		VALORE = @Valore
	WHERE 
		(ID_ESITO_GENERICO = @IdEsitoGenerico)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoUpdate';

