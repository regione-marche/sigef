CREATE PROCEDURE [dbo].[calcoloPriorita413_3_S]
(
@IdProgetto int,
@fase_istruttoria bit,
@IdVariante INT
)
AS
BEGIN
-- Investimenti relativi all`utilizzo delle Tecnologie di Informazione e Comunicazione >= 2% del totale investimenti (escluse le spese tecniche)
-- non obbligatorio

--declare @IdProgetto int, 
--@FASE_ISTRUTTORIA INT 

--set @IdProgetto = 834 
-- set @FASE_ISTRUTTORIA =0

DECLARE @COSTO_INVESTIMENTO DECIMAL(18,2), 
		@SPESE_TIC DECIMAL (18,2),
		@Punteggio decimal(10,2)
SET @Punteggio = 0

SELECT @COSTO_INVESTIMENTO=SUM(ISNULL(COSTO_INVESTIMENTO,0))  FROM PIANO_INVESTIMENTI INV 
WHERE ID_PROGETTO = @IdProgetto AND
			((@fase_istruttoria=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
				OR (@fase_istruttoria=1 AND (INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
				OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A' )))
  
SELECT @SPESE_TIC= SUM(ISNULL(COSTO_INVESTIMENTO,0)) 
	 FROM VPIANO_INVESTIMENTI INV 
		INNER JOIN DETTAGLIO_INVESTIMENTI D ON D.ID_DETTAGLIO_INVESTIMENTO = INV.ID_DETTAGLIO_INVESTIMENTO 
	 WHERE ID_PROGETTO = @IdProgetto AND D.COD_DETTAGLIO IN ('m')
	 AND ((@fase_istruttoria=0 AND INV.ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL )
			OR (@fase_istruttoria=1 AND (INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE  IS NULL AND @IdVariante IS NULL) 
			OR (ID_VARIANTE  = @IdVariante AND @IdVariante IS NOT NULL AND ISNULL(COD_VARIAZIONE, 'X' ) != 'A' )))
 
 
 IF(ISNULL(@SPESE_TIC,0) >= @COSTO_INVESTIMENTO*2 /100) SET @Punteggio = 1
ELSE SET  @Punteggio= 0
SELECT @Punteggio AS PUNTEGGIO
END
