CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoSegnatureUpdate]
(
	@IdDomandaPagamento INT, 
	@CodTipo CHAR(3), 
	@Data DATETIME, 
	@Operatore CHAR(16), 
	@Segnatura VARCHAR(100), 
	@Motivazione NTEXT, 
	@RiapriDomanda BIT
)
AS
	UPDATE DOMANDA_DI_PAGAMENTO_SEGNATURE
	SET
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		MOTIVAZIONE = @Motivazione, 
		RIAPRI_DOMANDA = @RiapriDomanda
	WHERE 
		(ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoSegnatureUpdate';

