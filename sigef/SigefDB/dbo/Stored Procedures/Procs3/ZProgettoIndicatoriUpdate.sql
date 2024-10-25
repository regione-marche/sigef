CREATE PROCEDURE [dbo].[ZProgettoIndicatoriUpdate]
(
	@IdProgettoIndicatori INT, 
	@IdDimXProgrammazione INT, 
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdVariante INT, 
	@CodTipo VARCHAR(255), 
	@ValoreProgrammatoRichiesto DECIMAL(18,2), 
	@ValoreRealizzatoRichiesto DECIMAL(18,2), 
	@DataRegistrazione DATETIME, 
	@Operatore INT, 
	@ValoreProgrammatoAmmesso DECIMAL(18,2), 
	@ValoreRealizzatoAmmesso DECIMAL(18,2), 
	@DataIstruttoria DATETIME, 
	@Istruttore INT
)
AS
	UPDATE PROGETTO_INDICATORI
	SET
		ID_DIM_X_PROGRAMMAZIONE = @IdDimXProgrammazione, 
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VARIANTE = @IdVariante, 
		COD_TIPO = @CodTipo, 
		VALORE_PROGRAMMATO_RICHIESTO = @ValoreProgrammatoRichiesto, 
		VALORE_REALIZZATO_RICHIESTO = @ValoreRealizzatoRichiesto, 
		DATA_REGISTRAZIONE = @DataRegistrazione, 
		OPERATORE = @Operatore, 
		VALORE_PROGRAMMATO_AMMESSO = @ValoreProgrammatoAmmesso, 
		VALORE_REALIZZATO_AMMESSO = @ValoreRealizzatoAmmesso, 
		DATA_ISTRUTTORIA = @DataIstruttoria, 
		ISTRUTTORE = @Istruttore
	WHERE 
		(ID_PROGETTO_INDICATORI = @IdProgettoIndicatori)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoIndicatoriUpdate';

