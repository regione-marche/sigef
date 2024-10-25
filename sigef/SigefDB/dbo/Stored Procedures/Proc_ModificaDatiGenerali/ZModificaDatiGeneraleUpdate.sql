CREATE PROCEDURE [dbo].[ZModificaDatiGeneraleUpdate]
(
	@IdModifica INT, 
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
	SET @DataModifica=getdate()
	UPDATE MODIFICA_DATI_GENERALE
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA = @IdDomanda, 
		ID_VARIANTE = @IdVariante, 
		ID_UTENTE_MODIFICA = @IdUtenteModifica, 
		DATA_MODIFICA = @DataModifica, 
		COD_TIPO_MODIFICA = @CodTipoModifica, 
		NOTE = @Note, 
		ISTANZA_PRECEDENTE = @IstanzaPrecedente, 
		ISTANZA_NUOVO = @IstanzaNuovo
	WHERE 
		(ID_MODIFICA = @IdModifica)
	SELECT @DataModifica;

GO