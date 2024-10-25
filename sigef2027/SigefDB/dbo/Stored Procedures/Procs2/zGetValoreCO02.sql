




CREATE PROCEDURE [dbo].[zGetValoreCO02] (@ID_PROGETTO int, @COD_PSR varchar(100) = '', @idPrioritaI int = 0, @idIndicatore int = 0)
AS

	SELECT DISTINCT COUNT(DISTINCT CODICE_FISCALE) AS ValoreRTot
	FROM            dbo.vCO01GetListPIva 
	WHERE        ID_PROGETTO = @ID_PROGETTO
			



