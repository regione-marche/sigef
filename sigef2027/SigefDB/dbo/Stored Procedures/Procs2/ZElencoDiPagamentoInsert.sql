CREATE PROCEDURE [dbo].[ZElencoDiPagamentoInsert]
(
	@IdBandoPrincipale INT, 
	@IdDisposizioneAttuativa INT, 
	@Provincia VARCHAR(255), 
	@CodElencoProvinciale VARCHAR(255), 
	@IdElencoRegionale INT, 
	@Segnatura VARCHAR(255), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(255), 
	@DataModifica DATETIME, 
	@Esportato BIT, 
	@EsitoEsportazione BIT, 
	@DataEsportazione DATETIME, 
	@CfOperatoreEsportazione VARCHAR(255), 
	@IdAttoAutorizzazione INT, 
	@ElaboratoDaSian BIT, 
	@DataElaborazioneSian DATETIME
)
AS
	INSERT INTO ELENCO_DI_PAGAMENTO
	(
		ID_BANDO_PRINCIPALE, 
		ID_DISPOSIZIONE_ATTUATIVA, 
		PROVINCIA, 
		COD_ELENCO_PROVINCIALE, 
		ID_ELENCO_REGIONALE, 
		SEGNATURA, 
		DATA_CREAZIONE, 
		CF_OPERATORE, 
		DATA_MODIFICA, 
		ESPORTATO, 
		ESITO_ESPORTAZIONE, 
		DATA_ESPORTAZIONE, 
		CF_OPERATORE_ESPORTAZIONE, 
		ID_ATTO_AUTORIZZAZIONE, 
		ELABORATO_DA_SIAN, 
		DATA_ELABORAZIONE_SIAN
	)
	VALUES
	(
		@IdBandoPrincipale, 
		@IdDisposizioneAttuativa, 
		@Provincia, 
		@CodElencoProvinciale, 
		@IdElencoRegionale, 
		@Segnatura, 
		@DataCreazione, 
		@CfOperatore, 
		@DataModifica, 
		@Esportato, 
		@EsitoEsportazione, 
		@DataEsportazione, 
		@CfOperatoreEsportazione, 
		@IdAttoAutorizzazione, 
		@ElaboratoDaSian, 
		@DataElaborazioneSian
	)
	SELECT SCOPE_IDENTITY() AS ID_ELENCO_PAGAMENTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZElencoDiPagamentoInsert]
(
	@IdBandoPrincipale INT, 
	@IdDisposizioneAttuativa INT, 
	@Provincia CHAR(2), 
	@CodElencoProvinciale CHAR(11), 
	@IdElencoRegionale INT, 
	@Segnatura VARCHAR(100), 
	@DataCreazione DATETIME, 
	@CfOperatore VARCHAR(16), 
	@DataModifica DATETIME, 
	@Esportato BIT, 
	@EsitoEsportazione BIT, 
	@DataEsportazione DATETIME, 
	@CfOperatoreEsportazione VARCHAR(16), 
	@IdAttoAutorizzazione INT, 
	@ElaboratoDaSian BIT, 
	@DataElaborazioneSian DATETIME
)
AS
	INSERT INTO ELENCO_DI_PAGAMENTO
	(
		ID_BANDO_PRINCIPALE, 
		ID_DISPOSIZIONE_ATTUATIVA, 
		PROVINCIA, 
		COD_ELENCO_PROVINCIALE, 
		ID_ELENCO_REGIONALE, 
		SEGNATURA, 
		DATA_CREAZIONE, 
		CF_OPERATORE, 
		DATA_MODIFICA, 
		ESPORTATO, 
		ESITO_ESPORTAZIONE, 
		DATA_ESPORTAZIONE, 
		CF_OPERATORE_ESPORTAZIONE, 
		ID_ATTO_AUTORIZZAZIONE, 
		ELABORATO_DA_SIAN, 
		DATA_ELABORAZIONE_SIAN
	)
	VALUES
	(
		@IdBandoPrincipale, 
		@IdDisposizioneAttuativa, 
		@Provincia, 
		@CodElencoProvinciale, 
		@IdElencoRegionale, 
		@Segnatura, 
		@DataCreazione, 
		@CfOperatore, 
		@DataModifica, 
		@Esportato, 
		@EsitoEsportazione, 
		@DataEsportazione, 
		@CfOperatoreEsportazione, 
		@IdAttoAutorizzazione, 
		@ElaboratoDaSian, 
		@DataElaborazioneSian
	)
	SELECT SCOPE_IDENTITY() AS ID_ELENCO_PAGAMENTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZElencoDiPagamentoInsert';

