CREATE  PROCEDURE [dbo].[calcoloPriorita413_2FERM]
(@IdProgetto int,
@FASE_ISTRUTTORIA bit = 0,
@IdVariante INT
)
AS
BEGIN

-- Investimenti con utilizzo di Tecnologie di Informazione e Comunicazione >= 30% del totale degli investimenti

DECLARE @Punteggio decimal(10,2)
DECLARE @CostoTIC int
DECLARE @CostoTotInvestimenti decimal(10,2)

SET @Punteggio = 0			

	SET @CostoTIC = (SELECT SUM(ISNULL(PI.COSTO_INVESTIMENTO,0)) + SUM(ISNULL(PI.SPESE_GENERALI,0))
										 FROM vPIANO_INVESTIMENTI PI INNER JOIN PROGETTO P ON (PI.ID_PROGETTO = P.ID_PROGETTO)
										 WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) 
											AND   ((@fase_istruttoria=0 AND PI.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
		 									OR	(@fase_istruttoria=1 AND (PI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
											OR    (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'  )))
											 AND PI.CODICE IN ('d'))

	SET @CostoTotInvestimenti = (SELECT ISNULL(SUM(I.COSTO_INVESTIMENTO),0) + SUM(ISNULL(I.SPESE_GENERALI,0))
										  FROM PIANO_INVESTIMENTI I INNER JOIN PROGETTO P ON (I.ID_PROGETTO = P.ID_PROGETTO)
										  WHERE (P.ID_PROGETTO=@IdProgetto OR P.ID_PROG_INTEGRATO=@IdProgetto) AND I.COD_TIPO_INVESTIMENTO = 1
											AND ((@fase_istruttoria=0 AND I.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
											OR  (@fase_istruttoria=1 AND (I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
											OR	(ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A'  ) ) ))

-- Investimenti con utilizzo di Tecnologie di Informazione e Comunicazione >= 30% del totale degli investimenti

IF (@CostoTIC >= (@CostoTotInvestimenti * 0.30)) SET @Punteggio = 1
ELSE
	SET @Punteggio = 0			
END

SELECT @Punteggio AS PUNTEGGIO
