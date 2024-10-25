CREATE PROCEDURE [dbo].[ZZquerySqlInsert]
(
	@Nome NVARCHAR(255), 
	@Testo NVARCHAR(max)
)
AS
	INSERT INTO zQUERY_SQL
	(
		NOME, 
		TESTO
	)
	VALUES
	(
		@Nome, 
		@Testo
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZquerySqlInsert';

