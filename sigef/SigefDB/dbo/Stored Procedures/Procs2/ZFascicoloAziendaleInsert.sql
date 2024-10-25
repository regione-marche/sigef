CREATE PROCEDURE [dbo].[ZFascicoloAziendaleInsert]
(
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
	INSERT INTO FASCICOLO_AZIENDALE
	(
		ID_IMPRESA, 
		DATA_DOWNLOAD, 
		DATA_CREAZIONE, 
		OPERATORE_CREAZIONE, 
		DATA_STORICIZZAZIONE, 
		DATA_APERTURA_FASCICOLO, 
		DATA_CHIUSURA_FASCICOLO, 
		DATA_ELABORAZIONE, 
		DATA_VALIDAZIONE_FASCICOLO, 
		ORGANISMO_PAGATORE, 
		OTE, 
		UDE, 
		RLS, 
		UBA, 
		DATA_SCHEDA_VALIDAZIONE, 
		BARCODE, 
		COD_TIPO_DETENTORE, 
		COD_DETENTORE, 
		STATO_TERRITORIO, 
		STATO_VETERINARIA, 
		STATO_FABBRICATI, 
		STATO_MANODOPERA, 
		STATO_MACCHINARI
	)
	VALUES
	(
		@IdImpresa, 
		@DataDownload, 
		@DataCreazione, 
		@OperatoreCreazione, 
		@DataStoricizzazione, 
		@DataAperturaFascicolo, 
		@DataChiusuraFascicolo, 
		@DataElaborazione, 
		@DataValidazioneFascicolo, 
		@OrganismoPagatore, 
		@Ote, 
		@Ude, 
		@Rls, 
		@Uba, 
		@DataSchedaValidazione, 
		@Barcode, 
		@CodTipoDetentore, 
		@CodDetentore, 
		@StatoTerritorio, 
		@StatoVeterinaria, 
		@StatoFabbricati, 
		@StatoManodopera, 
		@StatoMacchinari
	)
	SELECT SCOPE_IDENTITY() AS ID_FASCICOLO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZFascicoloAziendaleInsert]
(
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
	INSERT INTO FASCICOLO_AZIENDALE
	(
		ID_IMPRESA, 
		DATA_DOWNLOAD, 
		DATA_CREAZIONE, 
		OPERATORE_CREAZIONE, 
		DATA_STORICIZZAZIONE, 
		DATA_APERTURA_FASCICOLO, 
		DATA_CHIUSURA_FASCICOLO, 
		DATA_ELABORAZIONE, 
		DATA_VALIDAZIONE_FASCICOLO, 
		ORGANISMO_PAGATORE, 
		OTE, 
		UDE, 
		RLS, 
		UBA, 
		DATA_SCHEDA_VALIDAZIONE, 
		BARCODE, 
		COD_TIPO_DETENTORE, 
		COD_DETENTORE
	)
	VALUES
	(
		@IdImpresa, 
		@DataDownload, 
		GETDATE(), 
		@OperatoreCreazione, 
		@DataStoricizzazione, 
		@DataAperturaFascicolo, 
		@DataChiusuraFascicolo, 
		@DataElaborazione, 
		@DataValidazioneFascicolo, 
		@OrganismoPagatore, 
		@Ote, 
		@Ude, 
		@Rls, 
		@Uba, 
		@DataSchedaValidazione, 
		@Barcode, 
		@CodTipoDetentore, 
		@CodDetentore
	)
	SELECT SCOPE_IDENTITY() AS ID_FASCICOLO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloAziendaleInsert';

