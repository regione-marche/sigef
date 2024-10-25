
CREATE PROCEDURE [dbo].[ZDatiMonitoraggioFESRGetById]
(
	@IdDatiMonitoraggioFESR INT
)
AS
	SELECT *
	FROM DATI_MONITORAGGIO_FESR
	WHERE 
		(ID_DATI_MONIT = @IdDatiMonitoraggioFESR)

