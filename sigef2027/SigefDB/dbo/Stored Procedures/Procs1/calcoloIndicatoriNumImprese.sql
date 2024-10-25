




CREATE PROCEDURE [dbo].[calcoloIndicatoriNumImprese] 
(
	@ID_PROGETTO int 
)

AS

	SELECT DISTINCT COUNT(DISTINCT CODICE_FISCALE) AS ValoreRTot
	FROM   dbo.vCO01GetListPIva 
	WHERE  ID_PROGETTO = @ID_PROGETTO

