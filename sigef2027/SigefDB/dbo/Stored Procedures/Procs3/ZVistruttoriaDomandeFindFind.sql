CREATE PROCEDURE [dbo].[ZVistruttoriaDomandeFindFind]
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdIstruttoreequalthis INT, 
	@ProvinciaAssegnazioneequalthis CHAR(2), 
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@RagioneSocialelikethis VARCHAR(255), 
	@FiltroStatoIstruttoriaequalthis CHAR(1), 
	@SelezionataXRevisioneequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, COD_STATO, STATO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, ID_ISTRUTTORE, VIA, SEGNATURA_RI, FILTRO_STATO_ISTRUTTORIA, ORDINE_STATO, ID_IMPRESA FROM vISTRUTTORIA_DOMANDE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_ISTRUTTORE = @IdIstruttoreequalthis)'; set @lensql=@lensql+len(@IdIstruttoreequalthis);end;
	IF (@ProvinciaAssegnazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis)'; set @lensql=@lensql+len(@ProvinciaAssegnazioneequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)'; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	IF (@FiltroStatoIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis)'; set @lensql=@lensql+len(@FiltroStatoIstruttoriaequalthis);end;
	IF (@SelezionataXRevisioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)'; set @lensql=@lensql+len(@SelezionataXRevisioneequalthis);end;
	set @sql = @sql + 'ORDER BY ID_PROGETTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @IdIstruttoreequalthis INT, @ProvinciaAssegnazioneequalthis CHAR(2), @IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(16), @RagioneSocialelikethis VARCHAR(255), @FiltroStatoIstruttoriaequalthis CHAR(1), @SelezionataXRevisioneequalthis BIT',@IdBandoequalthis , @IdProgettoequalthis , @IdIstruttoreequalthis , @ProvinciaAssegnazioneequalthis , @IdImpresaequalthis , @Cuaaequalthis , @RagioneSocialelikethis , @FiltroStatoIstruttoriaequalthis , @SelezionataXRevisioneequalthis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, COD_STATO, STATO, CUAA, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, ID_ISTRUTTORE, VIA, SEGNATURA_RI, FILTRO_STATO_ISTRUTTORIA, ORDINE_STATO, ID_IMPRESA
		FROM vISTRUTTORIA_DOMANDE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdIstruttoreequalthis IS NULL) OR ID_ISTRUTTORE = @IdIstruttoreequalthis) AND 
			((@ProvinciaAssegnazioneequalthis IS NULL) OR PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis) AND 
			((@FiltroStatoIstruttoriaequalthis IS NULL) OR FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis) AND 
			((@SelezionataXRevisioneequalthis IS NULL) OR SELEZIONATA_X_REVISIONE = @SelezionataXRevisioneequalthis)
		ORDER BY ID_PROGETTO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVistruttoriaDomandeFindFind]
(
	@IdBandoequalthis INT, 
	@CfIstruttoreequalthis VARCHAR(16), 
	@IdProgettoequalthis INT, 
	@FiltroStatoIstruttoriaequalthis CHAR(1), 
	@ProvinciaAssegnazioneequalthis CHAR(2), 
	@Cuaalikethis VARCHAR(16), 
	@RagioneSocialelikethis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, CUAA, COD_STATO, STATO, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, FILTRO_STATO_ISTRUTTORIA, CF_ISTRUTTORE, VIA, SEGNATURA_RI FROM vISTRUTTORIA_DOMANDE WHERE 1=1'';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_BANDO = @IdBandoequalthis)''; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@CfIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CF_ISTRUTTORE = @CfIstruttoreequalthis)''; set @lensql=@lensql+len(@CfIstruttoreequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@FiltroStatoIstruttoriaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis)''; set @lensql=@lensql+len(@FiltroStatoIstruttoriaequalthis);end;
	IF (@ProvinciaAssegnazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis)''; set @lensql=@lensql+len(@ProvinciaAssegnazioneequalthis);end;
	IF (@Cuaalikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA LIKE @Cuaalikethis)''; set @lensql=@lensql+len(@Cuaalikethis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)''; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	set @sql = @sql + ''ORDER BY ID_PROGETTO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdBandoequalthis INT, @CfIstruttoreequalthis VARCHAR(16), @IdProgettoequalthis INT, @FiltroStatoIstruttoriaequalthis CHAR(1), @ProvinciaAssegnazioneequalthis CHAR(2), @Cuaalikethis VARCHAR(16), @RagioneSocialelikethis VARCHAR(255)'',@IdBandoequalthis , @CfIstruttoreequalthis , @IdProgettoequalthis , @FiltroStatoIstruttoriaequalthis , @ProvinciaAssegnazioneequalthis , @Cuaalikethis , @RagioneSocialelikethis ;
	else
		SELECT ID_PROGETTO, ID_BANDO, ID_PROG_INTEGRATO, CUAA, COD_STATO, STATO, PARTITA_IVA, RAGIONE_SOCIALE, COMUNE, SIGLA, CAP, ISTRUTTORE, PROVINCIA_ASSEGNAZIONE, SELEZIONATA_X_REVISIONE, PROVINCIA_DI_PRESENTAZIONE, FILTRO_STATO_ISTRUTTORIA, CF_ISTRUTTORE, VIA, SEGNATURA_RI
		FROM vISTRUTTORIA_DOMANDE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@CfIstruttoreequalthis IS NULL) OR CF_ISTRUTTORE = @CfIstruttoreequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@FiltroStatoIstruttoriaequalthis IS NULL) OR FILTRO_STATO_ISTRUTTORIA = @FiltroStatoIstruttoriaequalthis) AND 
			((@ProvinciaAssegnazioneequalthis IS NULL) OR PROVINCIA_ASSEGNAZIONE = @ProvinciaAssegnazioneequalthis) AND 
			((@Cuaalikethis IS NULL) OR CUAA LIKE @Cuaalikethis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)
		ORDER BY ID_PROGETTO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVistruttoriaDomandeFindFind';

