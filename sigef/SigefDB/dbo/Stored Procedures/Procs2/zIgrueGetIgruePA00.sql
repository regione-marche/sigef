-- =============================================
CREATE PROCEDURE [dbo].[zIgrueGetIgruePA00]
(
@IdInvio INT
)
AS
BEGIN
	SELECT * FROM IGRUE_MONIT.dbo.IGRUE_PA00
	WHERE ID_INVIO = @IdInvio  
END
