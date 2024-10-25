CREATE PROCEDURE [dbo].[ZSpesaIrregolareInsert]
(
	@CfInserimento VARCHAR(255), 
	@DataInserimento DATETIME, 
	@CfModifica VARCHAR(255), 
	@DataModifica DATETIME, 
	@IdIrregolarita INT, 
	@IdSpesa INT, 
	@ImportoIrregolare DECIMAL(15,2)
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO SPESA_IRREGOLARE
	(
		CF_INSERIMENTO, 
		DATA_INSERIMENTO, 
		CF_MODIFICA, 
		DATA_MODIFICA, 
		ID_IRREGOLARITA, 
		ID_SPESA, 
		IMPORTO_IRREGOLARE
	)
	VALUES
	(
		@CfInserimento, 
		@DataInserimento, 
		@CfModifica, 
		@DataModifica, 
		@IdIrregolarita, 
		@IdSpesa, 
		@ImportoIrregolare
	)
	SELECT SCOPE_IDENTITY() AS ID_SPESA_IRREGOLARE, @DataModifica AS DATA_MODIFICA

GO