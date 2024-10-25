CREATE PROCEDURE [dbo].[ZBandoProgrammazioneUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@IdProgrammazione INT, 
	@MisuraPrevalente BIT, 
	@IdDisposizioniAttuative INT
)
AS
	UPDATE BANDO_PROGRAMMAZIONE
	SET
		ID_BANDO = @IdBando, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		MISURA_PREVALENTE = @MisuraPrevalente, 
		ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuative
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoProgrammazioneUpdate]
(
	@Id INT, 
	@IdBando INT, 
	@IdProgrammazione INT, 
	@MisuraPrevalente BIT, 
	@IdDisposizioniAttuative INT
)
AS
	UPDATE BANDO_PROGRAMMAZIONE
	SET
		ID_BANDO = @IdBando, 
		ID_PROGRAMMAZIONE = @IdProgrammazione, 
		MISURA_PREVALENTE = @MisuraPrevalente, 
		ID_DISPOSIZIONI_ATTUATIVE = @IdDisposizioniAttuative
	WHERE 
		(ID = @Id)


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoProgrammazioneUpdate';

