﻿
CREATE PROCEDURE [dbo].[RptQuadroCSelect]
@ID_Domanda int, 
@Cod_Tipo char(1)
AS
BEGIN	
	
SET NOCOUNT ON;

DECLARE @Count int
SET @Count = (SELECT COUNT(*)
              FROM PROGETTO_ALLEGATI  AXP LEFT JOIN ALLEGATI A ON (AXP.ID_ALLEGATO = A.ID_ALLEGATO) 
              WHERE AXP.ID_PROGETTO = @ID_Domanda AND COD_TIPO = @Cod_Tipo)

DECLARE @ID_MODELLO INT
SELECT @ID_MODELLO = ID_DOMANDA FROM PROGETTO P INNER JOIN MODELLO_DOMANDA M ON P.ID_BANDO = M.ID_BANDO
WHERE ID_PROGETTO = @ID_Domanda

IF (@Count > 0)

SELECT AXP.DESCRIZIONE, NULL AS ALTRO_DESCRIZIONE, GIA_PRESENTATO, DESCRIZIONE_BREVE, TIPO_ALLEGATO AS TIPO_DOCUMENTO, COD_TIPO
FROM      vALLEGATI_X_DOMANDA  AXP INNER JOIN PROGETTO_ALLEGATI A ON (AXP.ID_ALLEGATO = A.ID_ALLEGATO)
WHERE     (ID_PROGETTO = @ID_Domanda) AND COD_TIPO = @Cod_Tipo
AND ID_DOMANDA = @ID_MODELLO
ORDER BY AXP.ORDINE 
                                
ELSE SELECT NULL AS DESCRIZIONE,	 
		    NULL AS ALTRO_DESCRIZIONE, NULL AS GIA_PRESENTATO, 
		    NULL AS DESCRIZIONE_BREVE, NULL AS TIPO_DOCUMENTO
		    
END