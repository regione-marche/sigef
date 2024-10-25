CREATE PROCEDURE [dbo].[ZBandoConfigInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO BANDO_CONFIG
	(
		ID_BANDO, 
		COD_TIPO, 
		VALORE, 
		ATTIVO, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		DATA_FINE, 
		OPERATORE_FINE
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@Valore, 
		@Attivo, 
		@DataInizio, 
		@OperatoreInizio, 
		@DataFine, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigInsert]
(
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
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO BANDO_CONFIG
	(
		ID_BANDO, 
		COD_TIPO, 
		VALORE, 
		ATTIVO, 
		DATA_INIZIO, 
		OPERATORE_INIZIO, 
		DATA_FINE, 
		OPERATORE_FINE
	)
	VALUES
	(
		@IdBando, 
		@CodTipo, 
		@Valore, 
		@Attivo, 
		@DataInizio, 
		@OperatoreInizio, 
		@DataFine, 
		@OperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigInsert';

