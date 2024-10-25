CREATE PROCEDURE [dbo].[ZCertificazioneContiDelete]
(
	@IdCertificazioneConti INT
)
AS
	DELETE CERTIFICAZIONE_CONTI
	WHERE 
		(ID_CERTIFICAZIONE_CONTI = @IdCertificazioneConti)