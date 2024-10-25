CREATE PROCEDURE [dbo].[ZBandoUpdate]
(
	@IdBando INT, 
	@CodEnte VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@ParoleChiave VARCHAR(255), 
	@DataInserimento DATETIME, 
	@DisposizioniAttuative BIT, 
	@IdSchedaValutazione INT, 
	@Multiprogetto BIT, 
	@Multimisura BIT, 
	@InteresseFiliera BIT, 
	@FascicoloRichiesto BIT, 
	@IdStoricoUltimo INT, 
	@DataApertura DATETIME, 
	@IdModelloDomanda INT, 
	@IdProgrammazione INT, 
	@IdIntegrazioneUltima INT, 
	@FirmaRichiesta BIT, 
	@AbilitaValutazione BIT
)
AS
	UPDATE BANDO
	SET
		COD_ENTE = @CodEnte, 
		DESCRIZIONE = @Descrizione, 
		PAROLE_CHIAVE = @ParoleChiave, 
		DATA_INSERIMENTO = @DataInserimento, 
		DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuative, 
		ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione, 
		MULTIPROGETTO = @Multiprogetto, 
		MULTIMISURA = @Multimisura, 
		INTERESSE_FILIERA = @InteresseFiliera, 
		FASCICOLO_RICHIESTO = @FascicoloRichiesto, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		DATA_APERTURA = @DataApertura, 
		ID_MODELLO_DOMANDA = @IdModelloDomanda, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltima, 
		FIRMA_RICHIESTA = @FirmaRichiesta, 
		ABILITA_VALUTAZIONE = @AbilitaValutazione
	WHERE 
		(ID_BANDO = @IdBando)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoUpdate]
(
	@IdBando INT, 
	@CodEnte VARCHAR(255), 
	@Descrizione VARCHAR(2000), 
	@ParoleChiave VARCHAR(255), 
	@DataInserimento DATETIME, 
	@DisposizioniAttuative BIT, 
	@IdSchedaValutazione INT, 
	@Multiprogetto BIT, 
	@Multimisura BIT, 
	@InteresseFiliera BIT, 
	@FascicoloRichiesto BIT, 
	@IdStoricoUltimo INT, 
	@DataApertura DATETIME, 
	@IdModelloDomanda INT, 
	@IdProgrammazione INT, 
	@IdIntegrazioneUltima INT, 
	@FirmaRichiesta BIT, 
	@AbilitaValutazione BIT
)
AS
	UPDATE BANDO
	SET
		COD_ENTE = @CodEnte, 
		DESCRIZIONE = @Descrizione, 
		PAROLE_CHIAVE = @ParoleChiave, 
		DATA_INSERIMENTO = @DataInserimento, 
		DISPOSIZIONI_ATTUATIVE = @DisposizioniAttuative, 
		ID_SCHEDA_VALUTAZIONE = @IdSchedaValutazione, 
		MULTIPROGETTO = @Multiprogetto, 
		MULTIMISURA = @Multimisura, 
		INTERESSE_FILIERA = @InteresseFiliera, 
		FASCICOLO_RICHIESTO = @FascicoloRichiesto, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		DATA_APERTURA = @DataApertura, 
		ID_MODELLO_DOMANDA = @IdModelloDomanda, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		ID_INTEGRAZIONE_ULTIMA = @IdIntegrazioneUltima, 
		FIRMA_RICHIESTA = @FirmaRichiesta, 
		ABILITA_VALUTAZIONE = @AbilitaValutazione
	WHERE 
		(ID_BANDO = @IdBando)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoUpdate';

