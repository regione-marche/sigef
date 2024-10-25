CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaInsert]
(
	@IdParagrafo INT, 
	@IdProgetto INT, 
	@Testo NTEXT
)
AS
	INSERT INTO PROGETTO_RELAZIONE_TECNICA
	(
		ID_PARAGRAFO, 
		ID_PROGETTO, 
		TESTO
	)
	VALUES
	(
		@IdParagrafo, 
		@IdProgetto, 
		@Testo
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaInsert]
(
	@IdParagrafo INT, 
	@IdProgetto INT, 
	@Testo NTEXT
)
AS
	INSERT INTO PROGETTO_RELAZIONE_TECNICA
	(
		ID_PARAGRAFO, 
		ID_PROGETTO, 
		TESTO
	)
	VALUES
	(
		@IdParagrafo, 
		@IdProgetto, 
		@Testo
	)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoRelazioneTecnicaInsert';

