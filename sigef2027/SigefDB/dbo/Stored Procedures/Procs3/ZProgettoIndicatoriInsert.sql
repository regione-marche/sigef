CREATE PROCEDURE [dbo].[ZProgettoIndicatoriInsert]
(
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
	INSERT INTO PROGETTO_INDICATORI
	(
		ID_DIM_X_PROGRAMMAZIONE, 
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VARIANTE, 
		COD_TIPO, 
		VALORE_PROGRAMMATO_RICHIESTO, 
		VALORE_REALIZZATO_RICHIESTO, 
		DATA_REGISTRAZIONE, 
		OPERATORE, 
		VALORE_PROGRAMMATO_AMMESSO, 
		VALORE_REALIZZATO_AMMESSO, 
		DATA_ISTRUTTORIA, 
		ISTRUTTORE
	)
	VALUES
	(
		@IdDimXProgrammazione, 
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdVariante, 
		@CodTipo, 
		@ValoreProgrammatoRichiesto, 
		@ValoreRealizzatoRichiesto, 
		@DataRegistrazione, 
		@Operatore, 
		@ValoreProgrammatoAmmesso, 
		@ValoreRealizzatoAmmesso, 
		@DataIstruttoria, 
		@Istruttore
	)
	SELECT SCOPE_IDENTITY() AS ID_PROGETTO_INDICATORI


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoIndicatoriInsert';

