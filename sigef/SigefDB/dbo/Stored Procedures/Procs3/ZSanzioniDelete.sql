CREATE PROCEDURE [dbo].[ZSanzioniDelete]
(
	@IdSanzione INT
)
AS
	DELETE SANZIONI
	WHERE 
		(ID_SANZIONE = @IdSanzione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSanzioniDelete]
(
	@IdSanzione INT
)
AS
	DELETE SANZIONI
	WHERE 
		(ID_SANZIONE = @IdSanzione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniDelete';

