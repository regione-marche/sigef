﻿CREATE PROCEDURE [dbo].[ZIstanzaChecklistGenericaGetById]
(
	@IdIstanzaGenerica INT
)
AS
	SELECT *
	FROM VISTANZA_CHECKLIST_GENERICA
	WHERE 
		(ID_ISTANZA_GENERICA = @IdIstanzaGenerica)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZIstanzaChecklistGenericaGetById';
