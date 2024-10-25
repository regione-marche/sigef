CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioDelete]
(
	@IdPagamentoBeneficiario INT
)
AS
	DELETE PAGAMENTI_BENEFICIARIO
	WHERE 
		(ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiario)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioDelete]
(
	@IdPagamentoBeneficiario INT
)
AS
	DELETE PAGAMENTI_BENEFICIARIO
	WHERE 
		(ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiario)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiBeneficiarioDelete';

