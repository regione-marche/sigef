﻿CREATE PROCEDURE [dbo].[ZQuadrodomandaDelete]
(
	@ID_QUADRO INT
)
AS
	DELETE QUADRO_DOMANDA
	WHERE 
		(ID_QUADRO = @ID_QUADRO)