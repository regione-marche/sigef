﻿CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDelete]
(
	@Id INT
)
AS
	DELETE PROGETTO_COMUNICAZIONI
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZProgettoComunicazioniDelete]
(
	@Id INT
)
AS
	DELETE PROGETTO_COMUNICAZIONI
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZProgettoComunicazioniDelete';
