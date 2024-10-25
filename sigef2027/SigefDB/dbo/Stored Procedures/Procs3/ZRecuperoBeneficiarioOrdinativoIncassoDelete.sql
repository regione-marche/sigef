CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioOrdinativoIncassoDelete]
(
	@IdOrdinativoIncasso INT
)
AS
	DELETE RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)