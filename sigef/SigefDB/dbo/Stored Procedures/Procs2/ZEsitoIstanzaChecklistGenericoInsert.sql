CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @EscludiDaComunicazione = ISNULL(@EscludiDaComunicazione,((0)))
	INSERT INTO ESITO_ISTANZA_CHECKLIST_GENERICO
	(
		ID_VOCE_GENERICA, 
		ID_ISTANZA_GENERICA, 
		COD_ESITO, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		NOTE, 
		COD_ESITO_REVISORE, 
		DATA_REVISORE, 
		REVISORE, 
		NOTE_REVISORE, 
		ESCLUDI_DA_COMUNICAZIONE, 
		VALORE
	)
	VALUES
	(
		@IdVoceGenerica, 
		@IdIstanzaGenerica, 
		@CodEsito, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@Note, 
		@CodEsitoRevisore, 
		@DataRevisore, 
		@Revisore, 
		@NoteRevisore, 
		@EscludiDaComunicazione, 
		@Valore
	)
	SELECT SCOPE_IDENTITY() AS ID_ESITO_GENERICO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @EscludiDaComunicazione AS ESCLUDI_DA_COMUNICAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZEsitoIstanzaChecklistGenericoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @EscludiDaComunicazione = ISNULL(@EscludiDaComunicazione,((0)))
	INSERT INTO ESITO_ISTANZA_CHECKLIST_GENERICO
	(
		ID_VOCE_GENERICA, 
		ID_ISTANZA_GENERICA, 
		COD_ESITO, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		NOTE, 
		COD_ESITO_REVISORE, 
		DATA_REVISORE, 
		REVISORE, 
		NOTE_REVISORE, 
		ESCLUDI_DA_COMUNICAZIONE, 
		VALORE
	)
	VALUES
	(
		@IdVoceGenerica, 
		@IdIstanzaGenerica, 
		@CodEsito, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@Note, 
		@CodEsitoRevisore, 
		@DataRevisore, 
		@Revisore, 
		@NoteRevisore, 
		@EscludiDaComunicazione, 
		@Valore
	)
	SELECT SCOPE_IDENTITY() AS ID_ESITO_GENERICO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @EscludiDaComunicazione AS ESCLUDI_DA_COMUNICAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZEsitoIstanzaChecklistGenericoInsert';

