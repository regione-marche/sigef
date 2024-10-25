CREATE PROCEDURE [dbo].[ZVcruscottoDomandeBeneficiarioFindFindbandioperatore]
(
	@IdUtenteequalthis INT, 
	@CodEnteBandoequalthis VARCHAR(255), 
	@IdProgrammazioneBandoequalthis INT, 
	@UtenteAttivoequalthis BIT, 
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@StatoProgettoequalthis VARCHAR(255), 
	@DataScadenzaBandoeqgreaterthanthis DATETIME, 
	@DataScadenzaBandoeqlessthanthis DATETIME, 
	@IdImpresaequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO, COD_RUOLO_UTENTE_IMPRESA, RUOLO_UTENTE_IMPRESA, DATA_INIZIO_UTENTE_IMPRESA, DATA_FINE_UTENTE_IMPRESA, POTERE_DI_FIRMA_UTENTE_IMPRESA FROM VCRUSCOTTO_DOMANDE_BENEFICIARIO WHERE 1=1';
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@IdProgrammazioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneBandoequalthis);end;
	IF (@UtenteAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UTENTE_ATTIVO = @UtenteAttivoequalthis)'; set @lensql=@lensql+len(@UtenteAttivoequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@StatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_PROGETTO = @StatoProgettoequalthis)'; set @lensql=@lensql+len(@StatoProgettoequalthis);end;
	IF (@DataScadenzaBandoeqgreaterthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO >= @DataScadenzaBandoeqgreaterthanthis)'; set @lensql=@lensql+len(@DataScadenzaBandoeqgreaterthanthis);end;
	IF (@DataScadenzaBandoeqlessthanthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO <= @DataScadenzaBandoeqlessthanthis)'; set @lensql=@lensql+len(@DataScadenzaBandoeqlessthanthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	set @sql = @sql + 'ORDER BY DATA_SCADENZA_BANDO ASC, ID_BANDO ASC, ID_PROGETTO ASC';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdUtenteequalthis INT, @CodEnteBandoequalthis VARCHAR(255), @IdProgrammazioneBandoequalthis INT, @UtenteAttivoequalthis BIT, @IdBandoequalthis INT, @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @StatoProgettoequalthis VARCHAR(255), @DataScadenzaBandoeqgreaterthanthis DATETIME, @DataScadenzaBandoeqlessthanthis DATETIME, @IdImpresaequalthis INT',@IdUtenteequalthis , @CodEnteBandoequalthis , @IdProgrammazioneBandoequalthis , @UtenteAttivoequalthis , @IdBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @StatoProgettoequalthis , @DataScadenzaBandoeqgreaterthanthis , @DataScadenzaBandoeqlessthanthis , @IdImpresaequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO, COD_RUOLO_UTENTE_IMPRESA, RUOLO_UTENTE_IMPRESA, DATA_INIZIO_UTENTE_IMPRESA, DATA_FINE_UTENTE_IMPRESA, POTERE_DI_FIRMA_UTENTE_IMPRESA
		FROM VCRUSCOTTO_DOMANDE_BENEFICIARIO
		WHERE 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@IdProgrammazioneBandoequalthis IS NULL) OR ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis) AND 
			((@UtenteAttivoequalthis IS NULL) OR UTENTE_ATTIVO = @UtenteAttivoequalthis) AND 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@StatoProgettoequalthis IS NULL) OR STATO_PROGETTO = @StatoProgettoequalthis) AND 
			((@DataScadenzaBandoeqgreaterthanthis IS NULL) OR DATA_SCADENZA_BANDO >= @DataScadenzaBandoeqgreaterthanthis) AND 
			((@DataScadenzaBandoeqlessthanthis IS NULL) OR DATA_SCADENZA_BANDO <= @DataScadenzaBandoeqlessthanthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis)
		ORDER BY DATA_SCADENZA_BANDO ASC, ID_BANDO ASC, ID_PROGETTO ASC