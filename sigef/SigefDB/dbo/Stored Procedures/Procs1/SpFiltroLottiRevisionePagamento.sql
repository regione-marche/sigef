﻿CREATE PROCEDURE [dbo].[SpFiltroLottiRevisionePagamento]
(
	@ID_BANDO INT,
	@ID_PROGETTO INT,
	@COD_TIPO_PAGAMENTO CHAR(3) = NULL
)
AS
	/*
	DECLARE @ID_BANDO INT,@ID_PROGETTO INT,@COD_PROVINCIA CHAR(2),@COD_TIPO_PAGAMENTO CHAR(3)
	SET @ID_BANDO=131
	SET @ID_PROGETTO=324
	SET @COD_TIPO_PAGAMENTO='SAL'
	*/

	--RITORNO IL LOTTO TROVATO
	SELECT TOP 1 L.ID_LOTTO 
	FROM LOTTO_DI_REVISIONE L 
		JOIN CTE_TESTATA_VALIDAZIONE R ON L.ID_LOTTO = R.ID_LOTTO
		JOIN DOMANDA_DI_PAGAMENTO D ON R.ID_DOMANDA_PAGAMENTO = D.ID_DOMANDA_PAGAMENTO
	WHERE 1 = 1
		AND L.ID_BANDO = @ID_BANDO 
		AND D.ID_PROGETTO = @ID_PROGETTO 
		AND (@COD_TIPO_PAGAMENTO IS NULL OR D.COD_TIPO = @COD_TIPO_PAGAMENTO)
GO


