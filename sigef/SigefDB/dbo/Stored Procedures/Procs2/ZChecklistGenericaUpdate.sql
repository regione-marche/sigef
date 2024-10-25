CREATE PROCEDURE [dbo].[ZChecklistGenericaUpdate]
(
	@IdChecklistGenerica INT, 
	@Descrizione VARCHAR(255), 
	@FlagTemplate BIT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE CHECKLIST_GENERICA
	SET
		DESCRIZIONE = @Descrizione, 
		FLAG_TEMPLATE = @FlagTemplate, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica
	WHERE 
		(ID_CHECKLIST_GENERICA = @IdChecklistGenerica)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZChecklistGenericaUpdate';

