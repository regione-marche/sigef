CREATE PROCEDURE [dbo].[ZGiustificativoXRegistroIrregolaritaGetById]
(
	@IdGiustificativoXIrregolarita INT
)
AS
	SELECT *
	FROM VGIUSTIFICATIVO_X_REGISTRO_IRREGOLARITA
	WHERE 
		(ID_GIUSTIFICATIVO_X_IRREGOLARITA = @IdGiustificativoXIrregolarita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGiustificativoXRegistroIrregolaritaGetById';

