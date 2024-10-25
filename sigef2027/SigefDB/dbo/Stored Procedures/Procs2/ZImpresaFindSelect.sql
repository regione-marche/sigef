CREATE PROCEDURE [dbo].[ZImpresaFindSelect]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@AnnoCostituzioneequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@IscrizioneRegistroImpreseequalthis VARCHAR(255), 
	@DataInizioAttivitaequalthis DATETIME, 
	@IdStoricoUltimoequalthis INT, 
	@IdSedelegaleUltimoequalthis INT, 
	@IdRapprlegaleUltimoequalthis INT, 
	@IdContoCorrenteUltimoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007 FROM vIMPRESA WHERE 1=1';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CUAA = @Cuaaequalthis)'; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@AnnoCostituzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNO_COSTITUZIONE = @AnnoCostituzioneequalthis)'; set @lensql=@lensql+len(@AnnoCostituzioneequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE = @CodEnteequalthis)'; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IscrizioneRegistroImpreseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ISCRIZIONE_REGISTRO_IMPRESE = @IscrizioneRegistroImpreseequalthis)'; set @lensql=@lensql+len(@IscrizioneRegistroImpreseequalthis);end;
	IF (@DataInizioAttivitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_ATTIVITA = @DataInizioAttivitaequalthis)'; set @lensql=@lensql+len(@DataInizioAttivitaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)'; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@IdSedelegaleUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SEDELEGALE_ULTIMO = @IdSedelegaleUltimoequalthis)'; set @lensql=@lensql+len(@IdSedelegaleUltimoequalthis);end;
	IF (@IdRapprlegaleUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RAPPRLEGALE_ULTIMO = @IdRapprlegaleUltimoequalthis)'; set @lensql=@lensql+len(@IdRapprlegaleUltimoequalthis);end;
	IF (@IdContoCorrenteUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTO_CORRENTE_ULTIMO = @IdContoCorrenteUltimoequalthis)'; set @lensql=@lensql+len(@IdContoCorrenteUltimoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @AnnoCostituzioneequalthis INT, @CodEnteequalthis VARCHAR(255), @IscrizioneRegistroImpreseequalthis VARCHAR(255), @DataInizioAttivitaequalthis DATETIME, @IdStoricoUltimoequalthis INT, @IdSedelegaleUltimoequalthis INT, @IdRapprlegaleUltimoequalthis INT, @IdContoCorrenteUltimoequalthis INT',@IdImpresaequalthis , @Cuaaequalthis , @CodiceFiscaleequalthis , @AnnoCostituzioneequalthis , @CodEnteequalthis , @IscrizioneRegistroImpreseequalthis , @DataInizioAttivitaequalthis , @IdStoricoUltimoequalthis , @IdSedelegaleUltimoequalthis , @IdRapprlegaleUltimoequalthis , @IdContoCorrenteUltimoequalthis ;
	else
		SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE, COD_ATECO2007
		FROM vIMPRESA
		WHERE 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@Cuaaequalthis IS NULL) OR CUAA = @Cuaaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@AnnoCostituzioneequalthis IS NULL) OR ANNO_COSTITUZIONE = @AnnoCostituzioneequalthis) AND 
			((@CodEnteequalthis IS NULL) OR COD_ENTE = @CodEnteequalthis) AND 
			((@IscrizioneRegistroImpreseequalthis IS NULL) OR ISCRIZIONE_REGISTRO_IMPRESE = @IscrizioneRegistroImpreseequalthis) AND 
			((@DataInizioAttivitaequalthis IS NULL) OR DATA_INIZIO_ATTIVITA = @DataInizioAttivitaequalthis) AND 
			((@IdStoricoUltimoequalthis IS NULL) OR ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis) AND 
			((@IdSedelegaleUltimoequalthis IS NULL) OR ID_SEDELEGALE_ULTIMO = @IdSedelegaleUltimoequalthis) AND 
			((@IdRapprlegaleUltimoequalthis IS NULL) OR ID_RAPPRLEGALE_ULTIMO = @IdRapprlegaleUltimoequalthis) AND 
			((@IdContoCorrenteUltimoequalthis IS NULL) OR ID_CONTO_CORRENTE_ULTIMO = @IdContoCorrenteUltimoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaFindSelect]
