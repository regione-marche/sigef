CREATE PROCEDURE [dbo].[ZCertspTestaDelete]
(
	@Idcertsp INT
)
AS
	DELETE CertSp_Testa
	WHERE 
		(IdCertSp = @Idcertsp)

GO