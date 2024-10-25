CREATE PROCEDURE [dbo].[ZBandoStoricoUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT, 
	@Segnatura VARCHAR(255), 
	@IdAtto INT
)
AS
	UPDATE BANDO_STORICO
	SET
		ID_BANDO = @IdBando, 
		COD_STATO = @CodStato, 
		DATA = @Data, 
		OPERATORE = @Operatore, 
		SEGNATURA = @Segnatura, 
		ID_ATTO = @IdAtto
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoStoricoUpdate';

