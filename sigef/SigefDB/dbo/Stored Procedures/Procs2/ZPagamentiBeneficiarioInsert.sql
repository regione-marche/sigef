CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioInsert]
(
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
	SET @SpesaTecnicaRichiesta = ISNULL(@SpesaTecnicaRichiesta,((0)))
	SET @SpesaTecnicaAmmessa = ISNULL(@SpesaTecnicaAmmessa,((0)))
	SET @SpesaTecnicaAmmessaContr = ISNULL(@SpesaTecnicaAmmessaContr,((0)))
	SET @CostituisceVariante = ISNULL(@CostituisceVariante,((0)))
	INSERT INTO PAGAMENTI_BENEFICIARIO
	(
		ID_PAGAMENTO_RICHIESTO, 
		ID_GIUSTIFICATIVO, 
		IMPORTO_RICHIESTO, 
		IMPORTO_AMMESSO, 
		CONTRIBUTO_AMMESSO, 
		QUOTA_CONTRIBUTO_AMMESSO, 
		SPESA_TECNICA_RICHIESTA, 
		SPESA_TECNICA_AMMESSA, 
		IMPORTO_NONAMM_NONRESP, 
		IMPORTO_AMMESSO_CONTR, 
		IMPORTO_NONAMM_CONTR_NONRESP, 
		SPESA_TECNICA_AMMESSA_CONTR, 
		COSTITUISCE_VARIANTE, 
		COD_RIDUZIONE, 
		MOTIVAZIONE_RIDUZIONE, 
		COD_RIDUZIONE_CONTR, 
		MOTIVAZIONE_RIDUZIONE_CONTR
	)
	VALUES
	(
		@IdPagamentoRichiesto, 
		@IdGiustificativo, 
		@ImportoRichiesto, 
		@ImportoAmmesso, 
		@ContributoAmmesso, 
		@QuotaContributoAmmesso, 
		@SpesaTecnicaRichiesta, 
		@SpesaTecnicaAmmessa, 
		@ImportoNonammNonresp, 
		@ImportoAmmessoContr, 
		@ImportoNonammContrNonresp, 
		@SpesaTecnicaAmmessaContr, 
		@CostituisceVariante, 
		@CodRiduzione, 
		@MotivazioneRiduzione, 
		@CodRiduzioneContr, 
		@MotivazioneRiduzioneContr
	)
	SELECT SCOPE_IDENTITY() AS ID_PAGAMENTO_BENEFICIARIO, @SpesaTecnicaRichiesta AS SPESA_TECNICA_RICHIESTA, @SpesaTecnicaAmmessa AS SPESA_TECNICA_AMMESSA, @SpesaTecnicaAmmessaContr AS SPESA_TECNICA_AMMESSA_CONTR, @CostituisceVariante AS COSTITUISCE_VARIANTE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPagamentiBeneficiarioInsert]
(
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
	SET @SpesaTecnicaRichiesta = ISNULL(@SpesaTecnicaRichiesta,((0)))
	SET @SpesaTecnicaAmmessa = ISNULL(@SpesaTecnicaAmmessa,((0)))
	SET @SpesaTecnicaAmmessaContr = ISNULL(@SpesaTecnicaAmmessaContr,((0)))
	SET @CostituisceVariante = ISNULL(@CostituisceVariante,((0)))
	INSERT INTO PAGAMENTI_BENEFICIARIO
	(
		ID_PAGAMENTO_RICHIESTO, 
		ID_GIUSTIFICATIVO, 
		IMPORTO_RICHIESTO, 
		IMPORTO_AMMESSO, 
		SPESA_TECNICA_RICHIESTA, 
		SPESA_TECNICA_AMMESSA, 
		IMPORTO_NONAMM_NONRESP, 
		IMPORTO_AMMESSO_CONTR, 
		IMPORTO_NONAMM_CONTR_NONRESP, 
		SPESA_TECNICA_AMMESSA_CONTR, 
		COSTITUISCE_VARIANTE, 
		COD_RIDUZIONE, 
		MOTIVAZIONE_RIDUZIONE, 
		COD_RIDUZIONE_CONTR, 
		MOTIVAZIONE_RIDUZIONE_CONTR
	)
	VALUES
	(
		@IdPagamentoRichiesto, 
		@IdGiustificativo, 
		@ImportoRichiesto, 
		@ImportoAmmesso, 
		@SpesaTecnicaRichiesta, 
		@SpesaTecnicaAmmessa, 
		@ImportoNonammNonresp, 
		@ImportoAmmessoContr, 
		@ImportoNonammContrNonresp, 
		@SpesaTecnicaAmmessaContr, 
		@CostituisceVariante, 
		@CodRiduzione, 
		@MotivazioneRiduzione, 
		@CodRiduzioneContr, 
		@MotivazioneRiduzioneContr
	)
	SELECT SCOPE_IDENTITY() AS ID_PAGAMENTO_BENEFICIARIO, @SpesaTecnicaRichiesta AS SPESA_TECNICA_RICHIESTA, @SpesaTecnicaAmmessa AS SPESA_TECNICA_AMMESSA, @SpesaTecnicaAmmessaContr AS SPESA_TECNICA_AMMESSA_CONTR, @CostituisceVariante AS COSTITUISCE_VARIANTE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPagamentiBeneficiarioInsert';

