﻿CREATE PROCEDURE [dbo].[ZBandoValutatoriDelete]
(
	@IdValutatore INT
)
AS
	DELETE BANDO_VALUTATORI
	WHERE 
		(ID_VALUTATORE = @IdValutatore)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZBandoValutatoriDelete]
(
	@IdValutatore INT
)
AS
	DELETE BANDO_VALUTATORI
	WHERE 
		(ID_VALUTATORE = @IdValutatore)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoValutatoriDelete';
