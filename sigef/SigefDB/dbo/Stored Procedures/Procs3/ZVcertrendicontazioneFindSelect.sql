CREATE PROCEDURE [dbo].[ZVcertrendicontazioneFindSelect]
(
	@CodPsrequalthis VARCHAR(255), 
	@IdDomandaPagamentoequalthis INT, 
	@DataApprovazioneequalthis DATETIME, 
	@DataVerdocumequalthis DATETIME, 
	@AsseCodiceequalthis VARCHAR(255), 
	@IdBandoequalthis INT, 
	@Interventoequalthis VARCHAR(255), 
	@Azioneequalthis VARCHAR(255), 
	@IdProgettoequalthis INT, 
	@CodiceCupequalthis VARCHAR(255), 
	@TipoOperazioneequalthis INT, 
	@Statoequalthis VARCHAR(255), 
	@Comuneequalthis INT, 
	@CostoTotaleequalthis DECIMAL(18,2), 
	@ImportoAmmessoequalthis DECIMAL(19,2), 
	@ImportoConcessoequalthis DECIMAL(38,2), 
	@OperazioniBeneficiarioequalthis INT, 
	@ContributoRichiestoequalthis INT, 
	@Beneficiarioequalthis VARCHAR(255), 
	@SpesaAmmessaequalthis DECIMAL(38,2), 
	@ContributoConcessoequalthis DECIMAL(38,2), 
	@ImportoContributoPubblicoequalthis DECIMAL(38,2), 
	@SpesaAmmessaIncrementaleequalthis DECIMAL(38,2), 
	@ImportoContributoPubblicoIncrementaleequalthis DECIMAL(18,2), 
	@ImportoLiquidatoequalthis INT, 
	@OperazioneEsclusaequalthis INT, 
	@MotivoEsclusioneequalthis INT, 
	@DomandaPagamentoIstruitaequalthis BIT, 
	@RdpApprovataequalthis BIT, 
	@InIntegrazioneequalthis BIT, 
	@ImportoPrivatoequalthis DECIMAL(38,2), 
	@Percrealequalthis DECIMAL(38,6), 
	@Rischioirequalthis DECIMAL(5,2), 
	@Rischiocrequalthis DECIMAL(5,2), 
	@Rischioequalthis VARCHAR(255), 
	@DomandaTipoequalthis VARCHAR(255)
)
AS
	declare @sql nvarchar(4000);
	declare @lensql int;
	set @lensql=0;
	SET @sql = 'SELECT Cod_Psr, Id_Domanda_Pagamento, Data_Approvazione, Data_VerDocum, Asse_Codice, Id_Bando, Intervento, Azione, Id_Progetto, Codice_CUP, Tipo_Operazione, Stato, Comune, Costo_Totale, Importo_Ammesso, Importo_Concesso, Operazioni_Beneficiario, Contributo_Richiesto, Beneficiario, Spesa_Ammessa, Contributo_Concesso, Importo_Contributo_Pubblico, Spesa_Ammessa_Incrementale, Importo_Contributo_Pubblico_Incrementale, Importo_Liquidato, Operazione_Esclusa, Motivo_Esclusione, domanda_pagamento_istruita, rdp_approvata, IN_INTEGRAZIONE, Importo_Privato, PercReal, RischioIR, RischioCR, Rischio, Domanda_Tipo FROM vCertRendicontazione WHERE 1=1';
	IF (@CodPsrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Cod_Psr = @CodPsrequalthis)'; set @lensql=@lensql+len(@CodPsrequalthis);end;
	IF (@IdDomandaPagamentoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis)'; set @lensql=@lensql+len(@IdDomandaPagamentoequalthis);end;
	IF (@DataApprovazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Data_Approvazione = @DataApprovazioneequalthis)'; set @lensql=@lensql+len(@DataApprovazioneequalthis);end;
	IF (@DataVerdocumequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Data_VerDocum = @DataVerdocumequalthis)'; set @lensql=@lensql+len(@DataVerdocumequalthis);end;
	IF (@AsseCodiceequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Asse_Codice = @AsseCodiceequalthis)'; set @lensql=@lensql+len(@AsseCodiceequalthis);end;
	IF (@IdBandoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Bando = @IdBandoequalthis)'; set @lensql=@lensql+len(@IdBandoequalthis);end;
	IF (@Interventoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Intervento = @Interventoequalthis)'; set @lensql=@lensql+len(@Interventoequalthis);end;
	IF (@Azioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Azione = @Azioneequalthis)'; set @lensql=@lensql+len(@Azioneequalthis);end;
	IF (@IdProgettoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Id_Progetto = @IdProgettoequalthis)'; set @lensql=@lensql+len(@IdProgettoequalthis);end;
	IF (@CodiceCupequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Codice_CUP = @CodiceCupequalthis)'; set @lensql=@lensql+len(@CodiceCupequalthis);end;
	IF (@TipoOperazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Tipo_Operazione = @TipoOperazioneequalthis)'; set @lensql=@lensql+len(@TipoOperazioneequalthis);end;
	IF (@Statoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Stato = @Statoequalthis)'; set @lensql=@lensql+len(@Statoequalthis);end;
	IF (@Comuneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Comune = @Comuneequalthis)'; set @lensql=@lensql+len(@Comuneequalthis);end;
	IF (@CostoTotaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Costo_Totale = @CostoTotaleequalthis)'; set @lensql=@lensql+len(@CostoTotaleequalthis);end;
	IF (@ImportoAmmessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Ammesso = @ImportoAmmessoequalthis)'; set @lensql=@lensql+len(@ImportoAmmessoequalthis);end;
	IF (@ImportoConcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Concesso = @ImportoConcessoequalthis)'; set @lensql=@lensql+len(@ImportoConcessoequalthis);end;
	IF (@OperazioniBeneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operazioni_Beneficiario = @OperazioniBeneficiarioequalthis)'; set @lensql=@lensql+len(@OperazioniBeneficiarioequalthis);end;
	IF (@ContributoRichiestoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Contributo_Richiesto = @ContributoRichiestoequalthis)'; set @lensql=@lensql+len(@ContributoRichiestoequalthis);end;
	IF (@Beneficiarioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Beneficiario = @Beneficiarioequalthis)'; set @lensql=@lensql+len(@Beneficiarioequalthis);end;
	IF (@SpesaAmmessaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Spesa_Ammessa = @SpesaAmmessaequalthis)'; set @lensql=@lensql+len(@SpesaAmmessaequalthis);end;
	IF (@ContributoConcessoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Contributo_Concesso = @ContributoConcessoequalthis)'; set @lensql=@lensql+len(@ContributoConcessoequalthis);end;
	IF (@ImportoContributoPubblicoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Contributo_Pubblico = @ImportoContributoPubblicoequalthis)'; set @lensql=@lensql+len(@ImportoContributoPubblicoequalthis);end;
	IF (@SpesaAmmessaIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Spesa_Ammessa_Incrementale = @SpesaAmmessaIncrementaleequalthis)'; set @lensql=@lensql+len(@SpesaAmmessaIncrementaleequalthis);end;
	IF (@ImportoContributoPubblicoIncrementaleequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Contributo_Pubblico_Incrementale = @ImportoContributoPubblicoIncrementaleequalthis)'; set @lensql=@lensql+len(@ImportoContributoPubblicoIncrementaleequalthis);end;
	IF (@ImportoLiquidatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Liquidato = @ImportoLiquidatoequalthis)'; set @lensql=@lensql+len(@ImportoLiquidatoequalthis);end;
	IF (@OperazioneEsclusaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Operazione_Esclusa = @OperazioneEsclusaequalthis)'; set @lensql=@lensql+len(@OperazioneEsclusaequalthis);end;
	IF (@MotivoEsclusioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Motivo_Esclusione = @MotivoEsclusioneequalthis)'; set @lensql=@lensql+len(@MotivoEsclusioneequalthis);end;
	IF (@DomandaPagamentoIstruitaequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (domanda_pagamento_istruita = @DomandaPagamentoIstruitaequalthis)'; set @lensql=@lensql+len(@DomandaPagamentoIstruitaequalthis);end;
	IF (@RdpApprovataequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (rdp_approvata = @RdpApprovataequalthis)'; set @lensql=@lensql+len(@RdpApprovataequalthis);end;
	IF (@InIntegrazioneequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (IN_INTEGRAZIONE = @InIntegrazioneequalthis)'; set @lensql=@lensql+len(@InIntegrazioneequalthis);end;
	IF (@ImportoPrivatoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Importo_Privato = @ImportoPrivatoequalthis)'; set @lensql=@lensql+len(@ImportoPrivatoequalthis);end;
	IF (@Percrealequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (PercReal = @Percrealequalthis)'; set @lensql=@lensql+len(@Percrealequalthis);end;
	IF (@Rischioirequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RischioIR = @Rischioirequalthis)'; set @lensql=@lensql+len(@Rischioirequalthis);end;
	IF (@Rischiocrequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (RischioCR = @Rischiocrequalthis)'; set @lensql=@lensql+len(@Rischiocrequalthis);end;
	IF (@Rischioequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Rischio = @Rischioequalthis)'; set @lensql=@lensql+len(@Rischioequalthis);end;
	IF (@DomandaTipoequalthis IS NOT NULL) BEGIN SET @sql = @sql + ' AND (Domanda_Tipo = @DomandaTipoequalthis)'; set @lensql=@lensql+len(@DomandaTipoequalthis);end;
	set @lensql=@lensql+len(@sql);
	if (@lensql<3000)
	exec sp_executesql @sql,N'@CodPsrequalthis VARCHAR(255), @IdDomandaPagamentoequalthis INT, @DataApprovazioneequalthis DATETIME, @DataVerdocumequalthis DATETIME, @AsseCodiceequalthis VARCHAR(255), @IdBandoequalthis INT, @Interventoequalthis VARCHAR(255), @Azioneequalthis VARCHAR(255), @IdProgettoequalthis INT, @CodiceCupequalthis VARCHAR(255), @TipoOperazioneequalthis INT, @Statoequalthis VARCHAR(255), @Comuneequalthis INT, @CostoTotaleequalthis DECIMAL(18,2), @ImportoAmmessoequalthis DECIMAL(19,2), @ImportoConcessoequalthis DECIMAL(38,2), @OperazioniBeneficiarioequalthis INT, @ContributoRichiestoequalthis INT, @Beneficiarioequalthis VARCHAR(255), @SpesaAmmessaequalthis DECIMAL(38,2), @ContributoConcessoequalthis DECIMAL(38,2), @ImportoContributoPubblicoequalthis DECIMAL(38,2), @SpesaAmmessaIncrementaleequalthis DECIMAL(38,2), @ImportoContributoPubblicoIncrementaleequalthis DECIMAL(18,2), @ImportoLiquidatoequalthis INT, @OperazioneEsclusaequalthis INT, @MotivoEsclusioneequalthis INT, @DomandaPagamentoIstruitaequalthis BIT, @RdpApprovataequalthis BIT, @InIntegrazioneequalthis BIT, @ImportoPrivatoequalthis DECIMAL(38,2), @Percrealequalthis DECIMAL(38,6), @Rischioirequalthis DECIMAL(5,2), @Rischiocrequalthis DECIMAL(5,2), @Rischioequalthis VARCHAR(255), @DomandaTipoequalthis VARCHAR(255)',@CodPsrequalthis , @IdDomandaPagamentoequalthis , @DataApprovazioneequalthis , @DataVerdocumequalthis , @AsseCodiceequalthis , @IdBandoequalthis , @Interventoequalthis , @Azioneequalthis , @IdProgettoequalthis , @CodiceCupequalthis , @TipoOperazioneequalthis , @Statoequalthis , @Comuneequalthis , @CostoTotaleequalthis , @ImportoAmmessoequalthis , @ImportoConcessoequalthis , @OperazioniBeneficiarioequalthis , @ContributoRichiestoequalthis , @Beneficiarioequalthis , @SpesaAmmessaequalthis , @ContributoConcessoequalthis , @ImportoContributoPubblicoequalthis , @SpesaAmmessaIncrementaleequalthis , @ImportoContributoPubblicoIncrementaleequalthis , @ImportoLiquidatoequalthis , @OperazioneEsclusaequalthis , @MotivoEsclusioneequalthis , @DomandaPagamentoIstruitaequalthis , @RdpApprovataequalthis , @InIntegrazioneequalthis , @ImportoPrivatoequalthis , @Percrealequalthis , @Rischioirequalthis , @Rischiocrequalthis , @Rischioequalthis , @DomandaTipoequalthis ;
	else
		SELECT Cod_Psr, Id_Domanda_Pagamento, Data_Approvazione, Data_VerDocum, Asse_Codice, Id_Bando, Intervento, Azione, Id_Progetto, Codice_CUP, Tipo_Operazione, Stato, Comune, Costo_Totale, Importo_Ammesso, Importo_Concesso, Operazioni_Beneficiario, Contributo_Richiesto, Beneficiario, Spesa_Ammessa, Contributo_Concesso, Importo_Contributo_Pubblico, Spesa_Ammessa_Incrementale, Importo_Contributo_Pubblico_Incrementale, Importo_Liquidato, Operazione_Esclusa, Motivo_Esclusione, domanda_pagamento_istruita, rdp_approvata, IN_INTEGRAZIONE, Importo_Privato, PercReal, RischioIR, RischioCR, Rischio, Domanda_Tipo
		FROM vCertRendicontazione
		WHERE 
			((@CodPsrequalthis IS NULL) OR Cod_Psr = @CodPsrequalthis) AND 
			((@IdDomandaPagamentoequalthis IS NULL) OR Id_Domanda_Pagamento = @IdDomandaPagamentoequalthis) AND 
			((@DataApprovazioneequalthis IS NULL) OR Data_Approvazione = @DataApprovazioneequalthis) AND 
			((@DataVerdocumequalthis IS NULL) OR Data_VerDocum = @DataVerdocumequalthis) AND 
			((@AsseCodiceequalthis IS NULL) OR Asse_Codice = @AsseCodiceequalthis) AND 
			((@IdBandoequalthis IS NULL) OR Id_Bando = @IdBandoequalthis) AND 
			((@Interventoequalthis IS NULL) OR Intervento = @Interventoequalthis) AND 
			((@Azioneequalthis IS NULL) OR Azione = @Azioneequalthis) AND 
			((@IdProgettoequalthis IS NULL) OR Id_Progetto = @IdProgettoequalthis) AND 
			((@CodiceCupequalthis IS NULL) OR Codice_CUP = @CodiceCupequalthis) AND 
			((@TipoOperazioneequalthis IS NULL) OR Tipo_Operazione = @TipoOperazioneequalthis) AND 
			((@Statoequalthis IS NULL) OR Stato = @Statoequalthis) AND 
			((@Comuneequalthis IS NULL) OR Comune = @Comuneequalthis) AND 
			((@CostoTotaleequalthis IS NULL) OR Costo_Totale = @CostoTotaleequalthis) AND 
			((@ImportoAmmessoequalthis IS NULL) OR Importo_Ammesso = @ImportoAmmessoequalthis) AND 
			((@ImportoConcessoequalthis IS NULL) OR Importo_Concesso = @ImportoConcessoequalthis) AND 
			((@OperazioniBeneficiarioequalthis IS NULL) OR Operazioni_Beneficiario = @OperazioniBeneficiarioequalthis) AND 
			((@ContributoRichiestoequalthis IS NULL) OR Contributo_Richiesto = @ContributoRichiestoequalthis) AND 
			((@Beneficiarioequalthis IS NULL) OR Beneficiario = @Beneficiarioequalthis) AND 
			((@SpesaAmmessaequalthis IS NULL) OR Spesa_Ammessa = @SpesaAmmessaequalthis) AND 
			((@ContributoConcessoequalthis IS NULL) OR Contributo_Concesso = @ContributoConcessoequalthis) AND 
			((@ImportoContributoPubblicoequalthis IS NULL) OR Importo_Contributo_Pubblico = @ImportoContributoPubblicoequalthis) AND 
			((@SpesaAmmessaIncrementaleequalthis IS NULL) OR Spesa_Ammessa_Incrementale = @SpesaAmmessaIncrementaleequalthis) AND 
			((@ImportoContributoPubblicoIncrementaleequalthis IS NULL) OR Importo_Contributo_Pubblico_Incrementale = @ImportoContributoPubblicoIncrementaleequalthis) AND 
			((@ImportoLiquidatoequalthis IS NULL) OR Importo_Liquidato = @ImportoLiquidatoequalthis) AND 
			((@OperazioneEsclusaequalthis IS NULL) OR Operazione_Esclusa = @OperazioneEsclusaequalthis) AND 
			((@MotivoEsclusioneequalthis IS NULL) OR Motivo_Esclusione = @MotivoEsclusioneequalthis) AND 
			((@DomandaPagamentoIstruitaequalthis IS NULL) OR domanda_pagamento_istruita = @DomandaPagamentoIstruitaequalthis) AND 
			((@RdpApprovataequalthis IS NULL) OR rdp_approvata = @RdpApprovataequalthis) AND 
			((@InIntegrazioneequalthis IS NULL) OR IN_INTEGRAZIONE = @InIntegrazioneequalthis) AND 
			((@ImportoPrivatoequalthis IS NULL) OR Importo_Privato = @ImportoPrivatoequalthis) AND 
			((@Percrealequalthis IS NULL) OR PercReal = @Percrealequalthis) AND 
			((@Rischioirequalthis IS NULL) OR RischioIR = @Rischioirequalthis) AND 
			((@Rischiocrequalthis IS NULL) OR RischioCR = @Rischiocrequalthis) AND 
			((@Rischioequalthis IS NULL) OR Rischio = @Rischioequalthis) AND 
			((@DomandaTipoequalthis IS NULL) OR Domanda_Tipo = @DomandaTipoequalthis)
		
