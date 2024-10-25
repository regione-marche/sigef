CREATE PROCEDURE [dbo].[ZPagamentiRichiestiFemFindSelect]
(
	@IdPagamentoRichiestoFemequalthis INT, 
	@DataInserimentoequalthis DATETIME, 
	@CfInserimentoequalthis VARCHAR(255), 
	@IdContrattoequalthis INT, 
	@IdInvestimentoequalthis INT, 
	@ImportoRichiestoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@Ammessoequalthis BIT, 
	@CfIstruttoreequalthis VARCHAR(255), 
	@DataValutazioneequalthis DATETIME, 
	@DataModificaequalthis DATETIME, 
	@CfModificaequalthis VARCHAR(255), 
	@NoteIstruttoreequalthis VARCHAR(max), 
	@IdDomandaPagamentoequalthis INT, 
	@IdGiustificativoequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PAGAMENTO_RICHIESTO_FEM, DATA_INSERIMENTO, CF_INSERIMENTO, ID_CONTRATTO, ID_INVESTIMENTO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, AMMESSO, CF_ISTRUTTORE, DATA_VALUTAZIONE, DATA_MODIFICA, CF_MODIFICA, NOTE_ISTRUTTORE, ID_DOMANDA_PAGAMENTO, ID_GIUSTIFICATIVO, ID_BANDO, ID_PROGETTO, ID_IMPRESA_CONTRATTO, IMPRESA_CONTRATTO, IMPORTO_CONTRATTO, SEGNATURA_CONTRATTO, DATA_CONTRATTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE_GIUSTIFICATIVO, ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO FROM VPAGAMENTI_RICHIESTI_FEM WHERE 1=1';
	IF (@IdPagamentoRichiestoFemequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFemequalthis)'; set @lensql=@lensql+len(@IdPagamentoRichiestoFemequalthis);end;
	IF (@DataInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_INSERIMENTO = @DataInserimentoequalthis)'; set @lensql=@lensql+len(@DataInserimentoequalthis);end;
	IF (@CfInserimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_INSERIMENTO = @CfInserimentoequalthis)'; set @lensql=@lensql+len(@CfInserimentoequalthis);end;
	IF (@IdContrattoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_CONTRATTO = @IdContrattoequalthis)'; set @lensql=@lensql+len(@IdContrattoequalthis);end;
	IF (@IdInvestimentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_INVESTIMENTO = @IdInvestimentoequalthis)'; set @lensql=@lensql+len(@IdInvestimentoequalthis);end;
	IF (@ImportoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RICHIESTO = @ImportoRichiestoequalthis)'; set @lensql=@lensql+len(@ImportoRichiestoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@Ammessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (AMMESSO = @Ammessoequalthis)'; set @lensql=@lensql+len(@Ammessoequalthis);end;
	IF (@CfIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_ISTRUTTORE = @CfIstruttoreequalthis)'; set @lensql=@lensql+len(@CfIstruttoreequalthis);end;
	IF (@DataValutazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_VALUTAZIONE = @DataValutazioneequalthis)'; set @lensql=@lensql+len(@DataValutazioneequalthis);end;
	IF (@DataModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (DATA_MODIFICA = @DataModificaequalthis)'; set @lensql=@lensql+len(@DataModificaequalthis);end;
	IF (@CfModificaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CF_MODIFICA = @CfModificaequalthis)'; set @lensql=@lensql+len(@CfModificaequalthis);end;
	IF (@NoteIstruttoreequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (NOTE_ISTRUTTORE = @NoteIstruttoreequalthis)'; set @lensql=@lensql+len(@NoteIstruttoreequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPagamentoRichiestoFemequalthis INT, @DataInserimentoequalthis DATETIME, @CfInserimentoequalthis VARCHAR(255), @IdContrattoequalthis INT, @IdInvestimentoequalthis INT, @ImportoRichiestoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @Ammessoequalthis BIT, @CfIstruttoreequalthis VARCHAR(255), @DataValutazioneequalthis DATETIME, @DataModificaequalthis DATETIME, @CfModificaequalthis VARCHAR(255), @NoteIstruttoreequalthis VARCHAR(max), @IdDomandaPagamentoequalthis INT, @IdGiustificativoequalthis INT',@IdPagamentoRichiestoFemequalthis , @DataInserimentoequalthis , @CfInserimentoequalthis , @IdContrattoequalthis , @IdInvestimentoequalthis , @ImportoRichiestoequalthis , @ImportoAmmessoequalthis , @Ammessoequalthis , @CfIstruttoreequalthis , @DataValutazioneequalthis , @DataModificaequalthis , @CfModificaequalthis , @NoteIstruttoreequalthis , @IdDomandaPagamentoequalthis , @IdGiustificativoequalthis ;
	else
		SELECT ID_PAGAMENTO_RICHIESTO_FEM, DATA_INSERIMENTO, CF_INSERIMENTO, ID_CONTRATTO, ID_INVESTIMENTO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, AMMESSO, CF_ISTRUTTORE, DATA_VALUTAZIONE, DATA_MODIFICA, CF_MODIFICA, NOTE_ISTRUTTORE, ID_DOMANDA_PAGAMENTO, ID_GIUSTIFICATIVO, ID_BANDO, ID_PROGETTO, ID_IMPRESA_CONTRATTO, IMPRESA_CONTRATTO, IMPORTO_CONTRATTO, SEGNATURA_CONTRATTO, DATA_CONTRATTO, NUMERO_GIUSTIFICATIVO, COD_TIPO_GIUSTIFICATIVO, TIPO_GIUSTIFICATIVO, DATA_GIUSTIFICATIVO, IMPONIBILE_GIUSTIFICATIVO, IVA_GIUSTIFICATIVO, DESCRIZIONE_GIUSTIFICATIVO, CF_FORNITORE_GIUSTIFICATIVO, DESCRIZIONE_FORNITORE_GIUSTIFICATIVO, IVA_NON_RECUPERABILE_GIUSTIFICATIVO, ID_FILE_GIUSTIFICATIVO, IN_INTEGRAZIONE_GIUSTIFICATIVO, ID_FILE_MODIFICATO_INTEGRAZIONE_GIUSTIFICATIVO
		FROM VPAGAMENTI_RICHIESTI_FEM
		WHERE 
			((@IdPagamentoRichiestoFemequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO_FEM = @IdPagamentoRichiestoFemequalthis) AND 
			((@DataInserimentoequalthis IS NULL) OR DATA_INSERIMENTO = @DataInserimentoequalthis) AND 
			((@CfInserimentoequalthis IS NULL) OR CF_INSERIMENTO = @CfInserimentoequalthis) AND 
			((@IdContrattoequalthis IS NULL) OR ID_CONTRATTO = @IdContrattoequalthis) AND 
			((@IdInvestimentoequalthis IS NULL) OR ID_INVESTIMENTO = @IdInvestimentoequalthis) AND 
			((@ImportoRichiestoequalthis IS NULL) OR IMPORTO_RICHIESTO = @ImportoRichiestoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@Ammessoequalthis IS NULL) OR AMMESSO = @Ammessoequalthis) AND 
			((@CfIstruttoreequalthis IS NULL) OR CF_ISTRUTTORE = @CfIstruttoreequalthis) AND 
			((@DataValutazioneequalthis IS NULL) OR DATA_VALUTAZIONE = @DataValutazioneequalthis) AND 
			((@DataModificaequalthis IS NULL) OR DATA_MODIFICA = @DataModificaequalthis) AND 
			((@CfModificaequalthis IS NULL) OR CF_MODIFICA = @CfModificaequalthis) AND 
			((@NoteIstruttoreequalthis IS NULL) OR NOTE_ISTRUTTORE = @NoteIstruttoreequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR ID_DOMANDA_PAGAMENTO = @IdDomandaPagamentoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)
		

GO