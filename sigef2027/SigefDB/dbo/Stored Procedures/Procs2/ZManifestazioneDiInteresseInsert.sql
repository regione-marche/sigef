CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseInsert]
(
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
	INSERT INTO MANIFESTAZIONE_DI_INTERESSE
	(
		ID_BANDO, 
		ID_FILIERA, 
		CUAA, 
		SEGNATURA, 
		OPERATORE, 
		DATA_INSERIMENTO, 
		DATA_ULTIMA_MODIFICA, 
		DICHIARAZIONI, 
		MOTIVAZIONI_ESCLUSIONE, 
		SEGNATURA_ALLEGATI
	)
	VALUES
	(
		@IdBando, 
		@IdFiliera, 
		@Cuaa, 
		@Segnatura, 
		@Operatore, 
		@DataInserimento, 
		@DataUltimaModifica, 
		@Dichiarazioni, 
		@MotivazioniEsclusione, 
		@SegnaturaAllegati
	)
	SELECT SCOPE_IDENTITY() AS ID_MANIFESTAZIONE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZManifestazioneDiInteresseInsert]
(
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
	INSERT INTO MANIFESTAZIONE_DI_INTERESSE
	(
		ID_BANDO, 
		ID_FILIERA, 
		CUAA, 
		SEGNATURA, 
		OPERATORE, 
		DATA_INSERIMENTO, 
		DATA_ULTIMA_MODIFICA, 
		DICHIARAZIONI, 
		MOTIVAZIONI_ESCLUSIONE, 
		SEGNATURA_ALLEGATI
	)
	VALUES
	(
		@IdBando, 
		@IdFiliera, 
		@Cuaa, 
		@Segnatura, 
		@Operatore, 
		@DataInserimento, 
		@DataUltimaModifica, 
		@Dichiarazioni, 
		@MotivazioniEsclusione, 
		@SegnaturaAllegati
	)
	SELECT SCOPE_IDENTITY() AS ID_MANIFESTAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneDiInteresseInsert';

