create PROCEDURE [dbo].[ZFilieraUpdate]
(
	@IdFiliera INT, 
	@CodTipoFiliera CHAR(3), 
	@Denominazione VARCHAR(255), 
	@IdeaProgettuale NTEXT, 
	@NumCertificato INT, 
	@DataCertificato DATETIME, 
	@DataInserimento DATETIME, 
	@DataUltimaModifica DATETIME, 
	@Operatore VARCHAR(16)
)
AS
	UPDATE FILIERA
	SET
		COD_TIPO_FILIERA = @CodTipoFiliera, 
		DENOMINAZIONE = @Denominazione, 
		IDEA_PROGETTUALE = @IdeaProgettuale, 
		NUM_CERTIFICATO = @NumCertificato, 
		DATA_CERTIFICATO = @DataCertificato, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_ULTIMA_MODIFICA = @DataUltimaModifica, 
		OPERATORE = @Operatore
	WHERE 
		(ID_FILIERA = @IdFiliera)
