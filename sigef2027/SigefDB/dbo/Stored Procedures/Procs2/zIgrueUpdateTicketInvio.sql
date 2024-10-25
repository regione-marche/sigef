CREATE PROCEDURE [dbo].[zIgrueUpdateTicketInvio]
	(
		@IdInvio INT,
		@IdTicket VARCHAR(50)
	)
AS
BEGIN

	UPDATE IGRUE_INVIO
	SET
	ID_TICKET = @IdTicket
	WHERE ID_INVIO = @IdInvio
	
END
