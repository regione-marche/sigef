CREATE PROCEDURE [dbo].[ZBandoResponsabiliInsert]
(
	@IdBando INT, 
	@IdUtente INT, 
	@Provincia VARCHAR(255), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	SET @Attivo = ISNULL(@Attivo,((0)))
	INSERT INTO BANDO_RESPONSABILI
	(
		ID_BANDO, 
		ID_UTENTE, 
		PROVINCIA, 
		ATTIVO, 
		DATA, 
		OPERATORE
	)
	VALUES
	(
		@IdBando, 
		@IdUtente, 
		@Provincia, 
		@Attivo, 
		@Data, 
		@Operatore
	)
	SELECT SCOPE_IDENTITY() AS ID, @Attivo AS ATTIVO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoResponsabiliInsert';

