CREATE PROCEDURE [dbo].[ZComuniFindSelect]
(
	@IdComuneequalthis INT, 
	@CodBelfioreequalthis VARCHAR(255), 
	@Denominazioneequalthis VARCHAR(255), 
	@CodProvinciaequalthis VARCHAR(255), 
	@Siglaequalthis VARCHAR(255), 
	@Capequalthis VARCHAR(255), 
	@Istatequalthis VARCHAR(255), 
	@TipoAreaequalthis VARCHAR(255), 
	@CodRubricaPaleoequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@IdOperatoreInizioequalthis INT, 
	@IdOperatoreFineequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_COMUNE, COD_BELFIORE, DENOMINAZIONE, COD_PROVINCIA, SIGLA, CAP, ISTAT, TIPO_AREA, COD_RUBRICA_PALEO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, COD_CITTA_METROPOLITANA, PROVINCIA, COD_REGIONE, REGIONE FROM vCOMUNI WHERE 1=1';
	IF (@IdComuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE = @IdComuneequalthis)'; set @lensql=@lensql+len(@IdComuneequalthis);end;
	IF (@CodBelfioreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_BELFIORE = @CodBelfioreequalthis)'; set @lensql=@lensql+len(@CodBelfioreequalthis);end;
	IF (@Denominazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DENOMINAZIONE = @Denominazioneequalthis)'; set @lensql=@lensql+len(@Denominazioneequalthis);end;
	IF (@CodProvinciaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_PROVINCIA = @CodProvinciaequalthis)'; set @lensql=@lensql+len(@CodProvinciaequalthis);end;
	IF (@Siglaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SIGLA = @Siglaequalthis)'; set @lensql=@lensql+len(@Siglaequalthis);end;
	IF (@Capequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CAP = @Capequalthis)'; set @lensql=@lensql+len(@Capequalthis);end;
	IF (@Istatequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISTAT = @Istatequalthis)'; set @lensql=@lensql+len(@Istatequalthis);end;
	IF (@TipoAreaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_AREA = @TipoAreaequalthis)'; set @lensql=@lensql+len(@TipoAreaequalthis);end;
	IF (@CodRubricaPaleoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUBRICA_PALEO = @CodRubricaPaleoequalthis)'; set @lensql=@lensql+len(@CodRubricaPaleoequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@IdOperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis)'; set @lensql=@lensql+len(@IdOperatoreInizioequalthis);end;
	IF (@IdOperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_FINE = @IdOperatoreFineequalthis)'; set @lensql=@lensql+len(@IdOperatoreFineequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdComuneequalthis INT, @CodBelfioreequalthis VARCHAR(255), @Denominazioneequalthis VARCHAR(255), @CodProvinciaequalthis VARCHAR(255), @Siglaequalthis VARCHAR(255), @Capequalthis VARCHAR(255), @Istatequalthis VARCHAR(255), @TipoAreaequalthis VARCHAR(255), @CodRubricaPaleoequalthis VARCHAR(255), @Attivoequalthis BIT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @IdOperatoreInizioequalthis INT, @IdOperatoreFineequalthis INT',@IdComuneequalthis , @CodBelfioreequalthis , @Denominazioneequalthis , @CodProvinciaequalthis , @Siglaequalthis , @Capequalthis , @Istatequalthis , @TipoAreaequalthis , @CodRubricaPaleoequalthis , @Attivoequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @IdOperatoreInizioequalthis , @IdOperatoreFineequalthis ;
	else
		SELECT ID_COMUNE, COD_BELFIORE, DENOMINAZIONE, COD_PROVINCIA, SIGLA, CAP, ISTAT, TIPO_AREA, COD_RUBRICA_PALEO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, COD_CITTA_METROPOLITANA, PROVINCIA, COD_REGIONE, REGIONE
		FROM vCOMUNI
		WHERE 
			((@IdComuneequalthis IS NULL) OR ID_COMUNE = @IdComuneequalthis) AND 
			((@CodBelfioreequalthis IS NULL) OR COD_BELFIORE = @CodBelfioreequalthis) AND 
			((@Denominazioneequalthis IS NULL) OR DENOMINAZIONE = @Denominazioneequalthis) AND 
			((@CodProvinciaequalthis IS NULL) OR COD_PROVINCIA = @CodProvinciaequalthis) AND 
			((@Siglaequalthis IS NULL) OR SIGLA = @Siglaequalthis) AND 
			((@Capequalthis IS NULL) OR CAP = @Capequalthis) AND 
			((@Istatequalthis IS NULL) OR ISTAT = @Istatequalthis) AND 
			((@TipoAreaequalthis IS NULL) OR TIPO_AREA = @TipoAreaequalthis) AND 
			((@CodRubricaPaleoequalthis IS NULL) OR COD_RUBRICA_PALEO = @CodRubricaPaleoequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@IdOperatoreInizioequalthis IS NULL) OR ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis) AND 
			((@IdOperatoreFineequalthis IS NULL) OR ID_OPERATORE_FINE = @IdOperatoreFineequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZComuniFindSelect';

