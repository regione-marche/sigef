CREATE PROCEDURE [dbo].[ZRevocaOrdinativoIncassoInsert]
(
	@IdRevoca INT, 
	@OrdinativoIncasso VARCHAR(255), 
	@DataOrdinativo DATETIME, 
	@ImportoOrdinativo DECIMAL(15,2), 
	@DataInserimento DATETIME
)
AS
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	INSERT INTO REVOCA_ORDINATIVO_INCASSO
	(
		ID_REVOCA, 
		ORDINATIVO_INCASSO, 
		DATA_ORDINATIVO, 
		IMPORTO_ORDINATIVO, 
		DATA_INSERIMENTO
	)
	VALUES
	(
		@IdRevoca, 
		@OrdinativoIncasso, 
		@DataOrdinativo, 
		@ImportoOrdinativo, 
		@DataInserimento
	)
	SELECT SCOPE_IDENTITY() AS ID_ORDINATIVO_INCASSO, @DataInserimento AS DATA_INSERIMENTO