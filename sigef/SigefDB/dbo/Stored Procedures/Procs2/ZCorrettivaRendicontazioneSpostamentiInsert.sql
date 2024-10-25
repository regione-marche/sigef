CREATE PROCEDURE [dbo].[ZCorrettivaRendicontazioneSpostamentiInsert]
(
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
	SET @ImportoSpostato = ISNULL(@ImportoSpostato,((0)))
	SET @Concluso = ISNULL(@Concluso,((0)))
	SET @Annullato = ISNULL(@Annullato,((0)))
	INSERT INTO CORRETTIVA_RENDICONTAZIONE_SPOSTAMENTI
	(
		ID_CORRETTIVA, 
		ID_INVESTIMENTO_DA, 
		ID_INVESTIMENTO_A, 
		IMPORTO_SPOSTATO, 
		CONCLUSO, 
		ANNULLATO, 
		ID_UTENTE, 
		DATA, 
		DESCRIZIONE, 
		ID_JSON_LOG
	)
	VALUES
	(
		@IdCorrettiva, 
		@IdInvestimentoDa, 
		@IdInvestimentoA, 
		@ImportoSpostato, 
		@Concluso, 
		@Annullato, 
		@IdUtente, 
		@Data, 
		@Descrizione, 
		@IdJsonLog
	)
	SELECT SCOPE_IDENTITY() AS ID, @ImportoSpostato AS IMPORTO_SPOSTATO, @Concluso AS CONCLUSO, @Annullato AS ANNULLATO

GO
EXECUTE sp_addextendedproperty @name = N'backup', @value = NULL, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'ZCorrettivaRendicontazioneSpostamentiInsert';

