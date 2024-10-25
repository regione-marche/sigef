CREATE PROCEDURE [dbo].[ZPersoneXImpreseFindSelect]
(
	@IdPersoneXImpreseequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdPersonaequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@Attivoequalthis BIT, 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@Ammessoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO, POTERE_DI_FIRMA, ATTIVO FROM vPERSONE_X_IMPRESE WHERE 1=1';
	IF (@IdPersoneXImpreseequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONE_X_IMPRESE = @IdPersoneXImpreseequalthis)'; set @lensql=@lensql+len(@IdPersoneXImpreseequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO = @CodRuoloequalthis)'; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO = @DataInizioequalthis)'; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE = @DataFineequalthis)'; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPersoneXImpreseequalthis INT, @IdImpresaequalthis INT, @IdPersonaequalthis INT, @CodRuoloequalthis VARCHAR(255), @Attivoequalthis BIT, @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @Ammessoequalthis BIT',@IdPersoneXImpreseequalthis , @IdImpresaequalthis , @IdPersonaequalthis , @CodRuoloequalthis , @Attivoequalthis , @DataInizioequalthis , @DataFineequalthis , @Ammessoequalthis ;
	else
		SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO, POTERE_DI_FIRMA, ATTIVO
		FROM vPERSONE_X_IMPRESE
		WHERE 
			((@IdPersoneXImpreseequalthis IS NULL) OR ID_PERSONE_X_IMPRESE = @IdPersoneXImpreseequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPersoneXImpreseFindSelect]
(
	@IdPersoneXImpreseequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdPersonaequalthis INT, 
	@CodRuoloequalthis VARCHAR(255), 
	@DataInizioequalthis DATETIME, 
	@DataFineequalthis DATETIME, 
	@Ammessoequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO FROM vPERSONE_X_IMPRESE WHERE 1=1'';
	IF (@IdPersoneXImpreseequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONE_X_IMPRESE = @IdPersoneXImpreseequalthis)''; set @lensql=@lensql+len(@IdPersoneXImpreseequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_IMPRESA = @IdImpresaequalthis)''; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PERSONA = @IdPersonaequalthis)''; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@CodRuoloequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RUOLO = @CodRuoloequalthis)''; set @lensql=@lensql+len(@CodRuoloequalthis);end;
	IF (@DataInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_INIZIO = @DataInizioequalthis)''; set @lensql=@lensql+len(@DataInizioequalthis);end;
	IF (@DataFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (DATA_FINE = @DataFineequalthis)''; set @lensql=@lensql+len(@DataFineequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (AMMESSO = @Ammessoequalthis)''; set @lensql=@lensql+len(@Ammessoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPersoneXImpreseequalthis INT, @IdImpresaequalthis INT, @IdPersonaequalthis INT, @CodRuoloequalthis VARCHAR(255), @DataInizioequalthis DATETIME, @DataFineequalthis DATETIME, @Ammessoequalthis BIT'',@IdPersoneXImpreseequalthis , @IdImpresaequalthis , @IdPersonaequalthis , @CodRuoloequalthis , @DataInizioequalthis , @DataFineequalthis , @Ammessoequalthis ;
	else
		SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_COMUNE_NASCITA, ID_CITTADINANZA, ID_PERSONE_X_IMPRESE, ID_IMPRESA, COD_RUOLO, DATA_INIZIO, DATA_FINE, RUOLO, COMUNE, SIGLA, CAP, COD_BELFIORE, AMMESSO
		FROM vPERSONE_X_IMPRESE
		WHERE 
			((@IdPersoneXImpreseequalthis IS NULL) OR ID_PERSONE_X_IMPRESE = @IdPersoneXImpreseequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@CodRuoloequalthis IS NULL) OR COD_RUOLO = @CodRuoloequalthis) AND 
			((@DataInizioequalthis IS NULL) OR DATA_INIZIO = @DataInizioequalthis) AND 
			((@DataFineequalthis IS NULL) OR DATA_FINE = @DataFineequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersoneXImpreseFindSelect';

