﻿CREATE PROCEDURE [dbo].[SpPsrGetTipoInvestimentiProgetto]
(
	@ID_BANDO INT,
	@MOSTRA_TUTTI BIT
)
AS
	IF @MOSTRA_TUTTI=1 BEGIN
		DECLARE @DISP_ATT TABLE (CODICE VARCHAR(30),DESCRIZIONE VARCHAR(500),MISURA_PREVALENTE BIT,ID_DISPOSIZIONI_ATTUATIVE INT,ID_PROGETTO INT)
		INSERT INTO @DISP_ATT
		EXEC SpPsrGetDispAttuativeBando @ID_BANDO
		
		SELECT DISTINCT T.* FROM @DISP_ATT D INNER JOIN BANDO_TIPO_INVESTIMENTI I ON D.ID_DISPOSIZIONI_ATTUATIVE=I.ID_BANDO
		INNER JOIN TIPO_INVESTIMENTO T ON I.COD_TIPO_INVESTIMENTO=T.COD_TIPO_INVESTIMENTO
	END
	ELSE 		
		SELECT DISTINCT T.* FROM BANDO_TIPO_INVESTIMENTI I INNER JOIN TIPO_INVESTIMENTO T ON I.COD_TIPO_INVESTIMENTO=T.COD_TIPO_INVESTIMENTO
		WHERE I.ID_BANDO=@ID_BANDO