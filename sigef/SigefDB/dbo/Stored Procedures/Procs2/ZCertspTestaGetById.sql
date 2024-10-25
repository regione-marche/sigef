CREATE PROCEDURE [dbo].[ZCertspTestaGetById]
(
	@Idcertsp INT
)
AS
	SELECT *
	FROM CertSp_Testa
	WHERE 
		(IdCertSp = @Idcertsp)

GO