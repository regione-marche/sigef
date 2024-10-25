CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioGetById]
(
	@IdRecuperoBeneficiario INT
)
AS
	SELECT *
	FROM RECUPERO_BENEFICIARIO
	WHERE 
		(ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiario)