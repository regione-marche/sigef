﻿CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaGetById]
(
	@IdParagrafo INT
)
AS
	SELECT *
	FROM BANDO_RELAZIONE_TECNICA
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZBandoRelazioneTecnicaGetById]
(
	@IdParagrafo INT
)
AS
	SELECT *
	FROM BANDO_RELAZIONE_TECNICA
	WHERE 
		(ID_PARAGRAFO = @IdParagrafo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoRelazioneTecnicaGetById';
