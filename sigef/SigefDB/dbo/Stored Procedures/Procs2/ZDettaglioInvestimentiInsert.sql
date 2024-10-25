CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiInsert]
(
	@IdCodificaInvestimento INT, 
	@CodDettaglio VARCHAR(255), 
	@Descrizione VARCHAR(255), 
	@Mobile BIT, 
	@QuotaSpeseGenerali DECIMAL(10,2), 
	@RichiediParticella BIT, 
	@IdUdm INT
)
AS
	SET @Mobile = ISNULL(@Mobile,((0)))
	INSERT INTO DETTAGLIO_INVESTIMENTI
	(
		ID_CODIFICA_INVESTIMENTO, 
		COD_DETTAGLIO, 
		DESCRIZIONE, 
		MOBILE, 
		QUOTA_SPESE_GENERALI, 
		RICHIEDI_PARTICELLA, 
		ID_UDM
	)
	VALUES
	(
		@IdCodificaInvestimento, 
		@CodDettaglio, 
		@Descrizione, 
		@Mobile, 
		@QuotaSpeseGenerali, 
		@RichiediParticella, 
		@IdUdm
	)
	SELECT SCOPE_IDENTITY() AS ID_DETTAGLIO_INVESTIMENTO, @Mobile AS MOBILE


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZDettaglioInvestimentiInsert]
(
	@IdCodificaInvestimento INT, 
	@CodDettaglio CHAR(2), 
	@Descrizione VARCHAR(255), 
	@Mobile BIT, 
	@QuotaSpeseGenerali DECIMAL(10,2), 
	@RichiediParticella BIT
)
AS
	INSERT INTO DETTAGLIO_INVESTIMENTI
	(
		ID_CODIFICA_INVESTIMENTO, 
		COD_DETTAGLIO, 
		DESCRIZIONE, 
		MOBILE, 
		QUOTA_SPESE_GENERALI, 
		RICHIEDI_PARTICELLA
	)
	VALUES
	(
		@IdCodificaInvestimento, 
		@CodDettaglio, 
		@Descrizione, 
		@Mobile, 
		@QuotaSpeseGenerali, 
		@RichiediParticella
	)
	SELECT SCOPE_IDENTITY() AS ID_DETTAGLIO_INVESTIMENTO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZDettaglioInvestimentiInsert';

