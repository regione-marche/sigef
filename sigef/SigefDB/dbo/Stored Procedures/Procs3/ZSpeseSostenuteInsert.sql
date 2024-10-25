CREATE PROCEDURE [dbo].[ZSpeseSostenuteInsert]
(
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
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO SPESE_SOSTENUTE
	(
		ID_GIUSTIFICATIVO, 
		COD_TIPO, 
		ESTREMI, 
		DATA, 
		IMPORTO, 
		NETTO, 
		ID_DOMANDA_PAGAMENTO, 
		AMMESSO, 
		DATA_APPROVAZIONE, 
		OPERATORE_APPROVAZIONE, 
		ID_FILE, 
		IN_INTEGRAZIONE, 
		ID_FILE_MODIFICATO_INTEGRAZIONE
	)
	VALUES
	(
		@IdGiustificativo, 
		@CodTipo, 
		@Estremi, 
		@Data, 
		@Importo, 
		@Netto, 
		@IdDomandaPagamento, 
		@Ammesso, 
		@DataApprovazione, 
		@OperatoreApprovazione, 
		@IdFile, 
		@InIntegrazione, 
		@IdFileModificatoIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_SPESA, @Ammesso AS AMMESSO, @InIntegrazione AS IN_INTEGRAZIONE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZSpeseSostenuteInsert]
(
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
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	SET @InIntegrazione = ISNULL(@InIntegrazione,((0)))
	INSERT INTO SPESE_SOSTENUTE
	(
		ID_GIUSTIFICATIVO, 
		COD_TIPO, 
		ESTREMI, 
		DATA, 
		IMPORTO, 
		NETTO, 
		ID_DOMANDA_PAGAMENTO, 
		AMMESSO, 
		DATA_APPROVAZIONE, 
		OPERATORE_APPROVAZIONE, 
		ID_FILE, 
		IN_INTEGRAZIONE, 
		ID_FILE_MODIFICATO_INTEGRAZIONE
	)
	VALUES
	(
		@IdGiustificativo, 
		@CodTipo, 
		@Estremi, 
		@Data, 
		@Importo, 
		@Netto, 
		@IdDomandaPagamento, 
		@Ammesso, 
		@DataApprovazione, 
		@OperatoreApprovazione, 
		@IdFile, 
		@InIntegrazione, 
		@IdFileModificatoIntegrazione
	)
	SELECT SCOPE_IDENTITY() AS ID_SPESA, @Ammesso AS AMMESSO, @InIntegrazione AS IN_INTEGRAZIONE

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZSpeseSostenuteInsert';

