CREATE PROCEDURE [dbo].[ZDecretiXDomPagEsportazioneInsert]
(
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@IdDecreto INT, 
	@Importo DECIMAL(18,2), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO DECRETI_X_DOM_PAG_ESPORTAZIONE
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_PROGETTO, 
		ID_DECRETO, 
		IMPORTO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdProgetto, 
		@IdDecreto, 
		@Importo, 
		@DataInserimento, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_DECRETI_X_DOM_PAG_ESPORTAZIONE, @DataInserimento AS DATA_INSERIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDecretiXDomPagEsportazioneInsert';

