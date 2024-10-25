CREATE PROCEDURE [dbo].[ZVariantiAllegatiGetById]
(
	@IdAllegato INT
)
AS
	SELECT *
	FROM vVARIANTI_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZVariantiAllegatiGetById]
(
	@IdAllegato INT
)
AS
	SELECT *
	FROM VARIANTI_ALLEGATI
	WHERE 
		(ID_ALLEGATO = @IdAllegato)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVariantiAllegatiGetById';

