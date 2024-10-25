CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileInsert]
(
	@IdSpesa INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@InIntegrazione BIT, 
	@Descrizione VARCHAR(255), 
	@IdFile INT
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO SPESE_SOSTENUTE_FILE
	(
		ID_SPESA, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		IN_INTEGRAZIONE, 
		DESCRIZIONE, 
		ID_FILE
	)
	VALUES
	(
		@IdSpesa, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@InIntegrazione, 
		@Descrizione, 
		@IdFile
	)
	SELECT SCOPE_IDENTITY() AS ID_FILE_SPESE_SOSTENUTE, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA, @InIntegrazione AS IN_INTEGRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileInsert';

