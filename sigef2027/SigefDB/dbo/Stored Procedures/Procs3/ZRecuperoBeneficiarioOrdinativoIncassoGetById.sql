CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioOrdinativoIncassoGetById]
(
	@IdOrdinativoIncasso INT
)
AS
	SELECT *
	FROM RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)
