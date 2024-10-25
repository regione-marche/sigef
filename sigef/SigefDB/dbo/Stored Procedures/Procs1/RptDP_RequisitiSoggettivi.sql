
create PROCEDURE [dbo].[RptDP_RequisitiSoggettivi]
@IdDomandaPagamento int	
AS
BEGIN	

IF (SELECT COUNT(*) FROM vDOMANDA_REQUISITI_PAGAMENTO 
				INNER JOIN DOMANDA_DI_PAGAMENTO DP 
				ON vDOMANDA_REQUISITI_PAGAMENTO.ID_DOMANDA_PAGAMENTO = DP.ID_DOMANDA_PAGAMENTO 
               INNER JOIN PROGETTO P ON DP.ID_PROGETTO = P.ID_PROGETTO 
               INNER JOIN vBANDO_REQUISITI_PAGAMENTO ON DP.COD_TIPO = vBANDO_REQUISITI_PAGAMENTO.COD_TIPO AND 
               vDOMANDA_REQUISITI_PAGAMENTO.ID_REQUISITO = vBANDO_REQUISITI_PAGAMENTO.ID_REQUISITO 
               AND vBANDO_REQUISITI_PAGAMENTO.ID_BANDO = P.ID_BANDO
               WHERE vDOMANDA_REQUISITI_PAGAMENTO.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND REQUISITO_DI_INSERIMENTO = 1) > 0
BEGIN

SELECT  vzPROGRAMMAZIONE.CODICE, vzPROGRAMMAZIONE.DESCRIZIONE, DRP.URL, vBANDO_REQUISITI_PAGAMENTO.ID_REQUISITO, 
               vBANDO_REQUISITI_PAGAMENTO.REQUISITO, DRP.VAL_NUMERICO, 
               CONVERT(VARCHAR(10), DRP.VAL_DATA, 103) AS VAL_DATA, 
               DRP.VAL_TESTO, DRP.CODICE_VALORE, 
               DRP.DESCRIZIONE_VALORE, 
               CASE WHEN vBANDO_REQUISITI_PAGAMENTO.OBBLIGATORIO = 1 THEN 'SI' 
						WHEN vBANDO_REQUISITI_PAGAMENTO.OBBLIGATORIO = 0 THEN 'NO' ELSE '' END AS OBBLIGATORIO , 
               DRP.SELEZIONATO
FROM     vDOMANDA_REQUISITI_PAGAMENTO DRP 
				INNER JOIN DOMANDA_DI_PAGAMENTO DP ON DRP.ID_DOMANDA_PAGAMENTO = DP.ID_DOMANDA_PAGAMENTO 
				INNER JOIN PROGETTO P ON DP.ID_PROGETTO = P.ID_PROGETTO
				INNER JOIN vBANDO_REQUISITI_PAGAMENTO ON DP.COD_TIPO = vBANDO_REQUISITI_PAGAMENTO.COD_TIPO AND 
									DRP.ID_REQUISITO = vBANDO_REQUISITI_PAGAMENTO.ID_REQUISITO AND vBANDO_REQUISITI_PAGAMENTO.ID_BANDO = P.ID_BANDO 
               INNER JOIN vBANDO ON P.ID_BANDO = vBANDO.ID_BANDO 
               INNER JOIN  vzPROGRAMMAZIONE ON vBANDO.ID_PROGRAMMAZIONE = vzPROGRAMMAZIONE.ID
WHERE  (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_7
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.NUMERICO = 1) AND 
               (DRP.VAL_NUMERICO IS NOT NULL) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_6
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_6
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.VAL_DATA IS NOT NULL) AND 
               (DRP.DATETIME = 1) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_5
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_5
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.VAL_TESTO IS NOT NULL) AND 
               (DRP.TESTO_SEMPLICE IS NOT NULL) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_4
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_4
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.VAL_TESTO IS NOT NULL) AND 
               (DRP.TESTO_AREA IS NOT NULL) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_3
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_3
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.URL IS NOT NULL) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_2
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_2
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.PLURIVALORE IS NOT NULL) AND 
               (DRP.ID_VALORE IS NOT NULL) OR
               (DRP.ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento) AND (vBANDO_REQUISITI_PAGAMENTO.REQUISITO_DI_INSERIMENTO = 1) AND 
               (vBANDO.ID_BANDO =
                   (SELECT  ID_BANDO
                    FROM     PROGETTO AS P_1
                    WHERE  (ID_PROGETTO =
                                       (SELECT  ID_PROGETTO
                                        FROM     vDOMANDA_DI_PAGAMENTO AS vDP_1
                                        WHERE  (ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento))))) AND (DRP.NUMERICO = 0) AND 
               (DRP.VAL_NUMERICO IS NULL) AND (DRP.VAL_DATA IS NULL) AND (DRP.DATETIME = 0) AND 
               (DRP.VAL_TESTO IS NULL) AND (DRP.TESTO_SEMPLICE = 0) AND (DRP.TESTO_AREA = 0) AND 
               (DRP.URL IS NULL) AND (DRP.PLURIVALORE = 0) AND (DRP.ID_VALORE IS NULL) AND 
               (DRP.SELEZIONATO = 1)
GROUP BY vzPROGRAMMAZIONE.CODICE, vzPROGRAMMAZIONE.DESCRIZIONE, vBANDO_REQUISITI_PAGAMENTO.ID_REQUISITO, vBANDO_REQUISITI_PAGAMENTO.REQUISITO, 
               DRP.VAL_NUMERICO, DRP.VAL_DATA, DRP.VAL_TESTO, 
               DRP.CODICE_VALORE, DRP.DESCRIZIONE_VALORE, vBANDO_REQUISITI_PAGAMENTO.OBBLIGATORIO, 
               DRP.URL, DRP.SELEZIONATO
ORDER BY vzPROGRAMMAZIONE.CODICE
		
	END
ELSE 
	BEGIN
		
		 SELECT NULL AS  CODICE, 
			NULL AS DESCRIZIONE, 
			NULL AS URL, 
			NULL AS ID_REQUISITO, 
            'Nessun requisito selezionato.' AS REQUISITO, 
            NULL AS VAL_NUMERICO, 
            NULL AS VAL_DATA, 
            NULL AS VAL_TESTO, 
            NULL AS CODICE_VALORE, 
            NULL AS DESCRIZIONE_VALORE, 
            NULL AS OBBLIGATORIO, 
            NULL AS SELEZIONATO
	END
END

