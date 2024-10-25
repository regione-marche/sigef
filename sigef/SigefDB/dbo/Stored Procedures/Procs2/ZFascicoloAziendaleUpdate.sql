CREATE PROCEDURE [dbo].[ZFascicoloAziendaleUpdate]
(
	@IdFascicolo INT, 
	@IdImpresa INT, 
	@DataDownload DATETIME, 
	@DataCreazione DATETIME, 
	@OperatoreCreazione CHAR(16), 
	@DataStoricizzazione DATETIME, 
	@DataAperturaFascicolo DATETIME, 
	@DataChiusuraFascicolo DATETIME, 
	@DataElaborazione DATETIME, 
	@DataValidazioneFascicolo DATETIME, 
	@OrganismoPagatore VARCHAR(4), 
	@Ote CHAR(4), 
	@Ude INT, 
	@Rls DECIMAL(18,2), 
	@Uba DECIMAL(18,2), 
	@DataSchedaValidazione DATETIME, 
	@Barcode CHAR(11), 
	@CodTipoDetentore CHAR(3), 
	@CodDetentore VARCHAR(20), 
	@StatoTerritorio CHAR(2), 
	@StatoVeterinaria CHAR(2), 
	@StatoFabbricati CHAR(2), 
	@StatoManodopera CHAR(2), 
	@StatoMacchinari CHAR(2)
)
AS
	UPDATE FASCICOLO_AZIENDALE
	SET
		ID_IMPRESA = @IdImpresa, 
		DATA_DOWNLOAD = @DataDownload, 
		DATA_CREAZIONE = @DataCreazione, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		DATA_STORICIZZAZIONE = @DataStoricizzazione, 
		DATA_APERTURA_FASCICOLO = @DataAperturaFascicolo, 
		DATA_CHIUSURA_FASCICOLO = @DataChiusuraFascicolo, 
		DATA_ELABORAZIONE = @DataElaborazione, 
		DATA_VALIDAZIONE_FASCICOLO = @DataValidazioneFascicolo, 
		ORGANISMO_PAGATORE = @OrganismoPagatore, 
		OTE = @Ote, 
		UDE = @Ude, 
		RLS = @Rls, 
		UBA = @Uba, 
		DATA_SCHEDA_VALIDAZIONE = @DataSchedaValidazione, 
		BARCODE = @Barcode, 
		COD_TIPO_DETENTORE = @CodTipoDetentore, 
		COD_DETENTORE = @CodDetentore, 
		STATO_TERRITORIO = @StatoTerritorio, 
		STATO_VETERINARIA = @StatoVeterinaria, 
		STATO_FABBRICATI = @StatoFabbricati, 
		STATO_MANODOPERA = @StatoManodopera, 
		STATO_MACCHINARI = @StatoMacchinari
	WHERE 
		(ID_FASCICOLO = @IdFascicolo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFascicoloAziendaleUpdate]
(
	@IdFascicolo INT, 
	@IdImpresa INT, 
	@DataDownload DATETIME, 
	@DataCreazione DATETIME, 
	@OperatoreCreazione CHAR(16), 
	@DataStoricizzazione DATETIME, 
	@DataAperturaFascicolo DATETIME, 
	@DataChiusuraFascicolo DATETIME, 
	@DataElaborazione DATETIME, 
	@DataValidazioneFascicolo DATETIME, 
	@OrganismoPagatore VARCHAR(4), 
	@Ote CHAR(4), 
	@Ude INT, 
	@Rls DECIMAL(18,2), 
	@Uba DECIMAL(18,2), 
	@DataSchedaValidazione DATETIME, 
	@Barcode CHAR(11), 
	@CodTipoDetentore CHAR(3), 
	@CodDetentore VARCHAR(20)
)
AS
	UPDATE FASCICOLO_AZIENDALE
	SET
		ID_IMPRESA = @IdImpresa, 
		DATA_DOWNLOAD = @DataDownload, 
		DATA_CREAZIONE = @DataCreazione, 
		OPERATORE_CREAZIONE = @OperatoreCreazione, 
		DATA_STORICIZZAZIONE = @DataStoricizzazione, 
		DATA_APERTURA_FASCICOLO = @DataAperturaFascicolo, 
		DATA_CHIUSURA_FASCICOLO = @DataChiusuraFascicolo, 
		DATA_ELABORAZIONE = @DataElaborazione, 
		DATA_VALIDAZIONE_FASCICOLO = @DataValidazioneFascicolo, 
		ORGANISMO_PAGATORE = @OrganismoPagatore, 
		OTE = @Ote, 
		UDE = @Ude, 
		RLS = @Rls, 
		UBA = @Uba, 
		DATA_SCHEDA_VALIDAZIONE = @DataSchedaValidazione, 
		BARCODE = @Barcode, 
		COD_TIPO_DETENTORE = @CodTipoDetentore, 
		COD_DETENTORE = @CodDetentore
	WHERE 
		(ID_FASCICOLO = @IdFascicolo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloAziendaleUpdate';

