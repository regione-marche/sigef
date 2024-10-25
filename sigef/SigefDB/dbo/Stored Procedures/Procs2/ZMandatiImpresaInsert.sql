CREATE PROCEDURE [dbo].[ZMandatiImpresaInsert]
(
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
	SET @TipoMandato = ISNULL(@TipoMandato,((0)))
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO MANDATI_IMPRESA
	(
		ID_IMPRESA, 
		ID_UTENTE_ABILITATO, 
		COD_ENTE, 
		CODICE_SPORTELLO_CAA, 
		TIPO_MANDATO, 
		ATTIVO, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ID_OPERATORE_INIZIO, 
		ID_OPERATORE_FINE, 
		SEGNATURA_MANDATO, 
		SEGNATURA_REVOCA
	)
	VALUES
	(
		@IdImpresa, 
		@IdUtenteAbilitato, 
		@CodEnte, 
		@CodiceSportelloCaa, 
		@TipoMandato, 
		@Attivo, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@IdOperatoreInizio, 
		@IdOperatoreFine, 
		@SegnaturaMandato, 
		@SegnaturaRevoca
	)
	SELECT SCOPE_IDENTITY() AS ID, @TipoMandato AS TIPO_MANDATO, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZMandatiImpresaInsert]
(
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
	SET @TipoMandato = ISNULL(@TipoMandato,((0)))
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO MANDATI_IMPRESA
	(
		ID_IMPRESA, 
		ID_UTENTE_ABILITATO, 
		CODICE_SPORTELLO_CAA, 
		TIPO_MANDATO, 
		ATTIVO, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ID_OPERATORE_INIZIO, 
		ID_OPERATORE_FINE, 
		SEGNATURA_MANDATO, 
		SEGNATURA_REVOCA
	)
	VALUES
	(
		@IdImpresa, 
		@IdUtenteAbilitato, 
		@CodiceSportelloCaa, 
		@TipoMandato, 
		@Attivo, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@IdOperatoreInizio, 
		@IdOperatoreFine, 
		@SegnaturaMandato, 
		@SegnaturaRevoca
	)
	SELECT SCOPE_IDENTITY() AS ID, @TipoMandato AS TIPO_MANDATO, @Attivo AS ATTIVO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZMandatiImpresaInsert';

