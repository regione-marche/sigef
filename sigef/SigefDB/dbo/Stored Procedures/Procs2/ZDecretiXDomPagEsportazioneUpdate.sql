CREATE PROCEDURE [dbo].[ZDecretiXDomPagEsportazioneUpdate]
(
	@IdDecretiXDomPagEsportazione INT, 
	@IdDomandaPagamento INT, 
	@IdProgetto INT, 
	@IdDecreto INT, 
	@Importo DECIMAL(18,2), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME
)
AS
	SET @DataModifica=getdate()
	UPDATE DECRETI_X_DOM_PAG_ESPORTAZIONE
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_PROGETTO = @IdProgetto, 
		ID_DECRETO = @IdDecreto, 
		IMPORTO = @Importo, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_DECRETI_X_DOM_PAG_ESPORTAZIONE = @IdDecretiXDomPagEsportazione)
	SELECT @DataModifica;


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDecretiXDomPagEsportazioneUpdate';

