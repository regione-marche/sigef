CREATE PROCEDURE [dbo].[ZMandatiImpresaFindSelect]
(
	@Idequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdUtenteAbilitatoequalthis INT, 
	@CodEnteequalthis VARCHAR(10), 
	@CodiceSportelloCaaequalthis CHAR(9), 
	@TipoMandatoequalthis CHAR(3), 
	@Attivoequalthis BIT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@IdOperatoreInizioequalthis INT, 
	@IdOperatoreFineequalthis INT, 
	@SegnaturaMandatoequalthis VARCHAR(100), 
	@SegnaturaRevocaequalthis VARCHAR(100)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_IMPRESA, ID_UTENTE_ABILITATO, COD_ENTE, CODICE_SPORTELLO_CAA, TIPO_MANDATO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, SEGNATURA_MANDATO, SEGNATURA_REVOCA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, ID_STORICO_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_SEDELEGALE_ULTIMO, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, COD_TIPO_ENTE, ENTE FROM vMANDATI_IMPRESA WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdUtenteAbilitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_ABILITATO = @IdUtenteAbilitatoequalthis)'; set @lensql=@lensql+len(@IdUtenteAbilitatoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodiceSportelloCaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_SPORTELLO_CAA = @CodiceSportelloCaaequalthis)'; set @lensql=@lensql+len(@CodiceSportelloCaaequalthis);end;
	IF (@TipoMandatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_MANDATO = @TipoMandatoequalthis)'; set @lensql=@lensql+len(@TipoMandatoequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@IdOperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis)'; set @lensql=@lensql+len(@IdOperatoreInizioequalthis);end;
	IF (@IdOperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_FINE = @IdOperatoreFineequalthis)'; set @lensql=@lensql+len(@IdOperatoreFineequalthis);end;
	IF (@SegnaturaMandatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_MANDATO = @SegnaturaMandatoequalthis)'; set @lensql=@lensql+len(@SegnaturaMandatoequalthis);end;
	IF (@SegnaturaRevocaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SEGNATURA_REVOCA = @SegnaturaRevocaequalthis)'; set @lensql=@lensql+len(@SegnaturaRevocaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdImpresaequalthis INT, @IdUtenteAbilitatoequalthis INT, @CodEnteequalthis VARCHAR(10), @CodiceSportelloCaaequalthis CHAR(9), @TipoMandatoequalthis CHAR(3), @Attivoequalthis BIT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @IdOperatoreInizioequalthis INT, @IdOperatoreFineequalthis INT, @SegnaturaMandatoequalthis VARCHAR(100), @SegnaturaRevocaequalthis VARCHAR(100)',@Idequalthis , @IdImpresaequalthis , @IdUtenteAbilitatoequalthis , @CodEnteequalthis , @CodiceSportelloCaaequalthis , @TipoMandatoequalthis , @Attivoequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @IdOperatoreInizioequalthis , @IdOperatoreFineequalthis , @SegnaturaMandatoequalthis , @SegnaturaRevocaequalthis ;
	else
		SELECT ID, ID_IMPRESA, ID_UTENTE_ABILITATO, COD_ENTE, CODICE_SPORTELLO_CAA, TIPO_MANDATO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, SEGNATURA_MANDATO, SEGNATURA_REVOCA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, ID_STORICO_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_SEDELEGALE_ULTIMO, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, COD_TIPO_ENTE, ENTE
		FROM vMANDATI_IMPRESA
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdUtenteAbilitatoequalthis IS NULL) OR ID_UTENTE_ABILITATO = @IdUtenteAbilitatoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodiceSportelloCaaequalthis IS NULL) OR CODICE_SPORTELLO_CAA = @CodiceSportelloCaaequalthis) AND 
			((@TipoMandatoequalthis IS NULL) OR TIPO_MANDATO = @TipoMandatoequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@IdOperatoreInizioequalthis IS NULL) OR ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis) AND 
			((@IdOperatoreFineequalthis IS NULL) OR ID_OPERATORE_FINE = @IdOperatoreFineequalthis) AND 
			((@SegnaturaMandatoequalthis IS NULL) OR SEGNATURA_MANDATO = @SegnaturaMandatoequalthis) AND 
			((@SegnaturaRevocaequalthis IS NULL) OR SEGNATURA_REVOCA = @SegnaturaRevocaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZMandatiImpresaFindSelect';

