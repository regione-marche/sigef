CREATE PROCEDURE [dbo].[ZComuniInsert]
(
	@CodBelfiore VARCHAR(255), 
	@Denominazione VARCHAR(255), 
	@CodProvincia VARCHAR(255), 
	@Sigla VARCHAR(255), 
	@Cap VARCHAR(255), 
	@Istat VARCHAR(255), 
	@TipoArea VARCHAR(255), 
	@CodRubricaPaleo VARCHAR(255), 
	@Attivo BIT, 
	@DataInizioValidita DATETIME, 
	@DataFineValidita DATETIME, 
	@IdOperatoreInizio INT, 
	@IdOperatoreFine INT
)
AS
	SET @Attivo = ISNULL(@Attivo,((1)))
	SET @DataInizioValidita = ISNULL(@DataInizioValidita,(getdate()))
	SET @IdOperatoreInizio = ISNULL(@IdOperatoreInizio,((11)))
	INSERT INTO COMUNI
	(
		COD_BELFIORE, 
		DENOMINAZIONE, 
		COD_PROVINCIA, 
		SIGLA, 
		CAP, 
		ISTAT, 
		TIPO_AREA, 
		COD_RUBRICA_PALEO, 
		ATTIVO, 
		DATA_INIZIO_VALIDITA, 
		DATA_FINE_VALIDITA, 
		ID_OPERATORE_INIZIO, 
		ID_OPERATORE_FINE
	)
	VALUES
	(
		@CodBelfiore, 
		@Denominazione, 
		@CodProvincia, 
		@Sigla, 
		@Cap, 
		@Istat, 
		@TipoArea, 
		@CodRubricaPaleo, 
		@Attivo, 
		@DataInizioValidita, 
		@DataFineValidita, 
		@IdOperatoreInizio, 
		@IdOperatoreFine
	)
	SELECT SCOPE_IDENTITY() AS ID_COMUNE, @Attivo AS ATTIVO, @DataInizioValidita AS DATA_INIZIO_VALIDITA, @IdOperatoreInizio AS ID_OPERATORE_INIZIO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZComuniInsert';

