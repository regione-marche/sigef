﻿CREATE PROCEDURE [dbo].[SpPsrGraduatoriaRiepilogoSpesaXMisura]
(
	@ID_BANDO INT
)
AS
	SELECT SUM(COSTO_TOTALE) AS COSTO,SUM(CONTRIBUTO_DI_MISURA) AS CONTRIBUTO,MISURA,MISURA_PREVALENTE 
	FROM GRADUATORIA_PROGETTI_FINANZIABILITA F
	INNER JOIN PROGETTO P ON F.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN PROGETTO P2 ON P.ID_PROG_INTEGRATO=P2.ID_PROGETTO	
	WHERE P2.ID_BANDO=@ID_BANDO GROUP BY MISURA,MISURA_PREVALENTE ORDER BY MISURA_PREVALENTE DESC,MISURA