﻿CREATE PROCEDURE [dbo].[ZQuadrodomandaFindFind]
(
	@ID_QUADROEQUALTHIS INT
)
AS
	SELECT * 
	FROM QUADRO_DOMANDA
	WHERE 
		((@ID_QUADROEQUALTHIS IS NULL) OR ID_QUADRO = @ID_QUADROEQUALTHIS)
