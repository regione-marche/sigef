﻿/* SI POTREBBE UTILIZZARE QUELLA PER GLI STEP AGGIUNGENDO L'ID VARIANTE */
CREATE PROCEDURE [dbo].[SpExecPrioritaQuerySql]
(
	@NOME NVARCHAR(3000),
	@ID_PROGETTO INT,
	@ID_VARIANTE INT=NULL,
	@FASE_ISTRUTTORIA bit
)
AS
	DECLARE @TESTO_QUERY NVARCHAR(MAX)
	IF LEN(@NOME)<101
		SELECT @TESTO_QUERY=TESTO FROM zQUERY_SQL WHERE NOME=@NOME
	IF @TESTO_QUERY IS NOT NULL 
		EXEC sp_executesql @TESTO_QUERY,N'@IdProgetto INT,@IdVariante INT,@fase_istruttoria bit',@ID_PROGETTO,@ID_VARIANTE,@FASE_ISTRUTTORIA
	ELSE 
		EXEC sp_executesql @NOME,N'@IdProgetto INT,@IdVariante INT,@fase_istruttoria bit',@ID_PROGETTO,@ID_VARIANTE,@FASE_ISTRUTTORIA