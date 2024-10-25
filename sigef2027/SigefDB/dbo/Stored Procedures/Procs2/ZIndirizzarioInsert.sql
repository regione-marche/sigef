CREATE PROCEDURE [dbo].[ZIndirizzarioInsert]
(
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
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	SET @FlagAttivo = ISNULL(@FlagAttivo,((0)))
	INSERT INTO INDIRIZZARIO
	(
		ID_INDIRIZZO, 
		ID_PERSONA, 
		ID_IMPRESA, 
		COD_TIPO_SEDE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		FLAG_ATTIVO, 
		TELEFONO, 
		FAX, 
		EMAIL, 
		PEC
	)
	VALUES
	(
		@IdIndirizzo, 
		@IdPersona, 
		@IdImpresa, 
		@CodTipoSede, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@FlagAttivo, 
		@Telefono, 
		@Fax, 
		@Email, 
		@Pec
	)
	SELECT SCOPE_IDENTITY() AS ID_INDIRIZZARIO, @DataInizioValidita AS DATA_INIZIO_VALIDITA, @FlagAttivo AS FLAG_ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZIndirizzarioInsert]
(
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
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	SET @FlagAttivo = ISNULL(@FlagAttivo,((0)))
	INSERT INTO INDIRIZZARIO
	(
		ID_INDIRIZZO, 
		ID_PERSONA, 
		ID_IMPRESA, 
		COD_TIPO_SEDE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		FLAG_ATTIVO, 
		TELEFONO, 
		FAX, 
		EMAIL, 
		PEC
	)
	VALUES
	(
		@IdIndirizzo, 
		@IdPersona, 
		@IdImpresa, 
		@CodTipoSede, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@FlagAttivo, 
		@Telefono, 
		@Fax, 
		@Email, 
		@Pec
	)
	SELECT SCOPE_IDENTITY() AS ID_INDIRIZZARIO, @DataInizioValidita AS DATA_INIZIO_VALIDITA, @FlagAttivo AS FLAG_ATTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIndirizzarioInsert';

