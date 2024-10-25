CREATE PROCEDURE [dbo].[ZCertspContiDelete]
(
	@IdConto INT
)
AS
	DELETE CERTSP_CONTI
	WHERE 
		(ID_CONTO = @IdConto)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZCertspContiDelete]
(
	@IdConto INT
)
AS
	DELETE CERTSP_CONTI
	WHERE 
		(ID_CONTO = @IdConto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspContiDelete';

