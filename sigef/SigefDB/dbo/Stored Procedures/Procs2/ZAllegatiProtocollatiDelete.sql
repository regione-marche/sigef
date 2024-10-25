CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiDelete]
(
	@IdAllegatoProtocollato INT
)
AS
	DELETE ALLEGATI_PROTOCOLLATI
	WHERE 
		(ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollato)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiDelete]
(
	@IdAllegatoProtocollato INT
)
AS
	DELETE ALLEGATI_PROTOCOLLATI
	WHERE 
		(ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollato)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiProtocollatiDelete';

