CREATE PROCEDURE [dbo].[ZPianoInvestimentiFindFind]
(
	@IdInvestimentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdDettaglioInvestimentoequalthis INT, 
	@IdSpecificaInvestimentoequalthis INT, 
	@IdInvestimentoOriginaleequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI FROM vPIANO_INVESTIMENTI WHERE 1=1';
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)'; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)'; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdSpecificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis)'; set @lensql=@lensql+len(@IdSpecificaInvestimentoequalthis);end;
	IF (@IdInvestimentoOriginaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginaleequalthis)'; set @lensql=@lensql+len(@IdInvestimentoOriginaleequalthis);end;
	set @sql = @sql + 'ORDER BY COD_TIPO_INVESTIMENTO, ID_INVESTIMENTO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdInvestimentoequalthis INT, @IdProgettoequalthis INT, @IdProgrammazioneequalthis INT, @IdCodificaInvestimentoequalthis INT, @IdDettaglioInvestimentoequalthis INT, @IdSpecificaInvestimentoequalthis INT, @IdInvestimentoOriginaleequalthis INT',@IdInvestimentoequalthis , @IdProgettoequalthis , @IdProgrammazioneequalthis , @IdCodificaInvestimentoequalthis , @IdDettaglioInvestimentoequalthis , @IdSpecificaInvestimentoequalthis , @IdInvestimentoOriginaleequalthis ;
	else
		SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI
		FROM vPIANO_INVESTIMENTI
		WHERE 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdProgrammazioneequalthis IS NULL) OR ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis) AND 
			((@IdCodificaInvestimentoequalthis IS NULL) OR ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis) AND 
			((@IdDettaglioInvestimentoequalthis IS NULL) OR ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis) AND 
			((@IdSpecificaInvestimentoequalthis IS NULL) OR ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis) AND 
			((@IdInvestimentoOriginaleequalthis IS NULL) OR ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginaleequalthis)
		ORDER BY COD_TIPO_INVESTIMENTO, ID_INVESTIMENTO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPianoInvestimentiFindFind]
(
	@IdInvestimentoequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdProgrammazioneequalthis INT, 
	@IdCodificaInvestimentoequalthis INT, 
	@IdDettaglioInvestimentoequalthis INT, 
	@IdSpecificaInvestimentoequalthis INT, 
	@IdInvestimentoOriginaleequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MISURA, NON_COFINANZIATO, IS_MAX, CONTRIBUTO_ALTRE_FONTI, QUOTA_CONTRIBUTO_ALTRE_FONTI FROM vPIANO_INVESTIMENTI WHERE 1=1'';
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)''; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdProgrammazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGRAMMAZIONE = @IdProgrammazioneequalthis)''; set @lensql=@lensql+len(@IdProgrammazioneequalthis);end;
	IF (@IdCodificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdCodificaInvestimentoequalthis);end;
	IF (@IdDettaglioInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_DETTAGLIO_INVESTIMENTO = @IdDettaglioInvestimentoequalthis)''; set @lensql=@lensql+len(@IdDettaglioInvestimentoequalthis);end;
	IF (@IdSpecificaInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_SPECIFICA_INVESTIMENTO = @IdSpecificaInvestimentoequalthis)''; set @lensql=@lensql+len(@IdSpecificaInvestimentoequalthis);end;
	IF (@IdInvestimentoOriginaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_INVESTIMENTO_ORIGINALE = @IdInvestimentoOriginaleequalthis)''; set @lensql=@lensql+len(@IdInvestimentoOriginaleequalthis);end;
	set @sql = @sql + ''ORDER BY COD_TIPO_INVESTIMENTO, ID_INVESTIMENTO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdInvestimentoequalthis INT, @IdProgettoequalthis INT, @IdProgrammazioneequalthis INT, @IdCodificaInvestimentoequalthis INT, @IdDettaglioInvestimentoequalthis INT, @IdSpecificaInvestimentoequalthis INT, @IdInvestimentoOriginaleequalthis INT'',@IdInvestimentoequalthis , @IdProgettoequalthis , @IdProgrammazioneequalthis , @IdCodificaInvestimentoequalthis , @IdDettaglioInvestimentoequalthis , @IdSpecificaInvestimentoequalthis , @IdInvestimentoOriginaleequalthis ;
	else
		SELECT ID_INVESTIMENTO, ID_PROGETTO, ID_PROGRAMMAZIONE, DESCRIZIONE, DATA_VARIAZIONE, OPERATORE_VARIAZIONE, COD_STP, ID_UNITA_MISURA, QUANTITA, COSTO_INVESTIMENTO, SPESE_GENERALI, CONTRIBUTO_RICHIESTO, QUOTA_CONTRIBUTO_RICHIESTO, ID_SETTORE_PRODUTTIVO, ID_PRIORITA_SETTORIALE, ID_OBIETTIVO_MISURA, AMMESSO, ISTRUTTORE, ID_INVESTIMENTO_ORIGINALE, DATA_VALUTAZIONE, ID_CODIFICA_INVESTIMENTO, ID_DETTAGLIO_INVESTIMENTO, ID_SPECIFICA_INVESTIMENTO, COD_TP, CODIFICA_INVESTIMENTO, AIUTO_MINIMO, CODICE, COD_SPECIFICA, SPECIFICA_INVESTIMENTI, DETTAGLIO_INVESTIMENTI, MOBILE, QUOTA_SPESE_GENERALI, SETTORE_PRODUTTIVO, COD_TIPO_INVESTIMENTO, RICHIEDI_PARTICELLA, VALUTAZIONE_INVESTIMENTO, ID_VARIANTE, COD_VARIAZIONE, TASSO_ABBUONO, MISURA, ID_MI', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoInvestimentiFindFind';

