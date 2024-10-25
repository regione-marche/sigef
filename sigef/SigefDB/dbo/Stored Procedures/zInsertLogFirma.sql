CREATE PROCEDURE [dbo].[zInsertLogFirma]
(
	@TipoDocumento varchar(MAX),
	@ParametriDocumento varchar(MAX),
	@Operatore varchar(30),
	@TipoFirma  varchar(100),
	@DominioFirma varchar(50),
	@Esito varchar(50),
	@DettaglioEsito nvarchar(MAX),
	@DataFirma datetime
	
)
AS


INSERT INTO FIRMA_LOG
(
	 TIPO_DOCUMENTO
    ,PARAMETRI_DOCUMENTO
    ,OPERATORE
    ,DATA_FIRMA
    ,TIPO_FIRMA
	,DOMINIO_FIRMA
    ,ESITO
    ,DETTAGLIO_ESITO
    ,DATA_INSERIMENTO
    ,DATA_AGGIORNAMENTO
)
VALUES
(
	@TipoDocumento,
	@ParametriDocumento,
	@Operatore,
	@DataFirma, 
	@TipoFirma,
	@DominioFirma,
	@Esito,
	@DettaglioEsito,
	getdate(),
	getdate()
    
)



	SELECT CAST(SCOPE_IDENTITY() AS INT)

GO
