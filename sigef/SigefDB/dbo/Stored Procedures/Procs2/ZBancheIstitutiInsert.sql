CREATE PROCEDURE [dbo].[ZBancheIstitutiInsert]
(
	@Abi VARCHAR(255), 
	@Denominazione VARCHAR(255), 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@Attivo BIT
)
AS
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO BANCHE_ISTITUTI
	(
		ABI, 
		DENOMINAZIONE, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ATTIVO
	)
	VALUES
	(
		@Abi, 
		@Denominazione, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@Attivo
	)
	SELECT @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBancheIstitutiInsert';

