CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoDelete]
(
	@IdEstrazioneIo INT
)
AS
	DELETE zDIMENSIONI_ESTRAZIONI_IO
	WHERE 
		(ID_ESTRAZIONE_IO = @IdEstrazioneIo)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZZdimensioniEstrazioniIoDelete]
(
	@IdEstrazione INT
)
AS
	DELETE zDIMENSIONI_ESTRAZIONI_IO
	WHERE 
		(ID_ESTRAZIONE = @IdEstrazione)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZZdimensioniEstrazioniIoDelete';

