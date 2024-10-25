CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneSpostamentiUpdate]
(
	@Id INT, 
	@IdCorrettiva INT, 
	@IdInvestimentoDa INT, 
	@IdInvestimentoA INT, 
	@ImportoSpostato DECIMAL(18,2), 
	@Concluso BIT, 
	@Annullato BIT, 
	@IdUtente INT, 
	@Data DATETIME, 
	@Descrizione VARCHAR(255), 
	@IdJsonLog INT
)
AS
	UPDATE CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI
	SET
		ID_CORRETTIVA = @IdCorrettiva, 
		ID_INVESTIMENTO_DA = @IdInvestimentoDa, 
		ID_INVESTIMENTO_A = @IdInvestimentoA, 
		IMPORTO_SPOSTATO = @ImportoSpostato, 
		CONCLUSO = @Concluso, 
		ANNULLATO = @Annullato, 
		ID_UTENTE = @IdUtente, 
		DATA = @Data, 
		DESCRIZIONE = @Descrizione, 
		ID_JSON_LOG = @IdJsonLog
	WHERE 
		(ID = @Id)

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneSpostamentiUpdate';

