CREATE PROCEDURE ZRnaProgettoCorFindSelect
(
	@IdRnaProgettoCorequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgettoRnaequalthis VARCHAR(255), 
	@IdRichiestaequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@IdFiscaleImpresaequalthis VARCHAR(255), 
	@IdOperatoreAssegnazioneCorequalthis INT, 
	@Corequalthis VARCHAR(255), 
	@StatoConcessioneequalthis VARCHAR(255), 
	@DataAssegnazioneCorequalthis DATETIME, 
	@Confermatoequalthis BIT, 
	@IdOperatoreConfermaConcessioneequalthis INT, 
	@DataConfermaConcessioneequalthis DATETIME, 
	@Annullatoequalthis BIT, 
	@IdOperatoreAnnullamentoequalthis INT, 
	@DataAnnullamentoequalthis DATETIME, 
	@DataInserimentoequalthis DATETIME, 
	@DataAggiornamentoequalthis DATETIME
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_PROGETTO_COR, ID_PROGETTO, ID_PROGETTO_RNA, ID_RICHIESTA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_OPERATORE_ASSEGNAZIONE_COR, COR, STATO_CONCESSIONE, DATA_ASSEGNAZIONE_COR, CONFERMATO, ID_OPERATORE_CONFERMA_CONCESSIONE, DATA_CONFERMA_CONCESSIONE, ANNULLATO, ID_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, DATA_INSERIMENTO, DATA_AGGIORNAMENTO FROM RNA_PROGETTO_COR WHERE 1=1';
	IF (@IdRnaProgettoCorequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_PROGETTO_COR = @IdRnaProgettoCorequalthis)'; set @lensql=@lensql+len(@IdRnaProgettoCorequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgettoRnaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_RNA = @IdProgettoRnaequalthis)'; set @lensql=@lensql+len(@IdProgettoRnaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdFiscaleImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis)'; set @lensql=@lensql+len(@IdFiscaleImpresaequalthis);end;
	IF (@IdOperatoreAssegnazioneCorequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_ASSEGNAZIONE_COR = @IdOperatoreAssegnazioneCorequalthis)'; set @lensql=@lensql+len(@IdOperatoreAssegnazioneCorequalthis);end;
	IF (@Corequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COR = @Corequalthis)'; set @lensql=@lensql+len(@Corequalthis);end;
	IF (@StatoConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (STATO_CONCESSIONE = @StatoConcessioneequalthis)'; set @lensql=@lensql+len(@StatoConcessioneequalthis);end;
	IF (@DataAssegnazioneCorequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCorequalthis)'; set @lensql=@lensql+len(@DataAssegnazioneCorequalthis);end;
	IF (@Confermatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONFERMATO = @Confermatoequalthis)'; set @lensql=@lensql+len(@Confermatoequalthis);end;
	IF (@IdOperatoreConfermaConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_CONFERMA_CONCESSIONE = @IdOperatoreConfermaConcessioneequalthis)'; set @lensql=@lensql+len(@IdOperatoreConfermaConcessioneequalthis);end;
	IF (@DataConfermaConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_CONFERMA_CONCESSIONE = @DataConfermaConcessioneequalthis)'; set @lensql=@lensql+len(@DataConfermaConcessioneequalthis);end;
	IF (@Annullatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ANNULLATO = @Annullatoequalthis)'; set @lensql=@lensql+len(@Annullatoequalthis);end;
	IF (@IdOperatoreAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_OPERATORE_ANNULLAMENTO = @IdOperatoreAnnullamentoequalthis)'; set @lensql=@lensql+len(@IdOperatoreAnnullamentoequalthis);end;
	IF (@DataAnnullamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_ANNULLAMENTO = @DataAnnullamentoequalthis)'; set @lensql=@lensql+len(@DataAnnullamentoequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@DataAggiornamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)'; set @lensql=@lensql+len(@DataAggiornamentoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaProgettoCorequalthis INT, @IdProgettoequalthis INT, @IdProgettoRnaequalthis VARCHAR(255), @IdRichiestaequalthis VARCHAR(255), @IdImpresaequalthis INT, @IdFiscaleImpresaequalthis VARCHAR(255), @IdOperatoreAssegnazioneCorequalthis INT, @Corequalthis VARCHAR(255), @StatoConcessioneequalthis VARCHAR(255), @DataAssegnazioneCorequalthis DATETIME, @Confermatoequalthis BIT, @IdOperatoreConfermaConcessioneequalthis INT, @DataConfermaConcessioneequalthis DATETIME, @Annullatoequalthis BIT, @IdOperatoreAnnullamentoequalthis INT, @DataAnnullamentoequalthis DATETIME, @DataInserimentoequalthis DATETIME, @DataAggiornamentoequalthis DATETIME',@IdRnaProgettoCorequalthis , @IdProgettoequalthis , @IdProgettoRnaequalthis , @IdRichiestaequalthis , @IdImpresaequalthis , @IdFiscaleImpresaequalthis , @IdOperatoreAssegnazioneCorequalthis , @Corequalthis , @StatoConcessioneequalthis , @DataAssegnazioneCorequalthis , @Confermatoequalthis , @IdOperatoreConfermaConcessioneequalthis , @DataConfermaConcessioneequalthis , @Annullatoequalthis , @IdOperatoreAnnullamentoequalthis , @DataAnnullamentoequalthis , @DataInserimentoequalthis , @DataAggiornamentoequalthis ;
	else
		SELECT ID_RNA_PROGETTO_COR, ID_PROGETTO, ID_PROGETTO_RNA, ID_RICHIESTA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_OPERATORE_ASSEGNAZIONE_COR, COR, STATO_CONCESSIONE, DATA_ASSEGNAZIONE_COR, CONFERMATO, ID_OPERATORE_CONFERMA_CONCESSIONE, DATA_CONFERMA_CONCESSIONE, ANNULLATO, ID_OPERATORE_ANNULLAMENTO, DATA_ANNULLAMENTO, DATA_INSERIMENTO, DATA_AGGIORNAMENTO
		FROM RNA_PROGETTO_COR
		WHERE 
			((@IdRnaProgettoCorequalthis IS NULL) OR ID_RNA_PROGETTO_COR = @IdRnaProgettoCorequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgettoRnaequalthis IS NULL) OR ID_PROGETTO_RNA = @IdProgettoRnaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdFiscaleImpresaequalthis IS NULL) OR ID_FISCALE_IMPRESA = @IdFiscaleImpresaequalthis) AND 
			((@IdOperatoreAssegnazioneCorequalthis IS NULL) OR ID_OPERATORE_ASSEGNAZIONE_COR = @IdOperatoreAssegnazioneCorequalthis) AND 
			((@Corequalthis IS NULL) OR COR = @Corequalthis) AND 
			((@StatoConcessioneequalthis IS NULL) OR STATO_CONCESSIONE = @StatoConcessioneequalthis) AND 
			((@DataAssegnazioneCorequalthis IS NULL) OR DATA_ASSEGNAZIONE_COR = @DataAssegnazioneCorequalthis) AND 
			((@Confermatoequalthis IS NULL) OR CONFERMATO = @Confermatoequalthis) AND 
			((@IdOperatoreConfermaConcessioneequalthis IS NULL) OR ID_OPERATORE_CONFERMA_CONCESSIONE = @IdOperatoreConfermaConcessioneequalthis) AND 
			((@DataConfermaConcessioneequalthis IS NULL) OR DATA_CONFERMA_CONCESSIONE = @DataConfermaConcessioneequalthis) AND 
			((@Annullatoequalthis IS NULL) OR ANNULLATO = @Annullatoequalthis) AND 
			((@IdOperatoreAnnullamentoequalthis IS NULL) OR ID_OPERATORE_ANNULLAMENTO = @IdOperatoreAnnullamentoequalthis) AND 
			((@DataAnnullamentoequalthis IS NULL) OR DATA_ANNULLAMENTO = @DataAnnullamentoequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@DataAggiornamentoequalthis IS NULL) OR DATA_AGGIORNAMENTO = @DataAggiornamentoequalthis)
		

GO