CREATE PROCEDURE [dbo].[ZSpeseSostenuteFileUpdate]
(
	@IdFileSpeseSostenute INT, 
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
	SET @DataModifica=getdate()
	UPDATE SPESE_SOSTENUTE_FILE
	SET
		ID_SPESA = @IdSpesa, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		DESCRIZIONE = @Descrizione, 
		ID_FILE = @IdFile
	WHERE 
		(ID_FILE_SPESE_SOSTENUTE = @IdFileSpeseSostenute)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteFileUpdate';

