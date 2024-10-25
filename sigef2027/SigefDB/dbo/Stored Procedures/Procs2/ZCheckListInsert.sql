CREATE PROCEDURE [dbo].[ZCheckListInsert]
(
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@DataModifica DATETIME, 
	@Operatore CHAR(16)
)
AS
	INSERT INTO CHECK_LIST
	(
		DESCRIZIONE, 
		FLAG_TEMPLATE, 
		DATA_MODIFICA, 
		OPERATORE
	)
	VALUES
	(
		@Descrizione, 
		@FlagTemplate, 
		@DataModifica, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID_CHECK_LIST

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZChecklistInsert]
(
	@DESCRIZIONE VARCHAR(255), 
	@FLAG_TEMPLATE BIT
)
AS
	INSERT INTO CHECK_LIST
	(
		DESCRIZIONE, 
		FLAG_TEMPLATE
	)
	VALUES
	(
		@DESCRIZIONE, 
		@FLAG_TEMPLATE
	)
	SELECT SCOPE_IDENTITY() AS ID_CHECK_LIST

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListInsert';

