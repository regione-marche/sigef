CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrUpdate]
(
	@IdEstrazioneIr INT, 
	@CodicePsr VARCHAR(255), 
	@IdDimensione INT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@ValoreBase DECIMAL(18,2), 
	@ValoreObbiettivo DECIMAL(18,2), 
	@ValoreRealizzato DECIMAL(18,2), 
	@Um VARCHAR(255), 
	@CodiceObmisura VARCHAR(255)
)
AS
	UPDATE zDIMENSIONI_ESTRAZIONI_IR
	SET
		CODICE_PSR = @CodicePsr, 
		ID_DIMENSIONE = @IdDimensione, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		VALORE_BASE = @ValoreBase, 
		VALORE_OBBIETTIVO = @ValoreObbiettivo, 
		VALORE_REALIZZATO = @ValoreRealizzato, 
		UM = @Um, 
		CODICE_OBMISURA = @CodiceObmisura
	WHERE 
		(ID_ESTRAZIONE_IR = @IdEstrazioneIr)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIrUpdate]
(
	@IdEstrazioneIr INT, 
	@CodicePsr VARCHAR(255), 
	@IdDimensione INT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@ValoreBase DECIMAL(18,2), 
	@ValoreObbiettivo DECIMAL(18,2), 
	@ValoreRealizzato DECIMAL(18,2), 
	@Um VARCHAR(255), 
	@CodiceObmisura VARCHAR(255)
)
AS
	UPDATE zDIMENSIONI_ESTRAZIONI_IR
	SET
		CODICE_PSR = @CodicePsr, 
		ID_DIMENSIONE = @IdDimensione, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		VALORE_BASE = @ValoreBase, 
		VALORE_OBBIETTIVO = @ValoreObbiettivo, 
		VALORE_REALIZZATO = @ValoreRealizzato, 
		UM = @Um, 
		CODICE_OBMISURA = @CodiceObmisura
	WHERE 
		(ID_ESTRAZIONE_IR = @IdEstrazioneIr)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIrUpdate';

