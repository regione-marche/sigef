CREATE PROCEDURE ZRnaBandoConfigGetById
(
	@IdRnaBandoConfig INT
)
AS
	SELECT *
	FROM RNA_BANDO_CONFIG
	WHERE 
		(ID_RNA_BANDO_CONFIG = @IdRnaBandoConfig)

GO