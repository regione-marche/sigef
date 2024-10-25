CREATE  PROCEDURE [dbo].[calcoloStep4131_AB]
(@IdProgetto int,
@FASE_ISTRUTTORIA bit = 0 
 
)
AS
BEGIN
-- Montefeltro
-- due dichiarazioni sono alternative una all'altra
-- una dichiarazione è obbligatoria se presenta intervento A

DECLARE @Result int
DECLARE @CountInterventoA int
DECLARE @CountDichiarazioneINTa int

DECLARE @CountDichiarazioneAlternative int

SET @Result = 0			

SET @CountInterventoA = (SELECT count(*) FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON P.ID_PROGETTO=I.ID_PROGETTO WHERE
							I.ID_INVESTIMENTO_ORIGINALE IS NULL AND
							I.COD_TIPO_INVESTIMENTO = 1 AND
							P.ID_PROGETTO = @IdProgetto AND
							I.CODICE = 'A' 				
							)

SET @CountDichiarazioneINTa = (SELECT COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (806))

SET @CountDichiarazioneAlternative = (SELECT COUNT(*) FROM DICHIARAZIONI_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_DICHIARAZIONE IN (650,652))


IF (((isnull(@CountInterventoA,0) > 0 AND isnull(@CountDichiarazioneINTa,0) > 0) or (isnull(@CountInterventoA,0) = 0 AND isnull(@CountDichiarazioneINTa,0) = 0)) AND (@CountDichiarazioneAlternative = 1))
SET @Result = 1
ELSE
	SET @Result = 0			


SELECT @Result AS RESULT

END
