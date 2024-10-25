CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaDelete]
(
	@IdParagrafo INT, 
	@IdProgetto INT
)
AS
	DELETE PROGETTO_RELAZIONE_TECNICA
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoRelazioneTecnicaDelete]
(
	@IdParagrafo INT, 
	@IdProgetto INT
)
AS
	DELETE PROGETTO_RELAZIONE_TECNICA
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoRelazioneTecnicaDelete';

