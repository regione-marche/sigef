﻿CREATE PROCEDURE [dbo].[SpGraduatoriaProgetti_mis911B]
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

	DECLARE @ID_PROGETTO INT,@ORDINE INT,@CONTRIBUTO_PROGETTO DECIMAL(18,2), @COSTO_PROGETTO DECIMAL(18,2),@FINANZIABILITA CHAR(1),@COD_STATO CHAR(1)
	SET @ORDINE=1
	-- IMPOSTO DI DEFAULT LA FINANZIABILITA TOTALE DELLA DOMANDA
	SET @FINANZIABILITA='S'
	DECLARE @ID_VARIANTE int = NULL	
		
	DECLARE PROGETTI CURSOR FOR SELECT P.ID_PROGETTO,V.COD_STATO FROM @GRADUATORIA_PROGETTI_T P
		INNER JOIN vPROGETTO V ON P.ID_PROGETTO=V.ID_PROGETTO 
		INNER JOIN IMPRESA IMP ON IMP.ID_IMPRESA= V.ID_IMPRESA
		INNER JOIN PERSONE_X_IMPRESE I ON IMP.ID_RAPPRLEGALE_ULTIMO=I.ID_PERSONE_X_IMPRESE
		INNER JOIN PERSONA_FISICA PF ON I.ID_PERSONA=PF.ID_PERSONA
		INNER JOIN (SELECT DISTINCT INV.ID_PROGETTO, PXI.ID_PRIORITA FROM PIANO_INVESTIMENTI INV
					INNER JOIN PRIORITA_X_INVESTIMENTI PXI ON inv.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND PXI.ID_PRIORITA IN (1223,1234)
						) AS PRIO_ORDINALE ON PRIO_ORDINALE.ID_PROGETTO = V.ID_PROGETTO 
		ORDER BY ID_PRIORITA,PUNTEGGIO DESC,DATA_NASCITA DESC 
	
	OPEN PROGETTI
	FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO,@COD_STATO
	WHILE @@FETCH_STATUS=0 BEGIN
		---
		DECLARE @ETTARI_PROGETTO DECIMAL(18,2)
		SELECT @ID_VARIANTE = MAX(ID_VARIANTE) 
		FROM VARIANTI WHERE ID_PROGETTO = @ID_PROGETTO AND APPROVATA = 1 AND ANNULLATA = 0 AND COD_TIPO IN ('AR','VA')
		
		IF (@COD_STATO in ('R','E')) SET @ETTARI_PROGETTO=0 --- rinuncia ed esclusi
		ELSE BEGIN  
			-- SET @CONTRIBUTO_PROGETTO=dbo.calcoloContributoTotaleProgetto(@ID_PROGETTO,1,@ID_VARIANTE)
			 SELECT @ETTARI_PROGETTO= SUM(QUANTITA ) FROM PIANO_INVESTIMENTI INV
			 WHERE INV.ID_PROGETTO = @ID_PROGETTO AND  ((INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL AND @ID_VARIANTE IS NULL )
					  OR (INV.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE=@ID_VARIANTE AND @ID_VARIANTE IS NOT NULL AND ISNULL(COD_VARIAZIONE,'X') != 'A'))
		END
 
     	SET @COSTO_PROGETTO = DBO.calcoloCostoTotaleProgetto(@ID_PROGETTO,1,@ID_VARIANTE)
		---
        IF @IMPORTO_TOTALE_BANDO >0 BEGIN
			IF /*@CONTRIBUTO_PROGETTO*/@ETTARI_PROGETTO>@IMPORTO_TOTALE_BANDO BEGIN
			--	SET /*@CONTRIBUTO_PROGETTO*/@ETTARI_PROGETTO = @IMPORTO_TOTALE_BANDO
			    SET @FINANZIABILITA='P' --- P parziale -- N non prevista finanziabilita parzialmente
				SET @ETTARI_PROGETTO= @IMPORTO_TOTALE_BANDO
				SET @IMPORTO_TOTALE_BANDO=0
			END
			ELSE SET @IMPORTO_TOTALE_BANDO=@IMPORTO_TOTALE_BANDO- @ETTARI_PROGETTO/*@CONTRIBUTO_PROGETTO*/
		END
		ELSE BEGIN
			SET @IMPORTO_TOTALE_BANDO=0
			SET @FINANZIABILITA='N' --NON FINANZIABILITA TOTALE
		END
		 
		UPDATE @GRADUATORIA_PROGETTI_T SET DATA_VALUTAZIONE=GETDATE(),OPERATORE=@OPERATORE,ORDINE=@ORDINE,COSTO_TOTALE = @COSTO_PROGETTO, 
		CONTRIBUTO_TOTALE=@ETTARI_PROGETTO,CONTRIBUTO_RIMANENTE=@IMPORTO_TOTALE_BANDO,FINANZIABILITA=@FINANZIABILITA
		WHERE ID_PROGETTO=@ID_PROGETTO
		SET @ORDINE=@ORDINE+1
		FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO, @COD_STATO
	END	
	CLOSE PROGETTI
	DEALLOCATE PROGETTI
 
	SELECT G.*,ID_BANDO,SEGNATURA_ALLEGATI,ID_PROG_INTEGRATO,FLAG_PREADESIONE,FLAG_DEFINITIVO,ID_FASCICOLO,ID_IMPRESA,
	PROVINCIA_DI_PRESENTAZIONE,SELEZIONATA_X_REVISIONE 
	FROM @GRADUATORIA_PROGETTI_T G INNER JOIN PROGETTO P ON G.ID_PROGETTO=P.ID_PROGETTO
	ORDER BY ORDINE
