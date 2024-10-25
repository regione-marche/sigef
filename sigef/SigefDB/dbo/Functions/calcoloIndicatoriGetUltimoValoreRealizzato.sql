



CREATE FUNCTION [dbo].[calcoloIndicatoriGetUltimoValoreRealizzato] (@idProgetto int, @idDimXProg int,  @dataMax date = NULL)
RETURNS DECIMAL(18,2)
AS
--Trova l'inserimento più recente in tabella PROGETTO_INDICATORI che però sia stato approvato, tra queste date:
-- data del passaggio a Finanziabile
-- data dell'accettazione dei vari pagamenti, il più recente
-- data dell'accettazione della variazione, la più recente
BEGIN
	DECLARE @DataUlt DATE, @IdPI INT, @ValUltimo decimal(18,2)
	DECLARE @ESITO INT, @DATA_ESITO DATE, @VAL_ESITO decimal(18,2)
	DECLARE @FaseProgetto INT, @StatoProgetto INT

-- Escludo i progetti che alla data siano in uno stato precedente l' 'F'=Finanziabile o Revocati,Esclusi,Rinuncia

	SELECT  TOP (1) @StatoProgetto = SP.ORDINE, @FaseProgetto = FP.ORDINE
	FROM  dbo.PROGETTO_STORICO AS PS INNER JOIN
							 dbo.STATO_PROGETTO AS SP ON PS.COD_STATO = SP.COD_STATO INNER JOIN
							 dbo.FASI_PROCEDURALI AS FP ON SP.COD_FASE = FP.COD_FASE
	WHERE (PS.DATA <= @dataMax OR @dataMax IS NULL) AND (PS.ID_PROGETTO = @idProgetto)
	ORDER BY PS.DATA DESC

	IF @FaseProgetto IS NULL OR (@StatoProgetto = 2 OR @FaseProgetto < 4) 
		SET @ESITO = 0
	ELSE
	  BEGIN
		SELECT top 1 @IdPI=PIN.ID_PROGETTO_INDICATORI, @DataUlt=PS.DATA, @ValUltimo =  PIN.VALORE_REALIZZATO_AMMESSO
		FROM PROGETTO_INDICATORI PIN 
			INNER JOIN PROGETTO_STORICO PS ON PIN.ID_PROGETTO = PS.ID_PROGETTO
		WHERE PIN.ID_PROGETTO = @idProgetto 
				AND PIN.ID_DIM_X_PROGRAMMAZIONE = @idDimXProg
				AND PS.COD_STATO ='F'
				AND PIN.VALORE_REALIZZATO_AMMESSO IS NOT NULL
				AND (PIN.ID_DOMANDA_PAGAMENTO IS NULL) AND (PIN.ID_VARIANTE IS NULL)

	--Se sono stati inseriti i valori in PROGETTO_INDICATORI per la fase di Presentazione prendo come data di riferimento 
	-- la data di Finanziabilità

		IF @DataUlt IS NOT NULL 
		  BEGIN
			SET @ESITO = @IdPI
			SET @DATA_ESITO = @DataUlt
			SET @VAL_ESITO = @ValUltimo
		  END 

		SELECT top 1 @IdPI=PIN.ID_PROGETTO_INDICATORI, @DataUlt=DP.DATA_APPROVAZIONE, @ValUltimo =  PIN.VALORE_REALIZZATO_AMMESSO
		FROM PROGETTO_INDICATORI PIN
			INNER JOIN DOMANDA_DI_PAGAMENTO DP ON PIN.ID_DOMANDA_PAGAMENTO = DP.ID_DOMANDA_PAGAMENTO
		WHERE PIN.ID_PROGETTO = @idProgetto 
			AND PIN.ID_DIM_X_PROGRAMMAZIONE = @idDimXProg
			AND PIN.VALORE_REALIZZATO_AMMESSO IS NOT NULL
			AND DP.APPROVATA = 1
			AND DP.DATA_APPROVAZIONE IS NOT NULL
		ORDER BY DP.DATA_APPROVAZIONE DESC
	
		IF @DataUlt IS NOT NULL AND ( @dataMax IS NULL OR @DataUlt < @dataMax ) AND (@DATA_ESITO IS NULL OR @DataUlt > @DATA_ESITO)
		  BEGIN
			SET @ESITO = @IdPI
			SET @DATA_ESITO = @DataUlt
			SET @VAL_ESITO = @ValUltimo
		  END

		SELECT top 1 @IdPI=PIN.ID_PROGETTO_INDICATORI, @DataUlt=VA.DATA_APPROVAZIONE, @ValUltimo =  PIN.VALORE_REALIZZATO_AMMESSO
		FROM PROGETTO_INDICATORI PIN
			INNER JOIN VARIANTI VA ON PIN.ID_VARIANTE = VA.ID_VARIANTE
		WHERE PIN.ID_PROGETTO = @idProgetto 
			AND PIN.ID_DIM_X_PROGRAMMAZIONE = @idDimXProg
			AND PIN.VALORE_REALIZZATO_AMMESSO IS NOT NULL
			AND VA.APPROVATA = 1
			AND VA.DATA_APPROVAZIONE IS NOT NULL
		ORDER BY VA.DATA_APPROVAZIONE DESC
	
		IF @DataUlt IS NOT NULL AND ( @dataMax IS NULL OR @DataUlt < @dataMax ) AND (@DATA_ESITO IS NULL OR @DataUlt > @DATA_ESITO)
		  BEGIN
			SET @ESITO = @IdPI
			SET @DATA_ESITO = @DataUlt
			SET @VAL_ESITO = @ValUltimo
		  END
	  END

	RETURN @VAL_ESITO   

END





