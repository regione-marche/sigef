﻿CREATE   PROCEDURE [dbo].[calcoloStepMF_5] 
(
@IdProgetto int,
@FASE_ISTRUTTORIA INT =0
)
AS
BEGIN
---- CONTROLLO quantita 
DECLARE @ID_MANIFESTAZIONE int

-- @IdProgetto INT, @FASE_ISTRUTTORIA INT  , 
-- set @IdProgetto= 5684
-- SET @FASE_ISTRUTTORIA  =0

DECLARE @RESULT INT , @COD_SETTORE CHAR(3), @COD_FILIERA VARCHAR(10), @QUANT decimal(18,2)

SET @RESULT =1 --PONGO LO STEP  VERIFICATO
SET @ID_MANIFESTAZIONE = (SELECT ID_VALORE FROM PRIORITA_X_PROGETTO WHERE ID_PROGETTO = @IdProgetto AND ID_PRIORITA in ( 374,406)) 
SET @COD_FILIERA = (SELECT VP.CODICE FROM PRIORITA_X_PROGETTO pp inner join VALORI_PRIORITA VP ON VP.ID_VALORE = PP.ID_VALORE WHERE ID_PROGETTO =  @IdProgetto AND PP.ID_PRIORITA in ( 374,406) )
SET @COD_SETTORE=(SELECT CODICE FROM PRIORITA_X_PROGETTO PP INNER JOIN VALORI_PRIORITA VP ON PP.id_valore =VP.id_valore WHERE PP.ID_PRIORITA = 397 AND ID_PROGETTO =  @IdProgetto  )
 
 -- tonnellate per -	Settore cerealicolo;
--Settore latte bovino;
--Settore prodotti biologici.

IF(@COD_SETTORE IN ('CER','LAB','PRB'))
BEGIN
SET @QUANT =( 
			SELECT SUM(ISNULL( PRODUZIONE_IN_FILIERA,0)) AS PRODUZIONE_IN_FILIERA
			FROM (SELECT I.CUAA, RAGIONE_SOCIALE, 
						'PRODUZIONE_TOTALE'= CASE WHEN COD_PRODOTTO IS NOT NULL THEN  ISNULL(SUM(isnull(PRODUZIONE_UNITARIA,0) * SAU/10000),0)
												WHEN  ID_CLASSE_ALLEVAMENTO IS NOT NULL  THEN  ISNULL(SUM(isnull(PRODUZIONE_UNITARIA,0) * SAU),0) 
												WHEN  ID_ATTIVITA_CONNESSA IS NOT NULL  THEN ISNULL( SAU,0)	END,
										 ISNULL(PRODUZIONE_IN_FILIERA,0) AS PRODUZIONE_IN_FILIERA, PLV AS PLV_TOTALE, ISNULL(PLV_FILIERA,0)   AS PLV_FILIERA
					FROM vPROGETTO  AS P 
						INNER JOIN VIMPRESA AS I ON I.ID_IMPRESA = P.ID_IMPRESA
						INNER JOIN  PRIORITA_X_PROGETTO AS PP ON PP.ID_PROGETTO = P.ID_PROGETTO AND ID_PRIORITA in (374,406) AND ID_VALORE =@ID_MANIFESTAZIONE  LEFT OUTER JOIN
						 (SELECT MIN(PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO) AS ID_PROGETTO_VALIDATO, AMMESSO 
						  FROM PARTECIPANTI_X_FILIERA
							   INNER JOIN PROGETTO ON PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO = PROGETTO.ID_PROGETTO
							   INNER JOIN PLV_IMPRESA ON PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO = PLV_IMPRESA.ID_PROGETTO  
						  WHERE (PARTECIPANTI_X_FILIERA.COD_FILIERA = @COD_FILIERA )  AND  PLV_IMPRESA.PRODUZIONE_IN_FILIERA > 0 AND AMMESSO = 1
						  GROUP BY PROGETTO.ID_IMPRESA,   AMMESSO  ) AS PxF ON P.ID_PROGETTO = PxF.ID_PROGETTO_VALIDATO INNER JOIN
						 (SELECT PREVISIONALE,  ID_PROGETTO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, ID_ATTIVITA_CONNESSA, 
								 CASE WHEN ID_UNITA_MISURA = 6 THEN PRODUZIONE_UNITARIA/1000
									  WHEN ID_UNITA_MISURA = 7 THEN PRODUZIONE_UNITARIA/10
									  WHEN ID_UNITA_MISURA = 26 THEN PRODUZIONE_UNITARIA/1000000
									  WHEN ID_UNITA_MISURA = 18 THEN PRODUZIONE_UNITARIA*1.03/1000
									 ELSE  PRODUZIONE_UNITARIA END AS  PRODUZIONE_UNITARIA, PRODUZIONE_IN_FILIERA, 
									 PREZZO_UNITARIO, PLV, PLV_FILIERA,  SAU , CUAA_TRASFORMATORE  
							FROM PLV_IMPRESA  )AS  PLV  ON P.ID_PROGETTO = PLV.ID_PROGETTO
							WHERE PxF.AMMESSO = 1 AND P.ID_PROGETTO !=  @IdProgetto  AND PREVISIONALE=1 AND COD_STATO IN('L','I','A','F') 
			GROUP BY  P.ID_PROGETTO, i.CUAA , RAGIONE_SOCIALE , COD_PRODOTTO,ID_CLASSE_ALLEVAMENTO,ID_ATTIVITA_CONNESSA, SAU, PRODUZIONE_IN_FILIERA, PLV,PLV_FILIERA) AS B)
