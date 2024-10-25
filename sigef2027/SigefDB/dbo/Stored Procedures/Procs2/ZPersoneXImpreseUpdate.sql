CREATE PROCEDURE [dbo].[ZPersoneXImpreseUpdate]
(
	@IdPersona INT, 
	@IdPersoneXImprese INT, 
	@IdImpresa INT, 
	@CodRuolo VARCHAR(255), 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ammesso BIT, 
	@Attivo BIT
)
AS
	UPDATE PERSONE_X_IMPRESE
	SET
		ID_PERSONA = @IdPersona, 
		ID_IMPRESA = @IdImpresa, 
		COD_RUOLO = @CodRuolo, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		AMMESSO = @Ammesso, 
		ATTIVO = @Attivo
	WHERE 
		(ID_PERSONE_X_IMPRESE = @IdPersoneXImprese)


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPersoneXImpreseUpdate]
(
	@IdPersona INT, 
	@IdPersoneXImprese INT, 
	@IdImpresa INT, 
	@CodRuolo VARCHAR(255), 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ammesso BIT
)
AS
	UPDATE PERSONE_X_IMPRESE
	SET
		ID_PERSONA = @IdPersona, 
		ID_IMPRESA = @IdImpresa, 
		COD_RUOLO = @CodRuolo, 
		DATA_INIZIO = @DataInizio, 
		DATA_FINE = @DataFine, 
		AMMESSO = @Ammesso
	WHERE 
		(ID_PERSONE_X_IMPRESE = @IdPersoneXImprese)
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersoneXImpreseUpdate';

