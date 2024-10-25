CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleInsert]
(
	@IdProgetto INT, 
	@IdDomanda INT, 
	@IdVariante INT, 
	@IdUtenteModifica INT, 
	@DataModifica DATETIME, 
	@CodTipoModifica INT, 
	@Note VARCHAR(max), 
	@IstanzaPrecedente XML, 
	@IstanzaNuovo XML
)
AS
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO MODIFICA_DATI_GENERALE
	(
		ID_PROGETTO, 
		ID_DOMANDA, 
		ID_VARIANTE, 
		ID_UTENTE_MODIFICA, 
		DATA_MODIFICA, 
		COD_TIPO_MODIFICA, 
		NOTE, 
		ISTANZA_PRECEDENTE, 
		ISTANZA_NUOVO
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomanda, 
		@IdVariante, 
		@IdUtenteModifica, 
		@DataModifica, 
		@CodTipoModifica, 
		@Note, 
		@IstanzaPrecedente, 
		@IstanzaNuovo
	)
	SELECT SCOPE_IDENTITY() AS ID_MODIFICA, @DataModifica AS DATA_MODIFICA

GO