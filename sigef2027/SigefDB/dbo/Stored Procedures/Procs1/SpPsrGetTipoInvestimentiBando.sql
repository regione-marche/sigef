﻿CREATE PROCEDURE [dbo].[SpPsrGetTipoInvestimentiBando]
(
	@ID_BANDO INT
)
AS
	SELECT T.COD_TIPO_INVESTIMENTO,DESCRIZIONE,URL,[TEXT],ID_TIPO_INVESTIMENTO,ID_BANDO,IMPORTO_MAX,IMPORTO_MIN,
		QUOTA_MAX,NOTE,PREMIO 
	FROM TIPO_INVESTIMENTO T
	LEFT JOIN BANDO_TIPO_INVESTIMENTI B ON T.COD_TIPO_INVESTIMENTO = B.COD_TIPO_INVESTIMENTO AND B.ID_BANDO=@ID_BANDO