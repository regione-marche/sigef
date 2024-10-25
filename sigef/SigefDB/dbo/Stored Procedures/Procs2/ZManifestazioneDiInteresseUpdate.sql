CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseUpdate]
(
	@IdManifestazione INT, 
	@IdBando INT, 
	@IdFiliera INT, 
	@Cuaa VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME, 
	@DataUltimaModifica DATETIME, 
	@Dichiarazioni NTEXT, 
	@MotivazioniEsclusione NTEXT, 
	@SegnaturaAllegati VARCHAR(100)
)
AS
	UPDATE MANIFESTAZIONE_DI_INTERESSE
	SET
		ID_BANDO = @IdBando, 
		ID_FILIERA = @IdFiliera, 
		CUAA = @Cuaa, 
		SEGNATURA = @Segnatura, 
		OPERATORE = @Operatore, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_ULTIMA_MODIFICA = @DataUltimaModifica, 
		DICHIARAZIONI = @Dichiarazioni, 
		MOTIVAZIONI_ESCLUSIONE = @MotivazioniEsclusione, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseUpdate]
(
	@IdManifestazione INT, 
	@IdBando INT, 
	@IdFiliera INT, 
	@Cuaa VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@Operatore VARCHAR(16), 
	@DataInserimento DATETIME, 
	@DataUltimaModifica DATETIME, 
	@Dichiarazioni NTEXT, 
	@MotivazioniEsclusione NTEXT, 
	@SegnaturaAllegati VARCHAR(100)
)
AS
	UPDATE MANIFESTAZIONE_DI_INTERESSE
	SET
		ID_BANDO = @IdBando, 
		ID_FILIERA = @IdFiliera, 
		CUAA = @Cuaa, 
		SEGNATURA = @Segnatura, 
		OPERATORE = @Operatore, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_ULTIMA_MODIFICA = @DataUltimaModifica, 
		DICHIARAZIONI = @Dichiarazioni, 
		MOTIVAZIONI_ESCLUSIONE = @MotivazioniEsclusione, 
		SEGNATURA_ALLEGATI = @SegnaturaAllegati
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseUpdate';

