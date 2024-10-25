CREATE PROCEDURE [dbo].[ZImpresaUpdate]
(
	@IdImpresa INT, 
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
	UPDATE IMPRESA
	SET
		CUAA = @Cuaa, 
		CODICE_FISCALE = @CodiceFiscale, 
		ANNO_COSTITUZIONE = @AnnoCostituzione, 
		COD_ENTE = @CodEnte, 
		ISCRIZIONE_REGISTRO_IMPRESE = @IscrizioneRegistroImprese, 
		PRESENTAZIONE = @Presentazione, 
		DESCRIZIONE = @Descrizione, 
		DATA_INIZIO_ATTIVITA = @DataInizioAttivita, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		ID_RAPPRLEGALE_ULTIMO = @IdRapprlegaleUltimo, 
		ID_CONTO_CORRENTE_ULTIMO = @IdContoCorrenteUltimo, 
		ID_SEDELEGALE_ULTIMO = @IdSedelegaleUltimo
	WHERE 
		(ID_IMPRESA = @IdImpresa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaUpdate]
(
	@IdImpresa INT, 
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
	UPDATE IMPRESA
	SET
		CUAA = @Cuaa, 
		CODICE_FISCALE = @CodiceFiscale, 
		ANNO_COSTITUZIONE = @AnnoCostituzione, 
		COD_ENTE = @CodEnte, 
		ISCRIZIONE_REGISTRO_IMPRESE = @IscrizioneRegistroImprese, 
		PRESENTAZIONE = @Presentazione, 
		DESCRIZIONE = @Descrizione, 
		DATA_INIZIO_ATTIVITA = @DataInizioAttivita, 
		ID_STORICO_ULTIMO = @IdStoricoUltimo, 
		ID_RAPPRLEGALE_ULTIMO = @IdRapprlegaleUltimo, 
		ID_CONTO_CORRENTE_ULTIMO = @IdContoCorrenteUltimo, 
		ID_SEDELEGALE_ULTIMO = @IdSedelegaleUltimo
	WHERE 
		(ID_IMPRESA = @IdImpresa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaUpdate';

