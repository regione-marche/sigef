﻿CREATE PROCEDURE [dbo].[RptQuadroProduzioneStandardZootecnia]
(
	@ID_PROGETTO int, 
	@PREVISIONALE BIT
)
AS
BEGIN	

	DECLARE @AMMESSO BIT =0
	IF(SELECT COD_STATO FROM vPROGETTO WHERE ID_PROGETTO = @ID_PROGETTO) != 'P' 
	SET @AMMESSO = 1 

	DECLARE @ID_PS INT 
	SELECT @ID_PS = ID FROM PRODUZIONE_STANDARD 
	WHERE ID_PROGETTO =@ID_PROGETTO and PREVISIONALE = @PREVISIONALE AND AMMESSO = @AMMESSO
	 
		DECLARE @TMP_Z TABLE (ID INT, ID_PS INT, COD_TIPO CHAR(1), ALLEVAMENTI_DESCRIZIONE varchar(255), ID_CLASSE_ALLEVAMENTO INT, COD_EVET VARCHAR(10), NR_CAPI INT, 		
		PS_STANDARD DECIMAL(18,2), PS_REALE DECIMAL(18,2), QUOTA_TRASFORMATA DECIMAL(6,2), ID_TRASFORMAZIONE INT, 
		QUOTA_BIO DECIMAL(5,2),  QUOTA_QM DECIMAL(5,2), QUOTA_DOP DECIMAL(5,2),  INEA_PREZZO_UNITARIO DECIMAL(18,2), 
		PRODUZIONE_UNITARIA DECIMAL(18,2), ALLEVAMENTI_PRODUZIONE_UNITARIA DECIMAL(18,2), ALLEVAMENTI_ORE INT, ALLEVAMENTI_ULA_UNITA_MISURA VARCHAR(255), 
		ULA_TOTALE DECIMAL(18,2), 
		ULA_PRODUZIONE DECIMAL(18,2), ULA_TRASFORMAZIONE DECIMAL(18,2), ULA_COMMERCIALIZZAZIONE DECIMAL(18,2), QUOTA_TRASFORMAZIONE_PRODOTTO DECIMAL(18,2),
		QUOTA_VENDITA_PRODOTTO DECIMAL(18,2), 	QUOTA_TRASFORMAZIONE_VENDITA DECIMAL(18,2), COEFF_ULA_VENDITA DECIMAL(18,2),
		QLM_300 BIT, ID_SOCIO INT
		)  
		
		INSERT INTO @TMP_Z 	
		exec SpPsrGetProduzioneStandard @ID_PS, 'Z'
		
		IF((SELECT COUNT(*) FROM @TMP_Z) >0)
		
			SELECT t.ID, ID_PS, COD_TIPO, T.ALLEVAMENTI_DESCRIZIONE, T.ID_CLASSE_ALLEVAMENTO, T.COD_EVET, T.NR_CAPI, 		
			PS_STANDARD, PS_REALE, ISNULL(QUOTA_TRASFORMATA, 0) AS QUOTA_TRASFORMATA, ID_TRASFORMAZIONE, 
			QUOTA_BIO,  QUOTA_QM, QUOTA_DOP,  INEA_PREZZO_UNITARIO, 
			PRODUZIONE_UNITARIA, T.ALLEVAMENTI_PRODUZIONE_UNITARIA, T.ALLEVAMENTI_ORE, T.ALLEVAMENTI_ULA_UNITA_MISURA, 
			ULA_TOTALE, 
			ULA_PRODUZIONE, ULA_TRASFORMAZIONE, ULA_COMMERCIALIZZAZIONE, QUOTA_TRASFORMAZIONE_PRODOTTO,
			QUOTA_VENDITA_PRODOTTO, QUOTA_TRASFORMAZIONE_VENDITA, T.COEFF_ULA_VENDITA, 
			QLM_300, CASE WHEN ID_SOCIO IS NOT NULL THEN '(*)' ELSE '' END AS ID_SOCIO, 
			P.DESCRIZIONE AS TRASFORMAZIONE
			FROM @TMP_Z T
			LEFT JOIN INEA_PRODUZIONE_STANDARD P ON T.ID_TRASFORMAZIONE = P.ID
		
		ELSE 
		
			SELECT NULL AS ID , NULL AS  ID_PS , NULL AS  COD_TIPO , NULL AS ALLEVAMENTI_DESCRIZIONE, 
			NULL AS ID_CLASSE_ALLEVAMENTO , NULL AS COD_EVET, NULL AS NR_CAPI , 
			NULL AS PS_STANDARD , NULL AS  PS_REALE , NULL AS  QUOTA_TRASFORMATA , NULL AS  ID_TRASFORMAZIONE , 
			NULL AS QUOTA_BIO, NULL AS   QUOTA_QM, NULL AS  QUOTA_DOP, NULL AS   INEA_PREZZO_UNITARIO , 
			NULL AS PRODUZIONE_UNITARIA , NULL AS ALLEVAMENTI_PRODUZIONE_UNITARIA , NULL AS ALLEVAMENTI_ORE , 
			NULL AS ALLEVAMENTI_ULA_UNITA_MISURA, NULL AS ULA_TOTALE , 
			NULL AS ULA_PRODUZIONE , NULL AS  ULA_TRASFORMAZIONE , NULL AS  ULA_COMMERCIALIZZAZIONE , 
			NULL AS  QUOTA_TRASFORMAZIONE_PRODOTTO , NULL AS QUOTA_VENDITA_PRODOTTO , 
			NULL AS  	QUOTA_TRASFORMAZIONE_VENDITA , NULL AS COEFF_ULA_VENDITA, 
			NULL AS QLM_300, NULL AS ID_SOCIO
	
END