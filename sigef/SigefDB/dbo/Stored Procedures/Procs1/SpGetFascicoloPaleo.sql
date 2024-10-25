﻿CREATE PROCEDURE [dbo].[SpGetFascicoloPaleo]
(
	@COD_TIPO VARCHAR(30),
	@COD_ENTE VARCHAR(10),
	@ANNO INT=NULL,
	@PROVINCIA CHAR(2)=NULL	
)
AS
	IF @PROVINCIA IS NOT NULL AND @PROVINCIA NOT IN ('AN', 'PU','MC' ,'AP','FM') SET @PROVINCIA=NULL
	SELECT TOP 1 FASCICOLO FROM FASCICOLO_PALEO WHERE COD_TIPO=@COD_TIPO AND COD_ENTE=@COD_ENTE
		AND ATTIVO=1 AND (@ANNO IS NULL OR ANNO=@ANNO) AND (@PROVINCIA IS NULL OR PROVINCIA=@PROVINCIA)
