CREATE PROCEDURE [dbo].[ZRevocaOrdinativoIncassoDelete]
(
	@IdOrdinativoIncasso INT
)
AS
	DELETE REVOCA_ORDINATIVO_INCASSO
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)