﻿CREATE PROCEDURE [dbo].[ZPianoDiSviluppoDelete]
(
	@IdPiano INT
)
AS
	DELETE PIANO_DI_SVILUPPO
	WHERE 
		(ID_PIANO = @IdPiano)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'

CREATE PROCEDURE [dbo].[ZPianoDiSviluppoDelete]
(
	@IdPiano INT
)
AS
	DELETE PIANO_DI_SVILUPPO
	WHERE 
		(ID_PIANO = @IdPiano)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPianoDiSviluppoDelete';
