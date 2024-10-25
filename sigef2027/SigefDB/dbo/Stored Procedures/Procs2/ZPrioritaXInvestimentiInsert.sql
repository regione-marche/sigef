CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiInsert]
(
	@IdPriorita INT, 
	@IdInvestimento INT, 
	@IdValore INT, 
	@Scelto BIT, 
	@Valore DECIMAL(18,2), 
	@ValData DATETIME, 
	@ValTesto VARCHAR(500)
)
AS
	INSERT INTO PRIORITA_X_INVESTIMENTI
	(
		ID_PRIORITA, 
		ID_INVESTIMENTO, 
		ID_VALORE, 
		SCELTO, 
		VALORE, 
		VAL_DATA, 
		VAL_TESTO
	)
	VALUES
	(
		@IdPriorita, 
		@IdInvestimento, 
		@IdValore, 
		@Scelto, 
		@Valore, 
		@ValData, 
		@ValTesto
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPrioritaXInvestimentiInsert]
(
	@IdPriorita INT, 
	@IdInvestimento INT, 
	@IdValore INT, 
	@Scelto BIT, 
	@Valore DECIMAL(18,2)
)
AS
	INSERT INTO PRIORITA_X_INVESTIMENTI
	(
		ID_PRIORITA, 
		ID_INVESTIMENTO, 
		ID_VALORE, 
		SCELTO, 
		VALORE
	)
	VALUES
	(
		@IdPriorita, 
		@IdInvestimento, 
		@IdValore, 
		@Scelto, 
		@Valore
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPrioritaXInvestimentiInsert';

