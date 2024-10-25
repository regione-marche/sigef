CREATE PROCEDURE [dbo].[ZContoCorrenteUpdate]
(
	@IdContoCorrente INT, 
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
	UPDATE CONTO_CORRENTE
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_PERSONA = @IdPersona, 
		COD_PAESE = @CodPaese, 
		CIN_EURO = @CinEuro, 
		CIN = @Cin, 
		ABI = @Abi, 
		CAB = @Cab, 
		NUMERO = @Numero, 
		NOTE = @Note, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ISTITUTO = @Istituto, 
		AGENZIA = @Agenzia, 
		ID_COMUNE = @IdComune
	WHERE 
		(ID_CONTO_CORRENTE = @IdContoCorrente)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZContoCorrenteUpdate]
(
	@IdContoCorrente INT, 
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
	UPDATE CONTO_CORRENTE
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_PERSONA = @IdPersona, 
		COD_PAESE = @CodPaese, 
		CIN_EURO = @CinEuro, 
		CIN = @Cin, 
		ABI = @Abi, 
		CAB = @Cab, 
		NUMERO = @Numero, 
		NOTE = @Note, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ISTITUTO = @Istituto, 
		AGENZIA = @Agenzia, 
		ID_COMUNE = @IdComune
	WHERE 
		(ID_CONTO_CORRENTE = @IdContoCorrente)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZContoCorrenteUpdate';

