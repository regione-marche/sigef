CREATE PROCEDURE [dbo].[calcoloPriorita126_3]
(
@IdProgetto int,
@fase_istruttoria bit,
@IdVariante int =NULL
)
AS
BEGIN
-- C.	Intensità del danno in relazione alla capacità produttiva aziendale
--declare @IdProgetto int, @fase_istruttoria bit, @IdVariante int 
--set @IdProgetto =2305
--set @fase_istruttoria= 0
--set @IdVariante= 0
DECLARE @Risultato decimal(10,2), @PLV_Investimento decimal(10,2), @FABBISOGNO DECIMAL(18,2)
 
SELECT @FABBISOGNO = VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_PRIORITA =781
IF(@FABBISOGNO IS NULL) SET @Risultato = 0
ELSE BEGIN 
	SET @PLV_Investimento = (SELECT ISNULL(SUM(PLV),0) AS PLV FROM PLV_IMPRESA WHERE PREVISIONALE =0  AND ID_PROGETTO = @IdProgetto)
	IF (@FABBISOGNO > (@PLV_Investimento * 0.7)) SET @Risultato = 1
	ELSE IF (@FABBISOGNO > (@PLV_Investimento * 0.6)) SET @Risultato = 0.8
	ELSE IF (@FABBISOGNO > (@PLV_Investimento * 0.5)) SET @Risultato = 0.6
	ELSE IF (@FABBISOGNO > (@PLV_Investimento * 0.4)) SET @Risultato = 0.4
	ELSE SET @Risultato =0
END
SELECT @Risultato 
END
