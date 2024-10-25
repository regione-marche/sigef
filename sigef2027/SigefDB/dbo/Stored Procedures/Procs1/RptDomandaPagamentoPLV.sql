﻿CREATE PROCEDURE [dbo].[RptDomandaPagamentoPLV] 
@ID_Domanda int,
@TipoPLV int
AS
BEGIN
	SET NOCOUNT ON;
    	
DECLARE @Count int
DECLARE @CountPac int
DECLARE @AnnoPresentazione int 
DECLARE @FLAG_DEFINITIVO BIT, @DATA_ULTIMA_MODIFICA DATETIME

	SELECT @FLAG_DEFINITIVO = FLAG_DEFINITIVO FROM PROGETTO p WHERE P.ID_PROGETTO = @ID_Domanda 
	IF (@FLAG_DEFINITIVO = 1) set @DATA_ULTIMA_MODIFICA = (SELECT DATA FROM PROGETTO_STORICO WHERE ID_PROGETTO = @ID_Domanda AND COD_STATO = 'L')
	ELSE SET @DATA_ULTIMA_MODIFICA = GETDATE()	
	
	IF (SELECT COUNT(DISTINCT ANNO)   FROM PLV_IMPRESA WHERE ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0) >= 2
		SELECT @AnnoPresentazione = MAX(ANNO) FROM PLV_IMPRESA WHERE ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0
	ELSE SELECT @AnnoPresentazione = MIN(ANNO) FROM PLV_IMPRESA WHERE  ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0 AND (ANNO > YEAR(@DATA_ULTIMA_MODIFICA) OR ANNO = YEAR(GETDATE()))

		
	IF (@ID_Domanda IS NOT NULL) SET @Count = (SELECT COUNT(ID_PLV) FROM vPLV_AZIENDALE WHERE ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione)     					
	ELSE SET @Count = (SELECT COUNT(ID_PLV) FROM PLV_IMPRESA WHERE ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0 	AND ANNO = @AnnoPresentazione )

	IF (@Count > 0)
	 BEGIN
	
		IF (@TipoPLV = 0) -- Plv Piano Colturale					 
			   
				BEGIN
			     SELECT PLVA.PRODOTTO,PLVA.VARIETA, ANNO, 
                      dbo.MqAEttari(PLVA.SAU) AS SAU,
                      ISNULL(PLVA.RESA_COLTURA,0) AS RESA_COLTURA,
                      ISNULL(PLVA.PRODUZIONE_UNITARIA,0) AS PRODUZIONE_UNITARIA,
			          ISNULL(PLVA.QUANTITA_REIMPIEGO,0) AS QUANTITA_REIMPIEGO, 
                      ISNULL(PLVA.PREZZO_COLTURA,0) AS PREZZO_COLTURA,
                      ISNULL(PLVA.PREZZO_UNITARIO_ALLEVAMENTI,0) AS PREZZO_UNITARIO_ALLEVAMENTI,
                      ISNULL(PLVA.PREZZO_ATTIVITA_CONNESSE,0) AS PREZZO_ATTIVITA_CONNESSE, 
                      ISNULL(PLVA.PREZZO_UNITARIO,0) AS PREZZO_UNITARIO,
					  UM.DESCRIZIONE AS UNITA_MISURA,
					  ISNULL(PLVA.PLV,0) AS PLV,
                      ISNULL(PLVA.ORE_UNITARIE,0) AS ORE_UNITARIE,
                      ISNULL(PLVA.ORE_COLTURA,0) AS ORE_COLTURA,
			          PLVA.ATTIVITA_CONNESSA,                       
			          PLVA.PAC,
					  PLVA.FLAG_BIOLOGICO,
					  PLVA.FLAG_ZONASVANTAGGIATA,
					  PLVA.FLAG_COMMERCIALIZZAZIONE,
					  PLVA.FLAG_TRASFORMAZIONE,
					  PLVA.CLASSE_ALLEVAMENTO,
					  PLVA.PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      ISNULL(PLVA.ORE_ALLEVAMENTI,0) AS ORE_ALLEVAMENTI,
					  dbo.MqAEttari((SELECT SUM(SAU) 
									FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA) 
									WHERE ID_PROGETTO = @ID_Domanda AND COD_PRODOTTO IS NOT NULL 
									AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione)) AS TOT_SAU

			   FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA)

			   WHERE ID_PROGETTO = @ID_Domanda AND COD_PRODOTTO IS NOT NULL
                     AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione
				END
		
		ELSE IF (@TipoPLV = 1) -- Plv Zootecnica		
			
			BEGIN
				   SELECT PLVA.PRODOTTO,PLVA.VARIETA, 
                      ISNULL(PLVA.SAU, 0) AS SAU,
                      ISNULL(PLVA.RESA_COLTURA,0) AS RESA_COLTURA,
                      ISNULL(PLVA.PRODUZIONE_UNITARIA,0) AS PRODUZIONE_UNITARIA,
			          ISNULL(PLVA.QUANTITA_REIMPIEGO,0) AS QUANTITA_REIMPIEGO, 
                      ISNULL(PLVA.PREZZO_COLTURA,0) AS PREZZO_COLTURA,
                      ISNULL(PLVA.PREZZO_UNITARIO_ALLEVAMENTI,0) AS PREZZO_UNITARIO_ALLEVAMENTI,
                      ISNULL(PLVA.PREZZO_ATTIVITA_CONNESSE,0) AS PREZZO_ATTIVITA_CONNESSE, 
                      ISNULL(PLVA.PREZZO_UNITARIO,0) AS PREZZO_UNITARIO,
					  UM.DESCRIZIONE AS UNITA_MISURA,
					  ISNULL(PLVA.PLV,0) AS PLV,
                      ISNULL(PLVA.ORE_UNITARIE,0) AS ORE_UNITARIE,
                      ISNULL(PLVA.ORE_COLTURA,0) AS ORE_COLTURA,
			          PLVA.ATTIVITA_CONNESSA,                       
			          PLVA.PAC,
					  PLVA.FLAG_BIOLOGICO,
					  PLVA.FLAG_ZONASVANTAGGIATA,
					  PLVA.FLAG_COMMERCIALIZZAZIONE,
					  PLVA.FLAG_TRASFORMAZIONE,
					  PLVA.CLASSE_ALLEVAMENTO,
					  PLVA.PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      ISNULL(PLVA.ORE_ALLEVAMENTI,0) AS ORE_ALLEVAMENTI,
					  dbo.MqAEttari((SELECT SUM(SAU) 
									FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA) 
									WHERE ID_PROGETTO = @ID_Domanda AND COD_PRODOTTO IS NOT NULL 
									AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione)) AS TOT_SAU

			   FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA)

			   WHERE ID_PROGETTO = @ID_Domanda AND ID_CLASSE_ALLEVAMENTO IS NOT NULL
                     AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione
			END
		   
		   ELSE IF (@TipoPLV = 2)  -- Plv Attività connesse	
		   	   
			    SELECT PLVA.PRODOTTO,PLVA.VARIETA, 
                      dbo.MqAEttari(PLVA.SAU) AS SAU,
                      ISNULL(PLVA.RESA_COLTURA,0) AS RESA_COLTURA,
                      ISNULL(PLVA.PRODUZIONE_UNITARIA,0) AS PRODUZIONE_UNITARIA,
			          ISNULL(PLVA.QUANTITA_REIMPIEGO,0) AS QUANTITA_REIMPIEGO, 
                      ISNULL(PLVA.PREZZO_COLTURA,0) AS PREZZO_COLTURA,
                      ISNULL(PLVA.PREZZO_UNITARIO_ALLEVAMENTI,0) AS PREZZO_UNITARIO_ALLEVAMENTI,
                      ISNULL(PLVA.PREZZO_ATTIVITA_CONNESSE,0) AS PREZZO_ATTIVITA_CONNESSE, 
                      ISNULL(PLVA.PREZZO_UNITARIO,0) AS PREZZO_UNITARIO,
					  UM.DESCRIZIONE AS UNITA_MISURA,
					  ISNULL(PLVA.PLV,0) AS PLV,
                      ISNULL(PLVA.ORE_UNITARIE,0) AS ORE_UNITARIE,
                      ISNULL(PLVA.ORE_COLTURA,0) AS ORE_COLTURA,
			          PLVA.ATTIVITA_CONNESSA,                       
			          PLVA.PAC,
					  PLVA.FLAG_BIOLOGICO,
					  PLVA.FLAG_ZONASVANTAGGIATA,
					  PLVA.FLAG_COMMERCIALIZZAZIONE,
					  PLVA.FLAG_TRASFORMAZIONE,
					  PLVA.CLASSE_ALLEVAMENTO,
					  PLVA.PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      ISNULL(PLVA.ORE_ALLEVAMENTI,0) AS ORE_ALLEVAMENTI,
					  dbo.MqAEttari((SELECT SUM(SAU) 
									FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA) 
									WHERE ID_PROGETTO = @ID_Domanda AND COD_PRODOTTO IS NOT NULL 
									AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione)) AS TOT_SAU

			   FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA)

			   WHERE ID_PROGETTO = @ID_Domanda AND ID_ATTIVITA_CONNESSA IS NOT NULL AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione
			
		  
  		   ELSE IF (@TipoPLV = 3)  -- Contributi P.A.C.	

			BEGIN
			 SET @CountPac = (SELECT COUNT(ID_PLV) FROM vPLV_AZIENDALE WHERE ID_PROGETTO = @ID_Domanda AND PREVISIONALE = 0 AND  CODICE_PAC IS NOT NULL 	AND ANNO = @AnnoPresentazione )						

			IF (@CountPac > 0)
	 		
			    SELECT PLVA.PRODOTTO,PLVA.VARIETA, 
                      dbo.MqAEttari(PLVA.SAU) AS SAU,
                      ISNULL(PLVA.RESA_COLTURA,0) AS RESA_COLTURA,
                      ISNULL(PLVA.PRODUZIONE_UNITARIA,0) AS PRODUZIONE_UNITARIA,
			          ISNULL(PLVA.QUANTITA_REIMPIEGO,0) AS QUANTITA_REIMPIEGO, 
                      ISNULL(PLVA.PREZZO_COLTURA,0) AS PREZZO_COLTURA,
                      ISNULL(PLVA.PREZZO_UNITARIO_ALLEVAMENTI,0) AS PREZZO_UNITARIO_ALLEVAMENTI,
                      ISNULL(PLVA.PREZZO_ATTIVITA_CONNESSE,0) AS PREZZO_ATTIVITA_CONNESSE, 
                      ISNULL(PLVA.PREZZO_UNITARIO,0) AS PREZZO_UNITARIO,
					  UM.DESCRIZIONE AS UNITA_MISURA,
					  ISNULL(PLVA.PLV,0) AS PLV,
                      ISNULL(PLVA.ORE_UNITARIE,0) AS ORE_UNITARIE,
                      ISNULL(PLVA.ORE_COLTURA,0) AS ORE_COLTURA,
			          PLVA.ATTIVITA_CONNESSA,                       
			          PLVA.PAC,
					  PLVA.FLAG_BIOLOGICO,
					  PLVA.FLAG_ZONASVANTAGGIATA,
					  PLVA.FLAG_COMMERCIALIZZAZIONE,
					  PLVA.FLAG_TRASFORMAZIONE,
					  PLVA.CLASSE_ALLEVAMENTO,
					  PLVA.PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      ISNULL(PLVA.ORE_ALLEVAMENTI,0) AS ORE_ALLEVAMENTI,
					  dbo.MqAEttari((SELECT SUM(SAU) 
									FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA) 
									WHERE ID_PROGETTO = @ID_Domanda AND COD_PRODOTTO IS NOT NULL 
									AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione)) AS TOT_SAU

			   FROM vPLV_AZIENDALE PLVA LEFT JOIN UNITA_DI_MISURA UM ON (PLVA.ID_UNITA_MISURA = UM.ID_UNITA_MISURA)
			
			   WHERE ID_PROGETTO = @ID_Domanda AND PLVA.CODICE_PAC IS NOT NULL  AND PREVISIONALE = 0 AND ANNO = @AnnoPresentazione
				
			ELSE
				    SELECT     CODICI_PAC.CODICE_PAC, 
                            CODICI_PAC.DESCRIZIONE AS PAC, 
							NULL AS PRODOTTO,
                            NULL AS VARIETA,
                            NULL AS SAU,
							NULL AS RESA_COLTURA,
                            NULL AS PRODUZIONE_UNITARIA,
							NULL AS QUANTITA_REIMPIEGO, 
                            NULL AS PREZZO_COLTURA,
							NULL AS PREZZO_UNITARIO_ALLEVAMENTI,
                            NULL AS PREZZO_ATTIVITA_CONNESSE, 
							NULL AS PREZZO_UNITARIO,
							NULL AS UNITA_MISURA,                            
							0 AS PLV, 
                            NULL AS ORE_UNITARIE ,
                            NULL AS CLASSE_ALLEVAMENTO,  							
							NULL AS ATTIVITA_CONNESSA

					FROM  CODICI_PAC 
			END

		  
	   ELSE  
	   SELECT NULL AS PRODOTTO,
					  NULL AS VARIETA, 
                      NULL AS SAU,
                      NULL AS RESA_COLTURA,
                      NULL AS PRODUZIONE_UNITARIA,
			          NULL AS QUANTITA_REIMPIEGO, 
                      NULL AS PREZZO_COLTURA,
                      NULL AS PREZZO_UNITARIO_ALLEVAMENTI,
                      NULL AS PREZZO_ATTIVITA_CONNESSE, 
                      NULL AS PREZZO_UNITARIO,
					  NULL AS UNITA_MISURA,
					  NULL AS PLV,
                      NULL AS ORE_UNITARIE,
                      NULL AS ORE_COLTURA,
			          NULL AS ATTIVITA_CONNESSA,                       
			          NULL AS PAC,
					  NULL AS FLAG_BIOLOGICO,
					  NULL AS FLAG_ZONASVANTAGGIATA,
					  NULL AS FLAG_COMMERCIALIZZAZIONE,
					  NULL AS FLAG_TRASFORMAZIONE,
					  NULL AS CLASSE_ALLEVAMENTO,
					  NULL AS PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      NULL AS ORE_ALLEVAMENTI
	 END	
	 ELSE 	

	   SELECT NULL AS PRODOTTO,
					  NULL AS VARIETA, 
                      NULL AS SAU,
                      NULL AS RESA_COLTURA,
                      NULL AS PRODUZIONE_UNITARIA,
			          NULL AS QUANTITA_REIMPIEGO, 
                      NULL AS PREZZO_COLTURA,
                      NULL AS PREZZO_UNITARIO_ALLEVAMENTI,
                      NULL AS PREZZO_ATTIVITA_CONNESSE, 
                      NULL AS PREZZO_UNITARIO,
					  NULL AS UNITA_MISURA,
					  NULL AS PLV,
                      NULL AS ORE_UNITARIE,
                      NULL AS ORE_COLTURA,
			          NULL AS ATTIVITA_CONNESSA,                       
			          NULL AS PAC,
					  NULL AS FLAG_BIOLOGICO,
					  NULL AS FLAG_ZONASVANTAGGIATA,
					  NULL AS FLAG_COMMERCIALIZZAZIONE,
					  NULL AS FLAG_TRASFORMAZIONE,
					  NULL AS CLASSE_ALLEVAMENTO,
					  NULL AS PRODUZIONE_UNITARIA_ALLEVAMENTI,
                      NULL AS ORE_ALLEVAMENTI



END
