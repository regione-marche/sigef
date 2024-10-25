CREATE PROCEDURE [dbo].[ZElencoDiPagamentoFindFind]
(
	@IdBandoPrincipaleequalthis INT, 
	@IdDisposizioneAttuativaequalthis INT, 
	@Provinciaequalthis VARCHAR(255), 
	@IdElencoRegionaleequalthis INT, 
	@CodElencoProvincialeequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, COD_DEFINIZIONE, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO FROM vELENCO_DI_PAGAMENTO WHERE 1=1';
	IF (@IdBandoPrincipaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis)'; set @lensql=@lensql+len(@IdBandoPrincipaleequalthis);end;
	IF (@IdDisposizioneAttuativaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis)'; set @lensql=@lensql+len(@IdDisposizioneAttuativaequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@IdElencoRegionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis)'; set @lensql=@lensql+len(@IdElencoRegionaleequalthis);end;
	IF (@CodElencoProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis)'; set @lensql=@lensql+len(@CodElencoProvincialeequalthis);end;
	set @lensql=@lensql+len(@sql);
	set @sql = @sql + ' ORDER BY ID_ELENCO_PAGAMENTO DESC';
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoPrincipaleequalthis INT, @IdDisposizioneAttuativaequalthis INT, @Provinciaequalthis VARCHAR(255), @IdElencoRegionaleequalthis INT, @CodElencoProvincialeequalthis VARCHAR(255)',@IdBandoPrincipaleequalthis , @IdDisposizioneAttuativaequalthis , @Provinciaequalthis , @IdElencoRegionaleequalthis , @CodElencoProvincialeequalthis ;
	else
		SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, COD_DEFINIZIONE, AW_DOCNUMBER, AW_DOCNUMBER_NUOVO
		FROM vELENCO_DI_PAGAMENTO
		WHERE 
			((@IdBandoPrincipaleequalthis IS NULL) OR ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis) AND 
			((@IdDisposizioneAttuativaequalthis IS NULL) OR ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@IdElencoRegionaleequalthis IS NULL) OR ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis) AND 
			((@CodElencoProvincialeequalthis IS NULL) OR COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis)
		ORDER BY ID_ELENCO_PAGAMENTO DESC

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZElencoDiPagamentoFindFind]
(
	@IdBandoPrincipaleequalthis INT, 
	@IdDisposizioneAttuativaequalthis INT, 
	@Provinciaequalthis CHAR(2), 
	@IdElencoRegionaleequalthis INT, 
	@CodElencoProvincialeequalthis CHAR(11)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, ID_DEFINIZIONE_ATTO, AW_DOCNUMBER FROM vELENCO_DI_PAGAMENTO WHERE 1=1'';
	IF (@IdBandoPrincipaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis)''; set @lensql=@lensql+len(@IdBandoPrincipaleequalthis);end;
	IF (@IdDisposizioneAttuativaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis)''; set @lensql=@lensql+len(@IdDisposizioneAttuativaequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA = @Provinciaequalthis)''; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@IdElencoRegionaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis)''; set @lensql=@lensql+len(@IdElencoRegionaleequalthis);end;
	IF (@CodElencoProvincialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis)''; set @lensql=@lensql+len(@CodElencoProvincialeequalthis);end;
	set @sql = @sql + ''ORDER BY ID_ELENCO_PAGAMENTO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoPrincipaleequalthis INT, @IdDisposizioneAttuativaequalthis INT, @Provinciaequalthis CHAR(2), @IdElencoRegionaleequalthis INT, @CodElencoProvincialeequalthis CHAR(11)'',@IdBandoPrincipaleequalthis , @IdDisposizioneAttuativaequalthis , @Provinciaequalthis , @IdElencoRegionaleequalthis , @CodElencoProvincialeequalthis ;
	else
		SELECT ID_ELENCO_PAGAMENTO, ID_BANDO_PRINCIPALE, ID_DISPOSIZIONE_ATTUATIVA, PROVINCIA, COD_ELENCO_PROVINCIALE, ID_ELENCO_REGIONALE, SEGNATURA, DATA_CREAZIONE, CF_OPERATORE, DATA_MODIFICA, ESPORTATO, ESITO_ESPORTAZIONE, DATA_ESPORTAZIONE, CF_OPERATORE_ESPORTAZIONE, NOMINATIVO_OPERATORE, ID_ATTO_AUTORIZZAZIONE, ELABORATO_DA_SIAN, DATA_ELABORAZIONE_SIAN, ID_DEFINIZIONE_ATTO, AW_DOCNUMBER
		FROM vELENCO_DI_PAGAMENTO
		WHERE 
			((@IdBandoPrincipaleequalthis IS NULL) OR ID_BANDO_PRINCIPALE = @IdBandoPrincipaleequalthis) AND 
			((@IdDisposizioneAttuativaequalthis IS NULL) OR ID_DISPOSIZIONE_ATTUATIVA = @IdDisposizioneAttuativaequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@IdElencoRegionaleequalthis IS NULL) OR ID_ELENCO_REGIONALE = @IdElencoRegionaleequalthis) AND 
			((@CodElencoProvincialeequalthis IS NULL) OR COD_ELENCO_PROVINCIALE = @CodElencoProvincialeequalthis)
		ORDER BY ID_ELENCO_PAGAMENTO
		

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZElencoDiPagamentoFindFind';

