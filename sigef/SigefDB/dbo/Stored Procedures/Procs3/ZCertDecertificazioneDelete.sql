CREATE PROCEDURE [dbo].[ZCertDecertificazioneDelete]
(
	@IdCertDecertificazione INT
)
AS
	DELETE CERT_DECERTIFICAZIONE
	WHERE 
		(ID_CERT_DECERTIFICAZIONE = @IdCertDecertificazione)