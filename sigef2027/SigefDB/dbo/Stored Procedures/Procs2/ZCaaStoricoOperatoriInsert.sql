CREATE PROCEDURE [dbo].[ZCaaStoricoOperatoriInsert]
(
	@IdOperatore INT, 
	@MandatoPsr BIT, 
	@MandatoUma BIT, 
	@Responsabile BIT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT
)
AS
	INSERT INTO CAA_STORICO_OPERATORI
	(
		ID_OPERATORE, 
		MANDATO_PSR, 
		MANDATO_UMA, 
		RESPONSABILE, 
		COD_STATO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdOperatore, 
		@MandatoPsr, 
		@MandatoUma, 
		@Responsabile, 
		@CodStato, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCaaStoricoOperatoriInsert';

