CREATE PROCEDURE [dbo].[calcoloStepVariante_B213]
@ID_VARIANTE int
AS
BEGIN
--Sono ammissibili all’aiuto i seguenti investimenti: 
--interventi strutturali di recupero, restauro e riqualificazione del patrimonio culturale delle aree rurali regionali attinenti: 
--1)      il paesaggio tipico rurale Marchigiano; 
--2)      il patrimonio architettonico dei borghi rurali; 
--3)      Il patrimonio artistico, storico ed archeologico delle aree rurali regionali; 
--4)      i luoghi di grande pregio ambientale; 

--a.    interventi di importo fino a 50.000,00 euro al netto iva riguardanti  il recupero, restauro e riqualificazione del patrimonio culturale delle aree rurali regionali attinenti: i luoghi di grande pregio ambientale, in funzione dell’individuazione delle potenzialità di valorizzazione del patrimonio stesso;
--b.    interventi di importi da 50.001,00 a 150.000,00 al netto iva, per  tutti  gli interventi di  recupero di  cui ai punti da 1 a 4.
--Acquasanta Terme, Acquaviva Picena, Appignano del Tronto, Arquata del Tronto, Carassai, Castignano, Castorano, Comunanza, Cossignano, Cupra Marittima, 
--Force, Massignano, Montalto Marche, Montedinove, Montefiore dell’Aso, Montegallo, Montemonaco, Monterubbiano, Offida, Palmiano, Ripatransone, Roccafluvione, Rotella, Venarotta.

DECLARE @IdProgetto int
SET @IdProgetto  = (SELECT ID_PROGETTO FROM VARIANTI WHERE ID_VARIANTE = @ID_VARIANTE)
-- P.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' 


DECLARE @COSTOINVESTIMENTO int, @MONTERUBBIANO int, @NOMONTERUBBIANO int, @VALOREP int, @result int
SET @result = 0 -- NON VERIFICATO

---
SET @COSTOINVESTIMENTO = (
SELECT ISNULL(SUM(COSTO_INVESTIMENTO),0) + ISNULL( SUM (SPESE_GENERALI) , 0)  AS Totale_Investimenti 
FROM PROGETTO P INNER JOIN PIANO_INVESTIMENTI I ON (P.ID_PROGETTO=I.ID_PROGETTO) 
WHERE I.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A')
--
-- priorità se presente massimale investimento fino a 150.000€
SET @VALOREP = (SELECT ID_VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PRIORITA = 664 AND ID_PROGETTO=@IdProgetto) 
---
---
SET @MONTERUBBIANO=(SELECT COUNT(ID_COMUNE) 
					FROM LOCALIZZAZIONE_INVESTIMENTO AS LI INNER JOIN
						 CATASTO_TERRENI AS CA ON CA.ID_CATASTO = LI.ID_CATASTO INNER JOIN
						 PIANO_INVESTIMENTI PI ON LI.ID_INVESTIMENTO = PI.ID_INVESTIMENTO 
					WHERE PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND CA.ID_COMUNE IN (5606,10616)
) 
---
SET @NOMONTERUBBIANO = (SELECT COUNT(ID_COMUNE) 
						FROM LOCALIZZAZIONE_INVESTIMENTO AS LI INNER JOIN
							 CATASTO_TERRENI AS CA ON CA.ID_CATASTO = LI.ID_CATASTO INNER JOIN
							 PIANO_INVESTIMENTI PI ON LI.ID_INVESTIMENTO = PI.ID_INVESTIMENTO 
					    WHERE PI.ID_VARIANTE = @ID_VARIANTE AND isnull(COD_VARIAZIONE,'x')!='A' AND CA.ID_COMUNE NOT IN (5606,10616)

) 
---
IF(((isnull(@MONTERUBBIANO,0) >= 1 AND isnull(@NOMONTERUBBIANO,0) = 0) AND 
	((@COSTOINVESTIMENTO <= 150000 AND @VALOREP = 744)OR 
	 (@COSTOINVESTIMENTO >= 50001 AND @COSTOINVESTIMENTO <= 150000 AND @VALOREP IN (741,742,743)))
	)OR
	(isnull(@MONTERUBBIANO,0) = 0 AND isnull(@NOMONTERUBBIANO,0) > 0 AND @COSTOINVESTIMENTO <= 50000)
)SET @result = 1	

ELSE SET @result =0 
IF (@VALOREP IS NULL) SET @result =0 

SELECT @result AS RESULT
END
