CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaUpdate]
(
	@IdParagrafo INT, 
	@IdProgetto INT, 
	@Testo NTEXT
)
AS
	UPDATE PROGETTO_RELAZIONE_TECNICA
	SET
		TESTO = @Testo
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaUpdate]
(
	@IdParagrafo INT, 
	@IdProgetto INT, 
	@Testo NTEXT
)
AS
	UPDATE PROGETTO_RELAZIONE_TECNICA
	SET
		TESTO = @Testo
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoRelazioneTecnicaUpdate';

