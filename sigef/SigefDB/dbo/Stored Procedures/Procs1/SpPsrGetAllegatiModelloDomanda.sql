﻿CREATE PROCEDURE [dbo].[SpPsrGetAllegatiModelloDomanda]
(
	@ID_MODELLO_DOMANDA INT,
	@MISURA VARCHAR(50)=NULL
)
AS

SELECT A.ID_ALLEGATO,A.DESCRIZIONE,MISURA,COD_TIPO,D.ID_DOMANDA,D.ORDINE,T.DESCRIZIONE AS TIPO_ALLEGATO 
FROM ALLEGATI A 
	INNER JOIN TIPO_ALLEGATO T ON A.COD_TIPO=T.CODICE 
    INNER JOIN ALLEGATI_X_DOMANDA D ON A.ID_ALLEGATO=D.ID_ALLEGATO AND D.ID_DOMANDA=@ID_MODELLO_DOMANDA 

UNION 

SELECT A.ID_ALLEGATO,A.DESCRIZIONE,MISURA,COD_TIPO, NULL ID_DOMANDA, NULL ORDINE, T.DESCRIZIONE AS TIPO_ALLEGATO 
FROM ALLEGATI A 
	INNER JOIN TIPO_ALLEGATO T ON A.COD_TIPO=T.CODICE  
WHERE ID_ALLEGATO NOT IN (SELECT ID_ALLEGATO FROM ALLEGATI_X_DOMANDA WHERE ID_DOMANDA = @ID_MODELLO_DOMANDA) 
AND ((A.MISURA LIKE '%'+  @MISURA + '%' AND @MISURA IS NOT NULL) OR (@MISURA IS NULL))
ORDER BY ID_DOMANDA DESC,ORDINE,A.ID_ALLEGATO, MISURA,DESCRIZIONE