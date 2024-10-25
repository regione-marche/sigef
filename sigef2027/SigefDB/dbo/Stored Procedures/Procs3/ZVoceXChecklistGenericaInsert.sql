CREATE PROCEDURE [dbo].[ZVoceXChecklistGenericaInsert]
(
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
	SET @Obbligatorio = ISNULL(@Obbligatorio,((0)))
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO VOCE_X_CHECKLIST_GENERICA
	(
		ID_CHECKLIST_GENERICA, 
		ID_VOCE_GENERICA, 
		ORDINE, 
		OBBLIGATORIO, 
		PESO, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		MISURA
	)
	VALUES
	(
		@IdChecklistGenerica, 
		@IdVoceGenerica, 
		@Ordine, 
		@Obbligatorio, 
		@Peso, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@Misura
	)
	SELECT SCOPE_IDENTITY() AS ID_VOCE_X_CHECKLIST_GENERICA, @Obbligatorio AS OBBLIGATORIO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVoceXChecklistGenericaInsert';

