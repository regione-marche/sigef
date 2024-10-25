CREATE PROCEDURE [dbo].[ZImpresaAggregazioneFindFind]
(
	@IdAggregazioneequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Attivoequalthis BIT, 
	@Cuaaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE, COD_ATECO2007 FROM vIMPRESA_AGGREGAZIONE WHERE 1=1';
	IF (@IdAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_AGGREGAZIONE = @IdAggregazioneequalthis)'; set @lensql=@lensql+len(@IdAggregazioneequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO = @CodRuoloequalthis)'; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, DATA_FINE, RAGIONE_SOCIALE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdAggregazioneequalthis INT, @CodRuoloequalthis VARCHAR(255), @IdImpresaequalthis INT, @Attivoequalthis BIT, @Cuaaequalthis VARCHAR(255)',@IdAggregazioneequalthis , @CodRuoloequalthis , @IdImpresaequalthis , @Attivoequalthis , @Cuaaequalthis ;
	else
		SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE, COD_ATECO2007
		FROM vIMPRESA_AGGREGAZIONE
		WHERE 
			((@IdAggregazioneequalthis IS NULL) OR ID_AGGREGAZIONE = @IdAggregazioneequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis)
		ORDER BY ATTIVO DESC, DATA_FINE, RAGIONE_SOCIALE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaAggregazioneFindFind]
(
	@IdAggregazioneequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@Attivoequalthis BIT, 
	@Cuaaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE FROM vIMPRESA_AGGREGAZIONE WHERE 1=1'';
	IF (@IdAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_AGGREGAZIONE = @IdAggregazioneequalthis)''; set @lensql=@lensql+len(@IdAggregazioneequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO = @CodRuoloequalthis)''; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ATTIVO = @Attivoequalthis)''; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	set @sql = @sql + ''ORDER BY ATTIVO DESC, DATA_FINE, RAGIONE_SOCIALE'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdAggregazioneequalthis INT, @CodRuoloequalthis VARCHAR(255), @IdImpresaequalthis INT, @Attivoequalthis BIT, @Cuaaequalthis VARCHAR(255)'',@IdAggregazioneequalthis , @CodRuoloequalthis , @IdImpresaequalthis , @Attivoequalthis , @Cuaaequalthis ;
	else
		SELECT ID, ID_AGGREGAZIONE, COD_RUOLO, ID_IMPRESA, PERCENTUALE, DATA_INIZIO, OPERATORE_INIZIO, ATTIVO, DATA_FINE, OPERATORE_FINE, CUAA, RAGIONE_SOCIALE, DENOMINAZIONE, RUOLO_AGGREGAZIONE
		FROM vIMPRESA_AGGREGAZIONE
		WHERE 
			((@IdAggregazioneequalthis IS NULL) OR ID_AGGREGAZIONE = @IdAggregazioneequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis)
		ORDER BY ATTIVO DESC, DATA_FINE, RAGIONE_SOCIALE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaAggregazioneFindFind';

