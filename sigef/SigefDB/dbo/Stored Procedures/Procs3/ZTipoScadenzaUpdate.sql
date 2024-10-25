CREATE PROCEDURE [dbo].[ZTipoScadenzaUpdate]
(
	@CodTipoScadenza INT, 
	@Descrizione VARCHAR(255), 
	@QuerySql VARCHAR(3000), 
	@ValMinimo VARCHAR(20), 
	@ValMassimo VARCHAR(20), 
	@MessaggioBase VARCHAR(2000), 
	@UrlBase VARCHAR(100)
)
AS
	UPDATE TIPO_SCADENZA
	SET
		DESCRIZIONE = @Descrizione, 
		QUERY_SQL = @QuerySql, 
		VAL_MINIMO = @ValMinimo, 
		VAL_MASSIMO = @ValMassimo, 
		MESSAGGIO_BASE = @MessaggioBase, 
		URL_BASE = @UrlBase
	WHERE 
		(COD_TIPO_SCADENZA = @CodTipoScadenza)
