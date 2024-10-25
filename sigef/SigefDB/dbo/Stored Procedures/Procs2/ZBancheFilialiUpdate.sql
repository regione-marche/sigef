CREATE PROCEDURE [dbo].[ZBancheFilialiUpdate]
(
	@Id INT, 
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
	UPDATE BANCHE_FILIALI
	SET
		ABI = @Abi, 
		CAB = @Cab, 
		NOTE = @Note, 
		INDIRIZZO = @Indirizzo, 
		ID_COMUNE = @IdComune, 
		COMUNE = @Comune, 
		PROVINCIA = @Provincia, 
		CAP = @Cap, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ATTIVO = @Attivo
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheFilialiUpdate';

