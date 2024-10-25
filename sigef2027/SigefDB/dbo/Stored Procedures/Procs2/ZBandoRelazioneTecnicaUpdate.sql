CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaUpdate]
(
	@IdParagrafo INT, 
	@IdBando INT, 
	@Descrizione VARCHAR(2000), 
	@Titolo VARCHAR(255), 
	@Ordine INT
)
AS
	UPDATE BANDO_RELAZIONE_TECNICA
	SET
		ID_BANDO = @IdBando, 
		DESCRIZIONE = @Descrizione, 
		TITOLO = @Titolo, 
		ORDINE = @Ordine
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaUpdate]
(
	@IdParagrafo INT, 
	@IdBando INT, 
	@Descrizione TEXT, 
	@Titolo VARCHAR(100)
)
AS
	UPDATE BANDO_RELAZIONE_TECNICA
	SET
		ID_BANDO = @IdBando, 
		DESCRIZIONE = @Descrizione, 
		TITOLO = @Titolo
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRelazioneTecnicaUpdate';

