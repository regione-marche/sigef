CREATE PROCEDURE [dbo].[ZBandoValutatoriInsert]
(
	@IdUtente INT, 
	@IdBando INT, 
	@Presidente BIT, 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ordine INT
)
AS
	INSERT INTO BANDO_VALUTATORI
	(
		ID_UTENTE, 
		ID_BANDO, 
		PRESIDENTE, 
		ATTIVO, 
		DATA_INIZIO, 
		DATA_FINE, 
		ORDINE
	)
	VALUES
	(
		@IdUtente, 
		@IdBando, 
		@Presidente, 
		@Attivo, 
		@DataInizio, 
		@DataFine, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID_VALUTATORE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriInsert]
(
	@IdBando INT, 
	@IdUtente INT, 
	@Presidente BIT, 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ordine INT
)
AS
	INSERT INTO BANDO_VALUTATORI
	(
		ID_BANDO, 
		ID_UTENTE, 
		PRESIDENTE, 
		ATTIVO, 
		DATA_INIZIO, 
		DATA_FINE, 
		ORDINE
	)
	VALUES
	(
		@IdBando, 
		@IdUtente, 
		@Presidente, 
		@Attivo, 
		@DataInizio, 
		@DataFine, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID_VALUTATORE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriInsert';

