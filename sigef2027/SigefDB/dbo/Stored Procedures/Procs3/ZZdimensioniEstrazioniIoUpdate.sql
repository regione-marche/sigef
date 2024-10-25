CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoUpdate]
(
	@CodPsr VARCHAR(255), 
	@IdDimPriorita INT, 
	@IdDimIndicatore INT, 
	@ValoreRtot DECIMAL(18,2), 
	@ValorePf DECIMAL(18,2), 
	@DataPf DATETIME, 
	@ValoreF DECIMAL(18,2), 
	@DataF DATETIME, 
	@IdEstrazione INT, 
	@DataEstrazione DATETIME, 
	@IdEstrazioneIo INT
)
AS
	UPDATE zDIMENSIONI_ESTRAZIONI_IO
	SET
		COD_PSR = @CodPsr, 
		ID_DIM_PRIORITA = @IdDimPriorita, 
		ID_DIM_INDICATORE = @IdDimIndicatore, 
		VALORE_RTOT = @ValoreRtot, 
		VALORE_PF = @ValorePf, 
		DATA_PF = @DataPf, 
		VALORE_F = @ValoreF, 
		DATA_F = @DataF, 
		ID_ESTRAZIONE = @IdEstrazione, 
		DATA_ESTRAZIONE = @DataEstrazione
	WHERE 
		(ID_ESTRAZIONE_IO = @IdEstrazioneIo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoUpdate]
(
	@CodPsr VARCHAR(255), 
	@IdDimPriorita INT, 
	@IdDimIndicatore INT, 
	@ValoreRtot DECIMAL(18,2), 
	@ValorePf DECIMAL(18,2), 
	@DataPf DATETIME, 
	@ValoreF DECIMAL(18,2), 
	@DataF DATETIME, 
	@IdEstrazione INT, 
	@DataEstrazione DATETIME
)
AS
	UPDATE zDIMENSIONI_ESTRAZIONI_IO
	SET
		COD_PSR = @CodPsr, 
		ID_DIM_PRIORITA = @IdDimPriorita, 
		ID_DIM_INDICATORE = @IdDimIndicatore, 
		VALORE_RTOT = @ValoreRtot, 
		VALORE_PF = @ValorePf, 
		DATA_PF = @DataPf, 
		VALORE_F = @ValoreF, 
		DATA_F = @DataF, 
		DATA_ESTRAZIONE = @DataEstrazione
	WHERE 
		(ID_ESTRAZIONE = @IdEstrazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoUpdate';

