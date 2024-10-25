CREATE PROCEDURE [dbo].[ZErroriPecDelete]
(
	@Id INT
)
AS
	DELETE ERRORI_PEC
	WHERE 
		(ID = @Id)

GO