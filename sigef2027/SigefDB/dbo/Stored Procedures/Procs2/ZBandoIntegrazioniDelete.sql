﻿CREATE PROCEDURE [dbo].[ZBandoIntegrazioniDelete]
(
	@Id INT
)
AS
	DELETE BANDO_INTEGRAZIONI
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoIntegrazioniDelete]
(
	@Id INT
)
AS
	DELETE BANDO_INTEGRAZIONI
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoIntegrazioniDelete';
