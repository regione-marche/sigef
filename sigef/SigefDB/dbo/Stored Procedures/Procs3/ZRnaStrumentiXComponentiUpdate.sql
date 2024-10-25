CREATE PROCEDURE [dbo].[ZRnaStrumentiXComponentiUpdate]
(
	@IdStrumentiXComponenti INT, 
	@IdComponentiXCodifica INT, 
	@CodTipoStrumentoAiuto INT, 
	@IntensitaStrumento DECIMAL(15,12)
)
AS
	UPDATE RNA_STRUMENTI_X_COMPONENTI
	SET
		ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodifica, 
		COD_TIPO_STRUMENTO_AIUTO = @CodTipoStrumentoAiuto, 
		INTENSITA_STRUMENTO = @IntensitaStrumento
	WHERE 
		(ID_STRUMENTI_X_COMPONENTI = @IdStrumentiXComponenti)