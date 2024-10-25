CREATE PROCEDURE [dbo].[ZCaaStoricoSportelloUpdate]
(
	@Id INT, 
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
	UPDATE CAA_STORICO_SPORTELLO
	SET
		CODICE_SPORTELLO = @CodiceSportello, 
		DENOMINAZIONE = @Denominazione, 
		UFFICIO_PROVINCIALE = @UfficioProvinciale, 
		UFFICIO_REGIONALE = @UfficioRegionale, 
		INDIRIZZO = @Indirizzo, 
		ID_COMUNE = @IdComune, 
		TELEFONO = @Telefono, 
		FAX = @Fax, 
		EMAIL = @Email, 
		COD_STATO = @CodStato, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoSportelloUpdate';

