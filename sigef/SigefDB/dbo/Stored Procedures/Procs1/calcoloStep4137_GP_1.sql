CREATE PROCEDURE [dbo].[calcoloStep4137_GP_1]
@IdProgetto int, 
@FASE_ISTRUTTORIA INT = 0
AS
BEGIN
-- Rispetto dei limiti del costo totale progetto.
-- minimo costo porgetto 150.000€
-- max costo progetto <= 350.000 se non raggruppati
-- max costo progetto <= 500.000 se raggruppati
-- priorità a livello di domanda Tipo di Beneficiario id :1126	

-- valori priorita 
-- id  1108	Raggrupamenti: ATI, ATS, RT, RTS e raggrupamenti di Enti Pubblici	codice: a
-- id  1109	Soggetti non raggrupati	   codice: b

DECLARE @COSTOINVESTIMENTO int, @TIPO_BENEFICIARIO int, 
		@CODICE_PRIORITA varchar(10), @result int
SET @result = 1 -- VERIFICATO

SET @CODICE_PRIORITA = (SELECT CODICE FROM PRIORITA_X_PROGETTO PXP
							INNER JOIN VALORI_PRIORITA VP ON PXP.ID_PRIORITA = VP.ID_PRIORITA AND PXP.ID_VALORE = VP.ID_VALORE
						WHERE PXP.ID_PRIORITA = 1126 AND ID_PROGETTO=@IdProgetto) 

IF (@CODICE_PRIORITA IS NULL) SET @result =0 
ELSE BEGIN
	SET @COSTOINVESTIMENTO = (SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) + ISNULL( SUM (SPESE_GENERALI) , 0)  AS Totale_Investimenti 
								FROM PROGETTO P 
									 INNER JOIN vPIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
								WHERE ((I.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 )OR(I.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) AND 
										I.COD_TIPO_INVESTIMENTO = 1 AND
										ID_VARIANTE IS NULL AND
										P.ID_PROGETTO=@IdProgetto)

	IF(@COSTOINVESTIMENTO >= 150000 AND ((@COSTOINVESTIMENTO <= 500000 AND @CODICE_PRIORITA = 'a') OR (@COSTOINVESTIMENTO <= 350000 AND @CODICE_PRIORITA = 'b')))
		SET @result = 1	
	ELSE SET @result =0 
END

SELECT @result AS RESULT
END
