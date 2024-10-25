CREATE PROCEDURE [dbo].[ZRegistroIrregolaritaGetById]
(
	@IdIrregolarita INT
)
AS
	SELECT *
	FROM VREGISTRO_IRREGOLARITA
	WHERE 
		(ID_IRREGOLARITA = @IdIrregolarita)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZRegistroIrregolaritaGetById]
(
	@IdIrregolarita INT
)
AS
	SELECT *
	FROM VREGISTRO_IRREGOLARITA
	WHERE 
		(ID_IRREGOLARITA = @IdIrregolarita)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZRegistroIrregolaritaGetById';

