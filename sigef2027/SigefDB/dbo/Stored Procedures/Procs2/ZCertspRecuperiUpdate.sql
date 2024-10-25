CREATE PROCEDURE [dbo].[ZCertspRecuperiUpdate]
(
	@IdRecupero INT, 
	@IdProgetto INT, 
	@IdAtto INT, 
	@Sostegno DECIMAL(18,2), 
	@SpeseAmm DECIMAL(18,2), 
	@DataRicevRimb DATETIME, 
	@RimbSostegno DECIMAL(18,2), 
	@RimbSpeseAmm DECIMAL(18,2), 
	@NonrSostegno DECIMAL(18,2), 
	@NonrSpeseAmm DECIMAL(18,2)
)
AS
	UPDATE CERTSP_RECUPERI
	SET
		Id_Progetto = @IdProgetto, 
		Id_Atto = @IdAtto, 
		Sostegno = @Sostegno, 
		Spese_Amm = @SpeseAmm, 
		Data_Ricev_Rimb = @DataRicevRimb, 
		Rimb_Sostegno = @RimbSostegno, 
		Rimb_Spese_Amm = @RimbSpeseAmm, 
		NonR_Sostegno = @NonrSostegno, 
		NonR_Spese_Amm = @NonrSpeseAmm
	WHERE 
		(Id_Recupero = @IdRecupero)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspRecuperiUpdate';

