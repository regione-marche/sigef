CREATE PROCEDURE [dbo].[ZRnaCostiXCodificaUpdate]
(
	@IdCostiXCodifica INT, 
	@IdCodificaInvestimento INT, 
	@CodTipoSpesa INT
)
AS
	UPDATE RNA_COSTI_X_CODIFICA
	SET
		ID_CODIFICA_INVESTIMENTO = @IdCodificaInvestimento, 
		COD_TIPO_SPESA = @CodTipoSpesa
	WHERE 
		(ID_COSTI_X_CODIFICA = @IdCostiXCodifica)