CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoInsert]
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
	INSERT INTO zDIMENSIONI_ESTRAZIONI_IO
	(
		COD_PSR, 
		ID_DIM_PRIORITA, 
		ID_DIM_INDICATORE, 
		VALORE_RTOT, 
		VALORE_PF, 
		DATA_PF, 
		VALORE_F, 
		DATA_F, 
		ID_ESTRAZIONE, 
		DATA_ESTRAZIONE
	)
	VALUES
	(
		@CodPsr, 
		@IdDimPriorita, 
		@IdDimIndicatore, 
		@ValoreRtot, 
		@ValorePf, 
		@DataPf, 
		@ValoreF, 
		@DataF, 
		@IdEstrazione, 
		@DataEstrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ESTRAZIONE_IO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoInsert]
(
	@CodPsr VARCHAR(255), 
	@IdDimPriorita INT, 
	@IdDimIndicatore INT, 
	@ValoreRtot DECIMAL(18,2), 
	@ValorePf DECIMAL(18,2), 
	@DataPf DATETIME, 
	@ValoreF DECIMAL(18,2), 
	@DataF DATETIME, 
	@DataEstrazione DATETIME
)
AS
	INSERT INTO zDIMENSIONI_ESTRAZIONI_IO
	(
		COD_PSR, 
		ID_DIM_PRIORITA, 
		ID_DIM_INDICATORE, 
		VALORE_RTOT, 
		VALORE_PF, 
		DATA_PF, 
		VALORE_F, 
		DATA_F, 
		DATA_ESTRAZIONE
	)
	VALUES
	(
		@CodPsr, 
		@IdDimPriorita, 
		@IdDimIndicatore, 
		@ValoreRtot, 
		@ValorePf, 
		@DataPf, 
		@ValoreF, 
		@DataF, 
		@DataEstrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_ESTRAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoInsert';

