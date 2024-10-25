CREATE PROCEDURE [dbo].[ZCertspDettaglioDelete]
(
	@IdcertspDettaglio INT
)
AS
	DELETE CertSp_Dettaglio
	WHERE 
		(IdCertSp_Dettaglio = @IdcertspDettaglio)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspDettaglioDelete]
(
	@IdcertspDettaglio INT
)
AS
	DELETE CertSp_Dettaglio
	WHERE 
		(IdCertSp_Dettaglio = @IdcertspDettaglio)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDettaglioDelete';

