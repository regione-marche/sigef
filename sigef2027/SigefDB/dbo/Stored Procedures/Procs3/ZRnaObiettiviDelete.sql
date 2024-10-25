CREATE PROCEDURE [dbo].[ZRnaObiettiviDelete]
(
	@IdObiettivo INT
)
AS
	DELETE RNA_OBIETTIVI
	WHERE 
		(ID_OBIETTIVO = @IdObiettivo)