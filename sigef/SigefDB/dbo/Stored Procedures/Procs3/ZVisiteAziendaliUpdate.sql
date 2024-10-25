CREATE PROCEDURE [dbo].[ZVisiteAziendaliUpdate]
(
	@IdVisita INT, 
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
	UPDATE VISITE_AZIENDALI
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_IMPRESA = @IdImpresa, 
		COD_TIPO = @CodTipo, 
		DATA_APERTURA = @DataApertura, 
		OPERATORE_APERTURA = @OperatoreApertura, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		DATA_CHIUSURA = @DataChiusura, 
		OPERATORE_CHIUSURA = @OperatoreChiusura, 
		SEGNATURA_VERBALE = @SegnaturaVerbale, 
		ID_DOMANDA_EROA = @IdDomandaEroa
	WHERE 
		(ID_VISITA = @IdVisita)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZVisiteAziendaliUpdate]
(
	@IdVisita INT, 
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
	UPDATE VISITE_AZIENDALI
	SET
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_IMPRESA = @IdImpresa, 
		COD_TIPO = @CodTipo, 
		DATA_APERTURA = @DataApertura, 
		OPERATORE_APERTURA = @OperatoreApertura, 
		CONTROLLO_CONCLUSO = @ControlloConcluso, 
		DATA_CHIUSURA = @DataChiusura, 
		OPERATORE_CHIUSURA = @OperatoreChiusura, 
		SEGNATURA_VERBALE = @SegnaturaVerbale
	WHERE 
		(ID_VISITA = @IdVisita)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZVisiteAziendaliUpdate';

