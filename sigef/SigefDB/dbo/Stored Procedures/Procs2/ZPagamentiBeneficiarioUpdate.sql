CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioUpdate]
(
	@IdPagamentoBeneficiario INT, 
	@IdPagamentoRichiesto INT, 
	@IdGiustificativo INT, 
	@ImportoRichiesto DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@ContributoAmmesso DECIMAL(18,2), 
	@QuotaContributoAmmesso DECIMAL(10,2), 
	@SpesaTecnicaRichiesta BIT, 
	@SpesaTecnicaAmmessa BIT, 
	@ImportoNonammNonresp DECIMAL(18,2), 
	@ImportoAmmessoContr DECIMAL(18,2), 
	@ImportoNonammContrNonresp DECIMAL(18,2), 
	@SpesaTecnicaAmmessaContr BIT, 
	@CostituisceVariante BIT, 
	@CodRiduzione VARCHAR(255), 
	@MotivazioneRiduzione INT, 
	@CodRiduzioneContr VARCHAR(255), 
	@MotivazioneRiduzioneContr INT
)
AS
	UPDATE PAGAMENTI_BENEFICIARIO
	SET
		ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiesto, 
		ID_GIUSTIFICATIVO = @IdGiustificativo, 
		IMPORTO_RICHIESTO = @ImportoRichiesto, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		CONTRIBUTO_AMMESSO = @ContributoAmmesso, 
		QUOTA_CONTRIBUTO_AMMESSO = @QuotaContributoAmmesso, 
		SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiesta, 
		SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessa, 
		IMPORTO_NONAMM_NONRESP = @ImportoNonammNonresp, 
		IMPORTO_AMMESSO_CONTR = @ImportoAmmessoContr, 
		IMPORTO_NONAMM_CONTR_NONRESP = @ImportoNonammContrNonresp, 
		SPESA_TECNICA_AMMESSA_CONTR = @SpesaTecnicaAmmessaContr, 
		COSTITUISCE_VARIANTE = @CostituisceVariante, 
		COD_RIDUZIONE = @CodRiduzione, 
		MOTIVAZIONE_RIDUZIONE = @MotivazioneRiduzione, 
		COD_RIDUZIONE_CONTR = @CodRiduzioneContr, 
		MOTIVAZIONE_RIDUZIONE_CONTR = @MotivazioneRiduzioneContr
	WHERE 
		(ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiario)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioUpdate]
(
	@IdPagamentoBeneficiario INT, 
	@IdPagamentoRichiesto INT, 
	@IdGiustificativo INT, 
	@ImportoRichiesto DECIMAL(18,2), 
	@ImportoAmmesso DECIMAL(18,2), 
	@SpesaTecnicaRichiesta BIT, 
	@SpesaTecnicaAmmessa BIT, 
	@ImportoNonammNonresp DECIMAL(18,2), 
	@ImportoAmmessoContr DECIMAL(18,2), 
	@ImportoNonammContrNonresp DECIMAL(18,2), 
	@SpesaTecnicaAmmessaContr BIT, 
	@CostituisceVariante BIT, 
	@CodRiduzione VARCHAR(255), 
	@MotivazioneRiduzione INT, 
	@CodRiduzioneContr VARCHAR(255), 
	@MotivazioneRiduzioneContr INT
)
AS
	UPDATE PAGAMENTI_BENEFICIARIO
	SET
		ID_PAGAMENTO_RICHIESTO = @IdPagamentoRichiesto, 
		ID_GIUSTIFICATIVO = @IdGiustificativo, 
		IMPORTO_RICHIESTO = @ImportoRichiesto, 
		IMPORTO_AMMESSO = @ImportoAmmesso, 
		SPESA_TECNICA_RICHIESTA = @SpesaTecnicaRichiesta, 
		SPESA_TECNICA_AMMESSA = @SpesaTecnicaAmmessa, 
		IMPORTO_NONAMM_NONRESP = @ImportoNonammNonresp, 
		IMPORTO_AMMESSO_CONTR = @ImportoAmmessoContr, 
		IMPORTO_NONAMM_CONTR_NONRESP = @ImportoNonammContrNonresp, 
		SPESA_TECNICA_AMMESSA_CONTR = @SpesaTecnicaAmmessaContr, 
		COSTITUISCE_VARIANTE = @CostituisceVariante, 
		COD_RIDUZIONE = @CodRiduzione, 
		MOTIVAZIONE_RIDUZIONE = @MotivazioneRiduzione, 
		COD_RIDUZIONE_CONTR = @CodRiduzioneContr, 
		MOTIVAZIONE_RIDUZIONE_CONTR = @MotivazioneRiduzioneContr
	WHERE 
		(ID_PAGAMENTO_BENEFICIARIO = @IdPagamentoBeneficiario)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiBeneficiarioUpdate';

