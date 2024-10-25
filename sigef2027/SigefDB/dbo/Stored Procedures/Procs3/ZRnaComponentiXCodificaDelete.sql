CREATE PROCEDURE [dbo].[ZRnaComponentiXCodificaDelete]
(
	@IdComponentiXCodifica INT
)
AS
	DELETE RNA_COMPONENTI_X_CODIFICA
	WHERE 
		(ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodifica)
