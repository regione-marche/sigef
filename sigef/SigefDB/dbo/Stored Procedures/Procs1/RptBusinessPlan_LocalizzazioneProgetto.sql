﻿CREATE PROCEDURE [dbo].[RptBusinessPlan_LocalizzazioneProgetto]
@ID_Impresa int,
@ID_Domanda int
AS
BEGIN	

	SET NOCOUNT ON;
    	
	DECLARE @CUAA varchar(16)
    DECLARE @Count int
		
	IF (@ID_Domanda IS NOT NULL) BEGIN
	  SET @ID_Impresa = (SELECT ID_IMPRESA FROM PROGETTO WHERE ID_PROGETTO = @ID_Domanda)
	  SET @Count = (SELECT COUNT(ID_IMPRESA) FROM LOCALIZZAZIONE_PROGETTO WHERE ID_PROGETTO = @ID_Domanda)
	END
	ELSE  
		SET @Count = (SELECT COUNT(ID_IMPRESA) FROM LOCALIZZAZIONE_PROGETTO WHERE ID_IMPRESA = @ID_Impresa)
	
	IF (@Count > 0)		
	
		SELECT ID_LOCALIZZAZIONE, ID_PROGETTO, ID_IMPRESA, ID_COMUNE, CAP, DUG, VIA, NUM, 
			EFFETTO_SU_CONTRIBUTO, COMUNE_BELFIORE, COMUNE_DENOMINAZIONE, COMUNE_PROV_CODE, 
			COMUNE_PROV_SIGLA, COMUNE_ISTAT, CATASTO_ID, CATASTO_FOGLIO, CATASTO_PARTICELLA, 
			CATASTO_SEZIONE, CATASTO_SUBALTERNO, CATASTO_SUPERFICIE, D.Descrizione AS TIPO_VIA
		FROM vLOCALIZZAZIONE_PROGETTO L INNER JOIN TIPO_DUG D ON L.DUG = D.ID_DUG
		WHERE ID_PROGETTO = @ID_Domanda
	
	ELSE 
	
		SELECT  NULL AS ID_LOCALIZZAZIONE, 
		NULL AS ID_PROGETTO, 
		NULL AS ID_IMPRESA, 
		NULL AS ID_COMUNE, 
		NULL AS CAP, 
		NULL AS DUG, 
		NULL AS VIA, 
		NULL AS NUM, 
		NULL AS EFFETTO_SU_CONTRIBUTO, 
		NULL AS COMUNE_BELFIORE, 
		NULL AS COMUNE_DENOMINAZIONE, 
		NULL AS COMUNE_PROV_CODE, 
		NULL AS COMUNE_PROV_SIGLA, 
		NULL AS COMUNE_ISTAT, 
		NULL AS CATASTO_ID, 
		NULL AS CATASTO_FOGLIO, 
		NULL AS CATASTO_PARTICELLA, 
		NULL AS CATASTO_SEZIONE, 
		NULL AS CATASTO_SUBALTERNO, 
		NULL AS CATASTO_SUPERFICIE, 
		NULL AS TIPO_VIA
				
				
END