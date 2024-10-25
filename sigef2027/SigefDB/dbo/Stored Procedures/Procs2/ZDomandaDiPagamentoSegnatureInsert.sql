CREATE PROCEDURE [dbo].[ZDomandaDiPagamentoSegnatureInsert]
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
	SET @RiapriDomanda = ISNULL(@RiapriDomanda,((0)))
	INSERT INTO DOMANDA_DI_PAGAMENTO_SEGNATURE
	(
		ID_DOMANDA_PAGAMENTO, 
		COD_TIPO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		MOTIVAZIONE, 
		RIAPRI_DOMANDA
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@CodTipo, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@Motivazione, 
		@RiapriDomanda
	)
	SELECT @RiapriDomanda AS RIAPRI_DOMANDA

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDomandaDiPagamentoSegnatureInsert';

