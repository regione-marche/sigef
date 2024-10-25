﻿CREATE PROCEDURE [dbo].[SpGraduatoriaProgetti_mis431]
(
	@ID_BANDO INT,
	@OPERATORE VARCHAR(16)
)
AS
 /*
DECLARE @ID_BANDO INT, @OPERATORE VARCHAR(16)
SET @ID_BANDO =
SET @OPERATORE ='' 
 
*/
 
 --IMPORTO MASSIMO DEL BANDO TRASVERSALE RISPETTO LE ALTRE MISURE ATTIVATE
DECLARE  @IMPORTO_TOTALE_BANDO DECIMAL(18,2)
SELECT @IMPORTO_TOTALE_BANDO=IMPORTO-IMPORTO*ISNULL(QUOTA_RISERVA,0)/100 FROM VBANDO WHERE ID_BANDO=@ID_BANDO

--SELEZIONO LA LISTA DELLE DOMANDE CON I RELATIVI PUNTEGGI
DECLARE @GRADUATORIA_PROGETTI_T TABLE (ID_PROGETTO INT,PUNTEGGIO DECIMAL(10,6),COSTO_TOTALE DECIMAL(18,2),UTILIZZA_FONDI_RISERVA BIT,
AMMONTARE_FONDI_RISERVA_UTILIZZATO DECIMAL(18,2),ORDINE INT,CONTRIBUTO_TOTALE DECIMAL(18,2),CONTRIBUTO_RIMANENTE DECIMAL(18,2),
FINANZIABILITA CHAR(1),DATA_VALUTAZIONE DATETIME,OPERATORE VARCHAR(16))
INSERT INTO @GRADUATORIA_PROGETTI_T
SELECT ID_PROGETTO,PUNTEGGIO,dbo.calcoloCostoTotaleProgetto(ID_PROGETTO,1,NULL),UTILIZZA_FONDI_RISERVA,AMMONTARE_FONDI_RISERVA_UTILIZZATO,
NULL,NULL,NULL,NULL,NULL,NULL FROM GRADUATORIA_PROGETTI WHERE ID_BANDO=@ID_BANDO

DECLARE @ID_PROGETTO INT,@ORDINE INT,@CONTRIBUTO_PROGETTO DECIMAL(18,2),@FINANZIABILITA CHAR(1),@COD_STATO CHAR(1),@COSTO_PROGETTO DECIMAL(18,2)
SET @ORDINE=1
-- IMPOSTO DI DEFAULT LA FINANZIABILITA TOTALE DELLA DOMANDA
SET @FINANZIABILITA='S'
IF @ID_BANDO=106 BEGIN	
DECLARE @ID_VARIANTE106 int = NULL
DECLARE PROGETTI CURSOR FOR 
	SELECT GP.ID_PROGETTO,V.COD_STATO FROM @GRADUATORIA_PROGETTI_T GP 
	INNER JOIN VPROGETTO V ON GP.ID_PROGETTO=V.ID_PROGETTO 
	OPEN PROGETTI
	FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO,@COD_STATO
	WHILE @@FETCH_STATUS=0 BEGIN
		---
		SET @ID_VARIANTE106 = (select MAX(ID_VARIANTE) from VARIANTI where ID_PROGETTO = @ID_PROGETTO AND APPROVATA = 1 AND ANNULLATA = 0 AND COD_TIPO IN ('AR','VA') )
		
		IF (@COD_STATO in ('R','E')) SET @CONTRIBUTO_PROGETTO=0 --- rinuncia ed esclusi
		ELSE 		
		begin
			SET @CONTRIBUTO_PROGETTO=dbo.calcoloContributoTotaleProgetto(@ID_PROGETTO,1,@ID_VARIANTE106)
		end
		
		SET @COSTO_PROGETTO = DBO.calcoloCostoTotaleProgetto(@ID_PROGETTO,1,@ID_VARIANTE106)
		---			
		IF @IMPORTO_TOTALE_BANDO>0 BEGIN
			IF @CONTRIBUTO_PROGETTO>@IMPORTO_TOTALE_BANDO BEGIN
				SET @CONTRIBUTO_PROGETTO=@IMPORTO_TOTALE_BANDO
				SET @IMPORTO_TOTALE_BANDO=0
				SET @FINANZIABILITA='N' --- P parziale -- N non prevista finanziabilita parzialmente
			END
			ELSE SET @IMPORTO_TOTALE_BANDO=@IMPORTO_TOTALE_BANDO-@CONTRIBUTO_PROGETTO
		END
		ELSE BEGIN
			SET @IMPORTO_TOTALE_BANDO=0
			SET @FINANZIABILITA='N' --NON FINANZIABILITA --- finita dotazione finanziaria
		END
		UPDATE @GRADUATORIA_PROGETTI_T SET DATA_VALUTAZIONE=GETDATE(),OPERATORE=@OPERATORE,ORDINE=@ORDINE,COSTO_TOTALE = @COSTO_PROGETTO, 
		CONTRIBUTO_TOTALE=@CONTRIBUTO_PROGETTO,CONTRIBUTO_RIMANENTE=@IMPORTO_TOTALE_BANDO,FINANZIABILITA=@FINANZIABILITA
		WHERE ID_PROGETTO=@ID_PROGETTO
		SET @ORDINE=@ORDINE+1
		FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO, @COD_STATO
	END	
	CLOSE PROGETTI
	DEALLOCATE PROGETTI
END

--- aggiornata
	SELECT G.*,ID_BANDO,SEGNATURA_ALLEGATI,ID_PROG_INTEGRATO,FLAG_PREADESIONE,FLAG_DEFINITIVO,ID_FASCICOLO,ID_IMPRESA,
	PROVINCIA_DI_PRESENTAZIONE,SELEZIONATA_X_REVISIONE 
	FROM @GRADUATORIA_PROGETTI_T G INNER JOIN PROGETTO P ON G.ID_PROGETTO=P.ID_PROGETTO
	ORDER BY ORDINE
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
