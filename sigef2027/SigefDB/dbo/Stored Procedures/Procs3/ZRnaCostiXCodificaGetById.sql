CREATE PROCEDURE [dbo].[ZRnaCostiXCodificaGetById]
(
	@IdCostiXCodifica INT
)
AS
	SELECT *
	FROM RNA_COSTI_X_CODIFICA
	WHERE 
		(ID_COSTI_X_CODIFICA = @IdCostiXCodifica)