CREATE PROCEDURE [dbo].[ZCertDecertificazioneGetById]
(
	@IdCertDecertificazione INT
)
AS
	SELECT *
	FROM CERT_DECERTIFICAZIONE
	WHERE 
		(ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)