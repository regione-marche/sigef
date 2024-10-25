CREATE PROCEDURE [dbo].[ZRevocaOrdinativoIncassoUpdate]
(
	@IdOrdinativoIncasso INT, 
	@IdRevoca INT, 
	@OrdinativoIncasso VARCHAR(255), 
	@DataOrdinativo DATETIME, 
	@ImportoOrdinativo DECIMAL(15,2), 
	@DataInserimento DATETIME
)
AS
	UPDATE REVOCA_ORDINATIVO_INCASSO
	SET
		ID_REVOCA = @IdRevoca, 
		ORDINATIVO_INCASSO = @OrdinativoIncasso, 
		DATA_ORDINATIVO = @DataOrdinativo, 
		IMPORTO_ORDINATIVO = @ImportoOrdinativo, 
		DATA_INSERIMENTO = @DataInserimento
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)