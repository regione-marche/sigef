
CREATE PROCEDURE [dbo].[ZDatiMonitoraggioFESRDelete]
(
	@IdDatiMonitoraggioFESR INT
)
AS
	DELETE DATI_MONITORAGGIO_FESR
	WHERE 
		(ID_DATI_MONIT = @IdDatiMonitoraggioFESR)

