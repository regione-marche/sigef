﻿CREATE PROCEDURE [dbo].[ZProgettoIndicatoriDelete]
(
	@IdProgettoIndicatori INT
)
AS
	DELETE PROGETTO_INDICATORI
	WHERE 
		(ID_PROGETTO_INDICATORI = @IdProgettoIndicatori)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoIndicatoriDelete';
