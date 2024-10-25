CREATE PROCEDURE [dbo].[ZBandoProgrammazioneInsert]
(
	@IdBando INT, 
	@IdProgrammazione INT, 
	@MisuraPrevalente BIT, 
	@IdDisposizioniAttuative INT
)
AS
	SET @MisuraPrevalente = ISNULL(@MisuraPrevalente,((1)))
	INSERT INTO BANDO_PROGRAMMAZIONE
	(
		ID_BANDO, 
		ID_PROGRAMMAZIONE, 
		MISURA_PREVALENTE, 
		ID_DISPOSIZIONI_ATTUATIVE
	)
	VALUES
	(
		@IdBando, 
		@IdProgrammazione, 
		@MisuraPrevalente, 
		@IdDisposizioniAttuative
	)
	SELECT SCOPE_IDENTITY() AS ID, @MisuraPrevalente AS MISURA_PREVALENTE

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = N'
CREATE PROCEDURE [dbo].[ZBandoProgrammazioneInsert]
(
	@IdBando INT, 
	@IdProgrammazione INT, 
	@MisuraPrevalente BIT, 
	@IdDisposizioniAttuative INT
)
AS
	SET @MisuraPrevalente = ISNULL(@MisuraPrevalente,((1)))
	INSERT INTO BANDO_PROGRAMMAZIONE
	(
		ID_BANDO, 
		ID_PROGRAMMAZIONE, 
		MISURA_PREVALENTE, 
		ID_DISPOSIZIONI_ATTUATIVE
	)
	VALUES
	(
		@IdBando, 
		@IdProgrammazione, 
		@MisuraPrevalente, 
		@IdDisposizioniAttuative
	)
	SELECT SCOPE_IDENTITY() AS ID, @MisuraPrevalente AS MISURA_PREVALENTE


', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZBandoProgrammazioneInsert';

