CREATE PROCEDURE [dbo].[ZRnaComponentiXCodificaGetById]
(
	@IdComponentiXCodifica INT
)
AS
	SELECT *
	FROM RNA_COMPONENTI_X_CODIFICA
	WHERE 
		(ID_COMPONENTI_X_CODIFICA = @IdComponentiXCodifica)