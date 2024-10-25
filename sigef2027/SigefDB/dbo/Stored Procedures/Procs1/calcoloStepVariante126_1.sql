CREATE PROCEDURE [dbo].[calcoloStepVariante126_1]
@ID_VARIANTE int
 
AS
BEGIN

-- verifica sostenibilità investimento:
-- rata annua reintegrazione < 40% PLV post-investimento

DECLARE @result inT, @PLV_Investimento decimal(10,2), @FABBISOGNO DECIMAL(18,2),@IdProgetto int
select @IdProgetto = id_progetto from varianti where id_variante = @ID_VARIANTE 
 
SELECT @FABBISOGNO = VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO=@IdProgetto AND ID_PRIORITA =781
IF(@FABBISOGNO IS NULL) SET @result = 0
ELSE BEGIN 
	SET @PLV_Investimento = (SELECT ISNULL(SUM(PLV),0) AS PLV FROM PLV_IMPRESA WHERE PREVISIONALE =0  AND ID_PROGETTO = @IdProgetto)

	IF (@FABBISOGNO > (@PLV_Investimento * 0.3)) SET @result = 1
	ELSE SET @result = 0
END

SELECT @result AS RESULT

END
