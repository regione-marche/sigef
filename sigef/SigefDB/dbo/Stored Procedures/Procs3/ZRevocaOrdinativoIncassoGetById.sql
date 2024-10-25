CREATE PROCEDURE [dbo].[ZRevocaOrdinativoIncassoGetById]
(
	@IdOrdinativoIncasso INT
)
AS
	SELECT *
	FROM REVOCA_ORDINATIVO_INCASSO
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)