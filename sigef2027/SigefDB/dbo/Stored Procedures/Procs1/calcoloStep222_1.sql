﻿CREATE PROCEDURE [dbo].[calcoloStep222_1]
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
	
DECLARE @Result int,
		@CODIFICA_AB decimal,
		@CODICE_INVESTIMENTO varchar(1),
		
		@COSTO_INVESTIMENTO_CORRENTE decimal,
		@ETTARI decimal,
		@TIPOLOGIA_SPECIE int,
		@ID_INVESTIMENTO_CORRENTE int,
		@NUMERO_PIANTE int,
		
		
		@ID_FASCICOLO INT, 
		@CUAA VARCHAR(16),
		@DATA_VALIDITA DATETIME,
		@ID_IMPRESA INT, 
		@COUNT_SUP_NON_CORRETTA INT,
		
		@RESULTATO decimal

SET @RESULT = 1 -- PONGO LO STEP IN STATO VERIFICATO

-- bando id 384
-- codifiche investimento a b 

--- //// Rispetto massimali per tipologia di impianto //// ----

-- id priorità: 1181 - Quota LAVORI IN ECONOMIA (€) -- numeroco livello inv
-- Numero piante -- la prendo dall'investimento campo QUANTITA
-- id priorità: 1185 - Ettari da piano colturale (m2) -- numeroco livello inv

--  Tipologia specie  - id priorità: 1180 -->  (livello investimento - plurivalore)
	-- id_valore priorita: 1151 - Arboree - codice: 1
	-- id_valore priorita: 1152	- Arbustive- codice: 2

--- Costo massimo ammissibile per tipologia di impianto
--- Codifica a --> max 2000€/Ha -- min 50ha -- max 100ha -- verifico il costo in proporzione agli attari  (solo arboree)

--- Codifica b --> max 3000€/Ha -- (min 50ha -- max 100ha --> se arboree)  -- verifico il costo in proporzione agli attari
--- Codifica b --> max 3000€/Ha -- (min 100ha -- max 200ha --> se arbustive)  -- verifico il costo in proporzione agli attari


-------------------
DECLARE @COSTO_TIP1 DECIMAL(18,2), @QUANTITA_TIP1 INT, @MQ_TIP1 DECIMAL(18,2), @MAX_SPESA_TIP1 DECIMAL(18,2), @MAX_PIANTE_TIP1 DECIMAL(18,2), @MIN_PIANTE_TIP1 DECIMAL(18,2)
DECLARE @COSTO_TIP2_ARBOREE DECIMAL(18,2), @QUANTITA_TIP2_ARBOREE INT, @MQ_TIP2_ARBOREE DECIMAL(18,2), @MAX_SPESA_TIP2_ARBOREE DECIMAL(18,2), @MAX_PIANTE_TIP2_ARBOREE  DECIMAL(18,2), @MIN_PIANTE_TIP2_ARBOREE  DECIMAL(18,2)
DECLARE @COSTO_TIP2_ARBUSTIVE DECIMAL(18,2), @QUANTITA_TIP2_ARBUSTIVE INT, @MQ_TIP2_ARBUSTIVE DECIMAL(18,2), @MAX_SPESA_TIP2_ARBUSTIVE DECIMAL(18,2), @MAX_PIANTE_TIP2_ARBUSTIVE DECIMAL(18,2), @MIN_PIANTE_TIP2_ARBUSTIVE DECIMAL(18,2)

--- tip1

	SELECT @COSTO_TIP1 = SUM(VPI.COSTO_INVESTIMENTO) --  VPI.ID_INVESTIMENTO, VPI.CODIFICA_INVESTIMENTO, VP.CODICE  AS TIPOLOGIA_SPECIE , PXI.VALORE AS NUMERO_PIANTE, VPI.QUANTITA
	FROM vPIANO_INVESTIMENTI AS VPI 
			INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1180
			INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE = VP.ID_VALORE
	WHERE
			VPI.COD_TIPO_INVESTIMENTO = 1 AND
			((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
			 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
			AND
			VPI.CODICE = 1 AND -- CODICE CODIFICA
			VP.CODICE = 1 AND --- CODICE VALORE PRIORITA' TITPOLOGIA IMPIANTO
			VPI.ID_PROGETTO = @IdProgetto


	IF (@COSTO_TIP1 >0)
	BEGIN
		SELECT @QUANTITA_TIP1 = VPI.QUANTITA, @MQ_TIP1 = PXI.VALORE FROM vPIANO_INVESTIMENTI AS VPI INNER JOIN DETTAGLIO_INVESTIMENTI DI ON VPI.ID_DETTAGLIO_INVESTIMENTO = DI.ID_DETTAGLIO_INVESTIMENTO
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1185
		WHERE
				VPI.COD_TIPO_INVESTIMENTO = 1 AND
				((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
				 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
				AND
				VPI.CODICE = '1' AND -- CODICE CODIFICA
				DI.COD_DETTAGLIO = 'a' AND
				VPI.ID_PROGETTO = @IdProgetto
				ORDER BY VPI.QUANTITA
							
				SET @MAX_SPESA_TIP1 = (2000 *(@MQ_TIP1/10000)) -- MAX SPESA SU TOTALE ETTARI INSERITI
				SET @MAX_PIANTE_TIP1 = (100 * (@MQ_TIP1/10000)) -- MAX PIANTE IN BASE AGLI ETTARI INSERITI
				SET @MIN_PIANTE_TIP1 = (50 * (@MQ_TIP1/10000)) -- MIN PIANTE IN BASE AGLI ETTARI INSERITI
				
			 IF ((@COSTO_TIP1 > @MAX_SPESA_TIP1) OR ((@QUANTITA_TIP1 < @MIN_PIANTE_TIP1) or (@QUANTITA_TIP1 > @MAX_PIANTE_TIP1))
			 ) SET @RESULT = 0
	END

-- tip2 ARBOREE

	SELECT @COSTO_TIP2_ARBOREE = SUM(VPI.COSTO_INVESTIMENTO) --  VPI.ID_INVESTIMENTO, VPI.CODIFICA_INVESTIMENTO, VP.CODICE  AS TIPOLOGIA_SPECIE , PXI.VALORE AS NUMERO_PIANTE, VPI.QUANTITA
	FROM vPIANO_INVESTIMENTI AS VPI 
			INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1180  -- tipologia
			INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE = VP.ID_VALORE
	WHERE
			VPI.COD_TIPO_INVESTIMENTO = 1 AND
			((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
			 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
			AND
			VPI.CODICE = '2' AND -- CODICE CODIFICA
			VP.CODICE = '1' AND --- CODICE VALORE PRIORITA' TIPOLOGIA IMPIANTO
			VPI.ID_PROGETTO = @IdProgetto
		    


	IF (@COSTO_TIP2_ARBOREE >0)
	BEGIN
		SELECT @QUANTITA_TIP2_ARBOREE = VPI.QUANTITA, @MQ_TIP2_ARBOREE = PXI.VALORE 
		FROM vPIANO_INVESTIMENTI AS VPI 
				INNER JOIN DETTAGLIO_INVESTIMENTI DI ON VPI.ID_DETTAGLIO_INVESTIMENTO = DI.ID_DETTAGLIO_INVESTIMENTO
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1185 -- Ettari MQ
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI_T ON PXI_T.ID_INVESTIMENTO = VPI.ID_INVESTIMENTO AND PXI_T.ID_PRIORITA = 1180
				INNER JOIN VALORI_PRIORITA AS VP ON PXI_T.ID_VALORE = VP.ID_VALORE
		WHERE
				VPI.COD_TIPO_INVESTIMENTO = 1 AND
				((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
				 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
				AND
				VPI.CODICE = '2' AND -- CODICE CODIFICA
				DI.COD_DETTAGLIO = 'a' AND
				VP.CODICE = '1' AND -- TIPOLOGIA IMPIANTO
				VPI.ID_PROGETTO = @IdProgetto
				ORDER BY VPI.QUANTITA		
			
				SET @MAX_SPESA_TIP2_ARBOREE  = (2000 *(@MQ_TIP2_ARBOREE/10000)) -- MAX SPESA SU TOTALE ETTARI INSERITI
				SET @MAX_PIANTE_TIP2_ARBOREE  = (100 * (@MQ_TIP2_ARBOREE/10000)) -- MAX PIANTE IN BASE AGLI ETTARI INSERITI
				SET @MIN_PIANTE_TIP2_ARBOREE  = (50 * (@MQ_TIP2_ARBOREE/10000)) -- MIN PIANTE IN BASE AGLI ETTARI INSERITI
				
			 IF ((@COSTO_TIP2_ARBOREE > @MAX_SPESA_TIP2_ARBOREE ) OR ((@QUANTITA_TIP2_ARBOREE < @MIN_PIANTE_TIP2_ARBOREE) or (@QUANTITA_TIP2_ARBOREE > @MAX_PIANTE_TIP2_ARBOREE))
			 ) SET @RESULT = 0
				
	END



-- tip2 ARBUSTIVE

	SELECT @COSTO_TIP2_ARBUSTIVE = SUM(VPI.COSTO_INVESTIMENTO)
	FROM vPIANO_INVESTIMENTI AS VPI 
			INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1180  -- tipologia
			INNER JOIN VALORI_PRIORITA AS VP ON PXI.ID_VALORE = VP.ID_VALORE
	WHERE
			VPI.COD_TIPO_INVESTIMENTO = 1 AND
			((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
			 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
			AND
			VPI.CODICE = '2' AND -- CODICE CODIFICA
			VP.CODICE = '2' AND --- CODICE VALORE PRIORITA' TIPOLOGIA IMPIANTO
			VPI.ID_PROGETTO = @IdProgetto
	    


	IF (@COSTO_TIP2_ARBUSTIVE >0)
	BEGIN
		SELECT @QUANTITA_TIP2_ARBUSTIVE = VPI.QUANTITA, @MQ_TIP2_ARBUSTIVE = PXI.VALORE 
		FROM vPIANO_INVESTIMENTI AS VPI 
				INNER JOIN DETTAGLIO_INVESTIMENTI DI ON VPI.ID_DETTAGLIO_INVESTIMENTO = DI.ID_DETTAGLIO_INVESTIMENTO
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI ON VPI.ID_INVESTIMENTO = PXI.ID_INVESTIMENTO AND ID_PRIORITA =  1185 -- Ettari MQ
				INNER JOIN PRIORITA_X_INVESTIMENTI AS PXI_T ON PXI_T.ID_INVESTIMENTO = VPI.ID_INVESTIMENTO AND PXI_T.ID_PRIORITA = 1180
				INNER JOIN VALORI_PRIORITA AS VP ON PXI_T.ID_VALORE = VP.ID_VALORE
		WHERE
				VPI.COD_TIPO_INVESTIMENTO = 1 AND
				((VPI.ID_INVESTIMENTO_ORIGINALE IS NULL AND @FASE_ISTRUTTORIA=0 AND ID_VARIANTE IS NULL) OR
				 (VPI.ID_INVESTIMENTO_ORIGINALE IS NOT NULL AND @FASE_ISTRUTTORIA =1 AND ID_VARIANTE IS NULL)) 
				AND
				VPI.CODICE = '2' AND -- CODICE CODIFICA
				DI.COD_DETTAGLIO = 'a' AND
				VP.CODICE = '2' AND -- TIPOLOGIA IMPIANTO
				VPI.ID_PROGETTO = @IdProgetto
				ORDER BY VPI.QUANTITA
				 
			 	SET @MAX_SPESA_TIP2_ARBUSTIVE  = (3000 *(@MQ_TIP2_ARBUSTIVE/10000)) -- MAX SPESA SU TOTALE ETTARI INSERITI
				SET @MAX_PIANTE_TIP2_ARBUSTIVE  = (200 * (@MQ_TIP2_ARBUSTIVE/10000)) -- MAX PIANTE IN BASE AGLI ETTARI INSERITI
				SET @MIN_PIANTE_TIP2_ARBUSTIVE  = (100 * (@MQ_TIP2_ARBUSTIVE/10000)) -- MIN PIANTE IN BASE AGLI ETTARI INSERITI
				
			 IF ((@COSTO_TIP2_ARBUSTIVE > @MAX_SPESA_TIP2_ARBUSTIVE ) OR ((@QUANTITA_TIP2_ARBUSTIVE < @MIN_PIANTE_TIP2_ARBUSTIVE) or (@QUANTITA_TIP2_ARBUSTIVE > @MAX_PIANTE_TIP2_ARBUSTIVE))
			 ) SET @RESULT = 0
			 
				
	END

SELECT @RESULT
END
