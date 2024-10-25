CREATE PROCEDURE [dbo].[ZElencoDiPagamentoFindSelect]
(
	@IdElencoPagamentoequalthis INT, 
	@CodElencoProvincialeequalthis VARCHAR(255), 
	@IdElencoRegionaleequalthis INT, 
	@IdBandoPrincipaleequalthis INT, 
	@IdDisposizioneAttuativaequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@Segnaturaequalthis VARCHAR(255), 
	@DataCreazioneequalthis DATETIME, 
	@CfOperatoreequalthis VARCHAR(255), 
	@DataModificaequalthis DATETIME, 
	@Esportatoequalthis BIT, 
	@EsitoEsportazioneequalthis BIT, 
	@DataEsportazioneequalthis DATETIME, 
	@CfOperatoreEsportazioneequalthis VARCHAR(255), 
	@ElaboratoDaSianequalthis BIT, 
	@DataElaborazioneSianequalthis DATETIME, 
	@IdAttoAutorizzazioneequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, COD_DEFINIZIONE, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO FROM vELENCO_DI_PAGAMENTO WHERE 1=1';
	IF (@IdElencoPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ELENCO_PAGAMENTO = @IdElencoPagamentoequalthis)'; set @lensql=@lensql+len(@IdElencoPagamentoequalthis);end;
	IF (@CodElencoProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis)'; set @lensql=@lensql+len(@CodElencoProvincialeequalthis);end;
	IF (@IdElencoRegionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis)'; set @lensql=@lensql+len(@IdElencoRegionaleequalthis);end;
	IF (@IdBandoPrincipaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis)'; set @lensql=@lensql+len(@IdBandoPrincipaleequalthis);end;
	IF (@IdDisposizioneAttuativaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis)'; set @lensql=@lensql+len(@IdDisposizioneAttuativaequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@Segnaturaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA = @Segnaturaequalthis)'; set @lensql=@lensql+len(@Segnaturaequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@CfOperatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE = @CfOperatoreequalthis)'; set @lensql=@lensql+len(@CfOperatoreequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@Esportatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESPORTATO = @Esportatoequalthis)'; set @lensql=@lensql+len(@Esportatoequalthis);end;
	IF (@EsitoEsportazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ESITO_ESPORTAZIONE = @EsitoEsportazioneequalthis)'; set @lensql=@lensql+len(@EsitoEsportazioneequalthis);end;
	IF (@DataEsportazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ESPORTAZIONE = @DataEsportazioneequalthis)'; set @lensql=@lensql+len(@DataEsportazioneequalthis);end;
	IF (@CfOperatoreEsportazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_OPERATORE_ESPORTAZIONE = @CfOperatoreEsportazioneequalthis)'; set @lensql=@lensql+len(@CfOperatoreEsportazioneequalthis);end;
	IF (@ElaboratoDaSianequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ELABORATO_DA_SIAN = @ElaboratoDaSianequalthis)'; set @lensql=@lensql+len(@ElaboratoDaSianequalthis);end;
	IF (@DataElaborazioneSianequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ELABORAZIONE_SIAN = @DataElaborazioneSianequalthis)'; set @lensql=@lensql+len(@DataElaborazioneSianequalthis);end;
	IF (@IdAttoAutorizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ATTO_AUTORIZZAZIONE = @IdAttoAutorizzazioneequalthis)'; set @lensql=@lensql+len(@IdAttoAutorizzazioneequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdElencoPagamentoequalthis INT, @CodElencoProvincialeequalthis VARCHAR(255), @IdElencoRegionaleequalthis INT, @IdBandoPrincipaleequalthis INT, @IdDisposizioneAttuativaequalthis INT, @Provinciaequalthis VARCHAR(255), @Segnaturaequalthis VARCHAR(255), @DataCreazioneequalthis DATETIME, @CfOperatoreequalthis VARCHAR(255), @DataModificaequalthis DATETIME, @Esportatoequalthis BIT, @EsitoEsportazioneequalthis BIT, @DataEsportazioneequalthis DATETIME, @CfOperatoreEsportazioneequalthis VARCHAR(255), @ElaboratoDaSianequalthis BIT, @DataElaborazioneSianequalthis DATETIME, @IdAttoAutorizzazioneequalthis INT',@IdElencoPagamentoequalthis , @CodElencoProvincialeequalthis , @IdElencoRegionaleequalthis , @IdBandoPrincipaleequalthis , @IdDisposizioneAttuativaequalthis , @Provinciaequalthis , @Segnaturaequalthis , @DataCreazioneequalthis , @CfOperatoreequalthis , @DataModificaequalthis , @Esportatoequalthis , @EsitoEsportazioneequalthis , @DataEsportazioneequalthis , @CfOperatoreEsportazioneequalthis , @ElaboratoDaSianequalthis , @DataElaborazioneSianequalthis , @IdAttoAutorizzazioneequalthis ;
	else
		SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, COD_DEFINIZIONE, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO
		FROM vELENCO_DI_PAGAMENTO
		WHERE 
			((@IdElencoPagamentoequalthis IS NULL) OR ID_ELENCO_PAGAMENTO = @IdElencoPagamentoequalthis) AND 
			((@CodElencoProvincialeequalthis IS NULL) OR COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis) AND 
			((@IdElencoRegionaleequalthis IS NULL) OR ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis) AND 
			((@IdBandoPrincipaleequalthis IS NULL) OR ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis) AND 
			((@IdDisposizioneAttuativaequalthis IS NULL) OR ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@Segnaturaequalthis IS NULL) OR SEGNATURA = @Segnaturaequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@CfOperatoreequalthis IS NULL) OR CF_OPERATORE = @CfOperatoreequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@Esportatoequalthis IS NULL) OR ESPORTATO = @Esportatoequalthis) AND 
			((@EsitoEsportazioneequalthis IS NULL) OR ESITO_ESPORTAZIONE = @EsitoEsportazioneequalthis) AND 
			((@DataEsportazioneequalthis IS NULL) OR DATA_ESPORTAZIONE = @DataEsportazioneequalthis) AND 
			((@CfOperatoreEsportazioneequalthis IS NULL) OR CF_OPERATORE_ESPORTAZIONE = @CfOperatoreEsportazioneequalthis) AND 
			((@ElaboratoDaSianequalthis IS NULL) OR ELABORATO_DA_SIAN = @ElaboratoDaSianequalthis) AND 
			((@DataElaborazioneSianequalthis IS NULL) OR DATA_ELABORAZIONE_SIAN = @DataElaborazioneSianequalthis) AND 
			((@IdAttoAutorizzazioneequalthis IS NULL) OR ID_ATTO_AUTORIZZAZIONE = @IdAttoAutorizzazioneequalthis)
