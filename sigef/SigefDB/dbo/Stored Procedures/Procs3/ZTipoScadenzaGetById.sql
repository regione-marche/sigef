CREATE PROCEDURE [dbo].[ZTipoScadenzaGetById]
(
	@CodTipoScadenza INT
)
AS
	SELECT *
	FROM TIPO_SCADENZA
	WHERE 
		(COD_TIPO_SCADENZA = @CodTipoScadenza)
