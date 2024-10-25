CREATE PROCEDURE [dbo].[ZErroriPecGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM VERRORI_PEC
	WHERE 
		(ID = @Id)

GO