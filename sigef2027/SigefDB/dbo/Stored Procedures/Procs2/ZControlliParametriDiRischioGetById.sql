CREATE PROCEDURE [dbo].[ZControlliParametriDiRischioGetById]
(
	@IdParametro INT
)
AS
	SELECT *
	FROM CONTROLLI_PARAMETRI_DI_RISCHIO
	WHERE 
		(ID_PARAMETRO = @IdParametro)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZControlliParametriDiRischioGetById';

