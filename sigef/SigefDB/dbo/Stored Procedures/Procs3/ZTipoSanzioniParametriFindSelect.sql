CREATE PROCEDURE [dbo].[ZTipoSanzioniParametriFindSelect]
(
	@Codiceequalthis INT, 
	@CodTipoSanzioneequalthis VARCHAR(10), 
	@Descrizioneequalthis VARCHAR(500), 
	@NonComportaSanzioneequalthis BIT, 
	@Durataequalthis BIT, 
	@Gravitaequalthis BIT, 
	@Entitaequalthis BIT, 
	@ClasseViolazioneequalthis INT, 
	@Tooltipequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT CODICE, COD_TIPO_SANZIONE, DESCRIZIONE, NON_COMPORTA_SANZIONE, DURATA, GRAVITA, ENTITA, CLASSE_VIOLAZIONE, TOOLTIP FROM TIPO_SANZIONI_PARAMETRI WHERE 1=1';
	IF (@Codiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE = @Codiceequalthis)'; set @lensql=@lensql+len(@Codiceequalthis);end;
	IF (@CodTipoSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SANZIONE = @CodTipoSanzioneequalthis)'; set @lensql=@lensql+len(@CodTipoSanzioneequalthis);end;
	IF (@Descrizioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE = @Descrizioneequalthis)'; set @lensql=@lensql+len(@Descrizioneequalthis);end;
	IF (@NonComportaSanzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NON_COMPORTA_SANZIONE = @NonComportaSanzioneequalthis)'; set @lensql=@lensql+len(@NonComportaSanzioneequalthis);end;
	IF (@Durataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DURATA = @Durataequalthis)'; set @lensql=@lensql+len(@Durataequalthis);end;
	IF (@Gravitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (GRAVITA = @Gravitaequalthis)'; set @lensql=@lensql+len(@Gravitaequalthis);end;
	IF (@Entitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ENTITA = @Entitaequalthis)'; set @lensql=@lensql+len(@Entitaequalthis);end;
	IF (@ClasseViolazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CLASSE_VIOLAZIONE = @ClasseViolazioneequalthis)'; set @lensql=@lensql+len(@ClasseViolazioneequalthis);end;
	IF (@Tooltipequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TOOLTIP = @Tooltipequalthis)'; set @lensql=@lensql+len(@Tooltipequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Codiceequalthis INT, @CodTipoSanzioneequalthis VARCHAR(10), @Descrizioneequalthis VARCHAR(500), @NonComportaSanzioneequalthis BIT, @Durataequalthis BIT, @Gravitaequalthis BIT, @Entitaequalthis BIT, @ClasseViolazioneequalthis INT, @Tooltipequalthis VARCHAR(255)',@Codiceequalthis , @CodTipoSanzioneequalthis , @Descrizioneequalthis , @NonComportaSanzioneequalthis , @Durataequalthis , @Gravitaequalthis , @Entitaequalthis , @ClasseViolazioneequalthis , @Tooltipequalthis ;
	else
		SELECT CODICE, COD_TIPO_SANZIONE, DESCRIZIONE, NON_COMPORTA_SANZIONE, DURATA, GRAVITA, ENTITA, CLASSE_VIOLAZIONE, TOOLTIP
		FROM TIPO_SANZIONI_PARAMETRI
		WHERE 
			((@Codiceequalthis IS NULL) OR CODICE = @Codiceequalthis) AND 
			((@CodTipoSanzioneequalthis IS NULL) OR COD_TIPO_SANZIONE = @CodTipoSanzioneequalthis) AND 
			((@Descrizioneequalthis IS NULL) OR DESCRIZIONE = @Descrizioneequalthis) AND 
			((@NonComportaSanzioneequalthis IS NULL) OR NON_COMPORTA_SANZIONE = @NonComportaSanzioneequalthis) AND 
			((@Durataequalthis IS NULL) OR DURATA = @Durataequalthis) AND 
			((@Gravitaequalthis IS NULL) OR GRAVITA = @Gravitaequalthis) AND 
			((@Entitaequalthis IS NULL) OR ENTITA = @Entitaequalthis) AND 
			((@ClasseViolazioneequalthis IS NULL) OR CLASSE_VIOLAZIONE = @ClasseViolazioneequalthis) AND 
			((@Tooltipequalthis IS NULL) OR TOOLTIP = @Tooltipequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZTipoSanzioniParametriFindSelect';

