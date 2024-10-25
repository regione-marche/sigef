CREATE PROCEDURE [dbo].[ZMandatiImpresaUpdate]
(
	@Id INT, 
	@IdImpresa INT, 
	@IdUtenteAbilitato INT, 
	@CodEnte VARCHAR(10), 
	@CodiceSportelloCaa CHAR(9), 
	@TipoMandato CHAR(3), 
	@Attivo BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@IdOperatoreInizio INT, 
	@IdOperatoreFine INT, 
	@SegnaturaMandato VARCHAR(100), 
	@SegnaturaRevoca VARCHAR(100)
)
AS
	UPDATE MANDATI_IMPRESA
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_UTENTE_ABILITATO = @IdUtenteAbilitato, 
		COD_ENTE = @CodEnte, 
		CODICE_SPORTELLO_CAA = @CodiceSportelloCaa, 
		TIPO_MANDATO = @TipoMandato, 
		ATTIVO = @Attivo, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ID_OPERATORE_INIZIO = @IdOperatoreInizio, 
		ID_OPERATORE_FINE = @IdOperatoreFine, 
		SEGNATURA_MANDATO = @SegnaturaMandato, 
		SEGNATURA_REVOCA = @SegnaturaRevoca
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZMandatiImpresaUpdate]
(
	@Id INT, 
	@IdImpresa INT, 
	@IdUtenteAbilitato INT, 
	@CodiceSportelloCaa CHAR(9), 
	@TipoMandato CHAR(3), 
	@Attivo BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@IdOperatoreInizio INT, 
	@IdOperatoreFine INT, 
	@SegnaturaMandato VARCHAR(100), 
	@SegnaturaRevoca VARCHAR(100)
)
AS
	UPDATE MANDATI_IMPRESA
	SET
		ID_IMPRESA = @IdImpresa, 
		ID_UTENTE_ABILITATO = @IdUtenteAbilitato, 
		CODICE_SPORTELLO_CAA = @CodiceSportelloCaa, 
		TIPO_MANDATO = @TipoMandato, 
		ATTIVO = @Attivo, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ID_OPERATORE_INIZIO = @IdOperatoreInizio, 
		ID_OPERATORE_FINE = @IdOperatoreFine, 
		SEGNATURA_MANDATO = @SegnaturaMandato, 
		SEGNATURA_REVOCA = @SegnaturaRevoca
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZMandatiImpresaUpdate';

