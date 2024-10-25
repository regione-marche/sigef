CREATE PROCEDURE [dbo].[ZChecklistGenericaInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255)
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO CHECKLIST_GENERICA
	(
		DESCRIZIONE, 
		FLAG_TEMPLATE, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA
	)
	VALUES
	(
		@Descrizione, 
		@FlagTemplate, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_CHECKLIST_GENERICA, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZChecklistGenericaInsert';

