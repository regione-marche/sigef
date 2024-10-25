CREATE PROCEDURE [dbo].[ZPianoDiSviluppoInsert]
(
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
	INSERT INTO PIANO_DI_SVILUPPO
	(
		ANNO, 
		ID_IMPRESA, 
		ID_PROGETTO, 
		COSTO_INVESTIMENTO, 
		MEZZI_PROPRI, 
		RISORSE_TERZI, 
		CONTRIBUTI_PUBBLICI, 
		SPESE_GESTIONE, 
		RIMBORSO_DEBITO, 
		ENTRATA_GESTIONE, 
		ALTRE_COPERTURE
	)
	VALUES
	(
		@Anno, 
		@IdImpresa, 
		@IdProgetto, 
		@CostoInvestimento, 
		@MezziPropri, 
		@RisorseTerzi, 
		@ContributiPubblici, 
		@SpeseGestione, 
		@RimborsoDebito, 
		@EntrataGestione, 
		@AltreCoperture
	)
	SELECT SCOPE_IDENTITY() AS ID_PIANO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZPianoDiSviluppoInsert]
(
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
	INSERT INTO PIANO_DI_SVILUPPO
	(
		ANNO, 
		ID_PROGETTO, 
		COSTO_INVESTIMENTO, 
		MEZZI_PROPRI, 
		RISORSE_TERZI, 
		CONTRIBUTI_PUBBLICI, 
		SPESE_GESTIONE, 
		RIMBORSO_DEBITO, 
		ENTRATA_GESTIONE, 
		ALTRE_COPERTURE
	)
	VALUES
	(
		@Anno, 
		@IdProgetto, 
		@CostoInvestimento, 
		@MezziPropri, 
		@RisorseTerzi, 
		@ContributiPubblici, 
		@SpeseGestione, 
		@RimborsoDebito, 
		@EntrataGestione, 
		@AltreCoperture
	)
	SELECT SCOPE_IDENTITY() AS ID_PIANO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoInsert';

