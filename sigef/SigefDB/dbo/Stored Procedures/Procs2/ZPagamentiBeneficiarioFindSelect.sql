CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioFindSelect]
(
	@IdPagamentoBeneficiarioequalthis INT, 
	@IdPagamentoRichiestoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@ImportoRichiestoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ContributoAmmessoequalthis DECIMAL(18,2), 
	@QuotaContributoAmmessoequalthis DECIMAL(10,2), 
	@CodRiduzioneequalthis VARCHAR(255), 
	@MotivazioneRiduzioneequalthis INT, 
	@ImportoNonammNonrespequalthis DECIMAL(18,2), 
	@ImportoAmmessoContrequalthis DECIMAL(18,2), 
	@ImportoNonammContrNonrespequalthis DECIMAL(18,2), 
	@SpesaTecnicaRichiestaequalthis BIT, 
	@SpesaTecnicaAmmessaequalthis BIT, 
	@SpesaTecnicaAmmessaContrequalthis BIT, 
	@CostituisceVarianteequalthis BIT, 
	@CodRiduzioneContrequalthis VARCHAR(255), 
	@MotivazioneRiduzioneContrequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, QUOTA_CONTRIBUTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE FROM vPAGAMENTI_BENEFICIARIO WHERE 1=1';
	IF (@IdPagamentoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis)'; set @lensql=@lensql+len(@IdPagamentoBeneficiarioequalthis);end;
	IF (@IdPagamentoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis)'; set @lensql=@lensql+len(@IdPagamentoRichiestoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@ImportoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_RICHIESTO = @ImportoRichiestoequalthis)'; set @lensql=@lensql+len(@ImportoRichiestoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis)'; set @lensql=@lensql+len(@ContributoAmmessoequalthis);end;
	IF (@QuotaContributoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (QUOTA_CONTRIBUTO_AMMESSO = @QuotaContributoAmmessoequalthis)'; set @lensql=@lensql+len(@QuotaContributoAmmessoequalthis);end;
	IF (@CodRiduzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RIDUZIONE = @CodRiduzioneequalthis)'; set @lensql=@lensql+len(@CodRiduzioneequalthis);end;
	IF (@MotivazioneRiduzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MOTIVAZIONE_RIDUZIONE = @MotivazioneRiduzioneequalthis)'; set @lensql=@lensql+len(@MotivazioneRiduzioneequalthis);end;
	IF (@ImportoNonammNonrespequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_NONAMM_NONRESP = @ImportoNonammNonrespequalthis)'; set @lensql=@lensql+len(@ImportoNonammNonrespequalthis);end;
	IF (@ImportoAmmessoContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_AMMESSO_CONTR = @ImportoAmmessoContrequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoContrequalthis);end;
	IF (@ImportoNonammContrNonrespequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IMPORTO_NONAMM_CONTR_NONRESP = @ImportoNonammContrNonrespequalthis)'; set @lensql=@lensql+len(@ImportoNonammContrNonrespequalthis);end;
	IF (@SpesaTecnicaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis)'; set @lensql=@lensql+len(@SpesaTecnicaRichiestaequalthis);end;
	IF (@SpesaTecnicaAmmessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)'; set @lensql=@lensql+len(@SpesaTecnicaAmmessaequalthis);end;
	IF (@SpesaTecnicaAmmessaContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_TECNICA_AMMESSA_CONTR = @SpesaTecnicaAmmessaContrequalthis)'; set @lensql=@lensql+len(@SpesaTecnicaAmmessaContrequalthis);end;
	IF (@CostituisceVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COSTITUISCE_VARIANTE = @CostituisceVarianteequalthis)'; set @lensql=@lensql+len(@CostituisceVarianteequalthis);end;
	IF (@CodRiduzioneContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (COD_RIDUZIONE_CONTR = @CodRiduzioneContrequalthis)'; set @lensql=@lensql+len(@CodRiduzioneContrequalthis);end;
	IF (@MotivazioneRiduzioneContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (MOTIVAZIONE_RIDUZIONE_CONTR = @MotivazioneRiduzioneContrequalthis)'; set @lensql=@lensql+len(@MotivazioneRiduzioneContrequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPagamentoBeneficiarioequalthis INT, @IdPagamentoRichiestoequalthis INT, @IdGiustificativoequalthis INT, @ImportoRichiestoequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(18,2), @ContributoAmmessoequalthis DECIMAL(18,2), @QuotaContributoAmmessoequalthis DECIMAL(10,2), @CodRiduzioneequalthis VARCHAR(255), @MotivazioneRiduzioneequalthis INT, @ImportoNonammNonrespequalthis DECIMAL(18,2), @ImportoAmmessoContrequalthis DECIMAL(18,2), @ImportoNonammContrNonrespequalthis DECIMAL(18,2), @SpesaTecnicaRichiestaequalthis BIT, @SpesaTecnicaAmmessaequalthis BIT, @SpesaTecnicaAmmessaContrequalthis BIT, @CostituisceVarianteequalthis BIT, @CodRiduzioneContrequalthis VARCHAR(255), @MotivazioneRiduzioneContrequalthis INT',@IdPagamentoBeneficiarioequalthis , @IdPagamentoRichiestoequalthis , @IdGiustificativoequalthis , @ImportoRichiestoequalthis , @ImportoAmmessoequalthis , @ContributoAmmessoequalthis , @QuotaContributoAmmessoequalthis , @CodRiduzioneequalthis , @MotivazioneRiduzioneequalthis , @ImportoNonammNonrespequalthis , @ImportoAmmessoContrequalthis , @ImportoNonammContrNonrespequalthis , @SpesaTecnicaRichiestaequalthis , @SpesaTecnicaAmmessaequalthis , @SpesaTecnicaAmmessaContrequalthis , @CostituisceVarianteequalthis , @CodRiduzioneContrequalthis , @MotivazioneRiduzioneContrequalthis ;
	else
		SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, QUOTA_CONTRIBUTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE
		FROM vPAGAMENTI_BENEFICIARIO
		WHERE 
			((@IdPagamentoBeneficiarioequalthis IS NULL) OR ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis) AND 
			((@IdPagamentoRichiestoequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@ImportoRichiestoequalthis IS NULL) OR IMPORTO_RICHIESTO = @ImportoRichiestoequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR IMPORTO_AMMESSO = @ImportoAmmessoequalthis) AND 
			((@ContributoAmmessoequalthis IS NULL) OR CONTRIBUTO_AMMESSO = @ContributoAmmessoequalthis) AND 
			((@QuotaContributoAmmessoequalthis IS NULL) OR QUOTA_CONTRIBUTO_AMMESSO = @QuotaContributoAmmessoequalthis) AND 
			((@CodRiduzioneequalthis IS NULL) OR COD_RIDUZIONE = @CodRiduzioneequalthis) AND 
			((@MotivazioneRiduzioneequalthis IS NULL) OR MOTIVAZIONE_RIDUZIONE = @MotivazioneRiduzioneequalthis) AND 
			((@ImportoNonammNonrespequalthis IS NULL) OR IMPORTO_NONAMM_NONRESP = @ImportoNonammNonrespequalthis) AND 
			((@ImportoAmmessoContrequalthis IS NULL) OR IMPORTO_AMMESSO_CONTR = @ImportoAmmessoContrequalthis) AND 
			((@ImportoNonammContrNonrespequalthis IS NULL) OR IMPORTO_NONAMM_CONTR_NONRESP = @ImportoNonammContrNonrespequalthis) AND 
			((@SpesaTecnicaRichiestaequalthis IS NULL) OR SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis) AND 
			((@SpesaTecnicaAmmessaequalthis IS NULL) OR SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis) AND 
			((@SpesaTecnicaAmmessaContrequalthis IS NULL) OR SPESA_TECNICA_AMMESSA_CONTR = @SpesaTecnicaAmmessaContrequalthis) AND 
			((@CostituisceVarianteequalthis IS NULL) OR COSTITUISCE_VARIANTE = @CostituisceVarianteequalthis) AND 
			((@CodRiduzioneContrequalthis IS NULL) OR COD_RIDUZIONE_CONTR = @CodRiduzioneContrequalthis) AND 
			((@MotivazioneRiduzioneContrequalthis IS NULL) OR MOTIVAZIONE_RIDUZIONE_CONTR = @MotivazioneRiduzioneContrequalthis)
		


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioFindSelect]
(
	@IdPagamentoBeneficiarioequalthis INT, 
	@IdPagamentoRichiestoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@ImportoRichiestoequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(18,2), 
	@ImportoNonammNonrespequalthis DECIMAL(18,2), 
	@ImportoAmmessoContrequalthis DECIMAL(18,2), 
	@ImportoNonammContrNonrespequalthis DECIMAL(18,2), 
	@SpesaTecnicaRichiestaequalthis BIT, 
	@SpesaTecnicaAmmessaequalthis BIT, 
	@SpesaTecnicaAmmessaContrequalthis BIT, 
	@CostituisceVarianteequalthis BIT, 
	@CodRiduzioneequalthis VARCHAR(255), 
	@MotivazioneRiduzioneequalthis INT, 
	@CodRiduzioneContrequalthis VARCHAR(255), 
	@MotivazioneRiduzioneContrequalthis INT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE FROM vPAGAMENTI_BENEFICIARIO WHERE 1=1'';
	IF (@IdPagamentoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis)''; set @lensql=@lensql+len(@IdPagamentoBeneficiarioequalthis);end;
	IF (@IdPagamentoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis)''; set @lensql=@lensql+len(@IdPagamentoRichiestoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)''; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@ImportoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_RICHIESTO = @ImportoRichiestoequalthis)''; set @lensql=@lensql+len(@ImportoRichiestoequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_AMMESSO = @ImportoAmmessoequalthis)''; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ImportoNonammNonrespequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_NONAMM_NONRESP = @ImportoNonammNonrespequalthis)''; set @lensql=@lensql+len(@ImportoNonammNonrespequalthis);end;
	IF (@ImportoAmmessoContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_AMMESSO_CONTR = @ImportoAmmessoContrequalthis)''; set @lensql=@lensql+len(@ImportoAmmessoContrequalthis);end;
	IF (@ImportoNonammContrNonrespequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (IMPORTO_NONAMM_CONTR_NONRESP = @ImportoNonammContrNonrespequalthis)''; set @lensql=@lensql+len(@ImportoNonammContrNonrespequalthis);end;
	IF (@SpesaTecnicaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis)''; set @lensql=@lensql+len(@SpesaTecnicaRichiestaequalthis);end;
	IF (@SpesaTecnicaAmmessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)''; set @lensql=@lensql+len(@SpesaTecnicaAmmessaequalthis);end;
	IF (@SpesaTecnicaAmmessaContrequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SPESA_TECNICA_AMMESSA_CONTR = @SpesaTecnicaAmmessaContrequalthis)''; set @lensql=@lensql+len(@SpesaTecnicaAmmessaContrequalthis);end;
	IF (@CostituisceVarianteequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COSTITUISCE_VARIANTE = @CostituisceVarianteequalthis)''; set @lensql=@lensql+len(@CostituisceVarianteequalthis);end;
	IF (@CodRiduzioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (COD_RIDUZIONE = @CodRiduzioneequalthis)''; set @lensql=', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiBeneficiarioFindSelect';

