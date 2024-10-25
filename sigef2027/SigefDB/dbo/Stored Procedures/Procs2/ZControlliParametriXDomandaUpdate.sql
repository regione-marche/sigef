CREATE PROCEDURE [dbo].[ZControlliParametriXDomandaUpdate]
(
	@IdDomandaPagamento INT, 
	@IdParametro INT, 
	@IdLotto INT, 
	@Punteggio INT, 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16)
)
AS
	UPDATE CONTROLLI_PARAMETRI_X_DOMANDA
	SET
		PUNTEGGIO = @Punteggio, 
		DATA_VALUTAZIONE = @DataValutazione, 
		OPERATORE = @Operatore
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(ID_PARAMETRO = @IdParametro) AND 
		(ID_LOTTO = @IdLotto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXDomandaUpdate';

