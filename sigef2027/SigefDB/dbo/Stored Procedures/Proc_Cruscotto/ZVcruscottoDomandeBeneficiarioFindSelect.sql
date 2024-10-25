CREATE PROCEDURE [dbo].[ZVcruscottoDomandeBeneficiarioFindSelect]
(
	@IdBandoequalthis INT, 
	@DescrizioneBandoequalthis VARCHAR(2000), 
	@DataScadenzaBandoequalthis DATETIME, 
	@CodEnteBandoequalthis VARCHAR(255), 
	@IdProgrammazioneBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoProgettoequalthis VARCHAR(255), 
	@StatoProgettoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@RagioneSocialeImpresaequalthis VARCHAR(255), 
	@IdUtenteequalthis INT, 
	@NominativoUtenteImpresaequalthis VARCHAR(511), 
	@CfUtenteImpresaequalthis VARCHAR(255), 
	@UtenteAttivoequalthis BIT, 
	@CodRuoloUtenteImpresaequalthis VARCHAR(255), 
	@RuoloUtenteImpresaequalthis VARCHAR(255), 
	@DataInizioUtenteImpresaequalthis DATETIME, 
	@DataFineUtenteImpresaequalthis DATETIME, 
	@PotereDiFirmaUtenteImpresaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO, COD_RUOLO_UTENTE_IMPRESA, RUOLO_UTENTE_IMPRESA, DATA_INIZIO_UTENTE_IMPRESA, DATA_FINE_UTENTE_IMPRESA, POTERE_DI_FIRMA_UTENTE_IMPRESA FROM VCRUSCOTTO_DOMANDE_BENEFICIARIO WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@DescrizioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DESCRIZIONE_BANDO = @DescrizioneBandoequalthis)'; set @lensql=@lensql+len(@DescrizioneBandoequalthis);end;
	IF (@DataScadenzaBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis)'; set @lensql=@lensql+len(@DataScadenzaBandoequalthis);end;
	IF (@CodEnteBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_ENTE_BANDO = @CodEnteBandoequalthis)'; set @lensql=@lensql+len(@CodEnteBandoequalthis);end;
	IF (@IdProgrammazioneBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO_PROGETTO = @CodStatoProgettoequalthis)'; set @lensql=@lensql+len(@CodStatoProgettoequalthis);end;
	IF (@StatoProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_PROGETTO = @StatoProgettoequalthis)'; set @lensql=@lensql+len(@StatoProgettoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@RagioneSocialeImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE_IMPRESA = @RagioneSocialeImpresaequalthis)'; set @lensql=@lensql+len(@RagioneSocialeImpresaequalthis);end;
	IF (@IdUtenteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_UTENTE = @IdUtenteequalthis)'; set @lensql=@lensql+len(@IdUtenteequalthis);end;
	IF (@NominativoUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOMINATIVO_UTENTE_IMPRESA = @NominativoUtenteImpresaequalthis)'; set @lensql=@lensql+len(@NominativoUtenteImpresaequalthis);end;
	IF (@CfUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_UTENTE_IMPRESA = @CfUtenteImpresaequalthis)'; set @lensql=@lensql+len(@CfUtenteImpresaequalthis);end;
	IF (@UtenteAttivoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (UTENTE_ATTIVO = @UtenteAttivoequalthis)'; set @lensql=@lensql+len(@UtenteAttivoequalthis);end;
	IF (@CodRuoloUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RUOLO_UTENTE_IMPRESA = @CodRuoloUtenteImpresaequalthis)'; set @lensql=@lensql+len(@CodRuoloUtenteImpresaequalthis);end;
	IF (@RuoloUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RUOLO_UTENTE_IMPRESA = @RuoloUtenteImpresaequalthis)'; set @lensql=@lensql+len(@RuoloUtenteImpresaequalthis);end;
	IF (@DataInizioUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INIZIO_UTENTE_IMPRESA = @DataInizioUtenteImpresaequalthis)'; set @lensql=@lensql+len(@DataInizioUtenteImpresaequalthis);end;
	IF (@DataFineUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_FINE_UTENTE_IMPRESA = @DataFineUtenteImpresaequalthis)'; set @lensql=@lensql+len(@DataFineUtenteImpresaequalthis);end;
	IF (@PotereDiFirmaUtenteImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (POTERE_DI_FIRMA_UTENTE_IMPRESA = @PotereDiFirmaUtenteImpresaequalthis)'; set @lensql=@lensql+len(@PotereDiFirmaUtenteImpresaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @DescrizioneBandoequalthis VARCHAR(2000), @DataScadenzaBandoequalthis DATETIME, @CodEnteBandoequalthis VARCHAR(255), @IdProgrammazioneBandoequalthis INT, @IdProgettoequalthis INT, @CodStatoProgettoequalthis VARCHAR(255), @StatoProgettoequalthis VARCHAR(255), @IdImpresaequalthis INT, @RagioneSocialeImpresaequalthis VARCHAR(255), @IdUtenteequalthis INT, @NominativoUtenteImpresaequalthis VARCHAR(511), @CfUtenteImpresaequalthis VARCHAR(255), @UtenteAttivoequalthis BIT, @CodRuoloUtenteImpresaequalthis VARCHAR(255), @RuoloUtenteImpresaequalthis VARCHAR(255), @DataInizioUtenteImpresaequalthis DATETIME, @DataFineUtenteImpresaequalthis DATETIME, @PotereDiFirmaUtenteImpresaequalthis BIT',@IdBandoequalthis , @DescrizioneBandoequalthis , @DataScadenzaBandoequalthis , @CodEnteBandoequalthis , @IdProgrammazioneBandoequalthis , @IdProgettoequalthis , @CodStatoProgettoequalthis , @StatoProgettoequalthis , @IdImpresaequalthis , @RagioneSocialeImpresaequalthis , @IdUtenteequalthis , @NominativoUtenteImpresaequalthis , @CfUtenteImpresaequalthis , @UtenteAttivoequalthis , @CodRuoloUtenteImpresaequalthis , @RuoloUtenteImpresaequalthis , @DataInizioUtenteImpresaequalthis , @DataFineUtenteImpresaequalthis , @PotereDiFirmaUtenteImpresaequalthis ;
	else
		SELECT ID_BANDO, DESCRIZIONE_BANDO, DATA_SCADENZA_BANDO, COD_ENTE_BANDO, ID_PROGRAMMAZIONE_BANDO, ID_PROGETTO, COD_STATO_PROGETTO, STATO_PROGETTO, ID_IMPRESA, RAGIONE_SOCIALE_IMPRESA, ID_UTENTE, NOMINATIVO_UTENTE_IMPRESA, CF_UTENTE_IMPRESA, UTENTE_ATTIVO, COD_RUOLO_UTENTE_IMPRESA, RUOLO_UTENTE_IMPRESA, DATA_INIZIO_UTENTE_IMPRESA, DATA_FINE_UTENTE_IMPRESA, POTERE_DI_FIRMA_UTENTE_IMPRESA
		FROM VCRUSCOTTO_DOMANDE_BENEFICIARIO
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@DescrizioneBandoequalthis IS NULL) OR DESCRIZIONE_BANDO = @DescrizioneBandoequalthis) AND 
			((@DataScadenzaBandoequalthis IS NULL) OR DATA_SCADENZA_BANDO = @DataScadenzaBandoequalthis) AND 
			((@CodEnteBandoequalthis IS NULL) OR COD_ENTE_BANDO = @CodEnteBandoequalthis) AND 
			((@IdProgrammazioneBandoequalthis IS NULL) OR ID_PROGRAMMAZIONE_BANDO = @IdProgrammazioneBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoProgettoequalthis IS NULL) OR COD_STATO_PROGETTO = @CodStatoProgettoequalthis) AND 
			((@StatoProgettoequalthis IS NULL) OR STATO_PROGETTO = @StatoProgettoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@RagioneSocialeImpresaequalthis IS NULL) OR RAGIONE_SOCIALE_IMPRESA = @RagioneSocialeImpresaequalthis) AND 
			((@IdUtenteequalthis IS NULL) OR ID_UTENTE = @IdUtenteequalthis) AND 
			((@NominativoUtenteImpresaequalthis IS NULL) OR NOMINATIVO_UTENTE_IMPRESA = @NominativoUtenteImpresaequalthis) AND 
			((@CfUtenteImpresaequalthis IS NULL) OR CF_UTENTE_IMPRESA = @CfUtenteImpresaequalthis) AND 
			((@UtenteAttivoequalthis IS NULL) OR UTENTE_ATTIVO = @UtenteAttivoequalthis) AND 
			((@CodRuoloUtenteImpresaequalthis IS NULL) OR COD_RUOLO_UTENTE_IMPRESA = @CodRuoloUtenteImpresaequalthis) AND 
			((@RuoloUtenteImpresaequalthis IS NULL) OR RUOLO_UTENTE_IMPRESA = @RuoloUtenteImpresaequalthis) AND 
			((@DataInizioUtenteImpresaequalthis IS NULL) OR DATA_INIZIO_UTENTE_IMPRESA = @DataInizioUtenteImpresaequalthis) AND 
			((@DataFineUtenteImpresaequalthis IS NULL) OR DATA_FINE_UTENTE_IMPRESA = @DataFineUtenteImpresaequalthis) AND 
			((@PotereDiFirmaUtenteImpresaequalthis IS NULL) OR POTERE_DI_FIRMA_UTENTE_IMPRESA = @PotereDiFirmaUtenteImpresaequalthis)