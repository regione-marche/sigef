﻿CREATE PROCEDURE [dbo].[RptQuadroDettaglio133Select]
(
@ID_Domanda int
)
AS
BEGIN	

SET NOCOUNT ON;

--DECLARE @ID_Domanda int 
--SET @ID_Domanda = 9409

DECLARE @ID_VARIANTE int 
DECLARE @FASE BIT


SET @ID_VARIANTE =(SELECT MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO=@ID_Domanda AND APPROVATA = 1)
SET @FASE = (SELECT CASE WHEN ORDINE_FASE>2 THEN 1 ELSE 0 END FROM vPROGETTO WHERE ID_PROGETTO = @ID_Domanda)


IF((SELECT COUNT(I.ID_INVESTIMENTO) 
				FROM vPROGETTO AS P INNER JOIN VPIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO
				WHERE P.ID_PROGETTO=@ID_Domanda AND
					((ORDINE_FASE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
					(ORDINE_FASE<4 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
					(ORDINE_FASE>=4  AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
					 ID_VARIANTE=@ID_VARIANTE)))) > 0) 
 

SELECT P.ID_PROGETTO, VP.DESCRIZIONE AS ANNO,DETTAGLIO_INVESTIMENTI, 
	SUM(PIN.COSTO_INVESTIMENTO) AS COSTO_INVESTIMENTO, SUM(PIN.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO_RICHIESTO,                      
	PIN.CODIFICA_INVESTIMENTO AS CODIFICA, PIN.ID_CODIFICA_INVESTIMENTO
FROM vPROGETTO AS P 
	INNER JOIN vPIANO_INVESTIMENTI AS PIN ON P.ID_PROGETTO = PIN.ID_PROGETTO
	INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON PXI.ID_INVESTIMENTO = PIN.ID_INVESTIMENTO AND PXI.ID_PRIORITA in (404, 228, 384, 859, 1080, 1130, 1418) 
	INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE = VP.ID_VALORE
WHERE P.ID_PROGETTO = @ID_Domanda AND
	((ORDINE_FASE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
	(ORDINE_FASE<4 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
	(ORDINE_FASE>=4  AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) OR
	 ID_VARIANTE=@ID_VARIANTE)))
	 AND ISNULL(COD_VARIAZIONE, 'X')!= 'A'  
GROUP BY P.ID_PROGETTO, VP.DESCRIZIONE, PIN.CODIFICA_INVESTIMENTO, DETTAGLIO_INVESTIMENTI, PIN.ID_CODIFICA_INVESTIMENTO
ORDER BY P.ID_PROGETTO, ANNO


ELSE SELECT NULL AS ID_PROGETTO,
            NULL AS ANNO,
		    NULL AS COSTO_INVESTIMENTO,
		    NULL AS CONTRIBUTO_RICHIESTO,
		    NULL AS CODIFICA,
		    NULL AS ID_CODIFICA_INVESTIMENTO, 
			NULL AS ID_CODIFICA_INVESTIMENTO

END