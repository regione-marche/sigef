CREATE PROCEDURE [dbo].[ZCertspDomandeInsert]
(
	@IdAtto INT, 
	@DataPres DATETIME, 
	@SpeseAmm DECIMAL(18,2), 
	@SpesaPubb DECIMAL(18,2), 
	@SfTot DECIMAL(18,2), 
	@SfSpesaPubb DECIMAL(18,2), 
	@SfSpeseAmm DECIMAL(18,2), 
	@SfSpesaPubbAmm DECIMAL(18,2), 
	@AsTot DECIMAL(18,2), 
	@AsCoperto DECIMAL(18,2), 
	@AsNonCoperto DECIMAL(18,2)
)
AS
	INSERT INTO CERTSP_DOMANDE
	(
		ID_ATTO, 
		DATA_PRES, 
		SPESE_AMM, 
		SPESA_PUBB, 
		SF_TOT, 
		SF_SPESA_PUBB, 
		SF_SPESE_AMM, 
		SF_SPESA_PUBB_AMM, 
		AS_TOT, 
		AS_COPERTO, 
		AS_NON_COPERTO
	)
	VALUES
	(
		@IdAtto, 
		@DataPres, 
		@SpeseAmm, 
		@SpesaPubb, 
		@SfTot, 
		@SfSpesaPubb, 
		@SfSpeseAmm, 
		@SfSpesaPubbAmm, 
		@AsTot, 
		@AsCoperto, 
		@AsNonCoperto
	)
	SELECT SCOPE_IDENTITY() AS ID_DOMANDA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDomandeInsert';

