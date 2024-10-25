CREATE PROCEDURE [dbo].[calcoloStep311_B_7]
@IdProgetto int 
AS
BEGIN


-- 311 B  AZIONE D - Controllo Materia Prima La Quantita_totale almeno il 80% del totale  valore PROPRIA
--declare @IdProgetto int 
--set @IdProgetto= 7534


DECLARE @Result int,	 
		@VALORE_TOT decimal(15,2) , 
		@VALORE_PROPRIO decimal(10,2)

SET @Result = 1 -- Impongo lo Step  verificato


DECLARE MATERIA_PRIMA CURSOR  FOR 
(select   isNull( SUM( ISNULL(VALORE_PROPRIO,0) + ISNULL(VALORE_EXTRA,0)),0), isnull( SUM ( VALORE_PROPRIO) ,0) 
from PRODOTTI_VENDITE where MATERIA_PRIMA=1 AND ID_PROGETTO =@IdProgetto and anno is not null
 group by anno )
 

OPEN MATERIA_PRIMA
FETCH NEXT FROM MATERIA_PRIMA 
INTO @VALORE_TOT , @VALORE_PROPRIO
WHILE @@FETCH_STATUS = 0
BEGIN
 	-- MODIFICA DEL 20 LUGLIO 2011 PER OBBLIGARE AD INSERIRE IL VALORE ENERGETICO
	IF( @VALORE_PROPRIO < ((@VALORE_TOT )*0.8) OR  @VALORE_TOT <=0 )	
	BEGIN Set @Result =0		
	END
FETCH NEXT FROM MATERIA_PRIMA 
INTO @VALORE_TOT , @VALORE_PROPRIO
END

CLOSE MATERIA_PRIMA
DEALLOCATE MATERIA_PRIMA 

SELECT @Result AS RESULT

END
