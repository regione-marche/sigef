CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaUpdate]
(
	@IdVoceXChecklistGenerica INT, 
	@IdChecklistGenerica INT, 
	@IdVoceGenerica INT, 
	@Ordine INT, 
	@Obbligatorio BIT, 
	@Peso DECIMAL(10,2), 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@Misura VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE VOCE_X_CHECKLIST_GENERICA
	SET
		ID_CHECKLIST_GENERICA = @IdChecklistGenerica, 
		ID_VOCE_GENERICA = @IdVoceGenerica, 
		ORDINE = @Ordine, 
		OBBLIGATORIO = @Obbligatorio, 
		PESO = @Peso, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		MISURA = @Misura
	WHERE 
		(ID_VOCE_X_CHECKLIST_GENERICA = @IdVoceXChecklistGenerica)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaUpdate';

