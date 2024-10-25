﻿/*************************************************************************************************************************************/
	 
	 CREATE PROCEDURE [dbo].[SpGraduatoriaProgetti_mis323c]
(
	@ID_BANDO INT,
	@OPERATORE VARCHAR(16)
)
AS
 /*
	DECLARE @ID_BANDO INT, @OPERATORE VARCHAR(16)
	SET @ID_BANDO =175--135
	SET @OPERATORE ='VLNMRN70H60F487Y' 
	*/

	--IMPORTO MASSIMO DEL BANDO TRASVERSALE RISPETTO LE ALTRE MISURE ATTIVATE
	DECLARE  @IMPORTO_TOTALE_BANDO DECIMAL(18,2)
	SET @IMPORTO_TOTALE_BANDO=(SELECT IMPORTO-IMPORTO*ISNULL(QUOTA_RISERVA,0)/100 FROM VBANDO WHERE ID_BANDO=@ID_BANDO)

	--SE LO STATO DI QUALCHE DOMANDA E' STATO CAMBIATO DOPO IL PRIMO CALCOLO DELLA GRADUATORIA CANCELLO DA GRADUATORIA_PROGETTI
	DELETE FROM GRADUATORIA_PROGETTI_FINANZIABILITA WHERE ID_PROG_INTEGRATO IN (SELECT ID_PROGETTO FROM vPROGETTO WHERE ID_BANDO=@ID_BANDO AND COD_STATO='B')
	DELETE FROM GRADUATORIA_PROGETTI WHERE ID_PROGETTO IN (SELECT ID_PROGETTO FROM vPROGETTO WHERE ID_BANDO=@ID_BANDO AND COD_STATO='B')

	--SELEZIONO LA LISTA DELLE DOMANDE CON I RELATIVI PUNTEGGI
	DECLARE @GRADUATORIA_PROGETTI_T TABLE (ID_PROGETTO INT,PUNTEGGIO DECIMAL(10,6),COSTO_TOTALE DECIMAL(18,2),UTILIZZA_FONDI_RISERVA BIT,
			AMMONTARE_FONDI_RISERVA_UTILIZZATO DECIMAL(18,2),ORDINE INT,CONTRIBUTO_TOTALE DECIMAL(18,2),CONTRIBUTO_RIMANENTE DECIMAL(18,2),
			FINANZIABILITA CHAR(1),DATA_VALUTAZIONE DATETIME,OPERATORE VARCHAR(16))
	INSERT INTO @GRADUATORIA_PROGETTI_T
	SELECT ID_PROGETTO,PUNTEGGIO,dbo.calcoloCostoTotaleProgetto(ID_PROGETTO,1,NULL),UTILIZZA_FONDI_RISERVA,AMMONTARE_FONDI_RISERVA_UTILIZZATO,
			NULL,NULL,NULL,NULL,NULL,NULL FROM GRADUATORIA_PROGETTI WHERE ID_BANDO=@ID_BANDO

	DECLARE @ID_PROGETTO INT,@ORDINE INT,@CONTRIBUTO_PROGETTO DECIMAL(18,2),@FINANZIABILITA CHAR(1),
			@UTILIZZA_FONDI_RISERVA BIT,@AMMONTARE_FONDI_RISERVA_UTILIZZATO DECIMAL(18,2)
	SET @ORDINE=1
	-- IMPOSTO DI DEFAULT LA FINANZIABILITA TOTALE DELLA DOMANDA
	SET @FINANZIABILITA='S'
	--ORDINAMENTO SPECIFICO DI BANDO
	DECLARE PROGETTI CURSOR FOR SELECT P.ID_PROGETTO,UTILIZZA_FONDI_RISERVA,AMMONTARE_FONDI_RISERVA_UTILIZZATO FROM @GRADUATORIA_PROGETTI_T P
	INNER JOIN PRIORITA_X_PROGETTO PXP ON PXP.ID_PROGETTO= P.ID_PROGETTO AND PXP.ID_PRIORITA=1149
	ORDER BY P.PUNTEGGIO DESC, PXP.VALORE DESC --,DATA_NASCITA DESC
	OPEN PROGETTI
	FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO,@UTILIZZA_FONDI_RISERVA,@AMMONTARE_FONDI_RISERVA_UTILIZZATO
	WHILE @@FETCH_STATUS=0 BEGIN
		SET @CONTRIBUTO_PROGETTO=dbo.calcoloContributoTotaleProgetto(@ID_PROGETTO,1,NULL)
		IF @UTILIZZA_FONDI_RISERVA=1 BEGIN
			SET @CONTRIBUTO_PROGETTO=@CONTRIBUTO_PROGETTO-ISNULL(@AMMONTARE_FONDI_RISERVA_UTILIZZATO,0)
			IF @CONTRIBUTO_PROGETTO<0 BEGIN 
				DECLARE @MESSAGGIO_ERRORE VARCHAR(300)
				SET @MESSAGGIO_ERRORE='L`IMPORTO DEL FONDO DI RISERVA UTILIZZATO DALLA DOMANDA DI AIUTO NR.'+CAST(@ID_PROGETTO AS VARCHAR(10))
					+' SUPERA IL CONTRIBUTO AMMESSO. IMPOSSIBILE CONTINUARE.'
				RAISERROR(@MESSAGGIO_ERRORE,13,1)
				RETURN
			END
		END
		IF @IMPORTO_TOTALE_BANDO>0 BEGIN
			IF (@IMPORTO_TOTALE_BANDO-@CONTRIBUTO_PROGETTO<0) BEGIN
				SET @CONTRIBUTO_PROGETTO=@IMPORTO_TOTALE_BANDO
				SET @IMPORTO_TOTALE_BANDO=0
			END
			ELSE SET @IMPORTO_TOTALE_BANDO=@IMPORTO_TOTALE_BANDO-@CONTRIBUTO_PROGETTO
		END
		ELSE BEGIN		
			SET @IMPORTO_TOTALE_BANDO=0
			SET @FINANZIABILITA='N'
		END
		UPDATE @GRADUATORIA_PROGETTI_T SET DATA_VALUTAZIONE=GETDATE(),OPERATORE=@OPERATORE,ORDINE=@ORDINE,
		CONTRIBUTO_TOTALE=@CONTRIBUTO_PROGETTO+CASE WHEN @UTILIZZA_FONDI_RISERVA=1 THEN ISNULL(@AMMONTARE_FONDI_RISERVA_UTILIZZATO,0) ELSE 0 END,
		CONTRIBUTO_RIMANENTE=@IMPORTO_TOTALE_BANDO,FINANZIABILITA=CASE WHEN ISNULL(@UTILIZZA_FONDI_RISERVA,0)=1 THEN 'S' ELSE @FINANZIABILITA END
		WHERE ID_PROGETTO=@ID_PROGETTO
		SET @ORDINE=@ORDINE+1
		FETCH NEXT FROM PROGETTI INTO @ID_PROGETTO,@UTILIZZA_FONDI_RISERVA,@AMMONTARE_FONDI_RISERVA_UTILIZZATO
	END
	CLOSE PROGETTI
	DEALLOCATE PROGETTI
	
	SELECT G.*,ID_BANDO,SEGNATURA_ALLEGATI,ID_PROG_INTEGRATO,FLAG_PREADESIONE,FLAG_DEFINITIVO,ID_FASCICOLO,ID_IMPRESA,
	PROVINCIA_DI_PRESENTAZIONE,SELEZIONATA_X_REVISIONE 
	FROM @GRADUATORIA_PROGETTI_T G INNER JOIN PROGETTO P ON G.ID_PROGETTO=P.ID_PROGETTO
	ORDER BY ORDINE
	
--FATTO!!!
