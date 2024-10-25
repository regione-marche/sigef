CREATE PROCEDURE [dbo].[ZManifestazioneSegnatureGetById]
(
	@IdManifestazione INT, 
	@CodTipo CHAR(3)
)
AS
	SELECT *
	FROM vMANIFESTAZIONE_SEGNATURE
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneSegnatureGetById';

