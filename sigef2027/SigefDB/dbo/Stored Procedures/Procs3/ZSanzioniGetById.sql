CREATE PROCEDURE [dbo].[ZSanzioniGetById]
(
	@IdSanzione INT
)
AS
	SELECT *
	FROM vSANZIONI
	WHERE 
		(ID_SANZIONE = @IdSanzione)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZSanzioniGetById]
(
	@IdSanzione INT
)
AS
	SELECT *
	FROM vSANZIONI
	WHERE 
		(ID_SANZIONE = @IdSanzione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniGetById';

