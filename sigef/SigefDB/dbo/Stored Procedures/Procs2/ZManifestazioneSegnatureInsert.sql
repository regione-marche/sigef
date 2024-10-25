CREATE PROCEDURE [dbo].[ZManifestazioneSegnatureInsert]
(
	@IdManifestazione INT, 
	@CodTipo CHAR(3), 
	@Data DATETIME, 
	@Operatore VARCHAR(16), 
	@Segnatura VARCHAR(100), 
	@Motivazione NTEXT
)
AS
	INSERT INTO MANIFESTAZIONE_SEGNATURE
	(
		ID_MANIFESTAZIONE, 
		COD_TIPO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		MOTIVAZIONE
	)
	VALUES
	(
		@IdManifestazione, 
		@CodTipo, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@Motivazione
	)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZManifestazioneSegnatureInsert';

