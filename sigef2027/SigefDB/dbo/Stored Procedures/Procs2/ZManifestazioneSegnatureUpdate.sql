CREATE PROCEDURE [dbo].[ZManifestazioneSegnatureUpdate]
(
	@IdManifestazione INT, 
	@CodTipo CHAR(3), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@Motivazione NTEXT
)
AS
	UPDATE MANIFESTAZIONE_SEGNATURE
	SET
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		MOTIVAZIONE = @Motivazione
	WHERE 
		(ID_MANIFESTAZIONE = @IdManifestazione) AND 
		(COD_TIPO = @CodTipo)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneSegnatureUpdate';

