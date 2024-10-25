CREATE PROCEDURE [dbo].[zIgrueGetLogErroriByIdTicket]
	(
		@IdTicket varchar(50)
	)
AS
BEGIN
	SELECT * FROM IGRUE_LOG_ERRORI
	WHERE
	ID_TICKET = @IdTicket
	
END
