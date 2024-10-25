CREATE PROCEDURE [dbo].[ZBandoConfigUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@CodTipo VARCHAR(255), 
	@Valore VARCHAR(255), 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@DataFine DATETIME, 
	@OperatoreFine INT
)
AS
	UPDATE BANDO_CONFIG
	SET
		ID_BANDO = @IdBando, 
		COD_TIPO = @CodTipo, 
		VALORE = @Valore, 
		ATTIVO = @Attivo, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@CodTipo VARCHAR(255), 
	@Valore VARCHAR(255), 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@OperatoreInizio INT, 
	@DataFine DATETIME, 
	@OperatoreFine INT
)
AS
	UPDATE BANDO_CONFIG
	SET
		ID_BANDO = @IdBando, 
		COD_TIPO = @CodTipo, 
		VALORE = @Valore, 
		ATTIVO = @Attivo, 
		DATA_INIZIO = @DataInizio, 
		OPERATORE_INIZIO = @OperatoreInizio, 
		DATA_FINE = @DataFine, 
		OPERATORE_FINE = @OperatoreFine
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigUpdate';

