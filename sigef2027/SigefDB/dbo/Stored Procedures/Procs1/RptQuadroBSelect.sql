﻿CREATE PROCEDURE [dbo].[RptQuadroBSelect]
@ID_Domanda int, 
@Obbligatorio bit
AS
BEGIN	
	
SET NOCOUNT ON;

--DECLARE @ID_Domanda int
--set @ID_Domanda = 3243

DECLARE @Count int
SET @Count = (SELECT COUNT(*)
	FROM CATALOGO_DICHIARAZIONI CD INNER JOIN DICHIARAZIONI_X_PROGETTO DXP ON (CD.ID_DICHIARAZIONE = DXP.ID_DICHIARAZIONE)
                                   INNER JOIN DICHIARAZIONI_X_DOMANDA DXD ON (CD.ID_DICHIARAZIONE = DXD.ID_DICHIARAZIONE)
								   INNER JOIN PROGETTO P ON (DXP.ID_PROGETTO = P.ID_PROGETTO)
	WHERE DXP.ID_PROGETTO = @ID_Domanda AND
		  DXD.ID_DOMANDA = (SELECT ID_DOMANDA FROM MODELLO_DOMANDA WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda))
		 AND OBBLIGATORIO = @Obbligatorio )


IF (@Count > 0)

	SELECT CD.DESCRIZIONE
	FROM CATALOGO_DICHIARAZIONI CD INNER JOIN DICHIARAZIONI_X_PROGETTO DXP ON (CD.ID_DICHIARAZIONE = DXP.ID_DICHIARAZIONE)
                                   INNER JOIN DICHIARAZIONI_X_DOMANDA DXD ON (CD.ID_DICHIARAZIONE = DXD.ID_DICHIARAZIONE)
								   INNER JOIN PROGETTO P ON (DXP.ID_PROGETTO = P.ID_PROGETTO)
	WHERE DXP.ID_PROGETTO = @ID_Domanda AND
		  DXD.ID_DOMANDA = (SELECT ID_DOMANDA FROM MODELLO_DOMANDA WHERE ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda))
		 AND OBBLIGATORIO = @Obbligatorio 

	ORDER BY ORDINE, OBBLIGATORIO DESC
                        
ELSE SELECT NULL AS DESCRIZIONE		 
		    
END
