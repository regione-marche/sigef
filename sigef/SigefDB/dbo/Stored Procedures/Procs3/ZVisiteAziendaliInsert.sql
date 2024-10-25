CREATE PROCEDURE [dbo].[ZVisiteAziendaliInsert]
(
	@IdDomandaPagamento INT, 
	@IdImpresa INT, 
	@CodTipo CHAR(3), 
	@DataApertura DATETIME, 
	@OperatoreApertura VARCHAR(16), 
	@ControlloConcluso BIT, 
	@DataChiusura DATETIME, 
	@OperatoreChiusura VARCHAR(16), 
	@SegnaturaVerbale VARCHAR(100), 
	@IdDomandaEroa INT
)
AS
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO VISITE_AZIENDALI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_IMPRESA, 
		COD_TIPO, 
		DATA_APERTURA, 
		OPERATORE_APERTURA, 
		CONTROLLO_CONCLUSO, 
		DATA_CHIUSURA, 
		OPERATORE_CHIUSURA, 
		SEGNATURA_VERBALE, 
		ID_DOMANDA_EROA
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdImpresa, 
		@CodTipo, 
		@DataApertura, 
		@OperatoreApertura, 
		@ControlloConcluso, 
		@DataChiusura, 
		@OperatoreChiusura, 
		@SegnaturaVerbale, 
		@IdDomandaEroa
	)
	SELECT SCOPE_IDENTITY() AS ID_VISITA, @ControlloConcluso AS CONTROLLO_CONCLUSO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVisiteAziendaliInsert]
(
	@IdDomandaPagamento INT, 
	@IdImpresa INT, 
	@CodTipo CHAR(3), 
	@DataApertura DATETIME, 
	@OperatoreApertura VARCHAR(16), 
	@ControlloConcluso BIT, 
	@DataChiusura DATETIME, 
	@OperatoreChiusura VARCHAR(16), 
	@SegnaturaVerbale VARCHAR(100)
)
AS
	SET @ControlloConcluso = ISNULL(@ControlloConcluso,((0)))
	INSERT INTO VISITE_AZIENDALI
	(
		ID_DOMANDA_PAGAMENTO, 
		ID_IMPRESA, 
		COD_TIPO, 
		DATA_APERTURA, 
		OPERATORE_APERTURA, 
		CONTROLLO_CONCLUSO, 
		DATA_CHIUSURA, 
		OPERATORE_CHIUSURA, 
		SEGNATURA_VERBALE
	)
	VALUES
	(
		@IdDomandaPagamento, 
		@IdImpresa, 
		@CodTipo, 
		@DataApertura, 
		@OperatoreApertura, 
		@ControlloConcluso, 
		@DataChiusura, 
		@OperatoreChiusura, 
		@SegnaturaVerbale
	)
	SELECT SCOPE_IDENTITY() AS ID_VISITA, @ControlloConcluso AS CONTROLLO_CONCLUSO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVisiteAziendaliInsert';

