﻿CREATE PROCEDURE [dbo].[RptQuadroASelect_ContoCorrente]
@ID_Domanda int	
AS
BEGIN	

DECLARE @ID_IMPRESA int
SET @ID_IMPRESA = (SELECT ID_IMPRESA FROM dbo.PROGETTO WHERE ID_PROGETTO = @ID_Domanda)

IF (@ID_IMPRESA IS NOT NULL)
	BEGIN
		SELECT C.ID_CONTO_CORRENTE, 
				C.ID_IMPRESA,
				C.ID_PERSONA,
				C.COD_PAESE,
				C.CIN_EURO,
				C.CIN, 
				C.ABI,
				C.CAB,
				C.NUMERO,
				C.NOTE,
				C.DATA_INIZIO_VALIDITA,
				C.DATA_FINE_VALIDITA,
				C.ISTITUTO,
				C.AGENZIA,
				C.ID_COMUNE
				
		FROM IMPRESA I INNER JOIN CONTO_CORRENTE C ON I.ID_CONTO_CORRENTE_ULTIMO = C.ID_CONTO_CORRENTE
		
		WHERE I.ID_IMPRESA = @ID_IMPRESA
		ORDER BY C.ID_CONTO_CORRENTE DESC
	END

ELSE 
	BEGIN
		
		 SELECT NULL AS ID_CONTO_CORRENTE, 
				NULL AS ID_IMPRESA,
				NULL AS ID_PERSONA,
				NULL AS COD_PAESE,
				NULL AS CIN_EURO,
				NULL AS CIN, 
				NULL AS ABI,
				NULL AS CAB,
				NULL AS NUMERO,
				NULL AS NOTE,
				NULL AS DATA_INIZIO_VALIDITA,
				NULL AS DATA_FINE_VALIDITA,
				NULL AS ISTITUTO,
				NULL AS AGENZIA,
				NULL AS ID_COMUNE 
	END
END