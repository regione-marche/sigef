﻿CREATE PROCEDURE [dbo].[ZIndirizzoFindFind]
(
	@ID_INDIRIZZOEQUALTHIS INT, 
	@ID_COMUNEEQUALTHIS INT, 
	@VIALIKETHIS VARCHAR(500)
)
AS
	SELECT * 
	FROM INDIRIZZO
	WHERE 
		((@ID_INDIRIZZOEQUALTHIS IS NULL) OR ID_INDIRIZZO = @ID_INDIRIZZOEQUALTHIS) AND 
		((@ID_COMUNEEQUALTHIS IS NULL) OR ID_COMUNE = @ID_COMUNEEQUALTHIS) AND 
		((@VIALIKETHIS IS NULL) OR VIA LIKE @VIALIKETHIS)