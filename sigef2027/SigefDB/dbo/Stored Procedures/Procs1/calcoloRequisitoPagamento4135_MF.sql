﻿CREATE PROCEDURE [dbo].[calcoloRequisitoPagamento4135_MF]
 @ID_DOMANDA_PAGAMENTO int
AS
BEGIN
 
--- massimale PER CODIFICA B -- NON PUò RICHEIDERE PER A MA NON POSSO CONTROLLARLO QUI

-- gal MONTEFELTRO MISURA 4135  - ANTICIPO
-- La domanda di anticipo è riferita esclusivamente alle spese previste per l`intervento b) della domanda d`aiuto
 
DECLARE @RESULT int,
		@ID_VARIANTE int,
		@CONTRIBUTO_RICHIESTO_CODIFICA_B DECIMAL (10,2),	 
	 	@CONTRIBUTO_ANTICIPO DECIMAL(10,2),
	 	@IdProgetto INT,
	 	@ID_BANDO INT
	
SET @RESULT = 0  -- Impongo lo Step NON verificato
set  @IdProgetto = ( SELECT ID_PROGETTO FROM DOMANDA_DI_PAGAMENTO WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  )

SET @ID_BANDO = (SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto )
-----------------------------------------------------------------------------------------------------------------------------
SET @ID_VARIANTE = (SELECT MAX(ID_VARIANTE) FROM VARIANTI WHERE ID_PROGETTO = @IdProgetto AND APPROVATA =1 AND ANNULLATA =0)
-----------------------------------------------------------------------------------------------------------------------------

IF (@ID_BANDO = 212)
 BEGIN
	SET @CONTRIBUTO_RICHIESTO_CODIFICA_B = (SELECT SUM(PI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
									  FROM PIANO_INVESTIMENTI PI INNER JOIN
										PROGETTO ON PI.ID_PROGETTO = PROGETTO.ID_PROGETTO
									  WHERE (PI.ID_PROGETTO = @IdProgetto) AND 
											PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM  CODIFICA_INVESTIMENTO WHERE ID_BANDO = 212 AND CODICE ='B') AND
											 ((@ID_VARIANTE IS NULL AND ID_VARIANTE IS NULL AND PI.ID_PROGETTO =@IdProgetto AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)OR
											  (@ID_VARIANTE IS NOT NULL AND ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X') != 'A')))
 END
									
IF (@ID_BANDO = 441)
 BEGIN
	SET @CONTRIBUTO_RICHIESTO_CODIFICA_B = (SELECT SUM(PI.CONTRIBUTO_RICHIESTO) AS CONTRIBUTO
									  FROM PIANO_INVESTIMENTI PI INNER JOIN
										PROGETTO ON PI.ID_PROGETTO = PROGETTO.ID_PROGETTO
									  WHERE (PI.ID_PROGETTO = @IdProgetto) AND 
											PI.ID_CODIFICA_INVESTIMENTO IN (SELECT ID_CODIFICA_INVESTIMENTO FROM  CODIFICA_INVESTIMENTO WHERE ID_BANDO = 441 AND CODICE ='B') AND
											 ((@ID_VARIANTE IS NULL AND ID_VARIANTE IS NULL AND PI.ID_PROGETTO =@IdProgetto AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)OR
											  (@ID_VARIANTE IS NOT NULL AND ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X') != 'A')))
 END										  
 
SET @CONTRIBUTO_ANTICIPO = (SELECT  ISNULL(CONTRIBUTO_RICHIESTO,0) FROM ANTICIPI_RICHIESTI WHERE ID_DOMANDA_PAGAMENTO = @ID_DOMANDA_PAGAMENTO  )

IF (@CONTRIBUTO_ANTICIPO <= ( ISNULL(@CONTRIBUTO_RICHIESTO_CODIFICA_B,0) * 0.5 ) ) SET @RESULT = 1
 
 SELECT @RESULT
 END
 
 
 
 --((@ID_VARIANTE IS NULL AND ID_VARIANTE IS NULL AND ID_PROGETTO =@IdProgetto AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL)OR
	--						(@ID_VARIANTE IS NOT NULL AND ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X') != 'A'))
