CREATE PROCEDURE [dbo].[ZIstanzaChecklistGenericaInsert]
(
	@IdChecklistGenerica INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@CodFase VARCHAR(255)
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ISTANZA_CHECKLIST_GENERICA
	(
		ID_CHECKLIST_GENERICA, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA, 
		COD_FASE
	)
	VALUES
	(
		@IdChecklistGenerica, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica, 
		@CodFase
	)
	SELECT SCOPE_IDENTITY() AS ID_ISTANZA_GENERICA, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIstanzaChecklistGenericaInsert';

