﻿CREATE PROCEDURE [dbo].[ZCollaboratoriXManifestazioneGetById]
(
	@IdCollaboratore INT
)
AS
	SELECT *
	FROM vCOLLABORATORI_X_MANIFESTAZIONE
	WHERE 
		(ID_COLLABORATORE = @IdCollaboratore)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCollaboratoriXManifestazioneGetById';
