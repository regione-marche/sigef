﻿CREATE PROCEDURE [dbo].[calcoloStep112_valutazione]
@IdProgetto int
AS
BEGIN
-- compilazione obbligatoria Quadri BP PIANO_DI_SVILUPPO
 
DECLARE @RESULT INT, @COPERTURA decimal (10,2), @FABBISOGNO decimal(10,2), @NUM_ANNO INT =3
SET @RESULT =1 --pongo lo step verificato
-- PER IL BANDO V SCADENZA ALMENO DUE ANNI
IF((SELECT ID_BANDO FROM PROGETTO WHERE ID_PROGETTO = @IdProgetto ) = 376) SET @NUM_ANNO =2

IF (( SELECT COUNT (*) from PIANO_DI_SVILUPPO where ID_PROGETTO = @IdProgetto )>=@NUM_ANNO )
	BEGIN 
			
		DECLARE PIANO_DI_SVILUPPO CURSOR  FOR 
			(SELECT  SUM ( ISNULL (COSTO_INVESTIMENTO,0) + ISNULL (SPESE_GESTIONE,0) + ISNULL (RIMBORSO_DEBITO,0 )) AS FABBISOGNO , SUM( ISNULL (MEZZI_PROPRI,0) + ISNULL (RISORSE_TERZI,0) 
			+ ISNULL (CONTRIBUTI_PUBBLICI,0) + ISNULL (ENTRATA_GESTIONE,0) + ISNULL (ALTRE_COPERTURE,0) )AS COPERTURA  
				FROM PIANO_DI_SVILUPPO WHERE  ID_PROGETTO = @IdProgetto   group by  ANNO ) 

			OPEN PIANO_DI_SVILUPPO
			FETCH NEXT FROM PIANO_DI_SVILUPPO
			INTO @FABBISOGNO,@COPERTURA
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF( @FABBISOGNO <=0 or @COPERTURA<=0 )
				BEGIN
					SET @RESULT=0
					BREAK
				END
			ELSE 	 
				IF( @COPERTURA - @FABBISOGNO <0  )
				BEGIN
					SET @RESULT=0
					BREAK
				END	
			FETCH NEXT FROM PIANO_DI_SVILUPPO
			INTO @FABBISOGNO,@COPERTURA
		END
		CLOSE PIANO_DI_SVILUPPO
		DEALLOCATE PIANO_DI_SVILUPPO
     
   END
else set @RESULT =0

SELECT @RESULT as result
 
end
