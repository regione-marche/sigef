CREATE  PROCEDURE [dbo].[calcoloStep311_B_12]
@IdProgetto int , 
@fase_istruttoria int =0
AS
BEGIN


-- 311 B  AZIONE D - 2013 -  Controllo Materia Prima La Quantita_totale materia prima proveniente dall`azienda > 70% nel caso di azienda singola o > 80% nel caso di aziende associate
-- sono escluse le domande sul fotovoltaico

DECLARE @Result int,@VALORE_TOT decimal(15,2) , @progetto_fotovoltaico int,@C INT,
		@QUANTITA_PROPRIA decimal(10,2), @tipo_azienda CHAR(1)
		
SET @Result = 1 -- Impongo lo Step  verificato

SELECT @C=COUNT(*)
FROM vPIANO_INVESTIMENTI INV 
WHERE inv.CODICE NOT IN ('FO','AM', 'SI')and ID_PROGETTO = @IdProgetto
	  AND((@fase_istruttoria =0 and ID_INVESTIMENTO_ORIGINALE is null and ID_VARIANTE is null )or 
	      (@fase_istruttoria =1 and ID_INVESTIMENTO_ORIGINALE is not null and ID_VARIANTE is null) )

IF(ISNULL(@C,0)!=0 ) BEGIN
	SELECT @tipo_azienda= VP.CODICE FROM PRIORITA_X_PROGETTO PP
		INNER JOIN VALORI_PRIORITA VP ON VP.ID_PRIORITA = PP.ID_PRIORITA
	WHERE ID_PROGETTO =@IdProgetto AND PP.ID_PRIORITA = 1187

 
		IF(@tipo_azienda IS NULL) SET @Result=0
		ELSE BEGIN 
			DECLARE @MATERIA_PRIMA INT
			 SELECT  @MATERIA_PRIMA =COUNT(*)
			 FROM PRODOTTI_VENDITE where MATERIA_PRIMA=1 AND ID_PROGETTO =@IdProgetto AND ANNO IS NOT NULL
			 
			 IF @MATERIA_PRIMA=0 SET @Result=0
			 ELSE BEGIN 	
					DECLARE MATERIA_PRIMA CURSOR  FOR 
					(SELECT ISNULL(SUM(ISNULL(QUANTITA_PROPRIA,0) + ISNULL(QUANTITA_EXTRA,0)),0), 
							ISNULL(SUM(QUANTITA_PROPRIA),0) 
					 FROM PRODOTTI_VENDITE where MATERIA_PRIMA=1 AND ID_PROGETTO =@IdProgetto AND ANNO IS NOT NULL
					 GROUP BY ANNO )

					OPEN MATERIA_PRIMA
					FETCH NEXT FROM MATERIA_PRIMA 
					INTO @VALORE_TOT , @QUANTITA_PROPRIA
					WHILE @@FETCH_STATUS = 0
					BEGIN
						IF(@tipo_azienda ='A')BEGIN IF(@QUANTITA_PROPRIA < ((@VALORE_TOT )*0.8) OR  @QUANTITA_PROPRIA =0)  Set @Result =0   END
						ELSE BEGIN IF(@QUANTITA_PROPRIA < ((@VALORE_TOT )*0.7) OR  @QUANTITA_PROPRIA =0)  Set @Result =0   END
					FETCH NEXT FROM MATERIA_PRIMA 
					INTO @VALORE_TOT , @QUANTITA_PROPRIA
					END
					CLOSE MATERIA_PRIMA
					DEALLOCATE MATERIA_PRIMA 
			END 
		END
	END
	
SELECT @Result AS RESULT
END
