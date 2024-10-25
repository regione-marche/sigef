CREATE PROCEDURE [dbo].[zIgrueGetCodProcAttivazioneByIdBando]
	(
		@IdBando INT
	)
AS
BEGIN
	SELECT * FROM BANDO_CODICI_ATTIVAZIONE
	WHERE
	ID_BANDO = @IdBando
	
END
