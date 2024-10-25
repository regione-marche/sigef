CREATE PROCEDURE [dbo].[ZSanzioniRecuperoGetById]
(
	@IdSanzioneRecupero INT
)
AS
	SELECT *
	FROM VSANZIONI_RECUPERO
	WHERE 
		(ID_SANZIONE_RECUPERO = @IdSanzioneRecupero)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSanzioniRecuperoGetById';

