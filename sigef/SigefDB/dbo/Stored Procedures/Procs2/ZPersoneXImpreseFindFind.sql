CREATE PROCEDURE [dbo].[ZPersoneXImpreseFindFind]
(
	@IdPersonaequalthis INT, 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@PotereDiFirmaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO, POTERE_DI_FIRMA, ATTIVO FROM vPERSONE_X_IMPRESE WHERE 1=1';
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO = @CodRuoloequalthis)'; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@PotereDiFirmaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POTERE_DI_FIRMA = @PotereDiFirmaequalthis)'; set @lensql=@lensql+len(@PotereDiFirmaequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_INIZIO DESC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPersonaequalthis INT, @CodiceFiscaleequalthis VARCHAR(255), @IdImpresaequalthis INT, @CodRuoloequalthis VARCHAR(255), @Attivoequalthis BIT, @PotereDiFirmaequalthis BIT',@IdPersonaequalthis , @CodiceFiscaleequalthis , @IdImpresaequalthis , @CodRuoloequalthis , @Attivoequalthis , @PotereDiFirmaequalthis ;
	else
		SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO, POTERE_DI_FIRMA, ATTIVO
		FROM vPERSONE_X_IMPRESE
		WHERE 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@PotereDiFirmaequalthis IS NULL) OR POTERE_DI_FIRMA = @PotereDiFirmaequalthis)
		ORDER BY DATA_INIZIO DESC


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPersoneXImpreseFindFind]
(
	@IdPersonaequalthis INT, 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@DataInizioeqlessthanthis DATETIME, 
	@DataFineeqgreaterthanthis DATETIME, 
	@DataFineisnull bit
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO FROM vPERSONE_X_IMPRESE WHERE 1=1'';
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA = @IdPersonaequalthis)''; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)''; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO = @CodRuoloequalthis)''; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@DataInizioeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO <= @DataInizioeqlessthanthis)''; set @lensql=@lensql+len(@DataInizioeqlessthanthis);end;
	IF (@DataFineeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE >= @DataFineeqgreaterthanthis)''; set @lensql=@lensql+len(@DataFineeqgreaterthanthis);end;
	IF (@DataFineisnull IS NOT NULL) BEGIN SET @sql = @sql + '' AND (((CASE WHEN (DATA_FINE IS NULL) THEN 1 ELSE 0 END) = @DataFineisnull))''; set @lensql=@lensql+len(@DataFineisnull);end;
	set @sql = @sql + ''ORDER BY DATA_INIZIO DESC'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPersonaequalthis INT, @CodiceFiscaleequalthis VARCHAR(255), @IdImpresaequalthis INT, @CodRuoloequalthis VARCHAR(255), @DataInizioeqlessthanthis DATETIME, @DataFineeqgreaterthanthis DATETIME, @DataFineisnull bit'',@IdPersonaequalthis , @CodiceFiscaleequalthis , @IdImpresaequalthis , @CodRuoloequalthis , @DataInizioeqlessthanthis , @DataFineeqgreaterthanthis , @DataFineisnull ;
	else
		SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO
		FROM vPERSONE_X_IMPRESE
		WHERE 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@DataInizioeqlessthanthis IS NULL) OR DATA_INIZIO <= @DataInizioeqlessthanthis) AND 
			((@DataFineeqgreaterthanthis IS NULL) OR DATA_FINE >= @DataFineeqgreaterthanthis) AND 
			((@DataFineisnull IS NULL) OR ((CASE WHEN (DATA_FINE IS NULL) THEN 1 ELSE 0 END) = @DataFineisnull))
		ORDER BY DATA_INIZIO DESC
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersoneXImpreseFindFind';

