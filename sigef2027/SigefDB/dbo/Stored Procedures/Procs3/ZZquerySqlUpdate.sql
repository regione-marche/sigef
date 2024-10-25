CREATE PROCEDURE [dbo].[ZZquerySqlUpdate]
(
	@Id INT, 
	@Nome NVARCHAR(255), 
	@Testo NVARCHAR(max)
)
AS
	UPDATE zQUERY_SQL
	SET
		NOME = @Nome, 
		TESTO = @Testo
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZquerySqlUpdate';

