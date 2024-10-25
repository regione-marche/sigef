CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFinanziabilitaGetById]
(
	@IdBando INT, 
	@IdProgetto INT
)
AS
	SELECT *
	FROM GRADUATORIA_PROGETTI_FINANZIABILITA
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFinanziabilitaGetById';

