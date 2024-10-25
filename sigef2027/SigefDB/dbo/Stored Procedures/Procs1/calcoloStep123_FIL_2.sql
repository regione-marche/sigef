CREATE  PROCEDURE [dbo].[calcoloStep123_FIL_2]
@IdProgetto int
AS
BEGIN

--Verifica % spese tecniche per fasce di spesa di investimento:Per progetti i cui costi materiali sopra indicati superano l’importo di € 500.000,00 al netto dell’IVA, 
--le spese tecniche progettuali sono ammissibili in misura pari al 60% 
  
DECLARE  @RESULT INT
SET  @RESULT=1

DECLARE @Count int
SET @Count = (SELECT COUNT(ID_INVESTIMENTO)
		      FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
		      WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 
			  AND (P.ID_PROGETTO=@IdProgetto )
			  AND COSTO_INVESTIMENTO > 500000 -- Investimenti che superano i 500.000,00
             )
 IF (@Count > 0) 
	BEGIN 
	--Spese tecniche progettuali per investimenti fissi 
		DECLARE @COUNT_MAX INT

		SET @COUNT_MAX =  ( SELECT  COUNT(*) 
							FROM  (SELECT CASE I.MOBILE
										WHEN 1 THEN (I.COSTO_INVESTIMENTO)*6  / (100)
										WHEN 0 THEN (I.COSTO_INVESTIMENTO  )*1.8  / (100)
										END AS SPESE_MAX,   I.SPESE_GENERALI, COSTO_INVESTIMENTO
								    FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
									WHERE I.ID_INVESTIMENTO_ORIGINALE IS NULL AND I.COD_TIPO_INVESTIMENTO = 1 
											AND (P.ID_PROGETTO=@IdProgetto )) as SPESE WHERE  SPESE_MAX>SPESE_GENERALI )
		IF (@COUNT_MAX >0) SET  @RESULT=0
 END 
 
SELECT @RESULT AS RESULT

END
