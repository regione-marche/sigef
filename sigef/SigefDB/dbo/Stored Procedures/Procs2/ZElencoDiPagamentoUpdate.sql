CREATE PROCEDURE [dbo].[ZElencoDiPagamentoUpdate]
(
	@IdElencoPagamento INT, 
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
	SET @DataModifica=getdate()
	UPDATE ELENCO_DI_PAGAMENTO
	SET
		ID_BANDO_PRINCIPALE = @IdBandoPrincipale, 
		ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativa, 
		PROVINCIA = @Provincia, 
		COD_ELENCO_PROVINCIALE = @CodElencoProvinciale, 
		ID_ELENCO_REGIONALE = @IdElencoRegionale, 
		SEGNATURA = @Segnatura, 
		DATA_CREAZIONE = @DataCreazione, 
		CF_OPERATORE = @CfOperatore, 
		DATA_MODIFICA = @DataModifica, 
		ESPORTATO = @Esportato, 
		ESITO_ESPORTAZIONE = @EsitoEsportazione, 
		DATA_ESPORTAZIONE = @DataEsportazione, 
		CF_OPERATORE_ESPORTAZIONE = @CfOperatoreEsportazione, 
		ID_ATTO_AUTORIZZAZIONE = @IdAttoAutorizzazione, 
		ELABORATO_DA_SIAN = @ElaboratoDaSian, 
		DATA_ELABORAZIONE_SIAN = @DataElaborazioneSian
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)
	SELECT @DataModifica;

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZElencoDiPagamentoUpdate]
(
	@IdElencoPagamento INT, 
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
	SET @DataModifica=getdate()
	UPDATE ELENCO_DI_PAGAMENTO
	SET
		ID_BANDO_PRINCIPALE = @IdBandoPrincipale, 
		ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativa, 
		PROVINCIA = @Provincia, 
		COD_ELENCO_PROVINCIALE = @CodElencoProvinciale, 
		ID_ELENCO_REGIONALE = @IdElencoRegionale, 
		SEGNATURA = @Segnatura, 
		DATA_CREAZIONE = @DataCreazione, 
		CF_OPERATORE = @CfOperatore, 
		DATA_MODIFICA = @DataModifica, 
		ESPORTATO = @Esportato, 
		ESITO_ESPORTAZIONE = @EsitoEsportazione, 
		DATA_ESPORTAZIONE = @DataEsportazione, 
		CF_OPERATORE_ESPORTAZIONE = @CfOperatoreEsportazione, 
		ID_ATTO_AUTORIZZAZIONE = @IdAttoAutorizzazione, 
		ELABORATO_DA_SIAN = @ElaboratoDaSian, 
		DATA_ELABORAZIONE_SIAN = @DataElaborazioneSian
	WHERE 
		(ID_ELENCO_PAGAMENTO = @IdElencoPagamento)
	SELECT @DataModifica;

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZElencoDiPagamentoUpdate';

