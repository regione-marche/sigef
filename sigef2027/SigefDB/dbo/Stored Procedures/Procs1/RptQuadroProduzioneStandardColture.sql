﻿CREATE PROCEDURE [dbo].[RptQuadroProduzioneStandardColture]
(
	@ID_PROGETTO int, 
	@PREVISIONALE BIT	
)
AS
BEGIN	
--DECLARE	@ID_PROGETTO int=16523, 	@PREVISIONALE BIT=0, 	@AMMESSO BIT=0
	DECLARE @AMMESSO BIT =0
	IF(SELECT COD_STATO FROM vPROGETTO WHERE ID_PROGETTO = @ID_PROGETTO) != 'P' 
	SET @AMMESSO = 1 

	DECLARE @ID_PS INT, @ANNO INT
	SELECT @ID_PS = ID, @ANNO = ANNO FROM PRODUZIONE_STANDARD 
	WHERE ID_PROGETTO =@ID_PROGETTO and PREVISIONALE = @PREVISIONALE AND AMMESSO = @AMMESSO
	
		DECLARE @TMP_V TABLE (ID INT,ID_PS INT,COD_TIPO CHAR(1), COD_PRODOTTO CHAR(3), COD_VARIETA CHAR(3), SAU INT, PS_STANDARD DECIMAL(18,2), 
		QUOTA_TRASFORMATA DECIMAL(6,2), ID_TRASFORMAZIONE INT, PS_REALE DECIMAL(18,2), QUOTA_BIO DECIMAL(5,2),  QUOTA_QM DECIMAL(5,2), QUOTA_DOP DECIMAL(5,2), 
		PRODOTTO VARCHAR(255), VARIETA VARCHAR(255), PRODOTTO_ID_INEA INT, INEA_PREZZO DECIMAL(18,2), INEA_PREZZO_UNITARIO DECIMAL(18,2), 
		PRODUZIONE_UNITARIA DECIMAL(18,2), PRODOTTO_PRODUZIONE_UNITARIA DECIMAL(18,2), PRODOTTO_ORE INT, PRODOTTO_ULA_UNITA_MISURA VARCHAR(255), 
		ULA_TOTALE DECIMAL(18,2), 
		ULA_PRODUZIONE DECIMAL(18,2), ULA_TRASFORMAZIONE DECIMAL(18,2), ULA_COMMERCIALIZZAZIONE DECIMAL(18,2), QUOTA_TRASFORMAZIONE_PRODOTTO DECIMAL(18,2),
		QUOTA_VENDITA_PRODOTTO DECIMAL(18,2), 	QUOTA_TRASFORMAZIONE_VENDITA DECIMAL(18,2), COEFF_ULA_VENDITA DECIMAL(18,2), PS_STANDARD_QUALITA INT,
		QLM_300 BIT, ID_SOCIO INT		
		)  
		INSERT INTO @TMP_V 	
		exec SpPsrGetProduzioneStandard @ID_PS, 'V'
		
		IF((SELECT COUNT(*) FROM PRODUZIONE_STANDARD WHERE ID_PROGETTO = @ID_PROGETTO AND PREVISIONALE = @PREVISIONALE AND ANNO =@ANNO AND AMMESSO = @AMMESSO) >0)
		
			SELECT @ANNO AS ANNO, T.ID ,ID_PS ,COD_TIPO, COD_PRODOTTO , COD_VARIETA , DBO.MqAEttari(SAU) AS SAU ,PS_STANDARD , 
			ISNULL(QUOTA_TRASFORMATA, 0) AS QUOTA_TRASFORMATA, ID_TRASFORMAZIONE ,PS_REALE , QUOTA_BIO,  QUOTA_QM, QUOTA_DOP, 
			PRODOTTO, VARIETA, PRODOTTO_ID_INEA ,INEA_PREZZO , INEA_PREZZO_UNITARIO , PRODUZIONE_UNITARIA,
			PRODOTTO_PRODUZIONE_UNITARIA , PRODOTTO_ORE ,PRODOTTO_ULA_UNITA_MISURA, ULA_TOTALE , 
			ULA_PRODUZIONE , ULA_TRASFORMAZIONE , ULA_COMMERCIALIZZAZIONE , QUOTA_TRASFORMAZIONE_PRODOTTO ,
			QUOTA_VENDITA_PRODOTTO, QUOTA_TRASFORMAZIONE_VENDITA, T.COEFF_ULA_VENDITA, 
			QLM_300, CASE WHEN ID_SOCIO IS NOT NULL THEN '(*)' ELSE '' END AS ID_SOCIO, 
			P.DESCRIZIONE AS TRASFORMAZIONE, PS_STANDARD_QUALITA, 
			PS.MAN_CAP_AGRARIO, PS.MAN_CAP_FONDIARIO, PS.AMMINISTRAZIONE
			FROM PRODUZIONE_STANDARD PS 
			LEFT JOIN @TMP_V T ON T.ID_PS = PS.ID
			LEFT JOIN INEA_PRODUZIONE_STANDARD P ON T.ID_TRASFORMAZIONE = P.ID
			WHERE PS.ID_PROGETTO = @ID_PROGETTO AND PS.PREVISIONALE = @PREVISIONALE AND PS.ANNO =@ANNO AND PS.AMMESSO = @AMMESSO
	
		ELSE
		
			SELECT NULL AS ANNO, NULL AS ID , NULL AS ID_PS , NULL AS COD_TIPO, NULL AS COD_PRODOTTO , NULL AS COD_VARIETA , NULL AS SAU ,
			NULL AS PS_STANDARD , NULL AS QUOTA_TRASFORMATA , NULL AS ID_TRASFORMAZIONE ,
			NULL AS PS_REALE , NULL AS QUOTA_BIO, NULL AS  QUOTA_QM, NULL AS QUOTA_DOP, NULL AS PRODOTTO, 
			NULL AS VARIETA, NULL AS PRODOTTO_ID_INEA , NULL AS INEA_PREZZO , NULL AS INEA_PREZZO_UNITARIO , 
			NULL AS PRODUZIONE_UNITARIA, NULL AS PRODOTTO_PRODUZIONE_UNITARIA , NULL AS PRODOTTO_ORE , 
			NULL AS PRODOTTO_ULA_UNITA_MISURA, NULL AS ULA_TOTALE , NULL AS ULA_PRODUZIONE , 
			NULL AS ULA_TRASFORMAZIONE , NULL AS ULA_COMMERCIALIZZAZIONE , NULL AS QUOTA_TRASFORMAZIONE_PRODOTTO ,
			NULL AS QUOTA_VENDITA_PRODOTTO, NULL AS QUOTA_TRASFORMAZIONE_VENDITA, NULL AS COEFF_ULA_VENDITA, 
			NULL AS TRASFORMAZIONE, NULL AS PS_STANDARD_QUALITA, 
			NULL AS QLM_300, NULL AS ID_SOCIO, NULL AS MAN_CAP_AGRARIO, NULL AS MAN_CAP_FONDIARIO, NULL AS AMMINISTRAZIONE
	
END
