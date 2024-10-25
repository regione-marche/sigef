CREATE PROCEDURE [dbo].[ZControlliParametriDiRischioInsert]
(
	@Descrizione VARCHAR(500), 
	@Manuale BIT, 
	@QuerySql VARCHAR(3000), 
	@Peso INT
)
AS
	SET @Manuale = ISNULL(@Manuale,((0)))
	INSERT INTO CONTROLLI_PARAMETRI_DI_RISCHIO
	(
		DESCRIZIONE, 
		MANUALE, 
		QUERY_SQL, 
		PESO
	)
	VALUES
	(
		@Descrizione, 
		@Manuale, 
		@QuerySql, 
		@Peso
	)
	SELECT SCOPE_IDENTITY() AS ID_PARAMETRO, @Manuale AS MANUALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriDiRischioInsert';

