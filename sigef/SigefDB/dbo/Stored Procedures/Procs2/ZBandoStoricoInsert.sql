CREATE PROCEDURE [dbo].[ZBandoStoricoInsert]
(
	@IdBando INT, 
	@CodStato VARCHAR(255), 
	@Data DATETIME, 
	@Operatore INT, 
	@Segnatura VARCHAR(255), 
	@IdAtto INT
)
AS
	INSERT INTO BANDO_STORICO
	(
		ID_BANDO, 
		COD_STATO, 
		DATA, 
		OPERATORE, 
		SEGNATURA, 
		ID_ATTO
	)
	VALUES
	(
		@IdBando, 
		@CodStato, 
		@Data, 
		@Operatore, 
		@Segnatura, 
		@IdAtto
	)
	SELECT SCOPE_IDENTITY() AS ID

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoStoricoInsert';

