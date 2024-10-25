CREATE PROCEDURE [dbo].[ZBandoValutatoriUpdate]
(
	@IdUtente INT, 
	@IdValutatore INT, 
	@IdBando INT, 
	@Presidente BIT, 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ordine INT
)
AS
	UPDATE BANDO_VALUTATORI
	SET
		ID_UTENTE = @IdUtente, 
		ID_BANDO = @IdBando, 
		PRESIDENTE = @Presidente, 
		ATTIVO = @Attivo, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		ORDINE = @Ordine
	WHERE 
		(ID_VALUTATORE = @IdValutatore)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriUpdate]
(
	@IdValutatore INT, 
	@IdBando INT, 
	@IdUtente INT, 
	@Presidente BIT, 
	@Attivo BIT, 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ordine INT
)
AS
	UPDATE BANDO_VALUTATORI
	SET
		ID_BANDO = @IdBando, 
		ID_UTENTE = @IdUtente, 
		PRESIDENTE = @Presidente, 
		ATTIVO = @Attivo, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		ORDINE = @Ordine
	WHERE 
		(ID_VALUTATORE = @IdValutatore)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriUpdate';

