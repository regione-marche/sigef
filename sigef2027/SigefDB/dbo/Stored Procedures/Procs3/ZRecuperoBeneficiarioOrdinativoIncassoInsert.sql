CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioOrdinativoIncassoInsert]
(
	@IdRecuperoBeneficiario INT, 
	@IdFileMandato INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@Importo DECIMAL(15,2), 
	@Quietanza DECIMAL(15,2)
)
AS
	INSERT INTO RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO
	(
		ID_RECUPERO_BENEFICIARIO, 
		ID_FILE_MANDATO, 
		NUMERO, 
		DATA, 
		IMPORTO, 
		QUIETANZA
	)
	VALUES
	(
		@IdRecuperoBeneficiario, 
		@IdFileMandato, 
		@Numero, 
		@Data, 
		@Importo, 
		@Quietanza
	)
	SELECT SCOPE_IDENTITY() AS ID_ORDINATIVO_INCASSO