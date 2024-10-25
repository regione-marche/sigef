﻿
CREATE PROCEDURE [dbo].[RptDp_Allegati]
@IdDomandaPagamento int, 
@Cod_Tipo char(1) -- FORMATO DOCUMENTO
AS
BEGIN	
	
SET NOCOUNT ON;
                                
	select ID_ALLEGATO, A.DESCRIZIONE, T.DESCRIZIONE AS DESCRIZIONE_DOCUMENTO, A.NUMERO, A.DATA, 
	ISNULL(E.DESCRIZIONE, 'Comune di ' + C.DENOMINAZIONE) AS ENTE, A.COD_ENTE_EMETTITORE, 
	ES.DESCRIZIONE AS ESITO_ALLEGATO, A.NOTE_ISTRUTTORE
	from DOMANDA_PAGAMENTO_ALLEGATI A
	INNER JOIN TIPO_DOCUMENTO T ON A.COD_TIPO_DOCUMENTO = T.CODICE
	LEFT JOIN ENTE E ON A.COD_ENTE_EMETTITORE = E.COD_ENTE
	LEFT JOIN COMUNI C ON A.ID_COMUNE = C.ID_COMUNE
	LEFT JOIN ESITI_STEP ES ON A.COD_ESITO = ES.COD_ESITO
	WHERE ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento AND
		((@Cod_Tipo = 'D' AND T.FORMATO IN ('D', 'C')) OR (@Cod_Tipo = 'S' AND T.FORMATO = 'S'))
		    
END