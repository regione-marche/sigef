CREATE PROCEDURE [dbo].[ZSpesaIrregolareDelete]
(
	@IdSpesaIrregolare INT
)
AS
	DELETE SPESA_IRREGOLARE
	WHERE 
		(ID_SPESA_IRREGOLARE = @IdSpesaIrregolare)

GO