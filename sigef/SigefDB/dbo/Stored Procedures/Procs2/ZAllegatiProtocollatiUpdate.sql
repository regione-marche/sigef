CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiUpdate]
(
	@IdAllegatoProtocollato INT, 
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdVariante INT, 
	@IdIntegrazione INT, 
	@IdComunicazione INT, 
	@IdFile INT, 
	@Protocollato BIT, 
	@Protocollo NVARCHAR(255), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME
)
AS
	UPDATE ALLEGATI_PROTOCOLLATI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VARIANTE = @IdVariante, 
		ID_INTEGRAZIONE = @IdIntegrazione, 
		ID_COMUNICAZIONE = @IdComunicazione, 
		ID_FILE = @IdFile, 
		PROTOCOLLATO = @Protocollato, 
		PROTOCOLLO = @Protocollo, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollato)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiUpdate]
(
	@IdAllegatoProtocollato INT, 
	@IdProgetto INT, 
	@IdDomandaPagamento INT, 
	@IdVariante INT, 
	@IdIntegrazione INT, 
	@IdFile INT, 
	@Protocollato BIT, 
	@Protocollo NVARCHAR(255), 
	@DataInserimento DATETIME, 
	@DataModifica DATETIME
)
AS
	UPDATE ALLEGATI_PROTOCOLLATI
	SET
		ID_PROGETTO = @IdProgetto, 
		ID_DOMANDA_PAGAMENTO = @IdDomandaPagamento, 
		ID_VARIANTE = @IdVariante, 
		ID_INTEGRAZIONE = @IdIntegrazione, 
		ID_FILE = @IdFile, 
		PROTOCOLLATO = @Protocollato, 
		PROTOCOLLO = @Protocollo, 
		DATA_INSERIMENTO = @DataInserimento, 
		DATA_MODIFICA = @DataModifica
	WHERE 
		(ID_ALLEGATO_PROTOCOLLATO = @IdAllegatoProtocollato)

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiProtocollatiUpdate';

