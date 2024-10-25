CREATE PROCEDURE [dbo].[ZAggregazioneFindFind]
(
	@CodTipoAggregazioneequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@IdImpresaequalthis INT, 
	@ImpresaAggregazioneAttivaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, DENOMINAZIONE, COD_TIPO_AGGREGAZIONE, DATA_INIZIO, ATTIVO, DATA_FINE, OPERATORE_INIZIO, OPERATORE_FINE, DESCRIZIONE_TIPO_AGGREGAZIONE, ID_IMPRESA, IMPRESA_AGGREGAZIONE_ATTIVA FROM vAGGREGAZIONE WHERE 1=1';
	IF (@CodTipoAggregazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_AGGREGAZIONE = @CodTipoAggregazioneequalthis)'; set @lensql=@lensql+len(@CodTipoAggregazioneequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@ImpresaAggregazioneAttivaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPRESA_AGGREGAZIONE_ATTIVA = @ImpresaAggregazioneAttivaequalthis)'; set @lensql=@lensql+len(@ImpresaAggregazioneAttivaequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, DATA_INIZIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodTipoAggregazioneequalthis VARCHAR(255), @Attivoequalthis BIT, @IdImpresaequalthis INT, @ImpresaAggregazioneAttivaequalthis BIT',@CodTipoAggregazioneequalthis , @Attivoequalthis , @IdImpresaequalthis , @ImpresaAggregazioneAttivaequalthis ;
	else
		SELECT ID, DENOMINAZIONE, COD_TIPO_AGGREGAZIONE, DATA_INIZIO, ATTIVO, DATA_FINE, OPERATORE_INIZIO, OPERATORE_FINE, DESCRIZIONE_TIPO_AGGREGAZIONE, ID_IMPRESA, IMPRESA_AGGREGAZIONE_ATTIVA
		FROM vAGGREGAZIONE
		WHERE 
			((@CodTipoAggregazioneequalthis IS NULL) OR COD_TIPO_AGGREGAZIONE = @CodTipoAggregazioneequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@ImpresaAggregazioneAttivaequalthis IS NULL) OR IMPRESA_AGGREGAZIONE_ATTIVA = @ImpresaAggregazioneAttivaequalthis)
		ORDER BY ATTIVO DESC, DATA_INIZIO DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAggregazioneFindFind';