(
	@IdImpresaequalthis INT, 
	@Cuaaequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@AnnoCostituzioneequalthis INT, 
	@CodEnteequalthis VARCHAR(255), 
	@IscrizioneRegistroImpreseequalthis VARCHAR(255), 
	@DataInizioAttivitaequalthis DATETIME, 
	@IdStoricoUltimoequalthis INT, 
	@IdSedelegaleUltimoequalthis INT, 
	@IdRapprlegaleUltimoequalthis INT, 
	@IdContoCorrenteUltimoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESENTAZIONE, DESCRIZIONE, ID_STORICO_IMPRESA, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, RAGIONE_SOCIALE, CODICE_INPS, COD_FORMA_GIURIDICA, ID_DIMENSIONE, DIMENSIONE_IMPRESA, FORMA_GIURIDICA, FOGLIA, DATA_INIZIO_ATTIVITA, REGISTRO_IMPRESE_NUMERO, REA_NUMERO, REA_ANNO, ID_STORICO_ULTIMO, ID_RAPPRLEGALE_ULTIMO, ID_CONTO_CORRENTE_ULTIMO, ID_SEDELEGALE_ULTIMO, COD_CLASSIFICAZIONE_UMA, ATTIVA, DATA_CESSAZIONE, SEGNATURA_CESSAZIONE, COD_TIPO_CESSAZIONE FROM vIMPRESA WHERE 1=1'';
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@Cuaaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CUAA = @Cuaaequalthis)''; set @lensql=@lensql+len(@Cuaaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)''; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@AnnoCostituzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ANNO_COSTITUZIONE = @AnnoCostituzioneequalthis)''; set @lensql=@lensql+len(@AnnoCostituzioneequalthis);end;
	IF (@CodEnteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_ENTE = @CodEnteequalthis)''; set @lensql=@lensql+len(@CodEnteequalthis);end;
	IF (@IscrizioneRegistroImpreseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ISCRIZIONE_REGISTRO_IMPRESE = @IscrizioneRegistroImpreseequalthis)''; set @lensql=@lensql+len(@IscrizioneRegistroImpreseequalthis);end;
	IF (@DataInizioAttivitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO_ATTIVITA = @DataInizioAttivitaequalthis)''; set @lensql=@lensql+len(@DataInizioAttivitaequalthis);end;
	IF (@IdStoricoUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_STORICO_ULTIMO = @IdStoricoUltimoequalthis)''; set @lensql=@lensql+len(@IdStoricoUltimoequalthis);end;
	IF (@IdSedelegaleUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SEDELEGALE_ULTIMO = @IdSedelegaleUltimoequalthis)''; set @lensql=@lensql+len(@IdSedelegaleUltimoequalthis);end;
	IF (@IdRapprlegaleUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_RAPPRLEGALE_ULTIMO = @IdRapprlegaleUltimoequalthis)''; set @lensql=@lensql+len(@IdRapprlegaleUltimoequalthis);end;
	IF (@IdContoCorrenteUltimoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CONTO_CORRENTE_ULTIMO = @IdContoCorrenteUltimoequalthis)''; set @lensql=@lensql+len(@IdContoCorrenteUltimoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdImpresaequalthis INT, @Cuaaequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @AnnoCostituzioneequalthis INT, @CodEnteequalthis VARCHAR(255), @IscrizioneRegistroImpreseequalthis VARCHAR(255), @DataInizioAttivitaequalthis DATETIME, @IdStoricoUltimoequalthis INT, @IdSedelegaleUltimoequalthis INT, @IdRapprlegaleUltimoequalthis INT, @IdContoCorrenteUltimoequalthis INT'',@IdImpresaequalthis , @Cuaaequalthis , @CodiceFiscaleequalthis , @AnnoCostituzioneequalthis , @CodEnteequalthis , @IscrizioneRegistroImpreseequalthis , @DataInizioAttivitaequalthis , @IdStoricoUltimoequalthis , @IdSedelegaleUltimoequalthis , @IdRapprlegaleUltimoequalthis , @IdContoCorrenteUltimoequalthis ;
	else
		SELECT ID_IMPRESA, CUAA, CODICE_FISCALE, ANNO_COSTITUZIONE, COD_ENTE, ISCRIZIONE_REGISTRO_IMPRESE, PRESE', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaFindSelect';

