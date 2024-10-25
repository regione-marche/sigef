CREATE PROCEDURE [dbo].[ZPersoneXImpreseInsert]
(
	@IdPersona INT, 
	@IdImpresa INT, 
	@CodRuolo VARCHAR(255), 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ammesso BIT, 
	@Attivo BIT
)
AS
	SET @DataInizio = ISNULL(@DataInizio,(getdate()))
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	SET @Attivo = ISNULL(@Attivo,((1)))
	INSERT INTO PERSONE_X_IMPRESE
	(
		ID_PERSONA, 
		ID_IMPRESA, 
		COD_RUOLO, 
		DATA_INIZIO, 
		DATA_FINE, 
		AMMESSO, 
		ATTIVO
	)
	VALUES
	(
		@IdPersona, 
		@IdImpresa, 
		@CodRuolo, 
		@DataInizio, 
		@DataFine, 
		@Ammesso, 
		@Attivo
	)
	SELECT SCOPE_IDENTITY() AS ID_PERSONE_X_IMPRESE, @DataInizio AS DATA_INIZIO, @Ammesso AS AMMESSO, @Attivo AS ATTIVO


GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = 'CREATE PROCEDURE [dbo].[ZPersoneXImpreseInsert]
(
	@IdPersona INT, 
	@IdImpresa INT, 
	@CodRuolo VARCHAR(255), 
	@DataInizio DATETIME, 
	@DataFine DATETIME, 
	@Ammesso BIT
)
AS
	SET @DataInizio = ISNULL(@DataInizio,(getdate()))
	SET @Ammesso = ISNULL(@Ammesso,((0)))
	INSERT INTO PERSONE_X_IMPRESE
	(
		ID_PERSONA, 
		ID_IMPRESA, 
		COD_RUOLO, 
		DATA_INIZIO, 
		DATA_FINE, 
		AMMESSO
	)
	VALUES
	(
		@IdPersona, 
		@IdImpresa, 
		@CodRuolo, 
		@DataInizio, 
		@DataFine, 
		@Ammesso
	)
	SELECT SCOPE_IDENTITY() AS ID_PERSONE_X_IMPRESE, @DataInizio AS DATA_INIZIO, @Ammesso AS AMMESSO
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZPersoneXImpreseInsert';

