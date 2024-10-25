CREATE PROCEDURE [dbo].[ZIrregolaritaGetById]
(
	@IdIrregolarita INT
)
AS
	SELECT *
	FROM VIRREGOLARITA
	WHERE 
		(ID_IRREGOLARITA = @IdIrregolarita)

GO