﻿CREATE PROCEDURE [dbo].[ZImpresaStoricoDelete]
(
	@IdStoricoImpresa INT
)
AS
	DELETE IMPRESA_STORICO
	WHERE 
		(ID_STORICO_IMPRESA = @IdStoricoImpresa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZImpresaStoricoDelete]
(
	@IdStoricoImpresa INT
)
AS
	DELETE IMPRESA_STORICO
	WHERE 
		(ID_STORICO_IMPRESA = @IdStoricoImpresa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZImpresaStoricoDelete';
