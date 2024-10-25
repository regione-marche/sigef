CREATE PROCEDURE ZRnaBandoConfigUpdate
(
	@IdRnaBandoConfig INT, 
	@IdBando INT, 
	@CodBandoRna INT, 
	@DataPrevistaConcessione DATETIME, 
	@Cumulabilita VARCHAR(255)
)
AS
	UPDATE RNA_BANDO_CONFIG
	SET
		ID_BANDO = @IdBando, 
		COD_BANDO_RNA = @CodBandoRna, 
		DATA_PREVISTA_CONCESSIONE = @DataPrevistaConcessione, 
		CUMULABILITA = @Cumulabilita
	WHERE 
		(ID_RNA_BANDO_CONFIG = @IdRnaBandoConfig)

GO