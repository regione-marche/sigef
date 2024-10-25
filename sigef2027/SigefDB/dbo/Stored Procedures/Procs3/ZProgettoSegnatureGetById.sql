CREATE PROCEDURE [dbo].[ZProgettoSegnatureGetById]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3)
)
AS
	SELECT *
	FROM vPROGETTO_SEGNATURE
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureGetById]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3)
)
AS
	SELECT *
	FROM vPROGETTO_SEGNATURE
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureGetById';

