CREATE PROCEDURE [dbo].[ZRnaCostiXCodificaDelete]
(
	@IdCostiXCodifica INT
)
AS
	DELETE RNA_COSTI_X_CODIFICA
	WHERE 
		(ID_COSTI_X_CODIFICA = @IdCostiXCodifica)