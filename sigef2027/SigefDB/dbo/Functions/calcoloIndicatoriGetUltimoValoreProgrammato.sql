
create FUNCTION [dbo].[calcoloIndicatoriGetUltimoValoreProgrammato] (@idProgetto int, @idDimXProg int, @dataMax date)
RETURNS DECIMAL(18,2)
AS
--Trova l'inserimento più recente in tabella PROGETTO_INDICATORI che però sia stato approvato, tra queste date:
-- data del passaggio a Finanziabile
-- data dell'accettazione della variazione, la più recente
BEGIN
DECLARE @DataUlt DATE, @IdPI INT, @ValUltimo decimal(18,2)
DECLARE @ESITO INT, @DATA_ESITO DATE, @VAL_ESITO decimal(18,2)

--
SELECT top 1 @IdPI=PIN.ID_PROGETTO_INDICATORI, @DataUlt=PS.DATA, @ValUltimo =  PIN.VALORE_PROGRAMMATO_AMMESSO
FROM PROGETTO_INDICATORI PIN 
	INNER JOIN PROGETTO_STORICO PS ON PIN.ID_PROGETTO = PS.ID_PROGETTO
WHERE PIN.ID_PROGETTO = @idProgetto 
		AND PIN.ID_DIM_X_PROGRAMMAZIONE = @idDimXProg
		AND PS.COD_STATO ='F'
		AND PIN.VALORE_PROGRAMMATO_AMMESSO IS NOT NULL
	    AND PIN.ID_DOMANDA_PAGAMENTO IS NULL
		AND PIN.ID_VARIANTE IS NULL

IF @DataUlt IS NULL OR (NOT @dataMax IS NULL AND @DataUlt > @dataMax )
	SET @ESITO = 0 -- Il progetto non è finanziabile
	
ELSE
  BEGIN
	SET @ESITO = @IdPI
	SET @DATA_ESITO = @DataUlt
	SET @VAL_ESITO = @ValUltimo

	SELECT top 1 @IdPI=PIN.ID_PROGETTO_INDICATORI, @DataUlt=VA.DATA_APPROVAZIONE, @ValUltimo =  PIN.VALORE_PROGRAMMATO_AMMESSO
	FROM PROGETTO_INDICATORI PIN
		INNER JOIN VARIANTI VA ON PIN.ID_VARIANTE = VA.ID_VARIANTE
	WHERE PIN.ID_PROGETTO = @idProgetto 
		AND PIN.ID_DIM_X_PROGRAMMAZIONE = @idDimXProg
		AND PIN.VALORE_PROGRAMMATO_AMMESSO IS NOT NULL
		AND VA.APPROVATA = 1
		AND VA.DATA_APPROVAZIONE IS NOT NULL
	ORDER BY VA.DATA_APPROVAZIONE DESC
	
	IF @DataUlt IS NOT NULL AND ( @dataMax IS NULL OR @DataUlt < @dataMax ) AND @DataUlt > @DATA_ESITO
	BEGIN
		SET @ESITO = @IdPI
		SET @DATA_ESITO = @DataUlt
		SET @VAL_ESITO = @ValUltimo
	END
  END

RETURN @VAL_ESITO   

END



