CREATE PROCEDURE [dbo].[ZComuniUpdate]
(
	@IdComune INT, 
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
	UPDATE COMUNI
	SET
		COD_BELFIORE = @CodBelfiore, 
		DENOMINAZIONE = @Denominazione, 
		COD_PROVINCIA = @CodProvincia, 
		SIGLA = @Sigla, 
		CAP = @Cap, 
		ISTAT = @Istat, 
		TIPO_AREA = @TipoArea, 
		COD_RUBRICA_PALEO = @CodRubricaPaleo, 
		ATTIVO = @Attivo, 
		DATA_INIZIO_VALIDITA = @DataInizioValidita, 
		DATA_FINE_VALIDITA = @DataFineValidita, 
		ID_OPERATORE_INIZIO = @IdOperatoreInizio, 
		ID_OPERATORE_FINE = @IdOperatoreFine
	WHERE 
		(ID_COMUNE = @IdComune)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZComuniUpdate';

