CREATE PROCEDURE [dbo].[ZControlliParametriXDomandaInsert]
(
	@IdDomandaPagamento INT, 
	@IdParametro INT, 
	@IdLotto INT, 
	@Punteggio INT, 
	@DataValutazione DATETIME, 
	@Operatore VARCHAR(16)
)
AS
	INSERT INTO CONTROLLI_PARAMETRI_X_DOMANDA
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PARAMETRO, 
		ID_LOTTO, 
		PUNTEGGIO, 
		DATA_VALUTAZIONE, 
		OPERATORE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdParametro, 
		@IdLotto, 
		@Punteggio, 
		@DataValutazione, 
		@Operatore
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriXDomandaInsert';

