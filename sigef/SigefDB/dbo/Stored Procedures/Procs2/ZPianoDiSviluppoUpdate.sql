CREATE PROCEDURE [dbo].[ZPianoDiSviluppoUpdate]
(
	@IdPiano INT, 
	@Anno INT, 
	@IdImpresa INT, 
	@IdProgetto INT, 
	@CostoInvestimento DECIMAL(10,2), 
	@MezziPropri DECIMAL(10,2), 
	@RisorseTerzi DECIMAL(10,2), 
	@ContributiPubblici DECIMAL(10,2), 
	@SpeseGestione DECIMAL(10,2), 
	@RimborsoDebito DECIMAL(10,2), 
	@EntrataGestione DECIMAL(10,2), 
	@AltreCoperture DECIMAL(10,2)
)
AS
	UPDATE PIANO_DI_SVILUPPO
	SET
		ANNO = @Anno, 
		ID_IMPRESA = @IdImpresa, 
		ID_PROGETTO = @IdProgetto, 
		COSTO_INVESTIMENTO = @CostoInvestimento, 
		MEZZI_PROPRI = @MezziPropri, 
		RISORSE_TERZI = @RisorseTerzi, 
		CONTRIBUTI_PUBBLICI = @ContributiPubblici, 
		SPESE_GESTIONE = @SpeseGestione, 
		RIMBORSO_DEBITO = @RimborsoDebito, 
		ENTRATA_GESTIONE = @EntrataGestione, 
		ALTRE_COPERTURE = @AltreCoperture
	WHERE 
		(ID_PIANO = @IdPiano)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPianoDiSviluppoUpdate]
(
	@IdPiano INT, 
	@Anno INT, 
	@IdProgetto INT, 
	@CostoInvestimento DECIMAL(10,2), 
	@MezziPropri DECIMAL(10,2), 
	@RisorseTerzi DECIMAL(10,2), 
	@ContributiPubblici DECIMAL(10,2), 
	@SpeseGestione DECIMAL(10,2), 
	@RimborsoDebito DECIMAL(10,2), 
	@EntrataGestione DECIMAL(10,2), 
	@AltreCoperture DECIMAL(10,2)
)
AS
	UPDATE PIANO_DI_SVILUPPO
	SET
		ANNO = @Anno, 
		ID_PROGETTO = @IdProgetto, 
		COSTO_INVESTIMENTO = @CostoInvestimento, 
		MEZZI_PROPRI = @MezziPropri, 
		RISORSE_TERZI = @RisorseTerzi, 
		CONTRIBUTI_PUBBLICI = @ContributiPubblici, 
		SPESE_GESTIONE = @SpeseGestione, 
		RIMBORSO_DEBITO = @RimborsoDebito, 
		ENTRATA_GESTIONE = @EntrataGestione, 
		ALTRE_COPERTURE = @AltreCoperture
	WHERE 
		(ID_PIANO = @IdPiano)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoUpdate';

