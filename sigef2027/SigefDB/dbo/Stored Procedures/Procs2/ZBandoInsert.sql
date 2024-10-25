CREATE PROCEDURE [dbo].[ZBandoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DisposizioniAttuative = ISNULL(@DisposizioniAttuative,((0)))
	SET @Multiprogetto = ISNULL(@Multiprogetto,((0)))
	SET @Multimisura = ISNULL(@Multimisura,((0)))
	SET @InteresseFiliera = ISNULL(@InteresseFiliera,((0)))
	SET @FascicoloRichiesto = ISNULL(@FascicoloRichiesto,((1)))
	SET @FirmaRichiesta = ISNULL(@FirmaRichiesta,((1)))
	SET @AbilitaValutazione = ISNULL(@AbilitaValutazione,((0)))
	INSERT INTO BANDO
	(
		COD_ENTE, 
		DESCRIZIONE, 
		PAROLE_CHIAVE, 
		DATA_INSERIMENTO, 
		DISPOSIZIONI_ATTUATIVE, 
		ID_SCHEDA_VALUTAZIONE, 
		MULTIPROGETTO, 
		MULTIMISURA, 
		INTERESSE_FILIERA, 
		FASCICOLO_RICHIESTO, 
		ID_STORICO_ULTIMO, 
		DATA_APERTURA, 
		ID_MODELLO_DOMANDA, 
		ID_PROGRAMMAZIONE, 
		ID_INTEGRAZIONE_ULTIMA, 
		FIRMA_RICHIESTA, 
		ABILITA_VALUTAZIONE
	)
	VALUES
	(
		@CodEnte, 
		@Descrizione, 
		@ParoleChiave, 
		@DataInserimento, 
		@DisposizioniAttuative, 
		@IdSchedaValutazione, 
		@Multiprogetto, 
		@Multimisura, 
		@InteresseFiliera, 
		@FascicoloRichiesto, 
		@IdStoricoUltimo, 
		@DataApertura, 
		@IdModelloDomanda, 
		@IdProgrammazione, 
		@IdIntegrazioneUltima, 
		@FirmaRichiesta, 
		@AbilitaValutazione
	)
	SELECT SCOPE_IDENTITY() AS ID_BANDO, @DataInserimento AS DATA_INSERIMENTO, @DisposizioniAttuative AS DISPOSIZIONI_ATTUATIVE, @Multiprogetto AS MULTIPROGETTO, @Multimisura AS MULTIMISURA, @InteresseFiliera AS INTERESSE_FILIERA, @FascicoloRichiesto AS FASCICOLO_RICHIESTO, @FirmaRichiesta AS FIRMA_RICHIESTA, @AbilitaValutazione AS ABILITA_VALUTAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoInsert]
(
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
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DisposizioniAttuative = ISNULL(@DisposizioniAttuative,((0)))
	SET @Multiprogetto = ISNULL(@Multiprogetto,((0)))
	SET @Multimisura = ISNULL(@Multimisura,((0)))
	SET @InteresseFiliera = ISNULL(@InteresseFiliera,((0)))
	SET @FascicoloRichiesto = ISNULL(@FascicoloRichiesto,((1)))
	SET @FirmaRichiesta = ISNULL(@FirmaRichiesta,((1)))
	SET @AbilitaValutazione = ISNULL(@AbilitaValutazione,((0)))
	INSERT INTO BANDO
	(
		COD_ENTE, 
		DESCRIZIONE, 
		PAROLE_CHIAVE, 
		DATA_INSERIMENTO, 
		DISPOSIZIONI_ATTUATIVE, 
		ID_SCHEDA_VALUTAZIONE, 
		MULTIPROGETTO, 
		MULTIMISURA, 
		INTERESSE_FILIERA, 
		FASCICOLO_RICHIESTO, 
		ID_STORICO_ULTIMO, 
		DATA_APERTURA, 
		ID_MODELLO_DOMANDA, 
		ID_PROGRAMMAZIONE, 
		ID_INTEGRAZIONE_ULTIMA, 
		FIRMA_RICHIESTA, 
		ABILITA_VALUTAZIONE
	)
	VALUES
	(
		@CodEnte, 
		@Descrizione, 
		@ParoleChiave, 
		@DataInserimento, 
		@DisposizioniAttuative, 
		@IdSchedaValutazione, 
		@Multiprogetto, 
		@Multimisura, 
		@InteresseFiliera, 
		@FascicoloRichiesto, 
		@IdStoricoUltimo, 
		@DataApertura, 
		@IdModelloDomanda, 
		@IdProgrammazione, 
		@IdIntegrazioneUltima, 
		@FirmaRichiesta, 
		@AbilitaValutazione
	)
	SELECT SCOPE_IDENTITY() AS ID_BANDO, @DataInserimento AS DATA_INSERIMENTO, @DisposizioniAttuative AS DISPOSIZIONI_ATTUATIVE, @Multiprogetto AS MULTIPROGETTO, @Multimisura AS MULTIMISURA, @InteresseFiliera AS INTERESSE_FILIERA, @FascicoloRichiesto AS FASCICOLO_RICHIESTO, @FirmaRichiesta AS FIRMA_RICHIESTA, @AbilitaValutazione AS ABILITA_VALUTAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoInsert';