END 
ELSE 
BEGIN
	IF(@COD_SETTORE IN ('CSU','CBO'))
	BEGIN
	SET @QUANT  =( 
		SELECT SUM(ISNULL( numero_capi,0)) AS PRODUZIONE_IN_FILIERA
		FROM (SELECT p.ID_IMPRESA , SUM(numero_capi) numero_capi
			   FROM  vPROGETTO AS P   
					INNER JOIN PRIORITA_X_PROGETTO AS PP ON PP.ID_PROGETTO = P.ID_PROGETTO AND ID_PRIORITA in (374,406) AND ID_VALORE =@ID_MANIFESTAZIONE  
					LEFT OUTER JOIN (SELECT MIN(PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO) AS ID_PROGETTO_VALIDATO, AMMESSO 
									 FROM PARTECIPANTI_X_FILIERA 
										INNER JOIN PROGETTO ON PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO = PROGETTO.ID_PROGETTO
										INNER JOIN PLV_IMPRESA ON PARTECIPANTI_X_FILIERA.ID_PROGETTO_VALIDATO = PLV_IMPRESA.ID_PROGETTO  
									  WHERE (PARTECIPANTI_X_FILIERA.COD_FILIERA = @COD_FILIERA )  AND  PLV_IMPRESA.PRODUZIONE_IN_FILIERA > 0 AND AMMESSO = 1
									  GROUP BY PROGETTO.ID_IMPRESA , AMMESSO) AS PxF ON P.ID_PROGETTO = PxF.ID_PROGETTO_VALIDATO 
					INNER JOIN( SELECT PREVISIONALE,  ID_PROGETTO, COD_VARIETA, COD_PRODOTTO, ID_CLASSE_ALLEVAMENTO, ID_MATERIA_PRIMA, ID_UNITA_MISURA, ID_ATTIVITA_CONNESSA, 
									   isnull(PRODUZIONE_IN_FILIERA,0)/isnull(PRODUZIONE_UNITARIA,1) as numero_capi,PREZZO_UNITARIO, PLV, PLV_FILIERA,  SAU , CUAA_TRASFORMATORE  
								FROM PLV_IMPRESA WHERE  PREVISIONALE = 1 AND PRODUZIONE_IN_FILIERA >0 )AS  PLV  ON P.ID_PROGETTO = PLV.ID_PROGETTO
					WHERE PxF.AMMESSO = 1 AND P.ID_PROGETTO !=  @IdProgetto  AND PREVISIONALE=1 aND COD_STATO IN('L','I','A','F') 
					GROUP BY  P.ID_PROGETTO,   P.ID_IMPRESA,  COD_PRODOTTO,ID_CLASSE_ALLEVAMENTO,ID_ATTIVITA_CONNESSA, SAU,  numero_capi) AS B)
		END
	END

-- numero capi
--select @QUANT
 
	IF(ISNULL(@COD_SETTORE,'0') ='0' ) SET @RESULT =0
	ELSE
		BEGIN
		IF( @COD_SETTORE= 'CBO') BEGIN IF( @QUANT<3000  ) SET @RESULT =0 END
		ELSE BEGIN
			 IF( @COD_SETTORE= 'CER') BEGIN  IF( @QUANT< 50000  ) SET @RESULT =0 END
			 ELSE BEGIN IF( @COD_SETTORE= 'CSU') BEGIN  IF( @QUANT<30000  ) SET @RESULT =0 END 
			 ELSE BEGIN  IF( @COD_SETTORE= 'LAB') BEGIN  IF( @QUANT<8000  ) SET @RESULT =0 END  
			 ELSE BEGIN IF( @COD_SETTORE= 'PRB') BEGIN  IF( @QUANT<10000  ) SET @RESULT =0 END 
			END
		END
	END
END
END
SELECT @RESULT AS RESULT
END