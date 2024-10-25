CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiGetById]
(
	@IdBando INT, 
	@IdProgetto INT
)
AS
	SELECT *
	FROM GRADUATORIA_PROGETTI
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiGetById]
(
	@IdBando INT, 
	@IdProgetto INT
)
AS
	SELECT *
	FROM GRADUATORIA_PROGETTI
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiGetById';

