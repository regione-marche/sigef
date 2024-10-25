


CREATE PROCEDURE [dbo].[ZCUPCategoriaGetById]
(
	@IdCUPCategoria char(7)
)
AS
	SELECT *
	FROM TIPO_CUP_CATEGORIE
	WHERE 
		(COD_CUP_CATEGORIE = @IdCUPCategoria)



