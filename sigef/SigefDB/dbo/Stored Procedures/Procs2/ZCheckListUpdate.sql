CREATE PROCEDURE [dbo].[ZCheckListUpdate]
(
	@IdCheckList INT, 
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@DataModifica DATETIME, 
	@Operatore CHAR(16)
)
AS
	SET @DataModifica=getdate()
	UPDATE CHECK_LIST
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_TEMPLATE = @FlagTemplate, 
		DATA_MODIFICA = @DataModifica, 
		OPERATORE = @Operatore
	WHERE 
		(ID_CHECK_LIST = @IdCheckList)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZChecklistUpdate]
(
	@ID_CHECK_LIST INT, 
	@DESCRIZIONE VARCHAR(255), 
	@FLAG_TEMPLATE BIT
)
AS
	UPDATE CHECK_LIST
	SET
		DESCRIZIONE = @DESCRIZIONE, 
		FLAG_TEMPLATE = @FLAG_TEMPLATE
	WHERE 
		(ID_CHECK_LIST = @ID_CHECK_LIST)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCheckListUpdate';

