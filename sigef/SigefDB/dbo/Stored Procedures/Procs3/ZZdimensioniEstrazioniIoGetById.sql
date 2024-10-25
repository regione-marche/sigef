CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoGetById]
(
	@IdEstrazioneIo INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_ESTRAZIONI_IO
	WHERE 
		(ID_ESTRAZIONE_IO = @IdEstrazioneIo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoGetById]
(
	@IdEstrazione INT
)
AS
	SELECT *
	FROM vzDIMENSIONI_ESTRAZIONI
	WHERE 
		(ID_ESTRAZIONE = @IdEstrazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoGetById';

