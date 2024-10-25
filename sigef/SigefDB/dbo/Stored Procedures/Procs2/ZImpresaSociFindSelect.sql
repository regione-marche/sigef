CREATE PROCEDURE [dbo].[ZImpresaSociFindSelect]
(
	@Idequalthis INT, 
	@IdImpresaequalthis INT, 
	@IdSocioequalthis INT, 
	@Attivoequalthis BIT, 
	@DataInizioValiditaequalthis DATETIME, 
	@DataFineValiditaequalthis DATETIME, 
	@IdOperatoreInizioequalthis INT, 
	@IdOperatoreFineequalthis INT, 
	@CodTipoSocioequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID, ID_IMPRESA, ID_SOCIO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, FORMA_GIURIDICA, COD_TIPO_SOCIO, TIPO_SOCIO FROM vIMPRESA_SOCI WHERE 1=1';
	IF (@Idequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID = @Idequalthis)'; set @lensql=@lensql+len(@Idequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdSocioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SOCIO = @IdSocioequalthis)'; set @lensql=@lensql+len(@IdSocioequalthis);end;
	IF (@Attivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ATTIVO = @Attivoequalthis)'; set @lensql=@lensql+len(@Attivoequalthis);end;
	IF (@DataInizioValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis)'; set @lensql=@lensql+len(@DataInizioValiditaequalthis);end;
	IF (@DataFineValiditaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_VALIDITA = @DataFineValiditaequalthis)'; set @lensql=@lensql+len(@DataFineValiditaequalthis);end;
	IF (@IdOperatoreInizioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis)'; set @lensql=@lensql+len(@IdOperatoreInizioequalthis);end;
	IF (@IdOperatoreFineequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_FINE = @IdOperatoreFineequalthis)'; set @lensql=@lensql+len(@IdOperatoreFineequalthis);end;
	IF (@CodTipoSocioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_TIPO_SOCIO = @CodTipoSocioequalthis)'; set @lensql=@lensql+len(@CodTipoSocioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@Idequalthis INT, @IdImpresaequalthis INT, @IdSocioequalthis INT, @Attivoequalthis BIT, @DataInizioValiditaequalthis DATETIME, @DataFineValiditaequalthis DATETIME, @IdOperatoreInizioequalthis INT, @IdOperatoreFineequalthis INT, @CodTipoSocioequalthis VARCHAR(255)',@Idequalthis , @IdImpresaequalthis , @IdSocioequalthis , @Attivoequalthis , @DataInizioValiditaequalthis , @DataFineValiditaequalthis , @IdOperatoreInizioequalthis , @IdOperatoreFineequalthis , @CodTipoSocioequalthis ;
	else
		SELECT ID, ID_IMPRESA, ID_SOCIO, ATTIVO, DATA_INIZIO_VALIDITA, DATA_FINE_VALIDITA, ID_OPERATORE_INIZIO, ID_OPERATORE_FINE, CUAA, CODICE_FISCALE, RAGIONE_SOCIALE, FORMA_GIURIDICA, COD_TIPO_SOCIO, TIPO_SOCIO
		FROM vIMPRESA_SOCI
		WHERE 
			((@Idequalthis IS NULL) OR ID = @Idequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdSocioequalthis IS NULL) OR ID_SOCIO = @IdSocioequalthis) AND 
			((@Attivoequalthis IS NULL) OR ATTIVO = @Attivoequalthis) AND 
			((@DataInizioValiditaequalthis IS NULL) OR DATA_INIZIO_VALIDITA = @DataInizioValiditaequalthis) AND 
			((@DataFineValiditaequalthis IS NULL) OR DATA_FINE_VALIDITA = @DataFineValiditaequalthis) AND 
			((@IdOperatoreInizioequalthis IS NULL) OR ID_OPERATORE_INIZIO = @IdOperatoreInizioequalthis) AND 
			((@IdOperatoreFineequalthis IS NULL) OR ID_OPERATORE_FINE = @IdOperatoreFineequalthis) AND 
			((@CodTipoSocioequalthis IS NULL) OR COD_TIPO_SOCIO = @CodTipoSocioequalthis)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaSociFindSelect';

