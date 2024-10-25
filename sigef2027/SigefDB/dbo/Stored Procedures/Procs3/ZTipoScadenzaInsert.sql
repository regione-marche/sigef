CREATE PROCEDURE [dbo].[ZTipoScadenzaInsert]
(
	@Descrizione VARCHAR(255), 
	@QuerySql VARCHAR(3000), 
	@ValMinimo VARCHAR(20), 
	@ValMassimo VARCHAR(20), 
	@MessaggioBase VARCHAR(2000), 
	@UrlBase VARCHAR(100)
)
AS
	INSERT INTO TIPO_SCADENZA
	(
		DESCRIZIONE, 
		QUERY_SQL, 
		VAL_MINIMO, 
		VAL_MASSIMO, 
		MESSAGGIO_BASE, 
		URL_BASE
	)
	VALUES
	(
		@Descrizione, 
		@QuerySql, 
		@ValMinimo, 
		@ValMassimo, 
		@MessaggioBase, 
		@UrlBase
	)
	SELECT SCOPE_IDENTITY() AS COD_TIPO_SCADENZA
