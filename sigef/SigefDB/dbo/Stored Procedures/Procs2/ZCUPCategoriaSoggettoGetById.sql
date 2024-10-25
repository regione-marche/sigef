



CREATE PROCEDURE [dbo].ZCUPCategoriaSoggettoGetById
(
	@IdCUPCategoriaSoggetto char(6)
)
AS
	SELECT *
	FROM TIPO_CUP_CATEGORIE_SOGGETTI
	WHERE 
		(COD_CUP_CATEGORIE_SOGGETTI = @IdCUPCategoriaSoggetto)




