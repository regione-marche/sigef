CREATE  PROCEDURE [dbo].[calcoloStepVariante123_11]
 @ID_VARIANTE INT 
AS
BEGIN
--
 
--  123 - verifica % spese tecniche per fasce di spesa di investimento:
 --Per progetti i cui costi materiali sopra indicati superano l’importo di € 500.000,00 al netto dell’IVA, 
-- le spese tecniche progettuali sono ammissibili in misura pari al 60% del costo dell’intero progetto.
 
--declare @IdProgetto int,
-- @FASE_ISTRUTTORIA INT  
--
--set @IdProgetto=7400
--set @FASE_ISTRUTTORIA=0

DECLARE  @count int, @COUNT_INV INT,@RESULT INT

SET @RESULT=0  --- NON VERIFICATO

 SET  @count = (SELECT COUNT(*)FROM PIANO_INVESTIMENTI I WHERE I.COD_TIPO_INVESTIMENTO = 1 AND ID_VARIANTE  =@ID_VARIANTE AND  isnull(COD_VARIAZIONE,'x')!='A'
				GROUP BY  i.ID_PROGETTO
				HAVING  SUM(COSTO_INVESTIMENTO) > 500000  )
IF (@Count > 0) 
BEGIN
	SET @COUNT_INV = ( SELECT COUNT(*) FROM (SELECT COUNT(*)AS CONT
						FROM PROGETTO P INNER JOIN VPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
						WHERE  ID_VARIANTE  =@ID_VARIANTE AND  isnull(COD_VARIAZIONE,'x')!='A'AND I.COD_TIPO_INVESTIMENTO = 1 
						GROUP BY I.ID_PROGETTO, SPESE_GENERALI, COSTO_INVESTIMENTO, QUOTA_SPESE_GENERALI
						HAVING SPESE_GENERALI >CAST((COSTO_INVESTIMENTO *((QUOTA_SPESE_GENERALI/100)* 0.6)) AS DECIMAL (10,2))) AS T )

	IF  (ISNULL(@COUNT_INV,0) >0 ) SET @RESULT=0 
	ELSE SET @RESULT=1 
END
ELSE SET @RESULT=1 
	
SELECT @RESULT

END
