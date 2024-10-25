CREATE PROCEDURE [dbo].[calcoloStep112_121_2]
@IdProgetto int
AS
	-- L'aumento del rendimento globale dell'azienda, si considera ottenuto qualora gli investimenti richiesti
    -- in domanda siano volti al raggiungimento di almeno una delle condizioni indicate nella prima colonna della tabella XXX
    -- Tali condizioni si intendono soddisfatte quando il costo complessivo degli investimenti è per oltre il 50% riferibile
    -- ad una o più di esse

DECLARE @RESULT INT
SET @RESULT =0
/*
 
DECLARE @IdProgetto INT
SET @IdProgetto=356*/

-- TROVO IL PROGETTO INTEGRATO

DECLARE @ID_PROG_CORRENTE_121 INT, @ID_BANDO_121 INT 

SELECT DISTINCT @ID_PROG_CORRENTE_121 = p.ID_PROGETTO, @ID_BANDO_121=P.ID_BANDO FROM PROGETTO P
	INNER JOIN BANDO B ON B.ID_BANDO = P.ID_BANDO INNER JOIN ZPROGRAMMAZIONE ZP ON ZP.ID =B.ID_PROGRAMMAZIONE AND CODICE = '1.2.1.'
WHERE ID_PROG_INTEGRATO = @IdProgetto

DECLARE @TotaleInvestimenti decimal(10,2), @TotaleInvestimentiPriorita decimal(10,2)

SET @TotaleInvestimenti = ( SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0)
							FROM PIANO_INVESTIMENTI INNER JOIN PROGETTO ON PIANO_INVESTIMENTI.ID_PROGETTO=PROGETTO.ID_PROGETTO							
							WHERE PIANO_INVESTIMENTI.ID_PROGETTO=@ID_PROG_CORRENTE_121
                                  AND COD_TIPO_INVESTIMENTO = 1 AND ((PROGETTO.FLAG_DEFINITIVO=0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)
									OR (PROGETTO.FLAG_DEFINITIVO =1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL  AND  ID_VARIANTE IS NULL  ))
							  )


IF (@TotaleInvestimenti > 0 )	-- MODIFICA II SCADENZA e III scadenza
BEGIN	
-- Investimenti volti al miglioramento globale dell'azienda (ID_PRIORITA 102)
	SET @TotaleInvestimentiPriorita = ( 
									   SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) FROM PIANO_INVESTIMENTI
										INNER JOIN PROGETTO ON PIANO_INVESTIMENTI.ID_PROGETTO=PROGETTO.ID_PROGETTO							
									   WHERE PIANO_INVESTIMENTI.ID_PROGETTO=@ID_PROG_CORRENTE_121 AND ID_INVESTIMENTO IN 
										(SELECT ID_INVESTIMENTO FROM PRIORITA_X_INVESTIMENTI 
										WHERE ID_PRIORITA = 102) AND ((PROGETTO.FLAG_DEFINITIVO=0 AND ID_INVESTIMENTO_ORIGINALE IS NULL)
									OR (PROGETTO.FLAG_DEFINITIVO=1 AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND  ID_VARIANTE IS NULL ))
									  )
		
IF (@TotaleInvestimentiPriorita > (@TotaleInvestimenti/2)) SET @RESULT=1
END
ELSE SET @RESULT=1

SELECT @RESULT AS RESULT
