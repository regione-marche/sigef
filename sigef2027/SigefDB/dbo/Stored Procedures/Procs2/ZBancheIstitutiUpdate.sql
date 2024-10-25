CREATE PROCEDURE [dbo].[ZBancheIstitutiUpdate]
(
	@Abi VARCHAR(255), 
	@Denominazione VARCHAR(255), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Attivo BIT
)
AS
	UPDATE BANCHE_ISTITUTI
	SET
		DENOMINAZIONE = @Denominazione, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ATTIVO = @Attivo
	WHERE 
		(ABI = @Abi)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiUpdate';

