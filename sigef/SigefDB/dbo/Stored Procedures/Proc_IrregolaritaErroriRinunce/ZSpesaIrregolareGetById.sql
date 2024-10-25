CREATE PROCEDURE [dbo].[ZSpesaIrregolareGetById]
(
	@IdSpesaIrregolare INT
)
AS
	SELECT *
	FROM VSPESA_IRREGOLARE
	WHERE 
		(ID_SPESA_IRREGOLARE = @IdSpesaIrregolare)

GO