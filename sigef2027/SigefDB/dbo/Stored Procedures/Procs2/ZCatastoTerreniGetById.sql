﻿CREATE PROCEDURE [dbo].[ZCatastoTerreniGetById]
(
	@IdCatasto INT
)
AS
	SELECT *
	FROM vCATASTO
	WHERE 
		(ID_CATASTO = @IdCatasto)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCatastoTerreniGetById]
(
	@IdCatasto INT
)
AS
	SELECT *
	FROM vCATASTO
	WHERE 
		(ID_CATASTO = @IdCatasto)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCatastoTerreniGetById';
