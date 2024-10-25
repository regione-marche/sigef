CREATE PROCEDURE [dbo].[ZMandatiImpresaFindFind]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(16), 
	@CodiceFiscaleequalthis VARCHAR(16), 
	@RagioneSocialelikethis VARCHAR(255), 
	@IdUtenteAbilitatoequalthis INT, 
	@CodEnteequalthis VARCHAR(10), 
	@CodTipoEnteequalthis VARCHAR(10), 
	@TipoMandatoequalthis CHAR(3), 
	@Attivoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_IMPRESA, ID_UTENTE_ABILITATO, COD_ENTE, CODICE_SPORTELLO_CAA, TIPO_MANDATO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, SEGNATURA_MANDATO, SEGNATURA_REVOCA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, ID_STORICO_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_SEDELEGALE_ULTIMO, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, COD_TIPO_ENTE, ENTE FROM vMANDATI_IMPRESA WHERE 1=1';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@RagioneSocialelikethis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE LIKE @RagioneSocialelikethis)'; set @lensql=@lensql+len(@RagioneSocialelikethis);end;
	IF (@IdUtenteAbilitatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE_ABILITATO = @IdUtenteAbilitatoequalthis)'; set @lensql=@lensql+len(@IdUtenteAbilitatoequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@CodTipoEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_ENTE = @CodTipoEnteequalthis)'; set @lensql=@lensql+len(@CodTipoEnteequalthis);end;
	IF (@TipoMandatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (TIPO_MANDATO = @TipoMandatoequalthis)'; set @lensql=@lensql+len(@TipoMandatoequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	set @sql = @sql + 'ORDER BY ATTIVO DESC, RAGIONE_SOCIALE';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(16), @CodiceFiscaleequalthis VARCHAR(16), @RagioneSocialelikethis VARCHAR(255), @IdUtenteAbilitatoequalthis INT, @CodEnteequalthis VARCHAR(10), @CodTipoEnteequalthis VARCHAR(10), @TipoMandatoequalthis CHAR(3), @Attivoequalthis BIT',@IdImpresaequalthis , @Cuaaequalthis , @CodiceFiscaleequalthis , @RagioneSocialelikethis , @IdUtenteAbilitatoequalthis , @CodEnteequalthis , @CodTipoEnteequalthis , @TipoMandatoequalthis , @Attivoequalthis ;
	else
		SELECT ID, ID_IMPRESA, ID_UTENTE_ABILITATO, COD_ENTE, CODICE_SPORTELLO_CAA, TIPO_MANDATO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, SEGNATURA_MANDATO, SEGNATURA_REVOCA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, ID_STORICO_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_SEDELEGALE_ULTIMO, RAGIONE_SOCIALE, COD_FORMA_GIURIDICA, ID_DIMENSIONE, COD_TIPO_ENTE, ENTE
		FROM vMANDATI_IMPRESA
		WHERE 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@RagioneSocialelikethis IS NULL) OR RAGIONE_SOCIALE LIKE @RagioneSocialelikethis) AND 
			((@IdUtenteAbilitatoequalthis IS NULL) OR ID_UTENTE_ABILITATO = @IdUtenteAbilitatoequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@CodTipoEnteequalthis IS NULL) OR COD_TIPO_ENTE = @CodTipoEnteequalthis) AND 
			((@TipoMandatoequalthis IS NULL) OR TIPO_MANDATO = @TipoMandatoequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis)
		ORDER BY ATTIVO DESC, RAGIONE_SOCIALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZMandatiImpresaFindFind';

