CREATE PROCEDURE [dbo].[ZRecuperoBeneficiarioOrdinativoIncassoUpdate]
(
	@IdOrdinativoIncasso INT, 
	@IdRecuperoBeneficiario INT, 
	@IdFileMandato INT, 
	@Numero VARCHAR(255), 
	@Data DATETIME, 
	@Importo DECIMAL(15,2), 
	@Quietanza DECIMAL(15,2)
)
AS
	UPDATE RECUPERO_BENEFICIARIO_ORDINATIVO_INCASSO
	SET
		ID_RECUPERO_BENEFICIARIO = @IdRecuperoBeneficiario, 
		ID_FILE_MANDATO = @IdFileMandato, 
		NUMERO = @Numero, 
		DATA = @Data, 
		IMPORTO = @Importo, 
		QUIETANZA = @Quietanza
	WHERE 
		(ID_ORDINATIVO_INCASSO = @IdOrdinativoIncasso)