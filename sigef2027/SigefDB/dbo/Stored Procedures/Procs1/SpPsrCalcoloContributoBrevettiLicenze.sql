﻿CREATE PROCEDURE [dbo].[SpPsrCalcoloContributoBrevettiLicenze]
(
	@ID_INVESTIMENTO INT,
	@FASE VARCHAR(10)
)
AS
	DECLARE @MAX_AIUTO DECIMAL(18,2),@MAX_QUOTA DECIMAL(15,2),@ID_PROGETTO_CORRELATO INT,@ID_VARIANTE INT,@ID_DISP_ATTUATIVA INT
	-- RECUPERO I DATI DEI BREVETTI/LICENZE
	SELECT TOP 1 @MAX_AIUTO=ISNULL(IMPORTO_MAX,1000000000),@MAX_QUOTA=ISNULL(QUOTA_MAX,100),@ID_PROGETTO_CORRELATO=I.ID_PROGETTO,
		@ID_VARIANTE=I.ID_VARIANTE,@ID_DISP_ATTUATIVA=P.ID_BANDO
	FROM PIANO_INVESTIMENTI I INNER JOIN PROGETTO P ON I.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN BANDO_TIPO_INVESTIMENTI B ON P.ID_BANDO=B.ID_BANDO AND B.COD_TIPO_INVESTIMENTO=5
	WHERE I.ID_INVESTIMENTO=@ID_INVESTIMENTO
	----------------------------------------------
	IF @@ROWCOUNT=0 RAISERROR('Il bando non prevede l`inserimento di questa tipologia di investimenti.',13,1)
	ELSE BEGIN
		-- SELEZIONO IL PIANO INVESTIMENTI RELATIVO ALLA FASE IN QUESTIONE
		DECLARE @PIANO_INVESTIMENTI TABLE (ID_INVESTIMENTO INT,ID_PROGETTO INT,ID_PROGRAMMAZIONE INT,COD_TIPO_INVESTIMENTO INT,
			COSTO_INVESTIMENTO DECIMAL(15, 2),SPESE_GENERALI DECIMAL(15, 2),CONTRIBUTO_RICHIESTO DECIMAL(15, 2),
			QUOTA_CONTRIBUTO_RICHIESTO DECIMAL(10, 2),AMMESSO BIT,ID_INVESTIMENTO_ORIGINALE INT,ID_VARIANTE INT,COD_VARIAZIONE CHAR(1))
		IF @FASE='PDOMANDA' BEGIN
			INSERT INTO @PIANO_INVESTIMENTI
			SELECT ID_INVESTIMENTO,ID_PROGETTO,ID_PROGRAMMAZIONE,COD_TIPO_INVESTIMENTO,COSTO_INVESTIMENTO,SPESE_GENERALI,
				CONTRIBUTO_RICHIESTO,QUOTA_CONTRIBUTO_RICHIESTO,AMMESSO,ID_INVESTIMENTO_ORIGINALE,ID_VARIANTE,COD_VARIAZIONE
			FROM PIANO_INVESTIMENTI I LEFT JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO
			WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO AND AMMESSO IS NULL AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NULL 
		END
		ELSE IF @FASE='IDOMANDA' BEGIN
			INSERT INTO @PIANO_INVESTIMENTI
			SELECT ID_INVESTIMENTO,ID_PROGETTO,ID_PROGRAMMAZIONE,COD_TIPO_INVESTIMENTO,COSTO_INVESTIMENTO,SPESE_GENERALI,
				CONTRIBUTO_RICHIESTO,QUOTA_CONTRIBUTO_RICHIESTO,AMMESSO,ID_INVESTIMENTO_ORIGINALE,ID_VARIANTE,COD_VARIAZIONE
			FROM PIANO_INVESTIMENTI I LEFT JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO
			WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO AND ID_VARIANTE IS NULL AND ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND AMMESSO IS NOT NULL
		END
		ELSE IF @FASE IN ('PVARIANTE','IVARIANTE') BEGIN
			INSERT INTO @PIANO_INVESTIMENTI
			SELECT ID_INVESTIMENTO,ID_PROGETTO,ID_PROGRAMMAZIONE,COD_TIPO_INVESTIMENTO,COSTO_INVESTIMENTO,SPESE_GENERALI,
				CONTRIBUTO_RICHIESTO,QUOTA_CONTRIBUTO_RICHIESTO,AMMESSO,ID_INVESTIMENTO_ORIGINALE,ID_VARIANTE,COD_VARIAZIONE
			FROM PIANO_INVESTIMENTI I LEFT JOIN DETTAGLIO_INVESTIMENTI D ON I.ID_DETTAGLIO_INVESTIMENTO=D.ID_DETTAGLIO_INVESTIMENTO
			WHERE ID_PROGETTO=@ID_PROGETTO_CORRELATO AND ID_VARIANTE=@ID_VARIANTE AND ISNULL(COD_VARIAZIONE,'X')!='A'
		END
		----------------------	
		DECLARE @COSTO_TOTALE_INVESTIMENTI DECIMAL(18,2),@SPESE_TOTALI DECIMAL(18,2),@COSTO_BREVETTI DECIMAL(18,2),@COSTO_POLIZZA DECIMAL(18,2),
			@MAX_SPESE_GENERALI DECIMAL(18,2),@AMMONTARE_DISPONIBILE DECIMAL(18,2),@CONTRIBUTO_BREVETTO DECIMAL(18,5)
				
		-- COSTO TOTALE DEGLI INVESTIMENTI
		SELECT @COSTO_TOTALE_INVESTIMENTI=SUM(COSTO_INVESTIMENTO),@SPESE_TOTALI=ROUND(SUM(CASE WHEN ISNULL(QUOTA_CONTRIBUTO_RICHIESTO,0)>0
			THEN (CONTRIBUTO_RICHIESTO/QUOTA_CONTRIBUTO_RICHIESTO*100)-COSTO_INVESTIMENTO ELSE 0 END),2)
		FROM @PIANO_INVESTIMENTI WHERE COD_TIPO_INVESTIMENTO=1
		
   		-- COSTO TOTALE DEI BREVETTI	
		SELECT @COSTO_BREVETTI=SUM(COSTO_INVESTIMENTO) FROM @PIANO_INVESTIMENTI
		WHERE COD_TIPO_INVESTIMENTO=5 AND ID_INVESTIMENTO!=@ID_INVESTIMENTO
		
		-- COSTO TOTALE POLIZZA
		SELECT @COSTO_POLIZZA=SUM(COSTO_INVESTIMENTO) FROM @PIANO_INVESTIMENTI WHERE COD_TIPO_INVESTIMENTO=4

		-- PERCENTUALE MAX SPESE GENERALI 
		SELECT @MAX_SPESE_GENERALI=ISNULL(QUOTA_MAX,100) FROM BANDO_TIPO_INVESTIMENTI
		WHERE ID_BANDO=@ID_DISP_ATTUATIVA AND COD_TIPO_INVESTIMENTO=6
		
		-- % SU COSTO TOTALE INVESTIMENTI - COSTO DEGLI ALTRI BREVETTI
		SET @AMMONTARE_DISPONIBILE=@COSTO_TOTALE_INVESTIMENTI/100*@MAX_QUOTA-ISNULL(@COSTO_BREVETTI,0)
		IF @AMMONTARE_DISPONIBILE<0 SET @AMMONTARE_DISPONIBILE=0
		IF @MAX_SPESE_GENERALI IS NOT NULL BEGIN
			DECLARE @RESTO DECIMAL(18,5)
			-- RIMANENTE DEI SOLDI CHE POSSONO ESSERE ATTRIBUITI ALLE SPESE DEL BREVETTO
			SET @RESTO=@COSTO_TOTALE_INVESTIMENTI/100*@MAX_SPESE_GENERALI-@SPESE_TOTALI-ISNULL(@COSTO_POLIZZA,0)			
			IF @RESTO<=0 SET @AMMONTARE_DISPONIBILE=0
			ELSE IF @AMMONTARE_DISPONIBILE>@RESTO SET @AMMONTARE_DISPONIBILE=@RESTO
		END
		
		DECLARE @COSTO_BREVETTO_CORRENTE DECIMAL(18,2)=0,@CONTRIBUTO_BREVETTO_CORRENTE DECIMAL(18,2)=0,@QUOTA_CONTRIBUTO DECIMAL(10,2)=0,
			@CONTRIBUTO_DISPONIBILE_MISURA DECIMAL(18,2),@COD_TRONCAMENTO CHAR(1),@ID_BREVETTO_ORIGINALE INT,
			@COSTO_NON_TRONCATO DECIMAL(18,2),@CONTRIBUTO_NON_TRONCATO DECIMAL(18,2)
		IF @AMMONTARE_DISPONIBILE>0 BEGIN		
			-- CALCOLO IL CONTRIBUTO MEDIO DA SPALMARE SUGLI INVESTIMENTI
			SELECT @CONTRIBUTO_BREVETTO=SUM((@AMMONTARE_DISPONIBILE*(COSTO_INVESTIMENTO/@COSTO_TOTALE_INVESTIMENTI))
				*QUOTA_CONTRIBUTO_RICHIESTO/100) FROM @PIANO_INVESTIMENTI WHERE COD_TIPO_INVESTIMENTO=1			
			-- CALCOLO LA % MEDIA DI CONTRIBUTO
			SET @QUOTA_CONTRIBUTO=ROUND(@CONTRIBUTO_BREVETTO/@AMMONTARE_DISPONIBILE*100,2)	
			
			-- COSTO BREVETTO CORRENTE
			SELECT @COSTO_BREVETTO_CORRENTE=COSTO_INVESTIMENTO,@ID_BREVETTO_ORIGINALE=ID_INVESTIMENTO_ORIGINALE
			FROM @PIANO_INVESTIMENTI WHERE ID_INVESTIMENTO=@ID_INVESTIMENTO
			IF @COSTO_BREVETTO_CORRENTE<0 BEGIN
				RAISERROR('Specificare un costo valido per l`investimento.',13,1)
				RETURN
			END
			IF @COSTO_BREVETTO_CORRENTE>@AMMONTARE_DISPONIBILE BEGIN
				SET @COSTO_NON_TRONCATO=@COSTO_BREVETTO_CORRENTE
				SET @COSTO_BREVETTO_CORRENTE=@AMMONTARE_DISPONIBILE
				SET @COD_TRONCAMENTO='Q' -- QUOTA MAX
			END
			SET @AMMONTARE_DISPONIBILE-=@COSTO_BREVETTO_CORRENTE			
			SET @CONTRIBUTO_BREVETTO_CORRENTE=ROUND(@QUOTA_CONTRIBUTO*@COSTO_BREVETTO_CORRENTE/100,2)
			
			-- CONTROLLO IL CONTRIBUTO DELL'INVESTIMENTO ORIGINALE
			IF @ID_BREVETTO_ORIGINALE IS NOT NULL BEGIN
				DECLARE @CONTRIBUTO_RICHIESTO DECIMAL(18,2)
				IF @FASE='IDOMANDA' OR (SELECT COUNT(*) FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE AND COD_TIPO IN ('AR','VI'))>0
					SELECT @CONTRIBUTO_RICHIESTO=CONTRIBUTO_RICHIESTO FROM PIANO_INVESTIMENTI WHERE ID_INVESTIMENTO=@ID_BREVETTO_ORIGINALE
				ELSE IF @FASE='IVARIANTE' AND (SELECT COUNT(*) FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE AND COD_TIPO IN ('AT','VA'))>0
					SELECT @CONTRIBUTO_RICHIESTO=dbo.controlloContributoInvestimentoRichiestoVariante(@ID_INVESTIMENTO)
				IF @CONTRIBUTO_BREVETTO_CORRENTE>@CONTRIBUTO_RICHIESTO BEGIN
					SET @CONTRIBUTO_NON_TRONCATO=@CONTRIBUTO_BREVETTO_CORRENTE
					SET @CONTRIBUTO_BREVETTO_CORRENTE=@CONTRIBUTO_RICHIESTO
					SET @COD_TRONCAMENTO='O' -- BREVETTO ORIGINALE
				END
			END
			
			-- CALCOLO IL CONTRIBUTO DISPONIBILE DI MISURA
			IF @ID_VARIANTE IS NULL OR (SELECT COUNT(*) FROM VARIANTI WHERE ID_VARIANTE=@ID_VARIANTE AND COD_TIPO='AR')>0
				SET @CONTRIBUTO_DISPONIBILE_MISURA=100000000
			ELSE SET @CONTRIBUTO_DISPONIBILE_MISURA=DBO.calcoloContributoRimanenteFinanziabileProgetto(@ID_PROGETTO_CORRELATO,
				@ID_VARIANTE,@ID_INVESTIMENTO)
			IF @CONTRIBUTO_BREVETTO_CORRENTE>@CONTRIBUTO_DISPONIBILE_MISURA BEGIN
				SET @CONTRIBUTO_NON_TRONCATO=@CONTRIBUTO_BREVETTO_CORRENTE
				SET @CONTRIBUTO_BREVETTO_CORRENTE=@CONTRIBUTO_DISPONIBILE_MISURA
				SET @COD_TRONCAMENTO='M' -- DOMANDA
			END
		END
		
		SELECT @COSTO_BREVETTO_CORRENTE AS COSTO_BREVETTO,@CONTRIBUTO_BREVETTO_CORRENTE AS CONTRIBUTO_BREVETTO,
			@QUOTA_CONTRIBUTO AS QUOTA_CONTRIBUTO,@AMMONTARE_DISPONIBILE AS AMMONTARE_DISPONIBILE,@COD_TRONCAMENTO AS COD_TRONCAMENTO,
			@COSTO_NON_TRONCATO AS COSTO_NON_TRONCATO,@CONTRIBUTO_NON_TRONCATO AS CONTRIBUTO_NON_TRONCATO
	END