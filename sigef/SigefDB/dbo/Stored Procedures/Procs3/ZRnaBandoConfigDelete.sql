CREATE PROCEDURE ZRnaBandoConfigDelete
(
	@IdRnaBandoConfig INT
)
AS
	DELETE RNA_BANDO_CONFIG
	WHERE 
		(ID_RNA_BANDO_CONFIG = @IdRnaBandoConfig)

GO