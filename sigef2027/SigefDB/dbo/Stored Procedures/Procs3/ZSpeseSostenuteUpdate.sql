CREATE PROCEDURE [dbo].[ZSpeseSostenuteUpdate]
(
	@IdSpesa INT, 
	@IdGiustificativo INT, 
	@CodTipo VARCHAR(255), 
	@Estremi VARCHAR(255), 
	@Data DATETIME, 
	@Importo DECIMAL(18,2), 
	@Netto DECIMAL(18,2), 
	@IdDomandaPagamento INT, 
	@Ammesso BIT, 
	@DataApprovazione DATETIME, 
	@OperatoreApprovazione INT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	UPDATE SPESE_SOSTENUTE
	SET
		ID_GIUSTIFICATIVO = @IdGiustificativo, 
		COD_TIPO = @CodTipo, 
		ESTREMI = @Estremi, 
		DATA = @Data, 
		IMPORTO = @Importo, 
		NETTO = @Netto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		AMMESSO = @Ammesso, 
		DATA_APPROVAZIONE = @DataApprovazione, 
		OPERATORE_APPROVAZIONE = @OperatoreApprovazione, 
		ID_FILE = @IdFile, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazione
	WHERE 
		(ID_SPESA = @IdSpesa)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpeseSostenuteUpdate]
(
	@IdSpesa INT, 
	@IdGiustificativo INT, 
	@CodTipo VARCHAR(255), 
	@Estremi VARCHAR(255), 
	@Data DATETIME, 
	@Importo DECIMAL(18,2), 
	@Netto DECIMAL(18,2), 
	@IdDomandaPagamento INT, 
	@Ammesso BIT, 
	@DataApprovazione DATETIME, 
	@OperatoreApprovazione INT, 
	@IdFile INT, 
	@InIntegrazione BIT, 
	@IdFileModificatoIntegrazione BIT
)
AS
	UPDATE SPESE_SOSTENUTE
	SET
		ID_GIUSTIFICATIVO = @IdGiustificativo, 
		COD_TIPO = @CodTipo, 
		ESTREMI = @Estremi, 
		DATA = @Data, 
		IMPORTO = @Importo, 
		NETTO = @Netto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		AMMESSO = @Ammesso, 
		DATA_APPROVAZIONE = @DataApprovazione, 
		OPERATORE_APPROVAZIONE = @OperatoreApprovazione, 
		ID_FILE = @IdFile, 
		IN_INTEGRAZIONE = @InIntegrazione, 
		ID_FILE_MODIFICATO_INTEGRAZIONE = @IdFileModificatoIntegrazione
	WHERE 
		(ID_SPESA = @IdSpesa)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteUpdate';

