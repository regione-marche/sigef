﻿CREATE PROCEDURE [dbo].[ZIndirizzoGetById]
(
	@ID_INDIRIZZO INT
)
AS
	SELECT *
	FROM INDIRIZZO
	WHERE 
		(ID_INDIRIZZO = @ID_INDIRIZZO)
