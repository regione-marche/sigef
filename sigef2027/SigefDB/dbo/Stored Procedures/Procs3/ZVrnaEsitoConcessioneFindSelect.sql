CREATE PROCEDURE ZVrnaEsitoConcessioneFindSelect
(
	@IdBandoequalthis INT, 
	@IdProgettoequalthis INT, 
	@CodStatoequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@CodiceFiscaleequalthis VARCHAR(255), 
	@RagioneSocialeequalthis VARCHAR(255), 
	@StatoConcessioneequalthis VARCHAR(255), 
	@IdRichiestaequalthis VARCHAR(255), 
	@Corequalthis VARCHAR(255), 
	@DataAssegnazioneCorequalthis DATETIME, 
	@Punteggioequalthis DECIMAL(10,6)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_BANDO, ID_PROGETTO, COD_STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, STATO_CONCESSIONE, ID_RICHIESTA, COR, DATA_ASSEGNAZIONE_COR, PUNTEGGIO FROM vRNA_ESITO_CONCESSIONE WHERE 1=1';
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_BANDO = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodStatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_STATO = @CodStatoequalthis)'; set @lensql=@lensql+len(@CodStatoequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@CodiceFiscaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CODICE_FISCALE = @CodiceFiscaleequalthis)'; set @lensql=@lensql+len(@CodiceFiscaleequalthis);end;
	IF (@RagioneSocialeequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RAGIONE_SOCIALE = @RagioneSocialeequalthis)'; set @lensql=@lensql+len(@RagioneSocialeequalthis);end;
	IF (@StatoConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_CONCESSIONE = @StatoConcessioneequalthis)'; set @lensql=@lensql+len(@StatoConcessioneequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@Corequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COR = @Corequalthis)'; set @lensql=@lensql+len(@Corequalthis);end;
	IF (@DataAssegnazioneCorequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCorequalthis)'; set @lensql=@lensql+len(@DataAssegnazioneCorequalthis);end;
	IF (@Punteggioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PUNTEGGIO = @Punteggioequalthis)'; set @lensql=@lensql+len(@Punteggioequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdBandoequalthis INT, @IdProgettoequalthis INT, @CodStatoequalthis VARCHAR(255), @IdImpresaequalthis INT, @CodiceFiscaleequalthis VARCHAR(255), @RagioneSocialeequalthis VARCHAR(255), @StatoConcessioneequalthis VARCHAR(255), @IdRichiestaequalthis VARCHAR(255), @Corequalthis VARCHAR(255), @DataAssegnazioneCorequalthis DATETIME, @Punteggioequalthis DECIMAL(10,6)',@IdBandoequalthis , @IdProgettoequalthis , @CodStatoequalthis , @IdImpresaequalthis , @CodiceFiscaleequalthis , @RagioneSocialeequalthis , @StatoConcessioneequalthis , @IdRichiestaequalthis , @Corequalthis , @DataAssegnazioneCorequalthis , @Punteggioequalthis ;
	else
		SELECT ID_BANDO, ID_PROGETTO, COD_STATO, ID_IMPRESA, CODICE_FISCALE, RAGIONE_SOCIALE, STATO_CONCESSIONE, ID_RICHIESTA, COR, DATA_ASSEGNAZIONE_COR, PUNTEGGIO
		FROM vRNA_ESITO_CONCESSIONE
		WHERE 
			((@IdBandoequalthis IS NULL) OR ID_BANDO = @IdBandoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@CodStatoequalthis IS NULL) OR COD_STATO = @CodStatoequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@CodiceFiscaleequalthis IS NULL) OR CODICE_FISCALE = @CodiceFiscaleequalthis) AND 
			((@RagioneSocialeequalthis IS NULL) OR RAGIONE_SOCIALE = @RagioneSocialeequalthis) AND 
			((@StatoConcessioneequalthis IS NULL) OR STATO_CONCESSIONE = @StatoConcessioneequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@Corequalthis IS NULL) OR COR = @Corequalthis) AND 
			((@DataAssegnazioneCorequalthis IS NULL) OR DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCorequalthis) AND 
			((@Punteggioequalthis IS NULL) OR PUNTEGGIO = @Punteggioequalthis)
		

GO