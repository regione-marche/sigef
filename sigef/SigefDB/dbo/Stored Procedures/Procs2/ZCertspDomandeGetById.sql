CREATE PROCEDURE [dbo].[ZCertspDomandeGetById]
(
	@IdDomanda INT
)
AS
	SELECT *
	FROM CERTSP_DOMANDE
	WHERE 
		(ID_DOMANDA = @IdDomanda)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDomandeGetById';

