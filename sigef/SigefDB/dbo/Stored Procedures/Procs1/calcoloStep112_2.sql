CREATE PROCEDURE [dbo].[calcoloStep112_2]
@IdProgetto int
AS
BEGIN	

-- 112 - L'ammontare del mutuo non deve essere superiore a 200.000 €

DECLARE @TotaleMutuo decimal(10,2)


SET @TotaleMutuo = (SELECT ISNULL(SUM(PI.COSTO_INVESTIMENTO),0)
					FROM PIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (P.ID_PROGETTO=PI.ID_PROGETTO)
					WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
                         AND COD_TIPO_INVESTIMENTO = 2 AND ID_INVESTIMENTO_ORIGINALE IS NULL)


IF (@TotaleMutuo > 200000) SELECT 0 AS RESULT
ELSE SELECT 1 AS RESULT

END
