CREATE PROCEDURE [dbo].[ZImpresaInsert]
(
	@Cuaa VARCHAR(255), 
	@CodiceFiscale VARCHAR(255), 
	@AnnoCostituzione INT, 
	@CodEnte VARCHAR(255), 
	@IscrizioneRegistroImprese VARCHAR(255), 
	@Presentazione NTEXT, 
	@Descrizione NTEXT, 
	@DataInizioAttivita DATETIME, 
	@IdStoricoUltimo INT, 
	@IdRapprlegaleUltimo INT, 
	@IdContoCorrenteUltimo INT, 
	@IdSedelegaleUltimo INT
)
AS
	INSERT INTO IMPRESA
	(
		CUAA, 
		CODICE_FISCALE, 
		ANNO_COSTITUZIONE, 
		COD_ENTE, 
		ISCRIZIONE_REGISTRO_IMPRESE, 
		PRESENTAZIONE, 
		DESCRIZIONE, 
		DATA_INIZIO_ATTIVITA, 
		ID_STORICO_ULTIMO, 
		ID_RAPPRLEGALE_ULTIMO, 
		ID_CONTO_CORRENTE_ULTIMO, 
		ID_SEDELEGALE_ULTIMO
	)
	VALUES
	(
		@Cuaa, 
		@CodiceFiscale, 
		@AnnoCostituzione, 
		@CodEnte, 
		@IscrizioneRegistroImprese, 
		@Presentazione, 
		@Descrizione, 
		@DataInizioAttivita, 
		@IdStoricoUltimo, 
		@IdRapprlegaleUltimo, 
		@IdContoCorrenteUltimo, 
		@IdSedelegaleUltimo
	)
	SELECT SCOPE_IDENTITY() AS ID_IMPRESA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaInsert]
(
	@Cuaa VARCHAR(255), 
	@CodiceFiscale VARCHAR(255), 
	@AnnoCostituzione INT, 
	@CodEnte VARCHAR(255), 
	@IscrizioneRegistroImprese VARCHAR(255), 
	@Presentazione NTEXT, 
	@Descrizione NTEXT, 
	@DataInizioAttivita DATETIME, 
	@IdStoricoUltimo INT, 
	@IdRapprlegaleUltimo INT, 
	@IdContoCorrenteUltimo INT, 
	@IdSedelegaleUltimo INT
)
AS
	INSERT INTO IMPRESA
	(
		CUAA, 
		CODICE_FISCALE, 
		ANNO_COSTITUZIONE, 
		COD_ENTE, 
		ISCRIZIONE_REGISTRO_IMPRESE, 
		PRESENTAZIONE, 
		DESCRIZIONE, 
		DATA_INIZIO_ATTIVITA, 
		ID_STORICO_ULTIMO, 
		ID_RAPPRLEGALE_ULTIMO, 
		ID_CONTO_CORRENTE_ULTIMO, 
		ID_SEDELEGALE_ULTIMO
	)
	VALUES
	(
		@Cuaa, 
		@CodiceFiscale, 
		@AnnoCostituzione, 
		@CodEnte, 
		@IscrizioneRegistroImprese, 
		@Presentazione, 
		@Descrizione, 
		@DataInizioAttivita, 
		@IdStoricoUltimo, 
		@IdRapprlegaleUltimo, 
		@IdContoCorrenteUltimo, 
		@IdSedelegaleUltimo
	)
	SELECT SCOPE_IDENTITY() AS ID_IMPRESA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaInsert';

