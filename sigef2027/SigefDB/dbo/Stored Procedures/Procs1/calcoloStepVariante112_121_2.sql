CREATE PROCEDURE [dbo].[calcoloStepVariante112_121_2]
@ID_VARIANTE int
AS
	-- L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
    -- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
    -- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
    -- ad una o più di esse
    

DECLARE @RESULT INT
SET @RESULT =0
/*SET @IdProgetto=356*/
DECLARE @IdProgetto INT,@ID_PROG_CORRENTE_121 INT
DECLARE @TotaleInvestimenti decimal(10,2), @TotaleInvestimentiPriorita decimal(10,2)

SET @IdProgetto  = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)

-- TROVO IL PROGETTO INTEGRATO
SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO FROM PROGETTO P
INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

SET @TotaleInvestimenti = (
							   SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0)
							   FROM PIANO_INVESTIMENTI PI
							   WHERE  PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND COD_TIPO_INVESTIMENTO = 1  AND ID_PROGETTO = @ID_PROG_CORRENTE_121
						  )
IF (@TotaleInvestimenti > 0 )	-- MODIFICA II SCADENZA
BEGIN	
-- Investimenti volti al miglioramento globale dell'azienda (ID_PRIORITA 102)
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) 
										FROM PIANO_INVESTIMENTI PI
										WHERE PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND
									    PI.ID_PROGETTO=@ID_PROG_CORRENTE_121 AND ID_INVESTIMENTO IN 
										 (SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI 
													WHERE ID_PRIORITA = 102) 
									  )
		
IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SET @RESULT=1
END
ELSE SET @RESULT=1

SELECT @RESULT AS RESULT
