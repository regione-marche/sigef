CREATE PROCEDURE [dbo].[ZRnaStrumentiXComponentiInsert]
(
	@IdComponentiXCodifica INT, 
	@CodTipoStrumentoAiuto INT, 
	@IntensitaStrumento DECIMAL(15,12)
)
AS
	INSERT INTO RNA_STRUMENTI_X_COMPONENTI
	(
		ID_COMPONENTI_X_CODIFICA, 
		COD_TIPO_STRUMENTO_AIUTO, 
		INTENSITA_STRUMENTO
	)
	VALUES
	(
		@IdComponentiXCodifica, 
		@CodTipoStrumentoAiuto, 
		@IntensitaStrumento
	)
	SELECT SCOPE_IDENTITY() AS ID_STRUMENTI_X_COMPONENTI