﻿CREATE PROCEDURE [dbo].[SpGetGiustificativiDomandaPagamento]
(
	@ID_DOMANDA_PAGAMENTO INT,
	@NUMERO VARCHAR(30)=NULL,
	@DATA DATETIME=NULL
)
AS
	SELECT DISTINCT G.* FROM GIUSTIFICATIVI G INNER JOIN SPESE_SOSTENUTE S ON G.ID_GIUSTIFICATIVO=S.ID_GIUSTIFICATIVO
	WHERE ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO AND (@NUMERO IS NULL OR NUMERO=@NUMERO)
		AND (@DATA IS NULL OR G.DATA=@DATA)