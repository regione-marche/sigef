CREATE PROCEDURE [dbo].[ZIndirizzarioUpdate]
(
	@IdIndirizzario INT, 
	@IdIndirizzo INT, 
	@IdPersona INT, 
	@IdImpresa INT, 
	@CodTipoSede VARCHAR(255), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@FlagAttivo BIT, 
	@Telefono VARCHAR(255), 
	@Fax VARCHAR(255), 
	@Email VARCHAR(255), 
	@Pec VARCHAR(255)
)
AS
	UPDATE INDIRIZZARIO
	SET
		ID_INDIRIZZO = @IdIndirizzo, 
		ID_PERSONA = @IdPersona, 
		ID_IMPRESA = @IdImpresa, 
		COD_TIPO_SEDE = @CodTipoSede, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		FLAG_ATTIVO = @FlagAttivo, 
		TELEFONO = @Telefono, 
		FAX = @Fax, 
		EMAIL = @Email, 
		PEC = @Pec
	WHERE 
		(ID_INDIRIZZARIO = @IdIndirizzario)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIndirizzarioUpdate]
(
	@IdIndirizzario INT, 
	@IdIndirizzo INT, 
	@IdPersona INT, 
	@IdImpresa INT, 
	@CodTipoSede CHAR(1), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@FlagAttivo BIT, 
	@Telefono VARCHAR(80), 
	@Fax VARCHAR(80), 
	@Email VARCHAR(80), 
	@Pec VARCHAR(200)
)
AS
	UPDATE INDIRIZZARIO
	SET
		ID_INDIRIZZO = @IdIndirizzo, 
		ID_PERSONA = @IdPersona, 
		ID_IMPRESA = @IdImpresa, 
		COD_TIPO_SEDE = @CodTipoSede, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		FLAG_ATTIVO = @FlagAttivo, 
		TELEFONO = @Telefono, 
		FAX = @Fax, 
		EMAIL = @Email, 
		PEC = @Pec
	WHERE 
		(ID_INDIRIZZARIO = @IdIndirizzario)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIndirizzarioUpdate';

