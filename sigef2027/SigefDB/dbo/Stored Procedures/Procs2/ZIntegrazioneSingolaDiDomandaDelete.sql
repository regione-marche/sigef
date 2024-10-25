CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaDelete]
(
	@IdSingolaIntegrazione INT
)
AS
	DELETE INTEGRAZIONE_SINGOLA_DI_DOMANDA
	WHERE 
		(ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazione)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZIntegrazioneSingolaDiDomandaDelete]
(
	@IdSingolaIntegrazione INT
)
AS
	DELETE INTEGRAZIONE_SINGOLA_DI_DOMANDA
	WHERE 
		(ID_SINGOLA_INTEGRAZIONE = @IdSingolaIntegrazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIntegrazioneSingolaDiDomandaDelete';

