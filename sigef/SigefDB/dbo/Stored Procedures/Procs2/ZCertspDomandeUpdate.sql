CREATE PROCEDURE [dbo].[ZCertspDomandeUpdate]
(
	@IdDomanda INT, 
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
	UPDATE CERTSP_DOMANDE
	SET
		ID_ATTO = @IdAtto, 
		DATA_PRES = @DataPres, 
		SPESE_AMM = @SpeseAmm, 
		SPESA_PUBB = @SpesaPubb, 
		SF_TOT = @SfTot, 
		SF_SPESA_PUBB = @SfSpesaPubb, 
		SF_SPESE_AMM = @SfSpeseAmm, 
		SF_SPESA_PUBB_AMM = @SfSpesaPubbAmm, 
		AS_TOT = @AsTot, 
		AS_COPERTO = @AsCoperto, 
		AS_NON_COPERTO = @AsNonCoperto
	WHERE 
		(ID_DOMANDA = @IdDomanda)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspDomandeUpdate';

