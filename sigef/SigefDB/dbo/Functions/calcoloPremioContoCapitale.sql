﻿CREATE FUNCTION [dbo].[calcoloPremioContoCapitale] 
(
	@ID_PROGETTO INT, --ID DEL PROGETTO O DEL PROGETTO INTEGRATO
	@FASE_ISTRUTTORIA BIT=0, --SE FASE ISTRUTTORIA TRUE, ALTRIMENTI DEVO CALCOLARE PER GLI INVESTIMENTI ORIGINALI
	@ID_VARIANTE INT=NULL
)
RETURNS DECIMAL(18,2)
AS
BEGIN
	--DECLARE @ID_PROGETTO INT,@FASE_ISTRUTTORIA BIT,@ID_VARIANTE INT
	--SET @ID_PROGETTO=324
	--SET	@FASE_ISTRUTTORIA=0
	--set @ID_VARIANTE=1069

	DECLARE @COD_PSR VARCHAR(20),@MAX_AIUTO DECIMAL(15,2),@MIN_AIUTO DECIMAL(15,2),@COD_AIUTO INT,@PREMIO DECIMAL(18,2)
	
	SELECT @COD_PSR=COD_PSR,@COD_AIUTO=COD_TIPO_INVESTIMENTO,@MIN_AIUTO=ISNULL(IMPORTO_MIN,0),@MAX_AIUTO=ISNULL(IMPORTO_MAX,1000000000)
	FROM PROGETTO AS P INNER JOIN BANDO B ON P.ID_BANDO=B.ID_BANDO
	INNER JOIN vzPROGRAMMAZIONE Z ON B.ID_PROGRAMMAZIONE=Z.ID
	INNER JOIN BANDO_TIPO_INVESTIMENTI AS BI ON P.ID_BANDO=BI.ID_BANDO AND COD_TIPO_INVESTIMENTO=3
	WHERE P.ID_PROGETTO=@ID_PROGETTO	

	IF @COD_AIUTO IS NOT NULL BEGIN	
		IF @COD_PSR='PSR20072013' BEGIN
			--SELECT @COD_AIUTO,@MIN_AIUTO,@MAX_AIUTO
			DECLARE @FINALE DECIMAL(20,6)		
			SELECT @FINALE=SUM(COEFF) FROM(
				SELECT OB.PUNTEGGIO*CASE 				
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))>150000 THEN 1
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))>100000 THEN 0.8
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))>75000 THEN 0.6
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))>50000 THEN 0.4
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))>25000 THEN 0.2
					WHEN SUM(I.COSTO_INVESTIMENTO+dbo.SIAR_MIN(I.SPESE_GENERALI,I.COSTO_INVESTIMENTO/100*D.QUOTA_SPESE_GENERALI))<25000 
						AND OB.ID_OBIETTIVO IN (1,4) THEN 0.1 ELSE 0 END AS COEFF
				FROM PROGETTO AS P
				INNER JOIN PIANO_INVESTIMENTI AS I ON P.ID_PROGETTO=I.ID_PROGETTO AND
					((@FASE_ISTRUTTORIA=0 AND ID_INVESTIMENTO_ORIGINALE IS NULL AND ID_VARIANTE IS NULL) OR 
					(@FASE_ISTRUTTORIA=1 AND ((@ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND ID_VARIANTE IS NULL) 
					OR (ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'x')!='A'))))
				LEFT JOIN CODIFICA_INVESTIMENTO C ON I.ID_CODIFICA_INVESTIMENTO=C.ID_CODIFICA_INVESTIMENTO
				LEFT JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON I.ID_INVESTIMENTO=PXI.ID_INVESTIMENTO 
					AND ID_PRIORITA IN (102,103,94)    -- ID DELLE PRIORITA PER IL CALCOLO DEL PREMIO, VARIA A SECONDA DELLE DISPOSIZIONI DI MISURA
				INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE=VP.ID_VALORE
				INNER JOIN zOBBP_PREMIO OB ON VP.ID_VALORE=OB.ID_VALORE_PRIORITA
				--INNER JOIN OBIETTIVO_BP_PREMIO AS PREMIO ON VP.ID_VALORE=PREMIO.ID_VALORE_PRIORITA
				WHERE P.ID_PROG_INTEGRATO=@ID_PROGETTO AND P.ID_PROGETTO!=@ID_PROGETTO AND I.COSTO_INVESTIMENTO>0--SOLO GLI INVESTIMENTI DELLE MISURE ATTIVATE CONCORRONO AL PREMIO
				GROUP BY OB.ID_VALORE_PRIORITA,OB.PUNTEGGIO,OB.ID_OBIETTIVO) Q1
					
				SET @FINALE=@MAX_AIUTO*ISNULL(@FINALE,0)		
				SET @PREMIO=CASE WHEN @FINALE>@MAX_AIUTO THEN @MAX_AIUTO WHEN @FINALE<@MIN_AIUTO THEN 0 ELSE @FINALE END
		END
		ELSE IF @COD_PSR='PSR20142020' BEGIN
			DECLARE @NR_BENEFICIARI INT,@COD_TIPO_AREA VARCHAR(5),@AMMONTARE_PS DECIMAL(18,2),@SOGLIA_PS DECIMAL(18,2)=16000,
				@COEFF_PREMIO DECIMAL(18,2)=50000, @PRES_ALLEVAMENTI INT ,@DATA_SCAD_BANDO DATETIME
			SELECT @PRES_ALLEVAMENTI= COUNT(*) FROM vALLEVAMENTI_CLASSIFICATI A INNER JOIN PROGETTO P ON P.ID_FASCICOLO= A.ID_FASCICOLO 
			WHERE P.ID_PROGETTO = @ID_PROGETTO AND COD_SPECIE IN( '0121','0129','0126','0124','0125') 
			SELECT @DATA_SCAD_BANDO = B.DATA_SCADENZA FROM vBANDO B INNER JOIN PROGETTO PR ON PR.ID_BANDO = B.ID_BANDO 
			INNER JOIN vzPROGRAMMAZIONE P ON B.ID_PROGRAMMAZIONE = P.ID  WHERE PR.ID_PROGETTO = @ID_PROGETTO 
			-- ZONA
			SELECT TOP 1 @COD_TIPO_AREA=TIPO_AREA FROM PROGETTO P INNER JOIN vTERRITORIO T ON P.ID_FASCICOLO=T.ID_FASCICOLO
			INNER JOIN UTILIZZO_TERRA UT ON UT.ID_TERRITORIO = T.ID_TERRITORIO INNER JOIN MACROUSI M ON M.COD_MACROUSO = UT.COD_MACROUSO 
				WHERE ID_PROGETTO=@ID_PROGETTO AND T.PROVINCIA IN ('AN','MC','AP','FM','PU')
				 AND (COD_TIPO_CONDUZIONE=1 OR (COD_TIPO_CONDUZIONE=2 AND T.DATA_FINE_CONDUZIONE > DATEADD(YEAR,8, DATEADD(DD,120, @DATA_SCAD_BANDO)))) 
				 AND ((@PRES_ALLEVAMENTI> 0 AND CONCORRE_SAU_AZIENDALE=1 AND M.COD_MACROUSO NOT IN ('720'))
						OR(@PRES_ALLEVAMENTI=0 AND CONCORRE_SAU_AZIENDALE=1 AND M.COD_MACROUSO NOT IN ('490','560','600','640','680','721','720')))
			GROUP BY TIPO_AREA ORDER BY SUM(SUPERFICIE_UTILIZZATA ) DESC
			
			IF @COD_TIPO_AREA IN ('C3','D')BEGIN 
				SET @COEFF_PREMIO=70000
				SET @SOGLIA_PS=12000
			END
			-- NR BENEFICIARI
			SELECT @NR_BENEFICIARI=dbo.fnGetNrFirmatariProgetto(@ID_PROGETTO,@FASE_ISTRUTTORIA)
			IF @NR_BENEFICIARI>2 SET @NR_BENEFICIARI=2			
			-- PRODUZIONE STANDARD
			SELECT @AMMONTARE_PS=SUM(PS) 
			FROM ( SELECT CASE WHEN I.CODICE IS NOT NULL THEN SUM(PSD.PS_REALE) ELSE SUM(PS_STANDARD) END AS PS
					FROM PRODUZIONE_STANDARD P INNER JOIN PRODUZIONE_STANDARD_DETTAGLIO PSD ON PSD.ID_PS = P.ID
						LEFT JOIN INEA_PRODUZIONE_STANDARD I ON I.ID = PSD.ID_TRASFORMAZIONE AND I.CODICE IN ('T10','T12') 
					WHERE P.ID_PROGETTO=@ID_PROGETTO AND PREVISIONALE=0 AND P.AMMESSO=@FASE_ISTRUTTORIA AND (@ID_VARIANTE IS NULL OR P.ID_VARIANTE=@ID_VARIANTE) GROUP BY I.CODICE ) TT 
			WHILE (ISNULL(@AMMONTARE_PS,0)<@NR_BENEFICIARI*@SOGLIA_PS AND @NR_BENEFICIARI>0) BEGIN
				SET @NR_BENEFICIARI=@NR_BENEFICIARI-1
			END	
			SET @PREMIO=@NR_BENEFICIARI*@COEFF_PREMIO			
		END	
		-- CONTROLLO CHE IL NUOVO PREMIO NON SUPERI QUELLO AMMESSO IN GRADUATORIA
		IF @FASE_ISTRUTTORIA=1 AND @ID_VARIANTE IS NOT NULL BEGIN		
			DECLARE @PREMIO_PRECEDENTE DECIMAL(18,2)
			SELECT @PREMIO_PRECEDENTE=dbo.calcoloPremioContoCapitale(@ID_PROGETTO,1,NULL)
			IF @PREMIO_PRECEDENTE<@PREMIO SET @PREMIO=@PREMIO_PRECEDENTE
		END	
	END
	RETURN @PREMIO
END