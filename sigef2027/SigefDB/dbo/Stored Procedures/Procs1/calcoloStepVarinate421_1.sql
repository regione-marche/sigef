﻿CREATE PROCEDURE [dbo].[calcoloStepVarinate421_1]
@ID_VARIANTE  int
AS
BEGIN

 --Coerenza tra soggetto attuatore ed investimenti 
 -- IL CAPOFILA solo PUò AVERE :Ai sensi del PSR 2007-2013 - Interventi di coordinamento

DECLARE @Result int,@IdProgetto int
SET @Result = 1 -- Impongo lo Step verificato

set @IdProgetto = (select id_progetto from VARIANTI where ID_VARIANTE = @ID_VARIANTE )

IF((SELECT COUNT(*) as PRIVATO FROM PRIORITA_X_PROGETTO WHERE ID_VALORE = 908 AND ID_PROGETTO = @IdProgetto) =0 )
BEGIN 
	DECLARE @COUNT_COOR INT
	
	SELECT @COUNT_COOR=COUNT(*) FROM PIANO_INVESTIMENTI INV
	INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_DETTAGLIO_INVESTIMENTO = INV.ID_DETTAGLIO_INVESTIMENTO AND D.ID_CODIFICA_INVESTIMENTO = INV.ID_CODIFICA_INVESTIMENTO
	WHERE D.COD_DETTAGLIO ='1' AND  inv.ID_VARIANTE = @ID_VARIANTE AND ISNULL(COD_VARIAZIONE,0) != 'A'
	--SELECT @COUNT_COOR AS COR
	IF(@COUNT_COOR >0)SET @Result= 0
END

SELECT @Result 
END
