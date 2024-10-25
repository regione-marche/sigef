CREATE PROCEDURE [dbo].[ZErroriPecUpdate]
(
	@Id INT, 
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
	SET @DataModifica=getdate()
	UPDATE ERRORI_PEC
	SET
		OPERATORE_INSERIMENTO = @OperatoreInserimento, 
		DATA_INSERIMENTO = @DataInserimento, 
		OPERATORE_MODIFICA = @OperatoreModifica, 
		DATA_MODIFICA = @DataModifica, 
		SEGNATURA = @Segnatura, 
		ID_STATO = @IdStato, 
		STATO = @Stato, 
		DESTINATARIO = @Destinatario, 
		EMAIL_DESTINATARIO = @EmailDestinatario
	WHERE 
		(ID = @Id)
	SELECT @DataModifica;

GO