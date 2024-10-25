CREATE PROCEDURE [dbo].[ZCertificazioneContiGetById]
(
	@IdCertificazioneConti INT
)
AS
	SELECT *
	FROM vCERTIFICAZIONE_CONTI
	WHERE 
		(ID_CERTIFICAZIONE_CONTI = @IdCertificazioneConti)