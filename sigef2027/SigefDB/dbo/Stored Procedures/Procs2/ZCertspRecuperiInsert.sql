CREATE PROCEDURE [dbo].[ZCertspRecuperiInsert]
(
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
	INSERT INTO CERTSP_RECUPERI
	(
		Id_Progetto, 
		Id_Atto, 
		Sostegno, 
		Spese_Amm, 
		Data_Ricev_Rimb, 
		Rimb_Sostegno, 
		Rimb_Spese_Amm, 
		NonR_Sostegno, 
		NonR_Spese_Amm
	)
	VALUES
	(
		@IdProgetto, 
		@IdAtto, 
		@Sostegno, 
		@SpeseAmm, 
		@DataRicevRimb, 
		@RimbSostegno, 
		@RimbSpeseAmm, 
		@NonrSostegno, 
		@NonrSpeseAmm
	)
	SELECT SCOPE_IDENTITY() AS Id_Recupero


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCertspRecuperiInsert';

