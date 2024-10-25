CREATE PROCEDURE [dbo].[ZGiustificativoXRegistroIrregolaritaInsert]
(
	@IdGiustificativo INT, 
	@IdRegistroIrregolarita INT, 
	@DataInserimento DATETIME, 
	@CfInserimento VARCHAR(255), 
	@DataModifica DATETIME, 
	@CfModifica VARCHAR(255)
)
AS
	INSERT INTO GIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA
	(
		ID_GIUSTIFICATIVO, 
		ID_REGISTRO_IRREGOLARITA, 
		DATA_INSERIMENTO, 
		CF_INSERIMENTO, 
		DATA_MODIFICA, 
		CF_MODIFICA
	)
	VALUES
	(
		@IdGiustificativo, 
		@IdRegistroIrregolarita, 
		@DataInserimento, 
		@CfInserimento, 
		@DataModifica, 
		@CfModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_GIUSTIFICATIVO_X_IRREGOLARITA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativoXRegistroIrregolaritaInsert';

