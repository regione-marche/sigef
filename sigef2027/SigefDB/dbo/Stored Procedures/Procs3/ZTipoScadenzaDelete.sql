CREATE PROCEDURE [dbo].[ZTipoScadenzaDelete]
(
	@CodTipoScadenza INT
)
AS
	DELETE TIPO_SCADENZA
	WHERE 
		(COD_TIPO_SCADENZA = @CodTipoScadenza)
