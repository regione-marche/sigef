create PROCEDURE [dbo].[ZFilieraInsert]
(
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
	INSERT INTO FILIERA
	(
		COD_TIPO_FILIERA, 
		DENOMINAZIONE, 
		IDEA_PROGETTUALE, 
		NUM_CERTIFICATO, 
		DATA_CERTIFICATO, 
		DATA_INSERIMENTO, 
		DATA_ULTIMA_MODIFICA, 
		OPERATORE
	)
	VALUES
	(
		@CodTipoFiliera, 
		@Denominazione, 
		@IdeaProgettuale, 
		@NumCertificato, 
		@DataCertificato, 
		@DataInserimento, 
		@DataUltimaModifica, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID_FILIERA
