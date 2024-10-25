CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFinanziabilitaInsert]
(
	@IdBando INT, 
	@IdProgetto INT, 
	@IdProgIntegrato INT, 
	@CostoTotale DECIMAL(18,2), 
	@ContributoDiMisura DECIMAL(18,2), 
	@ContributoRimanente DECIMAL(18,2), 
	@Misura VARCHAR(10), 
	@MisuraPrevalente BIT
)
AS
	INSERT INTO GRADUATORIA_PROGETTI_FINANZIABILITA
	(
		ID_BANDO, 
		ID_PROGETTO, 
		ID_PROG_INTEGRATO, 
		COSTO_TOTALE, 
		CONTRIBUTO_DI_MISURA, 
		CONTRIBUTO_RIMANENTE, 
		MISURA, 
		MISURA_PREVALENTE
	)
	VALUES
	(
		@IdBando, 
		@IdProgetto, 
		@IdProgIntegrato, 
		@CostoTotale, 
		@ContributoDiMisura, 
		@ContributoRimanente, 
		@Misura, 
		@MisuraPrevalente
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFinanziabilitaInsert';

