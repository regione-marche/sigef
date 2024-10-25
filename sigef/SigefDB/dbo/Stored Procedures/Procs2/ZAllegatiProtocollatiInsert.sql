CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiInsert]
(
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
	SET @Protocollato = ISNULL(@Protocollato,((0)))
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ALLEGATI_PROTOCOLLATI
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VARIANTE, 
		ID_INTEGRAZIONE, 
		ID_COMUNICAZIONE, 
		ID_FILE, 
		PROTOCOLLATO, 
		PROTOCOLLO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdVariante, 
		@IdIntegrazione, 
		@IdComunicazione, 
		@IdFile, 
		@Protocollato, 
		@Protocollo, 
		@DataInserimento, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO_PROTOCOLLATO, @Protocollato AS PROTOCOLLATO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZAllegatiProtocollatiInsert]
(
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
	SET @Protocollato = ISNULL(@Protocollato,((0)))
	SET @DataInserimento = ISNULL(@DataInserimento,(getdate()))
	SET @DataModifica = ISNULL(@DataModifica,(getdate()))
	INSERT INTO ALLEGATI_PROTOCOLLATI
	(
		ID_PROGETTO, 
		ID_DOMANDA_PAGAMENTO, 
		ID_VARIANTE, 
		ID_INTEGRAZIONE, 
		ID_FILE, 
		PROTOCOLLATO, 
		PROTOCOLLO, 
		DATA_INSERIMENTO, 
		DATA_MODIFICA
	)
	VALUES
	(
		@IdProgetto, 
		@IdDomandaPagamento, 
		@IdVariante, 
		@IdIntegrazione, 
		@IdFile, 
		@Protocollato, 
		@Protocollo, 
		@DataInserimento, 
		@DataModifica
	)
	SELECT SCOPE_IDENTITY() AS ID_ALLEGATO_PROTOCOLLATO, @Protocollato AS PROTOCOLLATO, @DataInserimento AS DATA_INSERIMENTO, @DataModifica AS DATA_MODIFICA

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZAllegatiProtocollatiInsert';

