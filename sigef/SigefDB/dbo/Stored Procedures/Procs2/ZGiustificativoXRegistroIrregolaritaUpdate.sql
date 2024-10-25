CREATE PROCEDURE [dbo].[ZGiustificativoXRegistroIrregolaritaUpdate]
(
	@IdGiustificativoXIrregolarita INT, 
	@IdGiustificativo INT, 
	@IdRegistroIrregolarita INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255)
)
AS
	SET @DataModifica=getdate()
	UPDATE GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA
	SET
		ID_GIUSTIFICATIVO = @IdGiustificativo, 
		ID_REGISTRO_IRREGOLARITA = @IdRegistroIrregolarita, 
		DATA_INSERIMENTO = @DataInserimento, 
		CF_INSERIMENTO = @CfInserimento, 
		DATA_MODIFICA = @DataModifica, 
		CF_MODIFICA = @CfModifica
	WHERE 
		(ID_GIUSTIFICATIVO_X_IRREGOLARITA = @IdGiustificativoXIrregolarita)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativoXRegistroIrregolaritaUpdate';

