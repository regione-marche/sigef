CREATE PROCEDURE ZRnaLogConcessioniFindFind
(
	@IdRnaLogConcessioneequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgettoRnaequalthis VARCHAR(255), 
	@IdImpresaequalthis INT, 
	@IdRichiestaequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_RNA_LOG_CONCESSIONE, ID_PROGETTO, ID_PROGETTO_RNA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, DATA_RICHIESTA, ID_OPERATORE_REG_AIUTO, ISTANZA_RICHIESTA, ISTANZA_RISPOSTA, COR, CODICE_ESITO, DESCRIZIONE_ESITO, CODICE_ESITO_STATO_RICHIESTA, DESCRIZIONE_ESITO_STATO_RICHIESTA, ID_OPERATORE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ERRORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO FROM RNA_LOG_CONCESSIONI WHERE 1=1';
	IF (@IdRnaLogConcessioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessioneequalthis)'; set @lensql=@lensql+len(@IdRnaLogConcessioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgettoRnaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO_RNA = @IdProgettoRnaequalthis)'; set @lensql=@lensql+len(@IdProgettoRnaequalthis);end;
	IF (@IdImpresaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_IMPRESA = @IdImpresaequalthis)'; set @lensql=@lensql+len(@IdImpresaequalthis);end;
	IF (@IdRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_RICHIESTA = @IdRichiestaequalthis)'; set @lensql=@lensql+len(@IdRichiestaequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdRnaLogConcessioneequalthis INT, @IdProgettoequalthis INT, @IdProgettoRnaequalthis VARCHAR(255), @IdImpresaequalthis INT, @IdRichiestaequalthis VARCHAR(255)',@IdRnaLogConcessioneequalthis , @IdProgettoequalthis , @IdProgettoRnaequalthis , @IdImpresaequalthis , @IdRichiestaequalthis ;
	else
		SELECT ID_RNA_LOG_CONCESSIONE, ID_PROGETTO, ID_PROGETTO_RNA, ID_IMPRESA, ID_FISCALE_IMPRESA, ID_RICHIESTA, DATA_RICHIESTA, ID_OPERATORE_REG_AIUTO, ISTANZA_RICHIESTA, ISTANZA_RISPOSTA, COR, CODICE_ESITO, DESCRIZIONE_ESITO, CODICE_ESITO_STATO_RICHIESTA, DESCRIZIONE_ESITO_STATO_RICHIESTA, ID_OPERATORE_STATO_RICHIESTA, DATA_STATO_RICHIESTA, ERRORE, DATA_INSERIMENTO, DATA_AGGIORNAMENTO
		FROM RNA_LOG_CONCESSIONI
		WHERE 
			((@IdRnaLogConcessioneequalthis IS NULL) OR ID_RNA_LOG_CONCESSIONE = @IdRnaLogConcessioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgettoRnaequalthis IS NULL) OR ID_PROGETTO_RNA = @IdProgettoRnaequalthis) AND 
			((@IdImpresaequalthis IS NULL) OR ID_IMPRESA = @IdImpresaequalthis) AND 
			((@IdRichiestaequalthis IS NULL) OR ID_RICHIESTA = @IdRichiestaequalthis)
		

GO