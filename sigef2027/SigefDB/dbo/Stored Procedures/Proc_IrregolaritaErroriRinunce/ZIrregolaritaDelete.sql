CREATE PROCEDURE [dbo].[ZIrregolaritaDelete]
(
	@IdIrregolarita INT
)
AS
	DELETE IRREGOLARITA
	WHERE 
		(ID_IRREGOLARITA = @IdIrregolarita)

GO