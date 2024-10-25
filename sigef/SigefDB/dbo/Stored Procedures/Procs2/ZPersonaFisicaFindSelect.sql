CREATE PROCEDURE [dbo].[ZPersonaFisicaFindSelect]
(
	@IdPersonaequalthis INT, 
	@Nomeequalthis VARCHAR(255), 
	@Cognomeequalthis VARCHAR(255), 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@Sessoequalthis VARCHAR(255), 
	@DataNascitaequalthis DATETIME, 
	@IdComuneNascitaequalthis INT, 
	@IdCittadinanzaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_CITTADINANZA, CITTADINANZA, ID_COMUNE_NASCITA, COMUNE, PROVINCIA FROM vPERSONA_FISICA WHERE 1=1';
	IF (@IdPersonaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PERSONA = @IdPersonaequalthis)'; set @lensql=@lensql+len(@IdPersonaequalthis);end;
	IF (@Nomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOME = @Nomeequalthis)'; set @lensql=@lensql+len(@Nomeequalthis);end;
	IF (@Cognomeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COGNOME = @Cognomeequalthis)'; set @lensql=@lensql+len(@Cognomeequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@Sessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SESSO = @Sessoequalthis)'; set @lensql=@lensql+len(@Sessoequalthis);end;
	IF (@DataNascitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_NASCITA = @DataNascitaequalthis)'; set @lensql=@lensql+len(@DataNascitaequalthis);end;
	IF (@IdComuneNascitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_COMUNE_NASCITA = @IdComuneNascitaequalthis)'; set @lensql=@lensql+len(@IdComuneNascitaequalthis);end;
	IF (@IdCittadinanzaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CITTADINANZA = @IdCittadinanzaequalthis)'; set @lensql=@lensql+len(@IdCittadinanzaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPersonaequalthis INT, @Nomeequalthis VARCHAR(255), @Cognomeequalthis VARCHAR(255), @CodiceFiscaleequalthis VARCHAR(255), @Sessoequalthis VARCHAR(255), @DataNascitaequalthis DATETIME, @IdComuneNascitaequalthis INT, @IdCittadinanzaequalthis INT',@IdPersonaequalthis , @Nomeequalthis , @Cognomeequalthis , @CodiceFiscaleequalthis , @Sessoequalthis , @DataNascitaequalthis , @IdComuneNascitaequalthis , @IdCittadinanzaequalthis ;
	else
		SELECT ID_PERSONA, NOME, COGNOME, CODICE_FISCALE, SESSO, DATA_NASCITA, ID_CITTADINANZA, CITTADINANZA, ID_COMUNE_NASCITA, COMUNE, PROVINCIA
		FROM vPERSONA_FISICA
		WHERE 
			((@IdPersonaequalthis IS NULL) OR ID_PERSONA = @IdPersonaequalthis) AND 
			((@Nomeequalthis IS NULL) OR NOME = @Nomeequalthis) AND 
			((@Cognomeequalthis IS NULL) OR COGNOME = @Cognomeequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@Sessoequalthis IS NULL) OR SESSO = @Sessoequalthis) AND 
			((@DataNascitaequalthis IS NULL) OR DATA_NASCITA = @DataNascitaequalthis) AND 
			((@IdComuneNascitaequalthis IS NULL) OR ID_COMUNE_NASCITA = @IdComuneNascitaequalthis) AND 
			((@IdCittadinanzaequalthis IS NULL) OR ID_CITTADINANZA = @IdCittadinanzaequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersonaFisicaFindSelect';

