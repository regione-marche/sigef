CREATE PROCEDURE [dbo].[ZBancheFilialiInsert]
(
	@Abi VARCHAR(255), 
	@Cab VARCHAR(255), 
	@Note VARCHAR(255), 
	@Indirizzo VARCHAR(255), 
	@IdComune INT, 
	@Comune VARCHAR(255), 
	@Provincia VARCHAR(255), 
	@Cap VARCHAR(255), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO BANCHE_FILIALI
	(
		ABI, 
		CAB, 
		NOTE, 
		INDIRIZZO, 
		ID_COMUNE, 
		COMUNE, 
		PROVINCIA, 
		CAP, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ATTIVO
	)
	VALUES
	(
		@Abi, 
		@Cab, 
		@Note, 
		@Indirizzo, 
		@IdComune, 
		@Comune, 
		@Provincia, 
		@Cap, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheFilialiInsert';

