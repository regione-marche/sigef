CREATE PROCEDURE [dbo].[ZRnaCostiXCodificaInsert]
(
	@IdCodificaInvestimento INT, 
	@CodTipoSpesa INT
)
AS
	INSERT INTO RNA_COSTI_X_CODIFICA
	(
		ID_CODIFICA_INVESTIMENTO, 
		COD_TIPO_SPESA
	)
	VALUES
	(
		@IdCodificaInvestimento, 
		@CodTipoSpesa
	)
	SELECT SCOPE_IDENTITY() AS ID_COSTI_X_CODIFICA