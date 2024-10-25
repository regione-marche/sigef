CREATE PROCEDURE [dbo].[ZControlliParametriDiRischioUpdate]
(
	@IdParametro INT, 
	@Descrizione VARCHAR(500), 
	@Manuale BIT, 
	@QuerySql VARCHAR(3000), 
	@Peso INT
)
AS
	UPDATE CONTROLLI_PARAMETRI_DI_RISCHIO
	SET
		DESCRIZIONE = @Descrizione, 
		MANUALE = @Manuale, 
		QUERY_SQL = @QuerySql, 
		PESO = @Peso
	WHERE 
		(ID_PARAMETRO = @IdParametro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriDiRischioUpdate';

