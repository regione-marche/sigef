create PROCEDURE [dbo].[rptEnte]
@COD_ENTE VARCHAR(16) 
AS
BEGIN	
	
	-- utilizzato in tutti i report in cui compare l'anagrafica, meno i report di presentazione della domanda di aiuto

	SELECT * FROM ENTE WHERE COD_ENTE = @COD_ENTE
		    
END
