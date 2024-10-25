﻿

CREATE PROCEDURE dbo.SpPsrGetDPagamentoSpesaXMisura
(
	@ID_DOMANDA_PAGAMENTO INT
)
AS
	SELECT R.TIPO+' '+R.CODICE AS MISURA,E.MISURA_PREVALENTE,E.IMPORTO_AMMESSO
	FROM DOMANDA_DI_PAGAMENTO_ESPORTAZIONE E INNER JOIN PROGETTO P ON E.ID_PROGETTO=P.ID_PROGETTO
	INNER JOIN BANDO B ON P.ID_BANDO=B.ID_BANDO INNER JOIN vzPROGRAMMAZIONE R ON B.ID_PROGRAMMAZIONE=R.ID 
	WHERE E.ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO ORDER BY MISURA_PREVALENTE DESC,R.TIPO+' '+R.CODICE

