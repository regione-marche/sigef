CREATE PROCEDURE [dbo].[ZProgettoSegnatureDelete]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3)
)
AS
	DELETE PROGETTO_SEGNATURE
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZProgettoSegnatureDelete]
(
	@IdProgetto INT, 
	@CodTipo CHAR(3)
)
AS
	DELETE PROGETTO_SEGNATURE
	WHERE 
		(ID_PROGETTO = @IdProgetto) AND 
		(COD_TIPO = @CodTipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoSegnatureDelete';

