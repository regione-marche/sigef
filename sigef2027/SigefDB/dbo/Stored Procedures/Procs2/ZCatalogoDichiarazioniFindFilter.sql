﻿CREATE PROCEDURE [dbo].[ZCatalogoDichiarazioniFindFilter]
(
	@MISURA VARCHAR(25),
	@DESCRIZIONE VARCHAR(250)
)
AS
SELECT *
FROM CATALOGO_DICHIARAZIONI
WHERE
	(@MISURA IS NULL OR MISURA = @MISURA)
	AND
	(@DESCRIZIONE IS NULL OR DESCRIZIONE LIKE '%' + @DESCRIZIONE + '%')