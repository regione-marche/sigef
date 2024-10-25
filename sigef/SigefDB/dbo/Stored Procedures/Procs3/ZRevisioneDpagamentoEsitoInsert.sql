CREATE PROCEDURE [dbo].[ZRevisioneDpagamentoEsitoInsert]
(
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
	SET @EscludiDaComunicazione = ISNULL(@EscludiDaComunicazione,((0)))
	INSERT INTO REVISIONE_DPAGAMENTO_ESITO
	(
		ID_LOTTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VLD_STEP, 
		COD_ESITO, 
		DATA, 
		OPERATORE, 
		NOTE, 
		ESCLUDI_DA_COMUNICAZIONE
	)
	VALUES
	(
		@IdLotto, 
		@IdDomandaPagamento, 
		@IdVldStep, 
		@CodEsito, 
		@Data, 
		@Operatore, 
		@Note, 
		@EscludiDaComunicazione
	)
	SELECT SCOPE_IDENTITY() AS ID, @EscludiDaComunicazione AS ESCLUDI_DA_COMUNICAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRevisioneDpagamentoEsitoInsert';

