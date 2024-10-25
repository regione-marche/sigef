CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioFindFind]
(
	@IdPagamentoRichiestoequalthis INT, 
	@IdPagamentoBeneficiarioequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@SpesaTecnicaRichiestaequalthis BIT, 
	@SpesaTecnicaAmmessaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, QUOTA_CONTRIBUTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE FROM vPAGAMENTI_BENEFICIARIO WHERE 1=1';
	IF (@IdPagamentoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis)'; set @lensql=@lensql+len(@IdPagamentoRichiestoequalthis);end;
	IF (@IdPagamentoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis)'; set @lensql=@lensql+len(@IdPagamentoBeneficiarioequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_PROGETTO = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)'; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@SpesaTecnicaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis)'; set @lensql=@lensql+len(@SpesaTecnicaRichiestaequalthis);end;
	IF (@SpesaTecnicaAmmessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)'; set @lensql=@lensql+len(@SpesaTecnicaAmmessaequalthis);end;
	set @sql = @sql + 'ORDER BY ID_PAGAMENTO_BENEFICIARIO';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@IdPagamentoRichiestoequalthis INT, @IdPagamentoBeneficiarioequalthis INT, @IdProgettoequalthis INT, @IdGiustificativoequalthis INT, @SpesaTecnicaRichiestaequalthis BIT, @SpesaTecnicaAmmessaequalthis BIT',@IdPagamentoRichiestoequalthis , @IdPagamentoBeneficiarioequalthis , @IdProgettoequalthis , @IdGiustificativoequalthis , @SpesaTecnicaRichiestaequalthis , @SpesaTecnicaAmmessaequalthis ;
	else
		SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, CONTRIBUTO_AMMESSO, QUOTA_CONTRIBUTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE
		FROM vPAGAMENTI_BENEFICIARIO
		WHERE 
			((@IdPagamentoRichiestoequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis) AND 
			((@IdPagamentoBeneficiarioequalthis IS NULL) OR ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@SpesaTecnicaRichiestaequalthis IS NULL) OR SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis) AND 
			((@SpesaTecnicaAmmessaequalthis IS NULL) OR SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)
		ORDER BY ID_PAGAMENTO_BENEFICIARIO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioFindFind]
(
	@IdPagamentoRichiestoequalthis INT, 
	@IdPagamentoBeneficiarioequalthis INT, 
	@IdProgettoequalthis INT, 
	@IdGiustificativoequalthis INT, 
	@SpesaTecnicaRichiestaequalthis BIT, 
	@SpesaTecnicaAmmessaequalthis BIT
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = ''SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE FROM vPAGAMENTI_BENEFICIARIO WHERE 1=1'';
	IF (@IdPagamentoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis)''; set @lensql=@lensql+len(@IdPagamentoRichiestoequalthis);end;
	IF (@IdPagamentoBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis)''; set @lensql=@lensql+len(@IdPagamentoBeneficiarioequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_PROGETTO = @IdProgettoequalthis)''; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@IdGiustificativoequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (ID_GIUSTIFICATIVO = @IdGiustificativoequalthis)''; set @lensql=@lensql+len(@IdGiustificativoequalthis);end;
	IF (@SpesaTecnicaRichiestaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis)''; set @lensql=@lensql+len(@SpesaTecnicaRichiestaequalthis);end;
	IF (@SpesaTecnicaAmmessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + '' AND (SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)''; set @lensql=@lensql+len(@SpesaTecnicaAmmessaequalthis);end;
	set @sql = @sql + ''ORDER BY ID_PAGAMENTO_BENEFICIARIO'';
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N''@IdPagamentoRichiestoequalthis INT, @IdPagamentoBeneficiarioequalthis INT, @IdProgettoequalthis INT, @IdGiustificativoequalthis INT, @SpesaTecnicaRichiestaequalthis BIT, @SpesaTecnicaAmmessaequalthis BIT'',@IdPagamentoRichiestoequalthis , @IdPagamentoBeneficiarioequalthis , @IdProgettoequalthis , @IdGiustificativoequalthis , @SpesaTecnicaRichiestaequalthis , @SpesaTecnicaAmmessaequalthis ;
	else
		SELECT ID_PAGAMENTO_BENEFICIARIO, ID_PAGAMENTO_RICHIESTO, ID_GIUSTIFICATIVO, IMPORTO_RICHIESTO, IMPORTO_AMMESSO, ID_PROGETTO, NUMERO, COD_TIPO, DATA, NUMERO_DOCTRASPORTO, DATA_DOCTRASPORTO, IMPONIBILE, IVA, ALTRI_ONERI, DESCRIZIONE, CF_FORNITORE, DESCRIZIONE_FORNITORE, TIPO_GIUSTIFICATIVO, SPESA_TECNICA_RICHIESTA, SPESA_TECNICA_AMMESSA, IVA_NON_RECUPERABILE, IMPORTO_NONAMM_NONRESP, IMPORTO_AMMESSO_CONTR, IMPORTO_NONAMM_CONTR_NONRESP, SPESA_TECNICA_AMMESSA_CONTR, COSTITUISCE_VARIANTE, LAVORI_IN_ECONOMIA, COD_RIDUZIONE, MOTIVAZIONE_RIDUZIONE, COD_RIDUZIONE_CONTR, MOTIVAZIONE_RIDUZIONE_CONTR, ID_FILE
		FROM vPAGAMENTI_BENEFICIARIO
		WHERE 
			((@IdPagamentoRichiestoequalthis IS NULL) OR ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiestoequalthis) AND 
			((@IdPagamentoBeneficiarioequalthis IS NULL) OR ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiarioequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR ID_PROGETTO = @IdProgettoequalthis) AND 
			((@IdGiustificativoequalthis IS NULL) OR ID_GIUSTIFICATIVO = @IdGiustificativoequalthis) AND 
			((@SpesaTecnicaRichiestaequalthis IS NULL) OR SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiestaequalthis) AND 
			((@SpesaTecnicaAmmessaequalthis IS NULL) OR SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessaequalthis)
		ORDER', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiBeneficiarioFindFind';

