﻿CREATE PROCEDURE [dbo].[ZQuadrodomandaUpdate]
(
	@ID_QUADRO INT, 
	@DENOMINAZIONE VARCHAR(70), 
	@DESCRIZIONE VARCHAR(500), 
	@METODO_REPORT VARCHAR(50)
)
AS
	UPDATE QUADRO_DOMANDA
	SET
		DENOMINAZIONE = @DENOMINAZIONE, 
		DESCRIZIONE = @DESCRIZIONE, 
		METODO_REPORT = @METODO_REPORT
	WHERE 
		(ID_QUADRO = @ID_QUADRO)