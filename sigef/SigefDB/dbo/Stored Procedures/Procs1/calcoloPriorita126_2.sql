CREATE PROCEDURE [dbo].[calcoloPriorita126_2]
(
@IdProgetto int,
@fase_istruttoria bit,
@IdVariante int =NULL
)
AS
BEGIN
-- B.	Tipologia di ripristino del potenziale produttivo
--declare @IdProgetto int, @fase_istruttoria bit, @IdVariante int 
--set @IdProgetto =2305
--set @fase_istruttoria= 0
--set @IdVariante= 0
DECLARE @Risultato decimal (8,2), @COD_CODIFICA char (1)
SET @Risultato =0

SELECT TOP(1) @COD_CODIFICA =I.CODICE FROM vPIANO_INVESTIMENTI I
WHERE I.ID_PROGETTO =@IdProgetto AND ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
		OR (@fase_istruttoria=1 AND(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL ) 
		OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE,'X') != 'A'  ) ) )
		AND COSTO_INVESTIMENTO >0
GROUP BY I.CODICE 
ORDER BY SUM(COSTO_INVESTIMENTO) DESC

IF(@COD_CODIFICA IN('B'))SET @Risultato = 1
ELSE IF(@COD_CODIFICA IN('C'))SET @Risultato = 0.4

SELECT @Risultato 
END
