CREATE PROCEDURE [dbo].[ZBandoResponsabiliUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@IdUtente INT, 
	@Provincia VARCHAR(255), 
	@Attivo BIT, 
	@Data DATETIME, 
	@Operatore INT
)
AS
	UPDATE BANDO_RESPONSABILI
	SET
		ID_BANDO = @IdBando, 
		ID_UTENTE = @IdUtente, 
		PROVINCIA = @Provincia, 
		ATTIVO = @Attivo, 
		DATA = @Data, 
		OPERATORE = @Operatore
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoResponsabiliUpdate';

