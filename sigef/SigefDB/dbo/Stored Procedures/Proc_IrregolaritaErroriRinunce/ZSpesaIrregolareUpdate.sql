CREATE PROCEDURE [dbo].[ZSpesaIrregolareUpdate]
(
	@IdSpesaIrregolare INT, 
	@CfInserimento VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataModifica DATETIME, 
	@IdIrregolarita INT, 
	@IdSpesa INT, 
	@ImportoIrregolare DECIMAL(15,2)
)
AS
	SET @DataModifica=getdate()
	UPDATE SPESA_IRREGOLARE
	SET
		CF_INSERIMENTO = @CfInserimento, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_MODIFICA = @CfModifica, 
		DATA_MODIFICA = @DataModifica, 
		ID_IRREGOLARITA = @IdIrregolarita, 
		ID_SPESA = @IdSpesa, 
		IMPORTO_IRREGOLARE = @ImportoIrregolare
	WHERE 
		(ID_SPESA_IRREGOLARE = @IdSpesaIrregolare)
	SELECT @DataModifica;

GO