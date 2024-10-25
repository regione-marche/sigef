CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaInsert]
(
	@IdBando INT, 
	@Descrizione VARCHAR(2000), 
	@Titolo VARCHAR(255), 
	@Ordine INT
)
AS
	SET @Ordine = ISNULL(@Ordine,((0)))
	INSERT INTO BANDO_RELAZIONE_TECNICA
	(
		ID_BANDO, 
		DESCRIZIONE, 
		TITOLO, 
		ORDINE
	)
	VALUES
	(
		@IdBando, 
		@Descrizione, 
		@Titolo, 
		@Ordine
	)
	SELECT SCOPE_IDENTITY() AS ID_PARAGRAFO, @Ordine AS ORDINE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaInsert]
(
	@IdBando INT, 
	@Descrizione TEXT, 
	@Titolo VARCHAR(100)
)
AS
	INSERT INTO BANDO_RELAZIONE_TECNICA
	(
		ID_BANDO, 
		DESCRIZIONE, 
		TITOLO
	)
	VALUES
	(
		@IdBando, 
		@Descrizione, 
		@Titolo
	)
	SELECT SCOPE_IDENTITY() AS ID_PARAGRAFO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRelazioneTecnicaInsert';

