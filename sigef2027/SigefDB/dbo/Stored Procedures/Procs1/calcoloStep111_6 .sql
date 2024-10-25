CREATE    PROCEDURE [dbo].[calcoloStep111_6 ]
@IdProgetto int
AS
BEGIN

-- OBIETTIVO Offerta formativa (azione C - Altra Formazione)

DECLARE @Result int, 
					@CODICE CHAR(2) , 
					@COSTO DECIMAL (18,2)

SET @Result = 1 -- Impongo lo Step verificato
--------------------------------------------------------------------------------------------------------------
    
DECLARE @COUNT_C INT, @COUNT_ATT INT
SET @COUNT_C = (SELECT COUNT(*) FROM  (SELECT     PI.ID_CODIFICA_INVESTIMENTO--, VP.ID_VALORE, VP.ID_PRIORITA
										FROM         PIANO_INVESTIMENTI AS PI LEFT OUTER JOIN
															  PRIORITA_X_INVESTIMENTI AS PXI ON PI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND PXI.ID_PRIORITA = 285 
										   left  JOIN  VALORI_PRIORITA AS VP ON VP.ID_VALORE = PXI.ID_VALORE
										WHERE     (PI.ID_PROGETTO = @IdProgetto) AND (PI.ID_INVESTIMENTO_ORIGINALE IS NULL)
										group by ID_CODIFICA_INVESTIMENTO)AS C
									 )
 
SET @COUNT_ATT  = ( SELECT COUNT(*) FROM  (SELECT    VP.ID_VALORE--, VP.ID_PRIORITA
											FROM         PIANO_INVESTIMENTI AS PI LEFT OUTER JOIN
																  PRIORITA_X_INVESTIMENTI AS PXI ON PI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND  PXI.ID_PRIORITA = 285  
											   LEFT  JOIN  VALORI_PRIORITA AS VP ON VP.ID_VALORE = PXI.ID_VALORE
											WHERE     (PI.ID_PROGETTO = @IdProgetto) AND (PI.ID_INVESTIMENTO_ORIGINALE IS NULL)  AND  VP.ID_VALORE IS NULL
											GROUP  BY  VP.ID_VALORE)AS C )
 

IF(@COUNT_ATT>0   OR   @COUNT_C >1 ) SET @Result =0
 
SELECT @Result AS RESULT


END
