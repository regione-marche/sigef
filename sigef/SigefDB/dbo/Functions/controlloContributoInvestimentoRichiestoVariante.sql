﻿CREATE FUNCTION [dbo].[controlloContributoInvestimentoRichiestoVariante]
(
	@ID_INVESTIMENTO INT
)
RETURNS DECIMAL(18,2)
AS BEGIN
	DECLARE @CONTRIBUTO_IN_PRESENTAZIONE DECIMAL(18,2)
	SELECT TOP 1 @CONTRIBUTO_IN_PRESENTAZIONE=CONTRIBUTO_RICHIESTO FROM PIANO_INVESTIMENTI_BK_VARIANTE 
	WHERE ID_INVESTIMENTO=@ID_INVESTIMENTO ORDER BY DATA DESC
	RETURN @CONTRIBUTO_IN_PRESENTAZIONE
END