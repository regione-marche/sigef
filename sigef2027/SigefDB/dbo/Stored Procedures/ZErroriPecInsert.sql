CREATE PROCEDURE [dbo].[ZErroriPecInsert]
(
	@OperatoreInserimento VARCHAR(max), 
	@DataInserimento DATETIME, 
	@OperatoreModifica VARCHAR(max), 
	@DataModifica DATETIME, 
	@Segnatura VARCHAR(max), 
	@IdStato INT, 
	@Stato VARCHAR(max), 
	@Destinatario VARCHAR(max), 
	@EmailDestinatario VARCHAR(max)
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ERRORI_PEC
	(
		OPERATORE_INSERIMENTO, 
		DATA_INSERIMENTO, 
		OPERATORE_MODIFICA, 
		DATA_MODIFICA, 
		SEGNATURA, 
		ID_STATO, 
		STATO, 
		DESTINATARIO, 
		EMAIL_DESTINATARIO
	)
	VALUES
	(
		@OperatoreInserimento, 
		@DataInserimento, 
		@OperatoreModifica, 
		@DataModifica, 
		@Segnatura, 
		@IdStato, 
		@Stato, 
		@Destinatario, 
		@EmailDestinatario
	)
	SELECT SCOPE_IDENTITY() AS ID, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA

GO