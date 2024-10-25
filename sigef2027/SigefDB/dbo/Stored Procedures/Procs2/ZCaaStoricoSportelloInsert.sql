CREATE PROCEDURE [dbo].[ZCaaStoricoSportelloInsert]
(
	@CodiceSportello VARCHAR(255), 
	@Denominazione VARCHAR(255), 
	@UfficioProvinciale BIT, 
	@UfficioRegionale BIT, 
	@Indirizzo VARCHAR(255), 
	@IdComune INT, 
	@Telefono VARCHAR(255), 
	@Fax VARCHAR(255), 
	@Email VARCHAR(255), 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT
)
AS
	SET @UfficioProvinciale = ISNULL(@UfficioProvinciale,((0)))
	SET @UfficioRegionale = ISNULL(@UfficioRegionale,((0)))
	INSERT INTO CAA_STORICO_SPORTELLO
	(
		CODICE_SPORTELLO, 
		DENOMINAZIONE, 
		UFFICIO_PROVINCIALE, 
		UFFICIO_REGIONALE, 
		INDIRIZZO, 
		ID_COMUNE, 
		TELEFONO, 
		FAX, 
		EMAIL, 
		COD_STATO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@CodiceSportello, 
		@Denominazione, 
		@UfficioProvinciale, 
		@UfficioRegionale, 
		@Indirizzo, 
		@IdComune, 
		@Telefono, 
		@Fax, 
		@Email, 
		@CodStato, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID, @UfficioProvinciale AS UFFICIO_PROVINCIALE, @UfficioRegionale AS UFFICIO_REGIONALE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'CREATE PROCEDURE [dbo].[ZCaaStoricoSportelloInsert]
(
	@CodiceSportello VARCHAR(255), 
	@Denominazione VARCHAR(255), 
	@Indirizzo VARCHAR(255), 
	@IdComune INT, 
	@Telefono VARCHAR(255), 
	@Fax VARCHAR(255), 
	@Email VARCHAR(255), 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT
)
AS
	INSERT INTO CAA_STORICO_SPORTELLO
	(
		CODICE_SPORTELLO, 
		DENOMINAZIONE, 
		INDIRIZZO, 
		ID_COMUNE, 
		TELEFONO, 
		FAX, 
		EMAIL, 
		COD_STATO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@CodiceSportello, 
		@Denominazione, 
		@Indirizzo, 
		@IdComune, 
		@Telefono, 
		@Fax, 
		@Email, 
		@CodStato, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID_STORICO

', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoSportelloInsert';

