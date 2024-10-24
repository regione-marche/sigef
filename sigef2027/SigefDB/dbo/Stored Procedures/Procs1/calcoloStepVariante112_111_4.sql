﻿CREATE  PROCEDURE [dbo].[calcoloStepVariante112_111_4]
@ID_VARIANTE  int

-- 111 - Verifica massimali da intervento su corsi di formazione  
 
AS
-- TROVO IL PROGETTO INTEGRATO
DECLARE @ID_PROG_CORRENTE INT, @Result INT  , @IdProgetto INT

SET @Result = 0-- NON VERIFICATO 
SELECT  @IdProgetto= ID_PROGETTO    FROM VARIANTI WHERE ID_VARIANTE =  @ID_VARIANTE

DECLARE @ID_PROG_INTEG_111 INT

SELECT DISTINCT @ID_PROG_INTEG_111 = p.ID_PROGETTO FROM PROGETTO P
	INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.1.1.A'
WHERE ID_PROG_INTEGRATO = @IdProgetto


SET @Result = (SELECT  COUNT(*) AS C FROM  PIANO_INVESTIMENTi I
					INNER JOIN VPRIORITA_X_INVESTIMENTI PXI ON I.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND PXI.ID_PRIORITA in (384 ,1179)
				WHERE ID_PROGETTO = @ID_PROG_CORRENTE AND ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE, 'X') != 'A' 
				GROUP BY PXI.DESCRIZIONE 
				HAVING SUM(CONTRIBUTO_RICHIESTO) > 1500)

 SELECT isnull(@Result,0) AS RESULT
