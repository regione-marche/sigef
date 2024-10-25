CREATE PROCEDURE [dbo].[ZIstanzaChecklistGenericaUpdate]
(
	@IdIstanzaGenerica INT, 
	@IdChecklistGenerica INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255), 
	@CodFase VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE ISTANZA_CHECKLIST_GENERICA
	SET
		ID_CHECKLIST_GENERICA = @IdChecklistGenerica, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		COD_FASE = @CodFase
	WHERE 
		(ID_ISTANZA_GENERICA = @IdIstanzaGenerica)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIstanzaChecklistGenericaUpdate';

