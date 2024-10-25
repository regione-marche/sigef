CREATE PROCEDURE [dbo].[zIgrueGetInvioMonitoraggioByIdTicket]
	(
		@IdTicket VARCHAR(50)
	)
AS
BEGIN
	SELECT * FROM IGRUE_INVIO
	WHERE
	ID_TICKET = @IdTicket
	
END
