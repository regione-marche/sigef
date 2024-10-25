﻿-- =============================================

create FUNCTION [dbo].[calcoloTotaleContributoRendicontatoInvestimento] 
(
	@ID_INVESTIMENTO INT, 
	@ID_DOMANDA_PAGAMENTO INT
)
RETURNS DECIMAL(18,2)
AS
BEGIN
	DECLARE @CONTRIBUTO DECIMAL(18,2),@ID_INVESTIMENTO_ORIGINALE INT
	SELECT @CONTRIBUTO=SUM(Q1.CONTRIBUTO),@ID_INVESTIMENTO_ORIGINALE=ID_INVESTIMENTO_ORIGINALE 
	FROM PIANO_INVESTIMENTI I LEFT JOIN
	   (SELECT ID_INVESTIMENTO,SUM(ISNULL(CONTRIBUTO_AMMESSO,CONTRIBUTO_RICHIESTO)) AS CONTRIBUTO FROM PAGAMENTI_RICHIESTI P
		LEFT JOIN DOMANDA_DI_PAGAMENTO D ON P.ID_DOMANDA_PAGAMENTO=D.ID_DOMANDA_PAGAMENTO 
		WHERE D.ID_DOMANDA_PAGAMENTO=@ID_DOMANDA_PAGAMENTO OR (D.ID_DOMANDA_PAGAMENTO<@ID_DOMANDA_PAGAMENTO AND D.APPROVATA=1 AND D.ANNULLATA=0)
		GROUP BY ID_INVESTIMENTO) AS Q1 ON I.ID_INVESTIMENTO=Q1.ID_INVESTIMENTO
	WHERE I.ID_INVESTIMENTO=@ID_INVESTIMENTO GROUP BY ID_INVESTIMENTO_ORIGINALE
	IF (@ID_INVESTIMENTO_ORIGINALE IS NOT NULL) 
		SET @CONTRIBUTO=ISNULL(@CONTRIBUTO,0) + dbo.calcoloTotaleContributoRendicontatoInvestimento(@ID_INVESTIMENTO_ORIGINALE,@ID_DOMANDA_PAGAMENTO)
	RETURN ISNULL(@CONTRIBUTO,0)	
END
