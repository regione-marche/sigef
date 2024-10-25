﻿CREATE PROCEDURE [dbo].[SpGetSegnatureDomandaPagamento]
(
	@ID_PROGETTO INT
)
AS
	SELECT @ID_PROGETTO AS ID_PROGETTO,Q1.*,U.NOMINATIVO,U.PROVINCIA,U.ID_PROFILO,U.PROFILO,U.COD_ENTE,U.ENTE 
	FROM (
		SELECT ID_DOMANDA_PAGAMENTO,D.COD_TIPO,CASE WHEN D.SEGNATURA IS NULL THEN 'Avvio lavorazione' ELSE 'Presentazione' END +' domanda di '+T.DESCRIZIONE AS TIPO_SEGNATURA,SEGNATURA,
			DATA_MODIFICA AS DATA,CF_OPERATORE AS OPERATORE,NULL AS MOTIVAZIONE,APPROVATA AS RIAPRI_DOMANDA
		FROM DOMANDA_DI_PAGAMENTO D INNER JOIN TIPO_DOMANDA_PAGAMENTO T ON D.COD_TIPO=T.COD_TIPO WHERE ID_PROGETTO=@ID_PROGETTO
		UNION ALL
		SELECT ID_DOMANDA_PAGAMENTO,D.COD_TIPO,TIPO_SEGNATURA=CASE WHEN APPROVATA=1 THEN 'Approvazione domanda di '+T.DESCRIZIONE 
			ELSE 'Bocciatura domanda di '+T.DESCRIZIONE END,SEGNATURA_APPROVAZIONE AS SEGNATURA,DATA_APPROVAZIONE AS DATA,
			CF_ISTRUTTORE AS OPERATORE,NULL AS MOTIVAZIONE,APPROVATA AS RIAPRI_DOMANDA 
		FROM DOMANDA_DI_PAGAMENTO D INNER JOIN TIPO_DOMANDA_PAGAMENTO T ON D.COD_TIPO=T.COD_TIPO
		WHERE ID_PROGETTO=@ID_PROGETTO AND APPROVATA IS NOT NULL
		UNION ALL
		SELECT D.ID_DOMANDA_PAGAMENTO,S.COD_TIPO,TIPO_SEGNATURA=CASE WHEN S.COD_TIPO='APP' THEN (CASE WHEN RIAPRI_DOMANDA=1 THEN 'Approvazione' 
			ELSE 'Bocciatura' END)+' domanda di '+ (SELECT DESCRIZIONE FROM DOMANDA_DI_PAGAMENTO D1 INNER JOIN TIPO_DOMANDA_PAGAMENTO T1 
			ON D1.COD_TIPO=T1.COD_TIPO WHERE D1.ID_DOMANDA_PAGAMENTO=S.ID_DOMANDA_PAGAMENTO) ELSE TS.DESCRIZIONE END,S.SEGNATURA,DATA,OPERATORE,
			MOTIVAZIONE,RIAPRI_DOMANDA 
		FROM DOMANDA_DI_PAGAMENTO D INNER JOIN DOMANDA_DI_PAGAMENTO_SEGNATURE S ON D.ID_DOMANDA_PAGAMENTO=S.ID_DOMANDA_PAGAMENTO
		INNER JOIN TIPO_SEGNATURA TS ON S.COD_TIPO=TS.COD_TIPO WHERE ID_PROGETTO=@ID_PROGETTO) AS Q1
	INNER JOIN vUTENTI U ON Q1.OPERATORE=U.CF_UTENTE ORDER BY ID_DOMANDA_PAGAMENTO DESC,DATA DESC
