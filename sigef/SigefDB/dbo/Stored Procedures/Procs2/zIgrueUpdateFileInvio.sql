CREATE PROCEDURE [dbo].[zIgrueUpdateFileInvio]
	(
		@IdInvio INT,
		@FileInvio VARBINARY(MAX)
	)
AS
BEGIN

	UPDATE IGRUE_INVIO
	SET
	FILE_INVIO = @FileInvio
	WHERE ID_INVIO = @IdInvio
	
END
