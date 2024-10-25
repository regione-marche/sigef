CREATE PROCEDURE [dbo].[ZFascicoloAziendaleFindSelect]
(
	@IdFascicoloequalthis INT, 
	@IdImpresaequalthis INT, 
	@DataDownloadequalthis DATETIME, 
	@DataCreazioneequalthis DATETIME, 
	@OperatoreCreazioneequalthis CHAR(16), 
	@DataStoricizzazioneequalthis DATETIME, 
	@DataAperturaFascicoloequalthis DATETIME, 
	@DataChiusuraFascicoloequalthis DATETIME, 
	@DataElaborazioneequalthis DATETIME, 
	@DataValidazioneFascicoloequalthis DATETIME, 
	@OrganismoPagatoreequalthis VARCHAR(4), 
	@Oteequalthis CHAR(4), 
	@Udeequalthis INT, 
	@Rlsequalthis DECIMAL(18,2), 
	@Ubaequalthis DECIMAL(18,2), 
	@DataSchedaValidazioneequalthis DATETIME, 
	@Barcodeequalthis CHAR(11), 
	@CodTipoDetentoreequalthis CHAR(3), 
	@CodDetentoreequalthis VARCHAR(20), 
	@StatoTerritorioequalthis CHAR(2), 
	@StatoVeterinariaequalthis CHAR(2), 
	@StatoFabbricatiequalthis CHAR(2), 
	@StatoManodoperaequalthis CHAR(2), 
	@StatoMacchinariequalthis CHAR(2)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE, STATO_TERRITORIO, STATO_VETERINARIA, STATO_FABBRICATI, STATO_MANODOPERA, STATO_MACCHINARI FROM FASCICOLO_AZIENDALE WHERE 1=1';
	IF (@IdFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FASCICOLO = @IdFascicoloequalthis)'; set @lensql=@lensql+len(@IdFascicoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@DataDownloadequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_DOWNLOAD = @DataDownloadequalthis)'; set @lensql=@lensql+len(@DataDownloadequalthis);end;
	IF (@DataCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CREAZIONE = @DataCreazioneequalthis)'; set @lensql=@lensql+len(@DataCreazioneequalthis);end;
	IF (@OperatoreCreazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis)'; set @lensql=@lensql+len(@OperatoreCreazioneequalthis);end;
	IF (@DataStoricizzazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_STORICIZZAZIONE = @DataStoricizzazioneequalthis)'; set @lensql=@lensql+len(@DataStoricizzazioneequalthis);end;
	IF (@DataAperturaFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_APERTURA_FASCICOLO = @DataAperturaFascicoloequalthis)'; set @lensql=@lensql+len(@DataAperturaFascicoloequalthis);end;
	IF (@DataChiusuraFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CHIUSURA_FASCICOLO = @DataChiusuraFascicoloequalthis)'; set @lensql=@lensql+len(@DataChiusuraFascicoloequalthis);end;
	IF (@DataElaborazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ELABORAZIONE = @DataElaborazioneequalthis)'; set @lensql=@lensql+len(@DataElaborazioneequalthis);end;
	IF (@DataValidazioneFascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALIDAZIONE_FASCICOLO = @DataValidazioneFascicoloequalthis)'; set @lensql=@lensql+len(@DataValidazioneFascicoloequalthis);end;
	IF (@OrganismoPagatoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ORGANISMO_PAGATORE = @OrganismoPagatoreequalthis)'; set @lensql=@lensql+len(@OrganismoPagatoreequalthis);end;
	IF (@Oteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (OTE = @Oteequalthis)'; set @lensql=@lensql+len(@Oteequalthis);end;
	IF (@Udeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UDE = @Udeequalthis)'; set @lensql=@lensql+len(@Udeequalthis);end;
	IF (@Rlsequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RLS = @Rlsequalthis)'; set @lensql=@lensql+len(@Rlsequalthis);end;
	IF (@Ubaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UBA = @Ubaequalthis)'; set @lensql=@lensql+len(@Ubaequalthis);end;
	IF (@DataSchedaValidazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCHEDA_VALIDAZIONE = @DataSchedaValidazioneequalthis)'; set @lensql=@lensql+len(@DataSchedaValidazioneequalthis);end;
	IF (@Barcodeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (BARCODE = @Barcodeequalthis)'; set @lensql=@lensql+len(@Barcodeequalthis);end;
	IF (@CodTipoDetentoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_DETENTORE = @CodTipoDetentoreequalthis)'; set @lensql=@lensql+len(@CodTipoDetentoreequalthis);end;
	IF (@CodDetentoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_DETENTORE = @CodDetentoreequalthis)'; set @lensql=@lensql+len(@CodDetentoreequalthis);end;
	IF (@StatoTerritorioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_TERRITORIO = @StatoTerritorioequalthis)'; set @lensql=@lensql+len(@StatoTerritorioequalthis);end;
	IF (@StatoVeterinariaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_VETERINARIA = @StatoVeterinariaequalthis)'; set @lensql=@lensql+len(@StatoVeterinariaequalthis);end;
	IF (@StatoFabbricatiequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_FABBRICATI = @StatoFabbricatiequalthis)'; set @lensql=@lensql+len(@StatoFabbricatiequalthis);end;
	IF (@StatoManodoperaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_MANODOPERA = @StatoManodoperaequalthis)'; set @lensql=@lensql+len(@StatoManodoperaequalthis);end;
	IF (@StatoMacchinariequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_MACCHINARI = @StatoMacchinariequalthis)'; set @lensql=@lensql+len(@StatoMacchinariequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdFascicoloequalthis INT, @IdImpresaequalthis INT, @DataDownloadequalthis DATETIME, @DataCreazioneequalthis DATETIME, @OperatoreCreazioneequalthis CHAR(16), @DataStoricizzazioneequalthis DATETIME, @DataAperturaFascicoloequalthis DATETIME, @DataChiusuraFascicoloequalthis DATETIME, @DataElaborazioneequalthis DATETIME, @DataValidazioneFascicoloequalthis DATETIME, @OrganismoPagatoreequalthis VARCHAR(4), @Oteequalthis CHAR(4), @Udeequalthis INT, @Rlsequalthis DECIMAL(18,2), @Ubaequalthis DECIMAL(18,2), @DataSchedaValidazioneequalthis DATETIME, @Barcodeequalthis CHAR(11), @CodTipoDetentoreequalthis CHAR(3), @CodDetentoreequalthis VARCHAR(20), @StatoTerritorioequalthis CHAR(2), @StatoVeterinariaequalthis CHAR(2), @StatoFabbricatiequalthis CHAR(2), @StatoManodoperaequalthis CHAR(2), @StatoMacchinariequalthis CHAR(2)',@IdFascicoloequalthis , @IdImpresaequalthis , @DataDownloadequalthis , @DataCreazioneequalthis , @OperatoreCreazioneequalthis , @DataStoricizzazioneequalthis , @DataAperturaFascicoloequalthis , @DataChiusuraFascicoloequalthis , @DataElaborazioneequalthis , @DataValidazioneFascicoloequalthis , @OrganismoPagatoreequalthis , @Oteequalthis , @Udeequalthis , @Rlsequalthis , @Ubaequalthis , @DataSchedaValidazioneequalthis , @Barcodeequalthis , @CodTipoDetentoreequalthis , @CodDetentoreequalthis , @StatoTerritorioequalthis , @StatoVeterinariaequalthis , @StatoFabbricatiequalthis , @StatoManodoperaequalthis , @StatoMacchinariequalthis ;
	else
		SELECT ID_FASCICOLO, ID_IMPRESA, DATA_DOWNLOAD, DATA_CREAZIONE, OPERATORE_CREAZIONE, DATA_STORICIZZAZIONE, DATA_APERTURA_FASCICOLO, DATA_CHIUSURA_FASCICOLO, DATA_ELABORAZIONE, DATA_VALIDAZIONE_FASCICOLO, ORGANISMO_PAGATORE, OTE, UDE, RLS, UBA, DATA_SCHEDA_VALIDAZIONE, BARCODE, COD_TIPO_DETENTORE, COD_DETENTORE, STATO_TERRITORIO, STATO_VETERINARIA, STATO_FABBRICATI, STATO_MANODOPERA, STATO_MACCHINARI
		FROM FASCICOLO_AZIENDALE
		WHERE 
			((@IdFascicoloequalthis IS NULL) OR ID_FASCICOLO = @IdFascicoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@DataDownloadequalthis IS NULL) OR DATA_DOWNLOAD = @DataDownloadequalthis) AND 
			((@DataCreazioneequalthis IS NULL) OR DATA_CREAZIONE = @DataCreazioneequalthis) AND 
			((@OperatoreCreazioneequalthis IS NULL) OR OPERATORE_CREAZIONE = @OperatoreCreazioneequalthis) AND 
			((@DataStoricizzazioneequalthis IS NULL) OR DATA_STORICIZZAZIONE = @DataStoricizzazioneequalthis) AND 
			((@DataAperturaFascicoloequalthis IS NULL) OR DATA_APERTURA_FASCICOLO = @DataAperturaFascicoloequalthis) AND 
			((@DataChiusuraFascicoloequalthis IS NULL) OR DATA_CHIUSURA_FASCICOLO = @DataChiusuraFascicoloequalthis) AND 
			((@DataElaborazioneequalthis IS NULL) OR DATA_ELABORAZIONE = @DataElaborazioneequalthis) AND 
			((@DataValidazioneFascicoloequalthis IS NULL) OR DATA_VALIDAZIONE_FASCICOLO = @DataValidazioneFascicoloequalthis) AND 
			((@OrganismoPagatoreequalthis IS NULL) OR ORGANISMO_PAGATORE = @OrganismoPagatoreequalthis) AND 
			((@Oteequalthis IS NULL) OR OTE = @Oteequalthis) AND 
			((@Udeequalthis IS NULL) OR UDE = @Udeequalthis) AND 
			((@Rlsequalthis IS NULL) OR RLS = @Rlsequalthis) AND 
			((@Ubaequalthis IS NULL) OR UBA = @Ubaequalthis) AND 
			((@DataSchedaValidazioneequalthis IS NULL) OR DATA_SCHEDA_VALIDAZIONE = @DataSchedaValidazioneequalthis) AND 
			((@Barcodeequalthis IS NULL) OR BARCODE = @Barcodeequalthis) AND 
			((@CodTipoDetentoreequalthis IS NULL) OR COD_TIPO_DETENTORE = @CodTipoDetentoreequalthis) AND 
			((@CodDetentoreequalthis IS NULL) OR COD_DETENTORE = @CodDetentoreequalthis) AND 
			((@StatoTerritorioequalthis IS NULL) OR STATO_TERRITORIO = @StatoTerritorioequalthis) AND 
			((@StatoVeterinariaequalthis IS NULL) OR STATO_VETERINARIA = @StatoVeterinariaequalthis) AND 
			((@StatoFabbricatiequalthis IS NULL) OR STATO_FABBRICATI = @StatoFabbricatiequalthis) AND 
			((@StatoManodoperaequalthis IS NULL) OR STATO_MANODOPERA = @StatoManodoperaequalthis) AND 
			((@StatoMacchinariequalthis IS NULL) OR STATO_MACCHINARI = @StatoMacchinariequalthis)
