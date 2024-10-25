CREATE  PROCEDURE [dbo].[calcoloPriorita413_6]
(@IdProgetto int,
@FASE_ISTRUTTORIA bit,
@IdVariante INT 
)
AS
BEGIN

-- Controllo dell'esistenza di investimenti destinati specifica (software e siti)

DECLARE @Punteggio decimal(10,2)
DECLARE @CountAsoftware int
DECLARE @CountBsiti int
DECLARE @CostoTIC int
DECLARE @CostoTotInvestimenti decimal(10,2)

SET @Punteggio = 0			

SET @CountAsoftware = (SELECT COUNT(I.ID_INVESTIMENTO) FROM vPIANO_INVESTIMENTI I INNER JOIN  PROGETTO P ON  I.ID_PROGETTO = P.ID_PROGETTO 
									         WHERE P.ID_PROGETTO=@IdProgetto AND 
									         I.COD_SPECIFICA = 'a' AND
											 ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL)
											 OR (@fase_istruttoria=1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @IdVariante IS NULL) 
											OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'))))


SET @CountBsiti = (SELECT COUNT(I.ID_INVESTIMENTO) 
								FROM vPIANO_INVESTIMENTI I  INNER JOIN PROGETTO P ON  I.ID_PROGETTO = P.ID_PROGETTO 
								WHERE P.ID_PROGETTO=@IdProgetto AND 
								I.COD_SPECIFICA = 'b' AND 
									 ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
									OR (@fase_istruttoria=1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
									OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'))))


IF (@CountBsiti > 0 AND @CountAsoftware > 0)
BEGIN
SET @CostoTIC = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO,0)) + SUM(ISNULL(PI.SPESE_GENERALI,0))
										 FROM vPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
										 WHERE P.ID_PROGETTO=@IdProgetto AND
											   PI.CODICE = '3' AND 
											   ((@fase_istruttoria=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
		 									    OR (@fase_istruttoria=1 AND (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
											    OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'))))

SET @CostoTotInvestimenti = (SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) + SUM(ISNULL(I.SPESE_GENERALI,0))
										  FROM PIANO_INVESTIMENTI I INNER JOIN PROGETTO P ON (I.ID_PROGETTO = P.ID_PROGETTO)
										  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND I.COD_TIPO_INVESTIMENTO = 1
											AND ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
											OR  (@fase_istruttoria=1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
											OR	(ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'))))

-- Quota investimenti per dettaglio investimento acquisizione di hardware e software > 5% del costo totale del progetto

IF (@CostoTIC >= (@CostoTotInvestimenti * 0.05)) SET @Punteggio = 1
ELSE
	SET @Punteggio = 0			
END

SELECT @Punteggio AS PUNTEGGIO
END
