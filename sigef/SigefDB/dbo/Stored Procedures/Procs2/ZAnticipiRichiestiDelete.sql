CREATE PROCEDURE [dbo].[ZAnticipiRichiestiDelete]
(
	@IdAnticipo INT
)
AS
	DELETE ANTICIPI_RICHIESTI
	WHERE 
		(ID_ANTICIPO = @IdAnticipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZAnticipiRichiestiDelete]
(
	@IdAnticipo INT
)
AS
	DELETE ANTICIPI_RICHIESTI
	WHERE 
		(ID_ANTICIPO = @IdAnticipo)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAnticipiRichiestiDelete';

