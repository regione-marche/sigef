CREATE PROCEDURE [dbo].[ZRevisioneDpagamentoEsitoUpdate]
(
	@Id INT, 
	@IdLotto INT, 
	@IdDomandaPagamento INT, 
	@IdVldStep INT, 
	@CodEsito VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT, 
	@Note VARCHAR(5000), 
	@EscludiDaComunicazione BIT
)
AS
	UPDATE REVISIONE_DPAGAMENTO_ESITO
	SET
		ID_LOTTO = @IdLotto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VLD_STEP = @IdVldStep, 
		COD_ESITO = @CodEsito, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		NOTE = @Note, 
		ESCLUDI_DA_COMUNICAZIONE = @EscludiDaComunicazione
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDpagamentoEsitoUpdate';

