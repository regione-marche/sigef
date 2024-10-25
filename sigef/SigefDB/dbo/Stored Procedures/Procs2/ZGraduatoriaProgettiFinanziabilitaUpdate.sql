CREATE PROCEDURE [dbo].[ZGraduatoriaProgettiFinanziabilitaUpdate]
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
	UPDATE GRADUATORIA_PROGETTI_FINANZIABILITA
	SET
		ID_PROG_INTEGRATO = @IdProgIntegrato, 
		COSTO_TOTALE = @CostoTotale, 
		CONTRIBUTO_DI_MISURA = @ContributoDiMisura, 
		CONTRIBUTO_RIMANENTE = @ContributoRimanente, 
		MISURA = @Misura, 
		MISURA_PREVALENTE = @MisuraPrevalente
	WHERE 
		(ID_BANDO = @IdBando) AND 
		(ID_PROGETTO = @IdProgetto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZGraduatoriaProgettiFinanziabilitaUpdate';

