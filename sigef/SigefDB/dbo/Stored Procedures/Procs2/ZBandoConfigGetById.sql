﻿CREATE PROCEDURE [dbo].[ZBandoConfigGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vBANDO_CONFIG
	WHERE 
		(ID = @Id)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoConfigGetById]
(
	@Id INT
)
AS
	SELECT *
	FROM vBANDO_CONFIG
	WHERE 
		(ID = @Id)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoConfigGetById';
