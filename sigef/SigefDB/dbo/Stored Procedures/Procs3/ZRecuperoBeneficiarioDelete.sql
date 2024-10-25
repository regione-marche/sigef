CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioDelete]
(
	@IdRecuperoBeneficiario INT
)
AS
	DELETE RECUPERO_BENEFICIARIO
	WHERE 
		(ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiario)