CREATE PROCEDURE [dbo].[ZFascicoloPaleoFindSelect]
(
	@Idequalthis INT, 
	@Annoequalthis INT, 
	@CodTipoequalthis VARCHAR(255), 
	@Fascicoloequalthis VARCHAR(255), 
	@Provinciaequalthis VARCHAR(255), 
	@CodEnteequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@Noteequalthis VARCHAR(1000)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ANNO, COD_TIPO, FASCICOLO, PROVINCIA, COD_ENTE, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, NOTE FROM FASCICOLO_PALEO WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@Annoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO = @Annoequalthis)'; set @lensql=@lensql+len(@Annoequalthis);end;
	IF (@CodTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO = @CodTipoequalthis)'; set @lensql=@lensql+len(@CodTipoequalthis);end;
	IF (@Fascicoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (FASCICOLO = @Fascicoloequalthis)'; set @lensql=@lensql+len(@Fascicoloequalthis);end;
	IF (@Provinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PROVINCIA = @Provinciaequalthis)'; set @lensql=@lensql+len(@Provinciaequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@Noteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE = @Noteequalthis)'; set @lensql=@lensql+len(@Noteequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @Annoequalthis INT, @CodTipoequalthis VARCHAR(255), @Fascicoloequalthis VARCHAR(255), @Provinciaequalthis VARCHAR(255), @CodEnteequalthis VARCHAR(255), @Attivoequalthis BIT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @Noteequalthis VARCHAR(1000)',@Idequalthis , @Annoequalthis , @CodTipoequalthis , @Fascicoloequalthis , @Provinciaequalthis , @CodEnteequalthis , @Attivoequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @Noteequalthis ;
	else
		SELECT ID, ANNO, COD_TIPO, FASCICOLO, PROVINCIA, COD_ENTE, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, NOTE
		FROM FASCICOLO_PALEO
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@Annoequalthis IS NULL) OR ANNO = @Annoequalthis) AND 
			((@CodTipoequalthis IS NULL) OR COD_TIPO = @CodTipoequalthis) AND 
			((@Fascicoloequalthis IS NULL) OR FASCICOLO = @Fascicoloequalthis) AND 
			((@Provinciaequalthis IS NULL) OR PROVINCIA = @Provinciaequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@Noteequalthis IS NULL) OR NOTE = @Noteequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZFascicoloPaleoFindSelect';

