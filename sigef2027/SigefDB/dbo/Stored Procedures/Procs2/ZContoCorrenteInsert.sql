CREATE PROCEDURE [dbo].[ZContoCorrenteInsert]
(
	@IdImpresa INT, 
	@IdPersona INT, 
	@CodPaese CHAR(2), 
	@CinEuro CHAR(2), 
	@Cin CHAR(1), 
	@Abi VARCHAR(5), 
	@Cab VARCHAR(5), 
	@Numero VARCHAR(20), 
	@Note VARCHAR(500), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Istituto VARCHAR(255), 
	@Agenzia VARCHAR(255), 
	@IdComune INT
)
AS
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	INSERT INTO CONTO_CORRENTE
	(
		ID_IMPRESA, 
		ID_PERSONA, 
		COD_PAESE, 
		CIN_EURO, 
		CIN, 
		ABI, 
		CAB, 
		NUMERO, 
		NOTE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ISTITUTO, 
		AGENZIA, 
		ID_COMUNE
	)
	VALUES
	(
		@IdImpresa, 
		@IdPersona, 
		@CodPaese, 
		@CinEuro, 
		@Cin, 
		@Abi, 
		@Cab, 
		@Numero, 
		@Note, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@Istituto, 
		@Agenzia, 
		@IdComune
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTO_CORRENTE, @DataInizioValidita AS DATA_INIZIO_VALIDITA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZContoCorrenteInsert]
(
	@IdImpresa INT, 
	@IdPersona INT, 
	@CodPaese CHAR(2), 
	@CinEuro CHAR(2), 
	@Cin CHAR(1), 
	@Abi VARCHAR(5), 
	@Cab VARCHAR(5), 
	@Numero VARCHAR(20), 
	@Note VARCHAR(500), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Istituto VARCHAR(255), 
	@Agenzia VARCHAR(255), 
	@IdComune INT
)
AS
	INSERT INTO CONTO_CORRENTE
	(
		ID_IMPRESA, 
		ID_PERSONA, 
		COD_PAESE, 
		CIN_EURO, 
		CIN, 
		ABI, 
		CAB, 
		NUMERO, 
		NOTE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ISTITUTO, 
		AGENZIA, 
		ID_COMUNE
	)
	VALUES
	(
		@IdImpresa, 
		@IdPersona, 
		@CodPaese, 
		@CinEuro, 
		@Cin, 
		@Abi, 
		@Cab, 
		@Numero, 
		@Note, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@Istituto, 
		@Agenzia, 
		@IdComune
	)
	SELECT SCOPE_IDENTITY() AS ID_CONTO_CORRENTE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZContoCorrenteInsert';

