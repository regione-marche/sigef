﻿CREATE PROCEDURE [dbo].[calcoloStepVariante112_114_5]
@ID_VARIANTE int
AS  
 DECLARE @RESULT INT
 SET @RESULT =1
-- ELIMINZIONE DELLA CONSULENZA  NON DEVE ESSERE AZZERATO 
--declare 
--set  @ID_VARIANTE =1051

DECLARE @ID_PROGETTO INT, @ID_PROGETTO_114 INT , 
		@COUNT_INV INT , @COUNT_C INT

SET @ID_PROGETTO  = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)

SELECT DISTINCT @ID_PROGETTO_114 = p.ID_PROGETTO  FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.4.' 
WHERE ID_PROG_INTEGRATO = @ID_PROGETTO

--SOLO SE LA VARIANTE è PER LA 114
SET @COUNT_INV = ( SELECT COUNT (*)  FROM  PIANO_INVESTIMENTI  I  WHERE ID_VARIANTE = @ID_VARIANTE AND ID_PROGETTO =  @ID_PROGETTO_114 AND (ISNULL(COD_VARIAZIONE , 'X' )!='A'  AND   COD_VARIAZIONE IS NOT NULL  )      )
--(SELECT id_investimento,  COD_VARIAZIONE, id_variante FROM  PIANO_INVESTIMENTI  I  WHERE ID_VARIANTE = @ID_VARIANTE AND ID_PROGETTO =  @ID_PROGETTO_114 AND (ISNULL(COD_VARIAZIONE , 'X' )!='A'  AND  COD_VARIAZIONE IS NOT NULL  )      )
--
--select  @COUNT_INV
IF( @COUNT_INV >0 ) BEGIN
		SET  @COUNT_C =(SELECT COUNT(*) FROM VPIANO_INVESTIMENTI I 
						WHERE ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE , 'X') != 'A' AND CODICE = '1' AND I.ID_PROGETTO = @ID_PROGETTO_114)

		SET @RESULT = ( SELECT COUNT(*) FROM VPIANO_INVESTIMENTI I
						WHERE ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE , 'X') != 'A' AND COSTO_INVESTIMENTO  >0  AND CODICE IN ( 'CG', 'BC','FO','SI' )  AND I.ID_PROGETTO = @ID_PROGETTO_114 )
 END

IF( @COUNT_C >0 OR @RESULT =0 ) SET @RESULT=0

SELECT @RESULT AS RESULT